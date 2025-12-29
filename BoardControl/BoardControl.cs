using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace BoardControl
{
	public enum SQUAREMODES{ DISPLAYONLY, CONNECTFOUR };

	/// <summary>
	/// BoardControl is a user control that draws squares for games and life simulators
	/// </summary>
	public class Board : UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// board width
		/// </summary>
		private int nBoardWidth;
		/// <summary>
		/// board height
		/// </summary>
		private int nBoardHeight;
		/// <summary>
		/// the number of hrizontal squares
		/// </summary>
		private int nHorizontalSquares;
		/// <summary>
		/// the number of vertical squares
		/// </summary>
		private int nVerticalSquares;
		/// <summary>
		/// Square width
		/// </summary>
		private int nSquareWidth;
		/// <summary>
		/// square height
		/// </summary>
		private int nSquareHeight;
		/// <summary>
		/// game types
		/// </summary>
		private SQUAREMODES mode;
		/// <summary>
		/// show the board legend
		/// </summary>
		private bool bShowLegend;
		/// <summary>
		/// colour of the legend
		/// </summary>
		private Color cLegendColor;
		/// <summary>
		/// size of the legend
		/// </summary>
		private int nLegendWidth;
		/// <summary>
		/// variable set so that I can decide which paint calls I want to debug
		/// </summary>
		private bool bTestPaint;


		/// <summary>
		/// private hash table for storing the square information
		/// </summary>
		private Hashtable hashSquares;


		public int BoardWidth
		{
			get
			{
				return nBoardWidth;
			}
			set
			{
				nBoardWidth = value;
			}
		}

		public int BoardHeight
		{
			get
			{
				return nBoardHeight;
			}
			set
			{
				nBoardHeight = value;
			}
		}


		public int HorizontalSquares
		{
			get
			{
				return nHorizontalSquares;
			}
			set
			{
				nHorizontalSquares = value;
			}
		}

		public int VerticalSquares
		{
			get
			{
				return nVerticalSquares;
			}
			set
			{
				nVerticalSquares = value;
			}
		}

		public int SquareWidth 
		{
			get
			{
				return nSquareWidth;
			}
			set
			{
				nSquareWidth = value;
			}
		}

		public int SquareHeight
		{
			get
			{
				return nSquareHeight;
			}
			set
			{
				nSquareHeight = value;
			}
		}

		public bool ShowLegend
		{
			get
			{
				return bShowLegend;
			}
			set
			{
				bShowLegend = value;
			}
		}

		public Color LegendColor
		{
			get
			{
				return cLegendColor;
			}
			set
			{
				cLegendColor = value;
			}
		}

		public int LegendWidth
		{
			get
			{
				return nLegendWidth;
			}
			set
			{
				nLegendWidth = value;
			}
		}

		public bool TestPaint
		{
			get
			{
				return bTestPaint;
			}
			set
			{
				bTestPaint = value;
			}
		}

		public Hashtable GetHashTable
		{
			get
			{
				return hashSquares;
			}
		}

		public void SetDisplayMode( string strDisplayMode )
		{
			switch( strDisplayMode )
			{
				case "CONNECTFOUR": mode =	SQUAREMODES.CONNECTFOUR; break;
				default : mode = SQUAREMODES.DISPLAYONLY; break;
			}
		}


		public Board()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			BoardWidth = 0;
			BoardHeight = 0;
			HorizontalSquares = 0;
			VerticalSquares = 0;
			SquareWidth = 0;
			SquareHeight = 0;
			ShowLegend = true;
			LegendColor = Color.LightBlue;
			LegendWidth = 10;

			mode = SQUAREMODES.DISPLAYONLY;

			hashSquares = new Hashtable();

			TestPaint = false;

			SetStyle( ControlStyles.UserPaint, true ); 
			SetStyle( ControlStyles.AllPaintingInWmPaint, true ); 
			SetStyle( ControlStyles.DoubleBuffer, true ); 
		}

		/// <summary>
		/// remove all the squares from the hashtable
		/// </summary>
		public void Clear()
		{
			hashSquares.Clear();
		}
			

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// BoardControl
			// 
			this.Name = "BoardControl";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);

		}
		#endregion

		private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics grfx = e.Graphics;

			if( mode == SQUAREMODES.DISPLAYONLY )
			{
				/// this code just gives something to look at when the control is dropped onto a 
				/// form the control should be set up programmatically by the container program 
				/// which will then select modes etc to use.
				Clear();

				/// create some squares 
				
				hashSquares.Add( "AA", new ControlDisplaySquare( 100, 100, 0, 0, "AA" ) );
				hashSquares.Add( "AB", new ControlDisplaySquare( 100, 100, 0, 100, "AB" ) );
				hashSquares.Add( "AC", new ControlDisplaySquare( 100, 100, 0, 200, "AC" ) );
				hashSquares.Add( "BA", new ControlDisplaySquare( 100, 100, 100, 0, "BA" ) );
				hashSquares.Add( "BB", new ControlDisplaySquare( 100, 100, 100, 100, "BB" ) );
				hashSquares.Add( "BC", new ControlDisplaySquare( 100, 100, 100, 200, "BC" ) );
				hashSquares.Add( "CA", new ControlDisplaySquare( 100, 100, 200, 0, "CA" ) );
				hashSquares.Add( "CB", new ControlDisplaySquare( 100, 100, 200, 100, "CB" ) );
				hashSquares.Add( "CC", new ControlDisplaySquare( 100, 100, 200, 200, "CC" ) );

				( ( BasicSquare )hashSquares[ "AA" ] ).DrawLegend = true;
				( ( BasicSquare )hashSquares[ "AC" ] ).IsBottomSquare = true;
				( ( BasicSquare )hashSquares[ "BC" ] ).IsBottomSquare = true;
				( ( BasicSquare )hashSquares[ "CA" ] ).IsRightEdgeSquare = true;
				( ( BasicSquare )hashSquares[ "CB" ] ).IsRightEdgeSquare = true;
				( ( BasicSquare )hashSquares[ "CC" ] ).IsRightEdgeSquare = true;
				( ( BasicSquare )hashSquares[ "CC" ] ).IsBottomSquare = true;

				foreach( DictionaryEntry dicEnt in hashSquares )
				{
					BasicSquare square = ( BasicSquare )dicEnt.Value;

					square.DrawSquare( e.Graphics );
				}

			}
			else /// draw the board
			{
				/// assume that the calls to paint are only made when necassary so draw all squares
				/// this avoids having to call in from the container ( hopefully )
				
				if( e.ClipRectangle.Width >= BoardWidth )
				{
					foreach( DictionaryEntry dicEnt in hashSquares )
					{
						BasicSquare square = ( BasicSquare )dicEnt.Value;

						square.IsValid = false;
					}
				}
				else
				{
					/// if not drawing the complet board work out which squares need drawing
					/// NOTE maths is slightly out if using the legend ( but not enough to make much difference )
					foreach( DictionaryEntry dicEnt in hashSquares )
					{
						BasicSquare square = ( BasicSquare )dicEnt.Value;

						if( e.ClipRectangle.Width >= square.SquareHorizontalLocation || 
							e.ClipRectangle.Height >= square.SquareVerticalLocation )
						{
							square.IsValid = false;
						}
					}
				}
			}
		}

		/// <summary>
		/// get a square given the passed in identifier
		/// </summary>
		/// <param name="strSquareIdentifier"></param>
		/// <returns></returns>
		public BasicSquare GetSquare( string squareIdentifier )
		{
			return ( BasicSquare )hashSquares[ squareIdentifier ];
		}

	
		/// <summary>
		/// Get square to the right of the square with the passed in identifier 
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either the square to the right or null</returns>
		public BasicSquare GetSquareToRight( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );
			
			char firstChar = strString[ 0 ];

			firstChar++;

			strString[ 0 ] = firstChar;

			return ( BasicSquare )this.hashSquares[ strString.ToString() ];

		}

		/// <summary>
		/// as above but returns the identifier
		/// </summary>
		/// <param name="squareIdentifier"></param>
		/// <returns></returns>
		public string GetIdentifierToRight( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];

			firstChar++;

			strString[ 0 ] = firstChar;

			return strString.ToString();
		}

		/// <summary>
		/// Get square to the left of the square with the passed in identifier
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either the square to the left or null</returns>
		public BasicSquare GetSquareToLeft( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];

			firstChar--;

			strString[ 0 ] = firstChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierToLeft( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];

			firstChar--;

			strString[ 0 ] = firstChar;

			return strString.ToString();
		}

		/// <summary>
		/// Get square above the square with the passed identifier
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either the square above or null</returns>
		public BasicSquare GetSquareAbove( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 1 ];

			firstChar--;

			strString[ 1 ] = firstChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierAbove( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 1 ];

			firstChar--;

			strString[ 1 ] = firstChar;

			return strString.ToString();
		}

		/// <summary>
		/// Get square to the above left of the square with the passed identifier
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either the square above left of the current square or null</returns>
		public BasicSquare GetSquareAboveLeft( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar--;
			secondChar--;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierAboveLeft( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar--;
			secondChar--;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return strString.ToString();
		}

		/// <summary>
		/// Get square to the above right of the square with the passed in identifier
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either the square above right of the current square or null</returns>
		public BasicSquare GetSquareAboveRight( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar++;
			secondChar--;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierAboveRight( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar++;
			secondChar--;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return strString.ToString();
		}

		/// <summary>
		/// Get the square below the square with the passed in identifier
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either ther square below the current square or null</returns>
		public BasicSquare GetSquareBelow( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 1 ];

			firstChar++;

			strString[ 1 ] = firstChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierBelow( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );
			
			char firstChar = strString[ 1 ];

			firstChar++;

			strString[ 1 ] = firstChar;

			return strString.ToString();
		}

		/// <summary>
		/// Get the square to the below left of the square with the passed in identifier
		/// </summary>
		/// <param name="squareIdentifier">current square ie "AF"</param>
		/// <returns>either the square below left of the square with the passed in identifier or null</returns>
		public BasicSquare GetSquareBelowLeft( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar--;
			secondChar++;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierBelowLeft( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar--;
			secondChar++;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return strString.ToString();
		}

		/// <summary>
		/// GEt the square to the below right of the square with the passed identifier
		/// </summary>
		/// <param name="squareIdentifier">square identifier ie "AF"</param>
		/// <returns>either the square below left of the square with the passed in identifier or null</returns>
		public BasicSquare GetSquareBelowRight( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar++;
			secondChar++;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return ( BasicSquare )hashSquares[ strString.ToString() ];
		}

		public string GetIdentifierBelowRight( string squareIdentifier )
		{
			StringBuilder strString = new StringBuilder( squareIdentifier );

			char firstChar = strString[ 0 ];
			char secondChar = strString[ 1 ];

			firstChar++;
			secondChar++;

			strString[ 0 ] = firstChar;
			strString[ 1 ] = secondChar;

			return strString.ToString();
		}


		/// <summary>
		/// invalidate a given square
		/// </summary>
		/// <param name="strIdentifier">hash table identifier for the string</param>
		public void InvalidateSquare( string identifier )
		{
			BasicSquare square = ( BasicSquare )hashSquares[ identifier ];

			if( square == null )
				return;

			if( ShowLegend == false )
				Invalidate( new Rectangle( square.SquareHorizontalLocation, square.SquareVerticalLocation, square.SquareWidth, square.SquareHeight ) ); 
			else
				Invalidate( new Rectangle( square.SquareHorizontalLocation + LegendWidth, square.SquareVerticalLocation + LegendWidth, square.SquareWidth, square.SquareHeight ) ); 

			square.IsValid = false;
		}

		/// <summary>
		/// get a square on the board gioven the widht and height
		/// </summary>
		/// <param name="width">horizontal position of the square on the board</param>
		/// <param name="height">vertical position of the square on the board</param>
		/// <returns></returns>
		public BasicSquare GetSquareAt( int width, int height )
		{
			foreach( DictionaryEntry dicEnt in hashSquares )
			{
				BasicSquare square = ( BasicSquare )dicEnt.Value;

				if( this.ShowLegend == false )
				{
					if( square.SquareHorizontalLocation <= width &&
						( square.SquareHorizontalLocation + square.SquareWidth ) >= width &&
						square.SquareVerticalLocation <= height &&
						( square.SquareVerticalLocation + square.SquareHeight ) >= height )
					{
						return square;
					}
				}
				else
				{
					if( ( square.SquareHorizontalLocation + this.LegendWidth ) <= width &&
						( square.SquareHorizontalLocation + LegendWidth + square.SquareWidth ) >= width &&
						( square.SquareVerticalLocation + LegendWidth ) <= height &&
						( square.SquareVerticalLocation + LegendWidth + square.SquareHeight ) >= height )
					{
						return square;
					}
				}
			}

			return null;
		}
	}
}
