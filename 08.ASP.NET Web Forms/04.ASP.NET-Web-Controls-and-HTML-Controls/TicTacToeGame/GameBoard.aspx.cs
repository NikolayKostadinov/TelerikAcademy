using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace TicTacToeGame
{
    public partial class GameBoard : System.Web.UI.Page
    {
        private string gamerSign = "X";
        private string botSign = "O";
        private string[,] gameBoard = null;
        private static Random randomGenerator = new Random();

        public GameBoard() 
        {
            if (gameBoard == null)
            {
                this.gameBoard = new string[3, 3];
            }
        }

        public void Button_Click(object sender, EventArgs e)
        {
            GetButtons();
            if (gameBoard == null)
            {
                gameBoard = new string[3, 3];
            }

            SetSimbol(sender, gamerSign);
            MakeReaction(sender);
            GenerateNextMove();
        }
  
        private void GetButtons()
        {
            var buttons = this.Buttons.FindControlsOfType<Button>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    this.gameBoard[row, col] = buttons[row * 3 + col].Text.Trim();
                }
            }
        }

        private void SetSimbol(object sender, string simbol)
        {
            var senderButton = (sender as Button).CommandArgument;
            var buttonId = int.Parse(senderButton);
            int row = buttonId / 3;
            int col = buttonId - 3 * row;
            if (string.IsNullOrEmpty((sender as Button).Text.Trim()))
            {
                (sender as Button).Text = simbol;
            }
            GetButtons();
            gameBoard[row, col] = simbol;
        }
  
        private void MakeReaction(object sender)
        {
            (sender as Button).Enabled = false;
            string winner;
            if (IsWinner(out winner)) 
            {
                SetButtonsState(false);
                gameBoard = null;
                this.LabelMessage.Text = winner;
            }
        }
  
        /// <summary>
        /// Sets the state of the buttons.
        /// </summary>
        /// <param name="p">The p.</param>
        private void SetButtonsState(bool state)
        {
            var buttons = this.Buttons.FindControlsOfType<Button>();
            foreach (var button in buttons)
            {
                button.Enabled = state;
            }
        }

        private void GenerateNextMove()
        {
            if (gameBoard == null)
            {
                return;
            }
            int nextSelectionId = randomGenerator.Next(0, 8);
            var buttons = this.Buttons.FindControlsOfType<Button>();

            if (string.IsNullOrEmpty(buttons[nextSelectionId].Text.Trim()))
            {
                SetSimbol(buttons[nextSelectionId], botSign);
                MakeReaction(buttons[nextSelectionId]);
                return;
            }
            else
            {
                int ix = 0;
                while (ix < 9) 
                {
                    if (nextSelectionId == 8)
                    {
                        nextSelectionId = 0;
                    }
                    ix++;
                    nextSelectionId++;
                    if (string.IsNullOrEmpty(buttons[nextSelectionId].Text.Trim()))
                    {
                        SetSimbol(buttons[nextSelectionId], botSign);
                        MakeReaction(buttons[nextSelectionId]);
                        return;
                    }
                }
            }
        }
  
        /// <summary>
        /// Determines whether the specified winner is winner.
        /// </summary>
        /// <param name="winner">The winner.</param>
        /// <returns></returns>
        private bool IsWinner(out string winner)
        {
            winner = null;
            
            for (int index = 0; index < 3; index++)
            {
                if ((!(string.IsNullOrEmpty(gameBoard[index, 0])) && gameBoard[index, 0] == gameBoard[index, 1] && gameBoard[index, 0] == gameBoard[index, 2]))
                {
                    winner = (gameBoard[index, 0] == gamerSign) ? "You win!" : "Computer wins";
                    return true;
                }

                if (!(string.IsNullOrEmpty(gameBoard[0, index])) && gameBoard[0, index] == gameBoard[1, index] && gameBoard[0, index] == gameBoard[2, index]) 
                {
                    winner = (gameBoard[0, index] == gamerSign) ? "You win!" : "Computer wins";
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(gameBoard[0, 0]) && gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[0, 0] == gameBoard[2, 2])
            {
                winner = (gameBoard[0, 0] == gamerSign) ? "You win!" : "Computer wins";
                return true;
            }

            if (!string.IsNullOrEmpty(gameBoard[2, 0]) && gameBoard[2, 0] == gameBoard[1, 1] && gameBoard[2, 0] == gameBoard[0, 2])
            {
                winner = (gameBoard[2, 0] == gamerSign) ? "You win!" : "Computer wins";
                return true;
            }
            return false;
        }

        public void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gameBoard == null)
            {
                if ((sender as RadioButton).ID == this.RadioButtonX.ID)
                {
                    gamerSign = "X";
                    botSign = "O";
                }
                else
                {
                    gamerSign = "O";
                    botSign = "X";
                }
            }
            else 
            {
                this.LabelMessage.Text = "You cannot change your sign until the end of game";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (gameBoard == null)
            {
                if (this.RadioButtonX.Checked)
                {
                    gamerSign = "X";
                    botSign = "O";
                }
                else
                {
                    gamerSign = "O";
                    botSign = "X";
                }
            }
          
            if (this.gameBoard!=null)
            {
                StringBuilder text = new StringBuilder();
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        text.Append(this.gameBoard[row, col] + " ");
                    }
                    text.Append("\r\n");
                }

                this.LabelMessage.Text=text.ToString();
            }
        }

        protected void ButtonNewGame_Click(object sender, EventArgs e)
        {
            gameBoard = null;
            var buttons = this.Buttons.FindControlsOfType<Button>();
            foreach (var button in buttons) 
            {
                button.Text = " ";
                button.Enabled = true;
                this.LabelMessage.Text = "";
            }
        }
    }
}