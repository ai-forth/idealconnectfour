using System.Collections;
using System.Xml;

namespace BoardControl
{
    /// <summary>
    /// A collection of basic game pattern sets.
    /// </summary>
    public class BasicGamePatternCollection
    {
        /// <summary>
        /// Array to hold the sets of patterns.
        /// </summary>
        private ArrayList arrayPatterns;
        public ArrayList Patterns
        {
            get
            {
                return arrayPatterns;
            }
        }
        public int Count
        {
            get
            {
                return arrayPatterns.Count;
            }
        }
        public BasicGamePatternCollection()
        {
            arrayPatterns = new ArrayList();
        }
        public void Clear()
        {
            for (int i = 0; i < arrayPatterns.Count; i++)
            {
                ((BasicGamePattern)arrayPatterns[i]).Clear();
            }

            arrayPatterns.Clear();
        }

        // Methods for searching the pattern collection 

        /// <summary>
        /// Get all the patterns that start with a given identifier ie CD
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public virtual BasicGamePatternCollection GetAllPatternsWithIdentifer(string identifier)
        {
            BasicGamePatternCollection unit = new BasicGamePatternCollection();

            for (int i = 0; i < arrayPatterns.Count; i++)
            {
                if (((BasicGamePattern)arrayPatterns[i]).StartsWith(identifier) == true)
                {
                    unit.AddPattern(new BasicGamePattern((BasicGamePattern)arrayPatterns[i]));
                }
            }

            return unit;
        }

        // Manipulate the pattern sets 

        public void AddPattern(BasicGamePattern basicGamePattern)
        {
            /// add a copy of the pattern using the copy constructor
            arrayPatterns.Add(new BasicGamePattern(basicGamePattern));
        }
        public bool IsIn(BasicGamePattern basicGamePattern)
        {
            for (int i = 0; i < arrayPatterns.Count; i++)
            {
                if (((BasicGamePattern)arrayPatterns[i]) == basicGamePattern)
                    return true;
            }

            return false;
        }
        public void UpdatePattern(BasicGamePattern basicGamePattern)
        {
            /// nothing to update here
            /// 
            BasicGamePatternCollection collection = GetAllPatternsWithIdentifer(basicGamePattern.GetStartsWith());

            if (collection.Count == 0)
            {
                System.Diagnostics.Debug.Assert(collection.Count != 0, "Error updating the pattern", "Error the pattern has been identified as " + basicGamePattern.GetStartsWith() + " but GetAllPatternsWithIdentifier returns a count of 0 ");
                return;
            }

            for (int i = 0; i < collection.Count; i++)
            {
                if (((BasicGamePattern)collection.Patterns[i]) == basicGamePattern)
                {
                    ((BasicGamePattern)collection.Patterns[i]).UpdatePattern(basicGamePattern);
                    return;
                }
            }
        }
        public BasicGamePattern GetPattern(BasicGamePattern basicGamePattern)
        {
            for (int i = 0; i < Patterns.Count; i++)
            {
                if (basicGamePattern == (BasicGamePattern)Patterns[i])
                {
                    return (BasicGamePattern)Patterns[i];
                }
            }

            return null;
        }
        public BasicGamePattern GetPattern(int patternID)
        {
            if (patternID <= Patterns.Count)
            {
                return (BasicGamePattern)Patterns[patternID];
            }

            return null;
        }

        // Save and Load 

        public virtual void Save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("BasicGamePatternCollection");
            for (int i = 0; i < Patterns.Count; i++)
            {
                if (((BasicGamePattern)Patterns[i]).GamePieces.Count != 0)
                    ((BasicGamePattern)Patterns[i]).Save(xmlWriter);
            }
            xmlWriter.WriteEndElement();
        }
        public virtual void Load(XmlReader xmlReader)
        {

            bool bBreak = false;
            for (; ; )
            {
                xmlReader.Read();
                if (xmlReader.EOF == true)
                    return;
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            switch (xmlReader.Name)
                            {
                                case "BasicGamePatternSet":
                                    {
                                        BasicGamePattern temp = new BasicGamePattern();
                                        temp.Load(xmlReader);
                                        Patterns.Add(temp);
                                        break;
                                    }
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        {
                            switch (xmlReader.Name)
                            {
                                case "BasicGamePatternCollection": bBreak = true; break;
                            }
                        }
                        break;
                }

                if (bBreak == true)
                    break;
            }
        }

    }
}
