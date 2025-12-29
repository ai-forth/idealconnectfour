using System;
using System.Collections;
using System.Xml;

namespace BoardControl
{
    public enum PIECEPOSITION { START, ABOVE, ABOVERIGHT, RIGHT, BELOWRIGHT, BELOW, BELOWLEFT, LEFT, ABOVELEFT };

    /// <summary>
    /// A collection of basic patterns which includes a weighting for this set
    /// Weighting should be based on success ie was this set used in a winning game
    /// what happened when this set was used?
    /// It's up to the individual game to decide how many patterns make a set ( could actually be a difficulty setting )
    /// </summary>
    public class BasicGamePattern
    {
        /// <summary>
        /// array to store the pattern objects
        /// </summary>
        private ArrayList arrayGamePieces;
        /// <summary>
        /// number of times this pattern has been seen
        /// </summary>
        private int nNumberOfTimesSeen;
        private int nNumberOfTimesSeenInWinningGame;
        private int nNumberOfTimesSeenInLosingGame;
        /// <summary>
        /// weighting for this pattern
        /// </summary>
        private int nWeighting;
        /// <summary>
        /// what was the previous response to this pattern
        /// </summary>
        private BasicGamePiece bgpResponse = null;
        /// <summary>
        /// id for this pattern set
        /// </summary>
        private static int nBasicGamePatternID = 0;
        private int nPatternID;
        /// <summary>
        /// Is there a response recorded for this pattern
        /// </summary>
        private bool bResponsePresent = false;
        /// <summary>
        /// Is this pattern a deciding pattern
        /// </summary>
        private bool bIsEndingPattern = false;
        /// <summary>
        /// class variables that are helpful for deciding what data to change but
        /// are not themselves saved
        /// </summary>
        private bool bIsWinningPattern = false;
        private bool bIsLosingPattern = false;
        public ArrayList GamePieces
        {
            get
            {
                return arrayGamePieces;
            }
        }
        public int NumberOfTimesSeen
        {
            get
            {
                return nNumberOfTimesSeen;
            }
            set
            {
                nNumberOfTimesSeen = value;
            }
        }
        public int NumberOfTimesSeenInWinningGame
        {
            get
            {
                return nNumberOfTimesSeenInWinningGame;
            }
            set
            {
                nNumberOfTimesSeenInWinningGame = value;
            }
        }
        public int NumberOfTimesSeenInLosingGame
        {
            get
            {
                return nNumberOfTimesSeenInLosingGame;
            }
            set
            {
                nNumberOfTimesSeenInLosingGame = value;
            }
        }
        public int Weighting
        {
            get
            {
                return nWeighting;
            }
            set
            {
                nWeighting = value;
            }
        }
        public BasicGamePiece Response
        {
            get
            {
                return bgpResponse;
            }
            set
            {
                bgpResponse = value;
                if (value != null)
                    bResponsePresent = true;
            }
        }
        public bool IsEndingPattern
        {
            get
            {
                return bIsEndingPattern;
            }
            set
            {
                bIsEndingPattern = value;
            }
        }
        public bool IsWinningPattern
        {
            get
            {
                return bIsWinningPattern;
            }
            set
            {
                bIsWinningPattern = value;
            }
        }
        public bool IsLosingPattern
        {
            get
            {
                return bIsLosingPattern;
            }
            set
            {
                bIsLosingPattern = value;
            }
        }
        public int PatternID
        {
            get
            {
                return nPatternID;
            }
            set
            {
                nPatternID = value;
            }
        }
        public bool ResponsePresent
        {
            get
            {
                return bResponsePresent;
            }
        }
        private bool SetResponsePresent
        {
            set
            {
                bResponsePresent = value;
            }
        }
        public int Count
        {
            get
            {
                return arrayGamePieces.Count;
            }
        }
        public BasicGamePattern()
        {
            arrayGamePieces = new ArrayList();
            nNumberOfTimesSeen = 0;
            nWeighting = 0;
            nPatternID = nBasicGamePatternID;
            nBasicGamePatternID++;
            bResponsePresent = false;
            Weighting = 0;
            bIsEndingPattern = false;
        }
        public BasicGamePattern(int numberOfTimesSeen) : this()
        {
            NumberOfTimesSeen = numberOfTimesSeen;
        }
        public BasicGamePattern(int numberOfTimesSeen, int weighting) : this(numberOfTimesSeen)
        {
            Weighting = weighting;
        }
        public BasicGamePattern(BasicGamePattern pattern) : this()
        {
            NumberOfTimesSeen = pattern.NumberOfTimesSeen;
            NumberOfTimesSeenInWinningGame = pattern.NumberOfTimesSeenInWinningGame;
            NumberOfTimesSeenInLosingGame = pattern.NumberOfTimesSeenInLosingGame;
            IsWinningPattern = pattern.IsWinningPattern;
            IsLosingPattern = pattern.IsLosingPattern;
            Weighting = pattern.Weighting;
            SetResponsePresent = pattern.ResponsePresent;
            Response = pattern.Response;
            PatternID = pattern.PatternID;
            IsEndingPattern = pattern.IsEndingPattern;

            for (int i = 0; i < pattern.GamePieces.Count; i++)
            {
                arrayGamePieces.Add(new BasicGamePiece((BasicGamePiece)pattern.GamePieces[i]));
            }
        }
        /// <summary>
        /// Clear out the data held in this pattern
        /// </summary>
        public void Clear()
        {
            NumberOfTimesSeen = 0;
            NumberOfTimesSeenInWinningGame = 0;
            NumberOfTimesSeenInLosingGame = 0;
            IsWinningPattern = false;
            IsLosingPattern = false;
            Weighting = 0;
            SetResponsePresent = false;
            Response = null;
            PatternID = 0;
            IsEndingPattern = false;

            arrayGamePieces.Clear();
        }
        /// <summary>
        /// add a piece to the set
        /// </summary>
        /// <param name="pattern"></param>
        public void AddBasicGamePiece(BasicGamePiece piece)
        {
            arrayGamePieces.Add(piece);
        }
        /// <summary>
        /// Add a piece to the set
        /// </summary>
        /// <param name="squareIdentifer"></param>
        /// <param name="isEnemy"></param>
        /// <param name="position"></param>
        public void AddBasicGamePiece(string squareIdentifier, bool isEnemy, PIECEPOSITION position)
        {
            arrayGamePieces.Add(new BasicGamePiece(squareIdentifier, isEnemy, position));
        }
        /// <summary>
        /// find out if the pattern starts with a given identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public bool StartsWith(string identifier)
        {
            for (int i = 0; i < arrayGamePieces.Count; i++)
            {
                if (((BasicGamePiece)arrayGamePieces[i]).IsStartForPattern == true)
                {
                    if (((BasicGamePiece)arrayGamePieces[i]).SquareIdentifier == identifier)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }
        /// <summary>
        /// Is there a piece with the given identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public bool Contains(string identifier)
        {
            foreach (BasicGamePiece piece in GamePieces)
            {
                if (piece.SquareIdentifier == identifier)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// does the pattern contain three of the identifiers
        /// </summary>
        /// <param name="identifierOne"></param>
        /// <param name="identifierTwo"></param>
        /// <param name="identifierThree"></param>
        /// <param name="identifierFour"></param>
        /// <returns></returns>
        public bool ContainsThreeOf(string identifierOne, string identifierTwo, string identifierThree, string identifierFour)
        {
            int nCount = 0;

            if (Contains(identifierOne) == true)
                nCount++;

            if (Contains(identifierTwo) == true)
                nCount++;

            if (Contains(identifierThree) == true)
                nCount++;

            if (Contains(identifierFour) == true)
                nCount++;

            if (nCount >= 3)
                return true;

            return false;
        }
        /// <summary>
        /// Get the identifier that the pattern starts with
        /// </summary>
        public string GetStartsWith()
        {
            for (int i = 0; i < GamePieces.Count; i++)
            {
                if (((BasicGamePiece)GamePieces[i]).IsStartForPattern == true)
                    return ((BasicGamePiece)GamePieces[i]).SquareIdentifier;
            }

            return null;
        }

        #region Get the strings that represent positions within the pattern
        public string GetAbovePieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[1];
            int nTopPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp > ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1];
                    nTopPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nTopPiece]).SquareIdentifier;
        }
        public string GetAboveRightPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[0];
            char szTemp2 = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[1];

