using System.Xml;

namespace BoardControl
{
    public class ConnectFourPatternCollection : BasicGamePatternCollection
	{
		public ConnectFourPatternCollection() : base() 	{ }
		public ConnectFourPattern GetStartPatternAt( string squareIdentifier )
		{
			for( int i=0; i<Patterns.Count; i++ )
			{
				if( ( ( ConnectFourPattern )Patterns[ i ] ).StartsWith( squareIdentifier ) == true )
					return ( ConnectFourPattern )Patterns[ i ];
			}

			return null;
		}
		public void AddPattern( ConnectFourPattern connectFourPattern )
		{
			Patterns.Add( new ConnectFourPattern( connectFourPattern ) );
		}
		public bool IsIn( ConnectFourPattern connectFourPattern )
		{
			for( int i=0; i<Patterns.Count; i++ )
			{
				if( ( ( BasicGamePattern )Patterns[ i ] ) == connectFourPattern )
					return true;
			}
			return false;
		}
		public void UpdatePattern( ConnectFourPattern pattern )
		{
			ConnectFourPatternCollection collection = ( ConnectFourPatternCollection )GetAllPatternsWithIdentifer( pattern.GetStartsWith() );

			if( collection.Count == 0 )
			{
				return;
			}
			for( int i=0; i<collection.Count; i++ )
			{
				if( ( ( ConnectFourPattern )collection.Patterns[ i ] ) == pattern )
				{
					( ( ConnectFourPattern )collection.Patterns[ i ] ).UpdatePattern( pattern );
				}
			}
		}
		public ConnectFourPattern GetPattern( ConnectFourPattern pattern )
		{
			for( int i=0; i<Patterns.Count; i++ )
			{
				if( pattern == ( ConnectFourPattern )Patterns[ i ] )
				{
					return ( ConnectFourPattern )Patterns[ i ];
				}
			}
			return null;
		}
		public new ConnectFourPattern GetPattern( int patternID )
		{
			if( patternID <= Patterns.Count )
			{
				return ( ConnectFourPattern )Patterns[ patternID ];
			}
			return null;
		}
		public new ConnectFourPatternCollection GetAllPatternsWithIdentifer(string identifier)
		{
			ConnectFourPatternCollection unit = new ConnectFourPatternCollection();

			for( int i=0; i<Patterns.Count; i++ )
			{
				if( ( ( ConnectFourPattern )Patterns[ i ] ).StartsWith( identifier ) == true )
				{
					/// note do not use copy constructor here moron.
					/// 

					unit.AddPattern( ( ( ConnectFourPattern )Patterns[ i ] ) );
				}
			}
			return unit;
		}
		public ConnectFourPattern HighestPatternWeighting()
		{
			int nHighest = 0;
			int nWeight = ( ( ConnectFourPattern )Patterns[ 0 ] ).Weighting;
			ConnectFourPattern pattern = null;

			for( int i=1; i<Patterns.Count; i++ )
			{
				pattern = ( ConnectFourPattern )Patterns[ i ];

				if( pattern.Weighting >= nWeight )
				{
					nHighest = i;
					nWeight = pattern.Weighting;
				}
			}
			return ( ConnectFourPattern )Patterns[ nHighest ];
		}
		public override void Save(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement( "ConnectFourPatternCollection" );
			base.Save (xmlWriter);
			xmlWriter.WriteEndElement();
		}
		public override void Load(XmlReader xmlReader)
		{
			bool bBreak = false;
			for( ;; )
			{
				xmlReader.Read();
				if( xmlReader.EOF == true )
					return;
				switch( xmlReader.NodeType )
				{
					case XmlNodeType.Element:
					{
						switch( xmlReader.Name )
						{
							case "ConnectFourPattern":
							{
								ConnectFourPattern temp = new ConnectFourPattern();
								temp.Load( xmlReader );
								Patterns.Add( temp );
								break;
							}
						}
					} break;
					case XmlNodeType.EndElement:
					{
						switch( xmlReader.Name )
						{
							case "ConnectFourPatternCollection": bBreak = true; break;
						}
					} break;
				}

				if( bBreak == true )
					break;
			}

		}
	}
}
