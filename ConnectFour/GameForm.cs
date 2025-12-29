using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectFour
{
    public class GameForm : Form
    {
        #region Designer
        private System.ComponentModel.IContainer components;
        private Button button;
        private BoardControl.ConnectFourBoard connectFourBoard;
        private GroupBox groupBox;
        private RadioButton redButton;
        private RadioButton blueButton;
        private Button startButton;
        private Button pauseButton;
        private Button resetButton;
        private Label outputPane;
        private RadioButton initializeBoard;
        private Timer outputTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.button = new System.Windows.Forms.Button();
            this.connectFourBoard = new BoardControl.ConnectFourBoard();
            this.outputPane = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.redButton = new System.Windows.Forms.RadioButton();
            this.blueButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.outputTimer = new System.Windows.Forms.Timer(this.components);
            this.initializeBoard = new System.Windows.Forms.RadioButton();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(490, 584);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(40, 23);
            this.button.TabIndex = 1;
            this.button.Text = "Test";
            this.button.Click += new System.EventHandler(this.TestButton);
            // 
            // connectFourBoard
            // 
            this.connectFourBoard.BoardHeight = 450;
            this.connectFourBoard.BoardWidth = 525;
            this.connectFourBoard.HorizontalSquares = 7;
            this.connectFourBoard.LegendColor = System.Drawing.Color.LightBlue;
            this.connectFourBoard.LegendWidth = 10;
            this.connectFourBoard.Location = new System.Drawing.Point(8, 8);
            this.connectFourBoard.Name = "connectFourBoard";
            this.connectFourBoard.ShowLegend = true;
            this.connectFourBoard.Size = new System.Drawing.Size(544, 472);
            this.connectFourBoard.SquareHeight = 75;
            this.connectFourBoard.SquareWidth = 75;
            this.connectFourBoard.TabIndex = 2;
            this.connectFourBoard.TestPaint = false;
            this.connectFourBoard.VerticalSquares = 6;
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
            // groupBox
            // 
            this.groupBox.Controls.Add(this.redButton);
            this.groupBox.Controls.Add(this.blueButton);
            this.groupBox.Location = new System.Drawing.Point(8, 512);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 100);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Choose Player Color";
            // 
            // redButton
            // 
            this.redButton.AutoCheck = false;
            this.redButton.Checked = true;
            this.redButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redButton.Location = new System.Drawing.Point(16, 24);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(104, 24);
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
            this.blueButton.Size = new System.Drawing.Size(104, 24);
            this.blueButton.TabIndex = 5;
            this.blueButton.Text = "Blue";
            this.blueButton.Click += new System.EventHandler(this.OnBlueClick);
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(392, 512);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.OnStart);
            // 
            // pauseButton
            // 
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.Location = new System.Drawing.Point(392, 544);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // resetButton
            // 
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Location = new System.Drawing.Point(392, 584);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.ResetButtonClick);
            // 
            // outputTimer
            // 
            this.outputTimer.Enabled = true;
            this.outputTimer.Interval = 600;
            this.outputTimer.Tick += new System.EventHandler(this.OnOutputTimer);
            // 
            // initializeBoard
            // 
            this.initializeBoard.AutoCheck = false;
            this.initializeBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.initializeBoard.Location = new System.Drawing.Point(490, 554);
            this.initializeBoard.Name = "initializeBoard";
            this.initializeBoard.Size = new System.Drawing.Size(65, 24);
            this.initializeBoard.TabIndex = 6;
            this.initializeBoard.Text = "Initialize";
            // 
            // GameForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 622);
            this.Controls.Add(this.initializeBoard);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.outputPane);
            this.Controls.Add(this.connectFourBoard);
            this.Controls.Add(this.button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Connect Four";
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        [STAThread]
        static void Main()
        {
            Application.Run(new GameForm());
        }

        #endregion

        public GameForm()
        {
            InitializeComponent();
            // Was here but certainly old.
            //boardControl.SetSquareMode( "CONNECTFOUR" );
            //if(initializeBoard.Checked)
            //    ConnectFourBoard.InializeBoard();
        }

        #region Click Events
        private void TestButton(object sender, EventArgs e)
        {
            connectFourBoard.Invalidate(new Rectangle(20, 20, 20, 20), false);
            connectFourBoard.GetSquare("AA").IsValid = false;

            connectFourBoard.GetConnectFourGame.SetSquare("BF", "RED");
            connectFourBoard.GetConnectFourGame.SetSquare("FF", "BLUE");
            connectFourBoard.InvalidateSquare("BF");
            connectFourBoard.InvalidateSquare("FF");
            connectFourBoard.TestPaint = true;

        }
        private void OnBlueClick(object sender, EventArgs e)
        {
            if (blueButton.Checked == true)
            {
                redButton.Checked = true;
                blueButton.Checked = false;
                outputPane.Text = "Player is Red";
                connectFourBoard.GetConnectFourGame.PlayerIsRed = true;
            }
            else
            {
                redButton.Checked = false;
                blueButton.Checked = true;
                outputPane.Text = "Player is Blue";
                connectFourBoard.GetConnectFourGame.PlayerIsRed = false;
            }
        }
        private void OnRedClick(object sender, EventArgs e)
        {
            if (redButton.Checked == true)
            {
                blueButton.Checked = true;
                redButton.Checked = false;
                outputPane.Text = "Player is Blue";
                connectFourBoard.GetConnectFourGame.PlayerIsRed = false;
            }
            else
            {
                redButton.Checked = true;
                blueButton.Checked = false;
                outputPane.Text = "Player is Red";
                connectFourBoard.GetConnectFourGame.PlayerIsRed = true;
            }
        }
        private void OnStart(object sender, EventArgs e)
        {
            if (connectFourBoard.GetConnectFourGame.IsStarted == true)
            {
                connectFourBoard.GetConnectFourGame.IsPaused = false;
                startButton.Text = "Start";
            }
            else
            {
                connectFourBoard.GetConnectFourGame.IsStarted = true;
                redButton.Enabled = false;
                blueButton.Enabled = false;
                // A bit of a hack as the code originally assumed that the player would always move first
                connectFourBoard.SetStarted(true);
            }
        }
        private void ResetButtonClick(object sender, EventArgs e)
        {
            redButton.Enabled = true;
            blueButton.Enabled = true;
            connectFourBoard.Reset();
            connectFourBoard.GetConnectFourGame.IsStarted = false;
            connectFourBoard.GetConnectFourGame.IsPaused = false;
        }
        private void OnOutputTimer(object sender, EventArgs e)
        {
            if (connectFourBoard.GetConnectFourGame.NewOutputText == true)
                outputPane.Text = connectFourBoard.GetConnectFourGame.OutputText;
        }
        private void PauseButtonClick(object sender, EventArgs e)
        {
            if (connectFourBoard.GetConnectFourGame.IsStarted == false)
                return;

            connectFourBoard.GetConnectFourGame.IsPaused = true;
            startButton.Text = "Continue";
        }
        #endregion
    }
}
