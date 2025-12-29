namespace BoardControl
{
    /// <summary>
    /// Class to hold the info needed by each square to play the game.
    /// </summary>
    public class ConnectFourSquareInfo
	{
		/// <summary>
		/// String to hold the square identifier.
		/// </summary>
		private string strSquareIdentifier;
		/// <summary>
		/// Square colour will be "EMPTY" ( Green ) "RED" or "BLUE".
		/// </summary>
		private string strSquareColor; 
		/// <summary>
		/// Has the square been occupied?
		/// </summary>
		private bool bIsOccupied;
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
		public string SquareColor
		{
			get
			{
				return strSquareColor;
			}
			set
			{
				strSquareColor = value;
			}
		}
		public bool IsRed 
		{
			get
			{
				if( strSquareColor == "RED" )
					return true;
				else
					return false;
			}
		}
		public bool IsOccupied 
		{
			get
			{
				return bIsOccupied;
			}
			set
			{
				bIsOccupied = value;
			}
		}
		public ConnectFourSquareInfo( string squareIdentifier, string squareColor )
		{
			SquareIdentifier = squareIdentifier;
			SquareColor = squareColor;
			IsOccupied = false;
		}
	}
}
