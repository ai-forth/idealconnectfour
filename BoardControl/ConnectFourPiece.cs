using System;

namespace BoardControl
{
    /// <summary>
    /// Summary description for ConnectFourPattern.
    /// </summary>
    public class ConnectFourPiece : BasicGamePiece
	{
		private bool bIsPieceRed;

		public bool IsPieceRed
		{
			get
			{
				return bIsPieceRed;
			}
			set
			{
				bIsPieceRed = value;
			}
		}

		public ConnectFourPiece() : base()
		{
			//
			// TODO: Add constructor logic here
			//

			IsPieceRed = false;
		}

		public ConnectFourPiece( bool isStartForPattern, string squareIdentifier ) : base( isStartForPattern, squareIdentifier )
		{
			IsPieceRed = false;
		}

		public ConnectFourPiece( string squareIdentifier ) : base( squareIdentifier )
		{
			IsPieceRed = false;
		}

		public ConnectFourPiece( bool isStartForPattern, string squareIdentifier, bool isEnemy ) : base( isStartForPattern, squareIdentifier, isEnemy )
		{
			IsPieceRed = false;
		}

		public ConnectFourPiece( string squareIdentifier, bool isEnemy ) : base( squareIdentifier, isEnemy )
		{
			IsPieceRed = false;
		}

		public ConnectFourPiece( ConnectFourPiece piece ) : base( piece )
		{
			IsPieceRed = false;
		}

		public override void Save(System.Xml.XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement( "ConnectFourPiece" );
			xmlWriter.WriteElementString( "IsRed", IsPieceRed.ToString() );
			base.Save (xmlWriter);
			xmlWriter.WriteEndElement();
		}


		public override void Load(System.Xml.XmlReader xmlReader)
		{
			while( xmlReader.Name != "IsRed" )
			{
				xmlReader.Read();
				if( xmlReader.EOF == true )
					return;
			}

			xmlReader.Read();
			if( xmlReader.Value == "True" )
				IsPieceRed = true;
			else
				IsPieceRed = false;

			base.Load (xmlReader);
		}

		public static bool operator ==( ConnectFourPiece pieceOne, ConnectFourPiece pieceTwo )
		{
			bool bOneIsNull = false;
			bool bBothAreNull = false;

			try
			{
				bool bTest = pieceOne.IsPieceRed;
			}
			catch( NullReferenceException nullRefExp )
			{
				string strTemp = nullRefExp.Message;

				bOneIsNull = true;
			}

			try
			{
				bool bTest = pieceTwo.IsPieceRed;
			}
			catch( NullReferenceException nullRefExp )
			{
				string strTemp = nullRefExp.Message;

				if( bOneIsNull == true )
					bBothAreNull = true;
				else
					bOneIsNull = true;
			}

			if( bOneIsNull == true && bBothAreNull == false )
				return false;

			if( bBothAreNull == true )
				return true;

			if( pieceOne.IsPieceRed == pieceTwo.IsPieceRed )
			{
				return ( BasicGamePiece )pieceOne == ( BasicGamePiece )pieceTwo;
			}

			return false;
		}

		public static bool operator !=( ConnectFourPiece pieceOne, ConnectFourPiece pieceTwo )
		{
			bool bOneIsNull = false;
			bool bBothAreNull = false;

			try
			{
				bool bTest = pieceOne.IsPieceRed;
			}
			catch( NullReferenceException nullRefExp )
			{
				string strTemp = nullRefExp.Message;

				bOneIsNull = true;
			}

			try
			{
				bool bTest = pieceTwo.IsPieceRed;	
			}
			catch( NullReferenceException nullRefExp )
			{
				string strTemp = nullRefExp.Message;

				if( bOneIsNull == true )
					bBothAreNull = true;
				else
					bOneIsNull = true;
			}

			if( bOneIsNull == true && bBothAreNull == false )
				return true;

			if( bBothAreNull == true )
				return false;

			if( pieceOne.IsPieceRed != pieceTwo.IsPieceRed )
			{
				return ( BasicGamePiece )pieceOne != ( BasicGamePiece )pieceTwo;
			}

			return false;
		}

		public override bool Equals(object obj)
		{
			if( obj == null && GetType() != obj.GetType() )
				return false;

			ConnectFourPiece piece = ( ConnectFourPiece )obj;

			return this == piece;
		}

		public override int GetHashCode()
		{
			return IsPieceRed.GetHashCode() ^ base.GetHashCode ();
		}
	}
}
