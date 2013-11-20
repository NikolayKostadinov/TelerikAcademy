namespace Minesweeper
{
    using System;

    class Score
    {
            private string playerName;
            private int points;

            public string PlayerName
            {
                get { return playerName; }
                set { playerName = value; }
            }

            public int Points
            {
                get { return points; }
                set { points = value; }
            }

            public Score() { }

            public Score(string playerName, int points)
            {
                this.PlayerName = playerName;
                this.Points = points;
            }
        }
}
