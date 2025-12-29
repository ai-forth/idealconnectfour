namespace BoardControl
{
	/// <summary>
	/// Basic game class to hold games-related stuff that will be generic to all the games (will get it's own file later).
	/// </summary>
	public abstract class BasicGame
	{
		/// <summary>
		/// has the game been restarted
		/// </summary>
		public bool bGameRestarted;
		/// <summary>
		/// has the game started
		/// </summary>
		public bool bGameStarted;
		/// <summary>
		/// haqs the game been paused
		/// </summary>
		public bool bGamePaused;
        public BasicGame()
        {
            GameRestarted = false;
            GameStarted = false;
            GamePaused = false;
        }
        public bool GameRestarted
		{
			get
			{
				return bGameRestarted;
			}
			set
			{
				bGameRestarted = value;
			}
		}
		public bool GameStarted 
		{
			get
			{
				return bGameStarted;
			}
			set
			{
				bGameStarted = value;
			}
		}
		public bool GamePaused 
		{
			get
			{
				return bGamePaused;
			}
			set
			{
				bGamePaused = value;
			}
		}
	}
}
