namespace BoardControl
{
	public enum CONNECTFOURPATTERNDIRECTION{ ERROR, VERTICAL, RIGHTHORIZONTAL, LEFTHORIZONTAL, LEFTDIAGONAL /* / */, RIGHTDIAGONAL /* \ */ }; 

	public class ConnectFourPattern : BasicGamePattern
	{
        public CONNECTFOURPATTERNDIRECTION GetPatternDirection()
        {
            if (GamePieces.Count == 1)
                return CONNECTFOURPATTERNDIRECTION.ERROR;

            System.Diagnostics.Debug.Assert(GamePieces[1] != null, "Error first piece in the pattern is invalid");

            BasicGamePiece piece = (BasicGamePiece)GamePieces[1];

            if (piece.Position == PIECEPOSITION.ABOVE)
                return CONNECTFOURPATTERNDIRECTION.VERTICAL;
            else if (piece.Position == PIECEPOSITION.ABOVERIGHT)
                return CONNECTFOURPATTERNDIRECTION.LEFTDIAGONAL;
            else if (piece.Position == PIECEPOSITION.RIGHT)
                return CONNECTFOURPATTERNDIRECTION.RIGHTHORIZONTAL;
            else if (piece.Position == PIECEPOSITION.BELOWRIGHT)
                return CONNECTFOURPATTERNDIRECTION.RIGHTDIAGONAL;
            else if (piece.Position == PIECEPOSITION.BELOW)
                return CONNECTFOURPATTERNDIRECTION.VERTICAL;
            else if (piece.Position == PIECEPOSITION.BELOWLEFT)
                return CONNECTFOURPATTERNDIRECTION.LEFTDIAGONAL;
            else if (piece.Position == PIECEPOSITION.LEFT)
                return CONNECTFOURPATTERNDIRECTION.LEFTHORIZONTAL;
            else if (piece.Position == PIECEPOSITION.ABOVELEFT)
                return CONNECTFOURPATTERNDIRECTION.RIGHTDIAGONAL;
            else
                return CONNECTFOURPATTERNDIRECTION.ERROR;
        }

        public ConnectFourPattern() : base() { }
		public ConnectFourPattern( int numberOfTimesSeen ) : base( numberOfTimesSeen ) { }
		public ConnectFourPattern( int numberOfTimesSeen, int weighting ) : base( numberOfTimesSeen, weighting ) { }
		public ConnectFourPattern( ConnectFourPattern patternSet ) : base( patternSet )	{ }
		public void UpdatePattern( ConnectFourPattern pattern )
		{
			base.UpdatePattern( ( BasicGamePattern )pattern );
		}
		public void AddGamePiece( ConnectFourPiece piece )
		{
			GamePieces.Add( piece );
		}
		public override void Save(System.Xml.XmlWriter xmlWriter)
		{
			if( GamePieces.Count == 0 )
				return;

			xmlWriter.WriteStartElement( "ConnectFourPattern" );

			base.Save( xmlWriter );

			xmlWriter.WriteEndElement();

		}
		public override void Load(System.Xml.XmlReader xmlReader)
		{
			base.Load( xmlReader );
		}
		public bool PatternDirectionAbove()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.ABOVE )
					return true;
				if( piece.Position == PIECEPOSITION.BELOW )
					return true;
			}

			return false;
		}
		public bool PatternDirectionAboveRight()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.ABOVERIGHT )
					return true;
				if( piece.Position == PIECEPOSITION.BELOWLEFT )
					return true;
			}

			return false;
		}
		public bool PatternDirectionRight()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.RIGHT )
					return true;
				if( piece.Position == PIECEPOSITION.LEFT )
					return true;
			}

			return false;
		}
		public bool PatternDirectionBelowRight()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.BELOWRIGHT )
					return true;
				if( piece.Position == PIECEPOSITION.ABOVELEFT )
					return true;
			}

			return false;
		}
		public bool PatternDirectionBelow()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.BELOW )
					return true;
				if( piece.Position == PIECEPOSITION.ABOVE )
					return true;
			}

			return false;
		}
		public bool PatternDirectionBelowLeft()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.BELOWLEFT )
					return true;
				if( piece.Position == PIECEPOSITION.ABOVERIGHT )
					return true;
			}

			return false;
		}
		public bool PatternDirectionLeft()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.LEFT )
					return true;
				if( piece.Position == PIECEPOSITION.RIGHT )
					return true;
			}

			return false;
		}
		public bool PatternDirectionAboveLeft()
		{
			if( GamePieces.Count == 1 )
				return false;

			BasicGamePiece piece = null;

			for( int i=1; i<GamePieces.Count; i++ )
			{
				piece = ( BasicGamePiece )GamePieces[ i ];

				if( piece.Position == PIECEPOSITION.ABOVELEFT )
					return true;
				if( piece.Position == PIECEPOSITION.BELOWRIGHT )
					return true;
			}

			return false;
		}
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}
	}
}
