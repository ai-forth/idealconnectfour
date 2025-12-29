using System;
using System.Xml;

namespace BoardControl
{
    /// <summary>
    /// A single pattern of pieces on the board.
    /// </summary>
    public class BasicGamePiece
    {
        public PIECEPOSITION Position { get { return pPosition; } set { pPosition = value; } }

        /// <summary>
        /// Identifer for the square in the pattern.
        /// </summary>
        private string strSquareIdentifier;
        /// <summary>
        /// Is the square occupied by an enemy.
        /// </summary>
        private bool bIsEnemy;
        /// <summary>
        /// Is this the starting point of the pattern.
        /// </summary>
        private bool bIsStartForPattern;
        /// <summary>
        /// The position relative to the start square.
        /// </summary>
        private PIECEPOSITION pPosition;
        /// <summary>
        /// What level is this piece at? i.e., how many squares away from start square level 1 are adjacent?
        /// </summary>
        private int nLevel;
        /// <summary>
        /// identifier for this pattern
        /// </summary>
        private static int nBasicPieceID = 0;
        private int nPieceID;
        public string SquareIdentifier
        {
            get
            {
                return strSquareIdentifier;
            }
            set
            {
                strSquareIdentifier = value;
            }
        }
        public bool IsEnemy
        {
            get
            {
                return bIsEnemy;
            }
            set
            {
                bIsEnemy = value;
            }
        }
        public bool IsStartForPattern
        {
            get
            {
                return bIsStartForPattern;
            }
            set
            {
                bIsStartForPattern = value;
            }
        }
        public int PieceID
        {
            get
            {
                return nPieceID;
            }
            set
            {
                nPieceID = value;
            }
        }
        public int Level
        {
            get
            {
                return nLevel;
            }
            set
            {
                nLevel = value;
            }
        }
        public BasicGamePiece()
        {
            //
            // TODO: Add constructor logic here
            //

            strSquareIdentifier = null;
            bIsEnemy = false;
            nPieceID = nBasicPieceID;
            nBasicPieceID++;
            bIsStartForPattern = false;
            nLevel = 0;
        }
        public BasicGamePiece(bool isStartForPattern, string squareIdentifier) : this(squareIdentifier)
        {
            IsStartForPattern = isStartForPattern;
        }
        public BasicGamePiece(string squareIdentifier) : this()
        {
            SquareIdentifier = squareIdentifier;
        }
        public BasicGamePiece(bool isStartForPattern, string squareIdentifier, bool isEnemy) : this(squareIdentifier, isEnemy)
        {
            IsStartForPattern = isStartForPattern;
        }
        public BasicGamePiece(string squareIdentifier, bool isEnemy) : this(squareIdentifier)
        {
            IsEnemy = isEnemy;
        }
        public BasicGamePiece(string squareIdentifier, bool isEnemy, PIECEPOSITION position) : this(squareIdentifier, isEnemy)
        {
            Position = position;
        }
        public BasicGamePiece(BasicGamePiece piece)
        {
            IsStartForPattern = piece.IsStartForPattern;
            SquareIdentifier = piece.SquareIdentifier;
            IsEnemy = piece.IsEnemy;
            Position = piece.Position;
            Level = piece.Level;
        }

        // Saving and loading.
        public virtual void Save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("BasicGamePiece");
            xmlWriter.WriteElementString("PieceID", nPieceID.ToString());
            xmlWriter.WriteElementString("IsStartForPattern", IsStartForPattern.ToString());
            xmlWriter.WriteElementString("Square", strSquareIdentifier);
            xmlWriter.WriteElementString("IsEnemy", bIsEnemy.ToString());
            xmlWriter.WriteElementString("PiecePosition", pPosition.ToString());
            xmlWriter.WriteElementString("Level", Level.ToString());
            xmlWriter.WriteEndElement();
        }
        public virtual void Load(XmlReader xmlReader)
        {
            while (xmlReader.Name != "PieceID")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            nPieceID = Int32.Parse(xmlReader.Value);

            while (xmlReader.Name != "IsStartForPattern")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            if (xmlReader.Value == "True")
                bIsStartForPattern = true;
            else
                bIsStartForPattern = false;

            while (xmlReader.Name != "Square")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            strSquareIdentifier = xmlReader.Value;

            while (xmlReader.Name != "IsEnemy")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            if (xmlReader.Value == "True")
                bIsEnemy = true;
            else
                bIsEnemy = false;

            while (xmlReader.Name != "PiecePosition")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            string strTest = xmlReader.Value;


            switch (strTest)
            {
                case "START": Position = PIECEPOSITION.START; break;
                case "ABOVE": Position = PIECEPOSITION.ABOVE; break;
                case "ABOVERIGHT": Position = PIECEPOSITION.ABOVERIGHT; break;
                case "RIGHT": Position = PIECEPOSITION.RIGHT; break;
                case "BELOWRIGHT": Position = PIECEPOSITION.BELOWRIGHT; break;
                case "BELOW": Position = PIECEPOSITION.BELOW; break;
                case "BELOWLEFT": Position = PIECEPOSITION.BELOWLEFT; break;
                case "LEFT": Position = PIECEPOSITION.ABOVELEFT; break;
            }

            while (xmlReader.Name != "Level")
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
            }

            xmlReader.Read();
            nLevel = int.Parse(xmlReader.Value);
        }

        // TEST THESE!

        // Compare basic patterns.
        public static bool operator ==(BasicGamePiece pieceOne, BasicGamePiece pieceTwo)
        {
            bool bOneIsNull = false;
            bool bBothAreNull = false;

            try
            {
                int nTest = pieceOne.PieceID;
            }
            catch (NullReferenceException nullRefExp)
            {
                string strTemp = nullRefExp.Message;

                bOneIsNull = true;
            }

            try
            {
                int nTest = pieceTwo.PieceID;
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

            if ( /*patternOne.SquareIdentifier == patternTwo.SquareIdentifier
				&&*/ pieceOne.IsStartForPattern == pieceTwo.IsStartForPattern
                && pieceOne.Position == pieceTwo.Position
                && pieceOne.IsEnemy == pieceTwo.IsEnemy
                && pieceOne.Level == pieceTwo.Level)
                return true;
            else
                return false;
        }
        public static bool operator !=(BasicGamePiece pieceOne, BasicGamePiece pieceTwo)
        {
            bool bOneIsNull = false;
            bool bBothAreNull = false;
            try
            {
                int nTest = pieceOne.PieceID;// <-- this is null
            }
            catch (NullReferenceException nullRefExp)
            {
                string strTemp = nullRefExp.Message;
                bOneIsNull = true;
            }
            try
            {
                int nTest = pieceTwo.PieceID;
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
            if (pieceOne.SquareIdentifier != pieceTwo.SquareIdentifier
                || pieceOne.IsStartForPattern != pieceTwo.IsStartForPattern
                || pieceOne.Position != pieceTwo.Position
                || pieceOne.IsEnemy != pieceTwo.IsEnemy
                || pieceOne.Level != pieceTwo.Level)
                return true;
            else
                return false;
        }

        // Required object overrides because of comparison operators.
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            BasicGamePiece temp = (BasicGamePiece)obj;

            return this == temp;
        }
        public override int GetHashCode()
        {
            return IsStartForPattern.GetHashCode() ^ SquareIdentifier.GetHashCode() ^ Position.GetHashCode() ^ IsEnemy.GetHashCode();
        }
    }
}