            int nAboveRightPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {

                if (szTemp < ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0]
                    && szTemp2 > ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0];
                    szTemp2 = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1];

                    nAboveRightPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nAboveRightPiece]).SquareIdentifier;
        }
        public string GetRightPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[0];
            int nRightPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp < ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0];
                    nRightPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nRightPiece]).SquareIdentifier;
        }
        public string GetBelowRightPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[0];
            char szTemp2 = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[1];
            int nBelowRightPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp < ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0]
                    && szTemp2 < ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0];
                    szTemp2 = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1];

                    nBelowRightPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nBelowRightPiece]).SquareIdentifier;
        }
        public string GetBelowPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[1];
            int nBelowPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp < ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1];
                    nBelowPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nBelowPiece]).SquareIdentifier;
        }
        public string GetBelowLeftPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[0];
            char szTemp2 = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[1];
            int nBelowLeftPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp > ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0]
                    && szTemp2 < ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0];
                    szTemp2 = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1];

                    nBelowLeftPiece = i;
                }
            }


            return ((BasicGamePiece)GamePieces[nBelowLeftPiece]).SquareIdentifier;
        }
        public string GetLeftPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[0];
            int nLeftPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp > ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0];
                    nLeftPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nLeftPiece]).SquareIdentifier;
        }
        public string GetAboveLeftPieceIdentifier()
        {
            if (GamePieces.Count < 2)
                return null;

            char szTemp = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[0];
            char szTemp2 = ((BasicGamePiece)GamePieces[0]).SquareIdentifier[1];

            int nAboveLeftPiece = 0;

            for (int i = 1; i < GamePieces.Count; i++)
            {
                if (szTemp > ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0]
                    && szTemp2 > ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1])
                {
                    szTemp = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[0];
                    szTemp2 = ((BasicGamePiece)GamePieces[i]).SquareIdentifier[1];

                    nAboveLeftPiece = i;
                }
            }

            return ((BasicGamePiece)GamePieces[nAboveLeftPiece]).SquareIdentifier;
        }
        #endregion

        public void UpdatePattern(BasicGamePattern pattern)
        {
            NumberOfTimesSeen++;

            if (pattern.IsLosingPattern == true)
                NumberOfTimesSeenInLosingGame++;
            if (pattern.IsWinningPattern == true)
                NumberOfTimesSeenInWinningGame++;
        }
        /// <summary>
        /// Save this pattern set
        /// </summary>
        /// <param name="xmlWriter"></param>
        public virtual void Save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("BasicGamePatternSet");
            xmlWriter.WriteElementString("PatternID", nPatternID.ToString());
            for (int i = 0; i < arrayGamePieces.Count; i++)
            {
                ((BasicGamePiece)arrayGamePieces[i]).Save(xmlWriter);
            }
            xmlWriter.WriteElementString("NumberOfTimesSeen", nNumberOfTimesSeen.ToString());
            xmlWriter.WriteElementString("NumberOfTimesSeenInWinningGame", nNumberOfTimesSeenInWinningGame.ToString());
            xmlWriter.WriteElementString("NumberOfTimesSeenInLosingGame", nNumberOfTimesSeenInLosingGame.ToString());
            xmlWriter.WriteElementString("EndingPattern", bIsEndingPattern.ToString());
            xmlWriter.WriteElementString("Weighting", nWeighting.ToString());
            xmlWriter.WriteStartElement("Response");
            if (bResponsePresent == true)
            {
                xmlWriter.WriteElementString("ResponsePresent", "1");
                bgpResponse.Save(xmlWriter);
            }
            else
                xmlWriter.WriteElementString("ResponsePresent", "0");

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

        }
        public virtual void Load(XmlReader xmlReader)
        {
            while (xmlReader.Name != "PatternID")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            nPatternID = int.Parse(xmlReader.Value);

            bool bBreak = false;
            for (; ; )
            {
                xmlReader.Read();
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            switch (xmlReader.Name)
                            {
                                case "BasicGamePiece":
                                    {
                                        BasicGamePiece temp = new BasicGamePiece();
                                        temp.Load(xmlReader);
                                        arrayGamePieces.Add(temp);
                                        break;
                                    }
                                case "NumberOfTimesSeen": bBreak = true; break;
                            }
                        }
                        break;
                }

                if (bBreak == true)
                    break;
            }

            /// should be on Number of times seen but doesn't hurt to check
            if (xmlReader.Name != "NumberOfTimesSeen")
                return;

            xmlReader.Read();
            nNumberOfTimesSeen = int.Parse(xmlReader.Value);

            while (xmlReader.Name != "NumberOfTimesSeenInWinningGame")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            nNumberOfTimesSeenInWinningGame = int.Parse(xmlReader.Value);

            while (xmlReader.Name != "NumberOfTimesSeenInLosingGame")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            nNumberOfTimesSeenInLosingGame = int.Parse(xmlReader.Value);

            while (xmlReader.Name != "EndingPattern")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            if (xmlReader.Value == "True")
                bIsEndingPattern = true;
            else
                bIsEndingPattern = false;

            while (xmlReader.Name != "Weighting")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            nWeighting = int.Parse(xmlReader.Value);

            while (xmlReader.Name != "Response")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            while (xmlReader.Name != "ResponsePresent")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            int nResponse = int.Parse(xmlReader.Value);

            if (nResponse != 0)
            {
                bResponsePresent = true;
                bgpResponse = new BasicGamePiece();
                bgpResponse.Load(xmlReader);
            }

        }

        // comparison stuff 

        /// <summary>
        ///  == operator
        ///  Note that class members that change during execution are not tested for equality
        ///  this means that say for eample the winning number of games has been incremented then the pattern
        ///  wont be considered to have changed if compared to a version of the pattern that hasn't been
        ///  incremented.
        /// </summary>
        /// <param name="patternOne"></param>
        /// <param name="patternTwo"></param>
        /// <returns></returns>
        public static bool operator ==(BasicGamePattern patternOne, BasicGamePattern patternTwo)
        {
            bool bOneIsNull = false;
            bool bBothAreNull = false;

            try
            {
                int nTest = patternOne.NumberOfTimesSeen;
            }
            catch (NullReferenceException nullRefExp)
            {
                string strTemp = nullRefExp.Message;

                bOneIsNull = true;
            }

            try
            {
                int nTest = patternTwo.NumberOfTimesSeen;
            }
            catch (NullReferenceException nullRefExp)
            {
                string strTemp = nullRefExp.Message;

                if (bOneIsNull == true)
                    bBothAreNull = true;
                else
                    bOneIsNull = true;
            }

            if (bOneIsNull == true && bBothAreNull == false)
                return false;

            if (bBothAreNull == true)
                return true;

            if (patternOne.GamePieces.Count != patternTwo.GamePieces.Count)
                return false;

            for (int i = 0; i < patternOne.GamePieces.Count; i++)
            {
                if ((BasicGamePiece)patternOne.GamePieces[i] != (BasicGamePiece)patternTwo.GamePieces[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(BasicGamePattern patternOne, BasicGamePattern patternTwo)
        {
            bool bOneIsNull = false;
            bool bBothAreNull = false;

            try
            {
                int nTest = patternOne.NumberOfTimesSeen;
            }
            catch (NullReferenceException nullRefExp)
            {
                string strTemp = nullRefExp.Message;

                bOneIsNull = true;
            }

            try
            {
                int nTest = patternTwo.NumberOfTimesSeen;
            }
            catch (NullReferenceException nullRefExp)
            {
                string strTemp = nullRefExp.Message;

                if (bOneIsNull == true)
                    bBothAreNull = true;
                else
                    bOneIsNull = true;
            }

            if (bOneIsNull == true && bBothAreNull == false)
                return true;

            if (bBothAreNull == true)
                return false;

            if (patternOne.GamePieces.Count != patternTwo.GamePieces.Count)
                return true;

            for (int i = 0; i < patternOne.GamePieces.Count; i++)
            {
                if ((BasicGamePiece)patternOne.GamePieces[i] == (BasicGamePiece)patternTwo.GamePieces[i])
                    return false;
            }

            return true;
        }

        // required overrides  
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            BasicGamePattern temp = (BasicGamePattern)obj;

            return this == temp;
        }
        public override int GetHashCode()
        {
            return Weighting.GetHashCode() ^ Response.GetHashCode() ^ NumberOfTimesSeen.GetHashCode() ^ GamePieces.GetHashCode();
        }
    }
}
