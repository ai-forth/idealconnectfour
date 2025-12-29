using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Connect_Four
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class GameForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private BoardControl.ConnectFourBoard connectFourBoard1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton redButton;
		private System.Windows.Forms.RadioButton blueButton;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button pauseButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.Label outputPane;
		private System.Windows.Forms.Timer outputTimer;
		private System.ComponentModel.IContainer components;

		public GameForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

	///		boardControl1.SetSquareMode( "CONNECTFOUR" );
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GameForm));
			this.button1 = new System.Windows.Forms.Button();
			this.connectFourBoard1 = new BoardControl.ConnectFourBoard();
			this.outputPane = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.redButton = new System.Windows.Forms.RadioButton();
			this.blueButton = new System.Windows.Forms.RadioButton();
			this.startButton = new System.Windows.Forms.Button();
			this.pauseButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.outputTimer = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(240, 584);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.TestButton);
			// 
			// connectFourBoard1
			// 
			this.connectFourBoard1.BoardHeight = 450;
			this.connectFourBoard1.BoardWidth = 525;
			this.connectFourBoard1.HorizontalSquares = 7;
			this.connectFourBoard1.LegendColor = System.Drawing.Color.LightBlue;
			this.connectFourBoard1.LegendWidth = 10;
			this.connectFourBoard1.Location = new System.Drawing.Point(8, 8);
			this.connectFourBoard1.Name = "connectFourBoard1";
			this.connectFourBoard1.ShowLegend = true;
			this.connectFourBoard1.Size = new System.Drawing.Size(544, 472);
			this.connectFourBoard1.SquareHeight = 75;
			this.connectFourBoard1.SquareWidth = 75;
			this.connectFourBoard1.TabIndex = 2;
			this.connectFourBoard1.TestPaint = false;
			this.connectFourBoard1.VerticalSquares = 6;
			// 
			// outputPane
			// 
			this.outputPane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.outputPane.Location = new System.Drawing.Point(8, 480);
			this.outputPane.Name = "outputPane";
			this.outputPane.Size = new System.Drawing.Size(544, 23);
			this.outputPane.TabIndex = 3;
			this.outputPane.Text = "Output Pane";
			this.outputPane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.redButton);
			this.groupBox1.Controls.Add(this.blueButton);
			this.groupBox1.Location = new System.Drawing.Point(8, 512);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Choose Player Color";
			// 
			// redButton
			// 
			this.redButton.AutoCheck = false;
			this.redButton.Checked = true;
			this.redButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.redButton.Location = new System.Drawing.Point(16, 24);
			this.redButton.Name = "redButton";
			this.redButton.TabIndex = 0;
			this.redButton.Text = "Red";
			this.redButton.Click += new System.EventHandler(this.OnRedClick);
			// 
			// blueButton
			// 
			this.blueButton.AutoCheck = false;
			this.blueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.blueButton.Location = new System.Drawing.Point(16, 56);
			this.blueButton.Name = "blueButton";
			this.blueButton.TabIndex = 5;
			this.blueButton.Text = "Blue";
			this.blueButton.Click += new System.EventHandler(this.OnBlueClick);
			// 
			// startButton
			// 
			this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startButton.Location = new System.Drawing.Point(392, 512);
			this.startButton.Name = "startButton";
			this.startButton.TabIndex = 5;
			this.startButton.Text = "Start";
			this.startButton.Click += new System.EventHandler(this.OnStart);
			// 
			// pauseButton
			// 
			this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pauseButton.Location = new System.Drawing.Point(392, 544);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.TabIndex = 1;
			this.pauseButton.Text = "Pause";
			this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.resetButton.Location = new System.Drawing.Point(392, 584);
			this.resetButton.Name = "resetButton";
			this.resetButton.TabIndex = 0;
			this.resetButton.Text = "Reset";
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// outputTimer
			// 
			this.outputTimer.Enabled = true;
			this.outputTimer.Interval = 600;
			this.outputTimer.Tick += new System.EventHandler(this.OnOutputTimer);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 622);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.pauseButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.outputPane);
			this.Controls.Add(this.connectFourBoard1);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Connect Four";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new GameForm());
		}

		private void TestButton(object sender, System.EventArgs e)
		{
			connectFourBoard1.Invalidate( new Rectangle( 20, 20, 20, 20 ), false );
			connectFourBoard1.GetSquare( "AA" ).IsValid = false;

			connectFourBoard1.GetConnectFourGame.SetSquare( "BF", "RED" );
			connectFourBoard1.GetConnectFourGame.SetSquare( "FF", "BLUE" );
			connectFourBoard1.InvalidateSquare( "BF" );
			connectFourBoard1.InvalidateSquare( "FF" );
			connectFourBoard1.TestPaint = true;
	
		}

		private void OnBlueClick(object sender, System.EventArgs e)
		{
			if( blueButton.Checked == true )
			{
				redButton.Checked = true;
				blueButton.Checked = false;
				outputPane.Text = "Player is Red";
				connectFourBoard1.GetConnectFourGame.PlayerIsRed = true;
			}
			else
			{
				redButton.Checked = false;
				blueButton.Checked = true;
				outputPane.Text = "Player is Blue";
				connectFourBoard1.GetConnectFourGame.PlayerIsRed = false;
			}
		}

		private void OnRedClick(object sender, System.EventArgs e)
		{
			if( redButton.Checked == true )
			{
				blueButton.Checked = true;
				redButton.Checked = false;
				outputPane.Text = "Player is Blue";
				connectFourBoard1.GetConnectFourGame.PlayerIsRed = false;
			}
			else 
			{
				redButton.Checked = true;
				blueButton.Checked = false;
				outputPane.Text = "Player is Red";
				connectFourBoard1.GetConnectFourGame.PlayerIsRed = true;
			}
		}

		private void OnStart(object sender, System.EventArgs e)
		{
			if( connectFourBoard1.GetConnectFourGame.IsStarted == true )
			{
				connectFourBoard1.GetConnectFourGame.IsPaused = false;
				this.startButton.Text = "Start";
			}
			else
			{
				connectFourBoard1.GetConnectFourGame.IsStarted = true;
				this.redButton.Enabled = false;
				this.blueButton.Enabled = false;

				/// bit of a hack as the code originally assumed that the player 
				/// would always move first ( Duh!!!! )
				/// 

				connectFourBoard1.SetStarted( true );
			}
		}

		private void resetButton_Click(object sender, System.EventArgs e)
		{
			this.redButton.Enabled = true;
			this.blueButton.Enabled = true;
			connectFourBoard1.Reset();
			connectFourBoard1.GetConnectFourGame.IsStarted = false;
			connectFourBoard1.GetConnectFourGame.IsPaused = false;
		}

		private void OnOutputTimer(object sender, System.EventArgs e)
		{
			if( connectFourBoard1.GetConnectFourGame.NewOutputText == true )
				outputPane.Text = connectFourBoard1.GetConnectFourGame.OutputText;
		}

		private void pauseButton_Click(object sender, System.EventArgs e)
		{
			if( connectFourBoard1.GetConnectFourGame.IsStarted == false )
				return;

			connectFourBoard1.GetConnectFourGame.IsPaused = true;
			this.startButton.Text = "Continue";
		}
	}
}
