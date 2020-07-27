using System;
using System.Drawing;
using System.Windows.Forms;
using W1_OX.Properties;

namespace W1_OX
{
    public partial class TicTacToe : Form
    {

        /// <summary>
        /// 
        ///     Variable initialisation.
        ///         Create variables to be used throughout the program.
        ///         Create ease-of-use names for reference.
        /// 
        /// </summary>
        
        private System.Drawing.Color ACTIVE = System.Drawing.Color.MediumSeaGreen;
        private System.Drawing.Color INACTIVE = System.Drawing.Color.IndianRed;

        private Bitmap X = Resources.Xs;
        private Bitmap O = Resources.Os;
        private Bitmap BLANK = Resources.Blank;
        private Bitmap WinnerX = Resources.WinnerXs;
        private Bitmap WinnerO = Resources.WinnerOs;

        private char turn = 'x';
        private char mode = 'p';
        private int p1Score = 0;
        private int p2Score = 0;
        private int compChoice;
        private int eChoice;
        private int cChoice;
        private bool roundOver = false;

        private int LT = 0, MT = 1, RT = 2, // LeftTop, MiddleTop, RightTop
                    LM = 3, MM = 4, RM = 5, // LeftMiddle, MiddleMiddle, RightMiddle
                    LB = 6, MB = 7, RB = 8; // LeftBottom, MiddleBottom, RightBottom

        private char[] tiles = { 'b', 'b', 'b',  // b = blank
                                 'b', 'b', 'b',  // o = naught
                                 'b', 'b', 'b'}; // x = cross

        private System.Windows.Forms.Timer rTimer = new System.Windows.Forms.Timer(); // reset timer
        private System.Windows.Forms.Timer eTimer = new System.Windows.Forms.Timer(); // easy timer
        private System.Windows.Forms.Timer cTimer = new System.Windows.Forms.Timer(); // challenging timer

        /// <summary>
        /// 
        ///     Class Constructor.
        ///         Begin the program.
        /// 
        /// </summary>
        public TicTacToe()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// 
        ///     Event trigger for each tile.
        ///         Check which mode is active.
        ///             If in player mode, run without timers.
        ///             If in easy mode, activate easy timer that chooses a tile for the computer's turn.
        ///             If in challenging mode, activate challenging timer that chooses a tile for the computer's turn.
        ///         Check the round isn't over and that the current tile is empty (blank).
        ///         Check who's turn it was that clicked on the tile.
        ///             If X.
        ///                 Update tile image with X image.
        ///                 Update tile array with an x.
        ///                 Change the turn to O.
        ///                 Check if there was a winner.
        ///                 Check if there was a draw.
        ///             If O.
        ///                 Update tile image with O image.
        ///                 Update tile array with an o.
        ///                 Change the turn to X.
        ///                 Check if there was a winner.
        ///                 Check if there was a draw.
        /// 
        /// </summary>

        /// <summary>
        /// 
        ///     Event trigger for Left Top tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgLeftTop_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[LT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftTop", 'x');
                        UpdateTurn();
                        tiles[LT] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                        
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftTop", 'o');
                        UpdateTurn();
                        tiles[LT] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[LT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftTop", 'x');
                        UpdateTurn();
                        tiles[LT] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftTop", 'o');
                        UpdateTurn();
                        tiles[LT] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[LT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftTop", 'x');
                        UpdateTurn();
                        tiles[LT] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftTop", 'o');
                        UpdateTurn();
                        tiles[LT] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Middle Top tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgMiddleTop_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[MT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleTop", 'x');
                        UpdateTurn();
                        tiles[MT] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleTop", 'o');
                        UpdateTurn();
                        tiles[MT] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[MT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleTop", 'x');
                        UpdateTurn();
                        tiles[MT] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleTop", 'o');
                        UpdateTurn();
                        tiles[MT] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[MT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleTop", 'x');
                        UpdateTurn();
                        tiles[MT] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleTop", 'o');
                        UpdateTurn();
                        tiles[MT] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Right Top tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgRightTop_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[RT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightTop", 'x');
                        UpdateTurn();
                        tiles[RT] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightTop", 'o');
                        UpdateTurn();
                        tiles[RT] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[RT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightTop", 'x');
                        UpdateTurn();
                        tiles[RT] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightTop", 'o');
                        UpdateTurn();
                        tiles[RT] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[RT] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightTop", 'x');
                        UpdateTurn();
                        tiles[RT] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightTop", 'o');
                        UpdateTurn();
                        tiles[RT] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Left Middle tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgLeftMiddle_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[LM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftMiddle", 'x');
                        UpdateTurn();
                        tiles[LM] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftMiddle", 'o');
                        UpdateTurn();
                        tiles[LM] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[LM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftMiddle", 'x');
                        UpdateTurn();
                        tiles[LM] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftMiddle", 'o');
                        UpdateTurn();
                        tiles[LM] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[LM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftMiddle", 'x');
                        UpdateTurn();
                        tiles[LM] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftMiddle", 'o');
                        UpdateTurn();
                        tiles[LM] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Middle Middle tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgMiddleMiddle_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[MM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleMiddle", 'x');
                        UpdateTurn();
                        tiles[MM] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleMiddle", 'o');
                        UpdateTurn();
                        tiles[MM] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[MM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleMiddle", 'x');
                        UpdateTurn();
                        tiles[MM] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleMiddle", 'o');
                        UpdateTurn();
                        tiles[MM] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[MM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleMiddle", 'x');
                        UpdateTurn();
                        tiles[MM] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleMiddle", 'o');
                        UpdateTurn();
                        tiles[MM] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Right Middle tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgRightMiddle_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[RM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightMiddle", 'x');
                        UpdateTurn();
                        tiles[RM] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightMiddle", 'o');
                        UpdateTurn();
                        tiles[RM] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[RM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightMiddle", 'x');
                        UpdateTurn();
                        tiles[RM] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightMiddle", 'o');
                        UpdateTurn();
                        tiles[RM] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[RM] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightMiddle", 'x');
                        UpdateTurn();
                        tiles[RM] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightMiddle", 'o');
                        UpdateTurn();
                        tiles[RM] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Left Bottom tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgLeftBottom_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[LB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftBottom", 'x');
                        UpdateTurn();
                        tiles[LB] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftBottom", 'o');
                        UpdateTurn();
                        tiles[LB] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[LB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftBottom", 'x');
                        UpdateTurn();
                        tiles[LB] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftBottom", 'o');
                        UpdateTurn();
                        tiles[LB] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[LB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("LeftBottom", 'x');
                        UpdateTurn();
                        tiles[LB] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("LeftBottom", 'o');
                        UpdateTurn();
                        tiles[LB] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Middle Bottom tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgMiddleBottom_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[MB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleBottom", 'x');
                        UpdateTurn();
                        tiles[MB] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleBottom", 'o');
                        UpdateTurn();
                        tiles[MB] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if (!roundOver && tiles[MB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleBottom", 'x');
                        UpdateTurn();
                        tiles[MB] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleBottom", 'o');
                        UpdateTurn();
                        tiles[MB] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[MB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("MiddleBottom", 'x');
                        UpdateTurn();
                        tiles[MB] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("MiddleBottom", 'o');
                        UpdateTurn();
                        tiles[MB] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Event trigger for Right Bottom tile.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void imgRightBottom_Click(object sender, EventArgs e)
        {
            if (mode == 'p')
            {
                if (!roundOver && tiles[RB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightBottom", 'x');
                        UpdateTurn();
                        tiles[RB] = 'x';
                        CheckWinnerX();
                        CheckDraw();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightBottom", 'o');
                        UpdateTurn();
                        tiles[RB] = 'o';
                        CheckWinnerO();
                        CheckDraw();
                    }
                }
            }
            else if (mode == 'e')
            {
                if(!roundOver && tiles[RB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightBottom", 'x');
                        UpdateTurn();
                        tiles[RB] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        eTimer.Tick += new EventHandler(ComputerChoiceEasy);
                        eTimer.Interval = 1000;
                        eTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightBottom", 'o');
                        UpdateTurn();
                        tiles[RB] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
                else if (!roundOver)
                {
                    BeginEasy();
                }
            }
            else if (mode == 'c')
            {
                if (!roundOver && tiles[RB] == 'b')
                {
                    if (turn == 'x')
                    {
                        UpdateTile("RightBottom", 'x');
                        UpdateTurn();
                        tiles[RB] = 'x';
                        CheckWinnerX();
                        CheckDraw();

                        DeactivateTiles();

                        cTimer.Tick += new EventHandler(ComputerChoiceChallenging);
                        cTimer.Interval = 1000;
                        cTimer.Start();
                    }
                    else if (turn == 'o')
                    {
                        UpdateTile("RightBottom", 'o');
                        UpdateTurn();
                        tiles[RB] = 'o';
                        CheckWinnerO();
                        CheckDraw();

                        ActivateTiles();
                    }
                }
            }
        }

        /// <summary>
        /// 
        ///     Clear all tiles on the board.
        ///         Set each tile array value to blank.
        ///         Set each tile image to blank.
        /// 
        /// </summary>
        private void ClearTiles()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = 'b';
            }

            imgLeftTop.Image = imgMiddleTop.Image = imgRightTop.Image =
            imgLeftMiddle.Image = imgMiddleMiddle.Image = imgRightMiddle.Image =
            imgLeftBottom.Image = imgMiddleBottom.Image = imgRightBottom.Image = BLANK;
        }

        /// <summary>
        /// 
        ///     Event trigger for each mode button.
        ///         Set the mode.
        ///         Set the active button.
        ///         Start the game.
        ///         
        /// 
        /// </summary>

        /// <summary>
        /// 
        ///     Event trigger for easy mode button.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void btnEasy_Click(object sender, EventArgs e)
        {
            mode = 'e';
            ActivateButton("Easy");
            Start();

        }

        /// <summary>
        /// 
        ///     Event trigger for challenging mode button.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void btnChallenging_Click(object sender, EventArgs e)
        {
            mode = 'c';
            ActivateButton("Challenging");
            Start();
        }

        /// <summary>
        /// 
        ///     Event trigger for player mode button.
        /// 
        /// </summary>
        /// <param name="sender"> TicTacToe game object. </param>
        /// <param name="e"></param>
        private void btnPlayer_Click(object sender, EventArgs e)
        {
            mode = 'p';
            ActivateButton("Player");
            Start();
        }

        /// <summary>
        /// 
        ///     Visually activate a button.
        ///         Check active mode.
        ///         Update background colours to active/inactive.
        /// 
        /// </summary>
        /// <param name="button"> Button mode name. </param>
        private void ActivateButton(string button)
        {
            if (button == "Easy")
            {
                btnEasy.BackColor = ACTIVE;
                btnChallenging.BackColor = INACTIVE;
                btnPlayer.BackColor = INACTIVE;
            }
            else if (button == "Challenging")
            {
                btnEasy.BackColor = INACTIVE;
                btnChallenging.BackColor = ACTIVE;
                btnPlayer.BackColor = INACTIVE;
            }
            else if (button == "Impossible")
            {
                btnEasy.BackColor = INACTIVE;
                btnChallenging.BackColor = INACTIVE;
                btnPlayer.BackColor = INACTIVE;
            }
            else if (button == "Player")
            {
                btnEasy.BackColor = INACTIVE;
                btnChallenging.BackColor = INACTIVE;
                btnPlayer.BackColor = ACTIVE;
            }
        }

        /// <summary>
        /// 
        ///     Flip turn.
        ///         If X, set to O.
        ///         If O, set to X.
        /// 
        /// </summary>
        private void UpdateTurn()
        {
            if (turn == 'x')
            {
                turn = 'o';
            }
            else if (turn == 'o')
            {
                turn = 'x';
            }
        }

        /// <summary>
        /// 
        ///     Visually update each tile image.
        ///         Check which tile to change.
        ///             If X, set X image.
        ///             If O, set O image.
        /// 
        /// </summary>
        /// <param name="tile"> Name of the tile to update. </param>
        /// <param name="type"> Type of tile to update to (X/O). </param>
        private void UpdateTile(string tile, char type)
        {
            if (tile == "LeftTop")
            {
                if (type == 'x')
                {
                    imgLeftTop.Image = X;
                }
                else if (type == 'o')
                {
                    imgLeftTop.Image = O;
                }
            }
            else if (tile == "MiddleTop")
            {
                if (type == 'x')
                {
                    imgMiddleTop.Image = X;
                }
                else if (type == 'o')
                {
                    imgMiddleTop.Image = O;
                }
            }
            else if (tile == "RightTop")
            {
                if (type == 'x')
                {
                    imgRightTop.Image = X;
                }
                else if (type == 'o')
                {
                    imgRightTop.Image = O;
                }
            }
            else if (tile == "LeftMiddle")
            {
                if (type == 'x')
                {
                    imgLeftMiddle.Image = X;
                }
                else if (type == 'o')
                {
                    imgLeftMiddle.Image = O;
                }
            }
            else if (tile == "MiddleMiddle")
            {
                if (type == 'x')
                {
                    imgMiddleMiddle.Image = X;
                }
                else if (type == 'o')
                {
                    imgMiddleMiddle.Image = O;
                }
            }
            else if (tile == "RightMiddle")
            {
                if (type == 'x')
                {
                    imgRightMiddle.Image = X;
                }
                else if (type == 'o')
                {
                    imgRightMiddle.Image = O;
                }
            }
            else if (tile == "LeftBottom")
            {
                if (type == 'x')
                {
                    imgLeftBottom.Image = X;
                }
                else if (type == 'o')
                {
                    imgLeftBottom.Image = O;
                }
            }
            else if (tile == "MiddleBottom")
            {
                if (type == 'x')
                {
                    imgMiddleBottom.Image = X;
                }
                else if (type == 'o')
                {
                    imgMiddleBottom.Image = O;
                }
            }
            else if (tile == "RightBottom")
            {
                if (type == 'x')
                {
                    imgRightBottom.Image = X;
                }
                else if (type == 'o')
                {
                    imgRightBottom.Image = O;
                }
            }
        }

        /// <summary>
        /// 
        ///     Reset the board.
        ///         Set all tiles to blank.
        ///         Set the turn back to X.
        ///         Allow tiles to be selected again.
        /// 
        /// </summary>
        private void Reset()
        {
            ClearTiles();
            roundOver = false;
            turn = 'x';
            ActivateTiles();
        }

        /// <summary>
        /// 
        ///     Begin the game.
        ///         Check for mode.
        ///         Activate relative button.
        /// 
        /// </summary>
        private void Start()
        {
            Reset();
            if (mode == 'e')
            {
                ActivateButton("Easy");
            }
            else if (mode == 'c')
            {
                ActivateButton("Challenging");
            }
            else if (mode == 'p')
            {
                ActivateButton("Player");
            }
        }

        /// <summary>
        /// 
        ///     Easy mode tile selector.
        ///         Check if the round isn't over and that it is O's (computer's) turn.
        ///         Run tile selector logic.
        ///         Check which tile was chosen
        ///         Invoke specified tile.
        /// 
        /// </summary>
        private void BeginEasy()
        {
            if (!roundOver && turn == 'o')
            {
                compChoice = CompChoiceEasy();

                if (compChoice == LT)
                {
                    imgLeftTop_Click(imgLeftTop, null);
                }
                else if (compChoice == MT)
                {
                    imgMiddleTop_Click(imgMiddleTop, null);
                }
                else if (compChoice == RT)
                {
                    imgRightTop_Click(imgRightTop, null);
                }
                else if (compChoice == LM)
                {
                   imgLeftMiddle_Click(imgLeftMiddle, null);
                }
                else if (compChoice == MM)
                {
                    imgMiddleMiddle_Click(imgMiddleMiddle, null);
                }
                else if (compChoice == RM)
                {
                    imgRightMiddle_Click(imgRightMiddle, null);
                }
                else if (compChoice == LB)
                {
                    imgLeftBottom_Click(imgLeftBottom, null);
                }
                else if (compChoice == MB)
                {
                    imgMiddleBottom_Click(imgMiddleBottom, null);
                }
                else if (compChoice == RB)
                {
                    imgRightBottom_Click(imgRightBottom, null);
                }
            }
        }

        /// <summary>
        /// 
        ///     Challenging mode tile selector.
        ///         Check if the round isn't over and that it is O's (computer's) turn.
        ///         Run tile selector logic.
        ///         Check which tile was chosen
        ///         Invoke specified tile.
        /// 
        /// </summary>
        private void BeginChallenging()
        {
            if (!roundOver && turn == 'o')
            {
                compChoice = CompChoiceChallenging();

                if (compChoice == LT)
                {
                    imgLeftTop_Click(imgLeftTop, null);
                }
                else if (compChoice == MT)
                {
                    imgMiddleTop_Click(imgMiddleTop, null);
                }
                else if (compChoice == RT)
                {
                    imgRightTop_Click(imgRightTop, null);
                }
                else if (compChoice == LM)
                {
                    imgLeftMiddle_Click(imgLeftMiddle, null);
                }
                else if (compChoice == MM)
                {
                    imgMiddleMiddle_Click(imgMiddleMiddle, null);
                }
                else if (compChoice == RM)
                {
                    imgRightMiddle_Click(imgRightMiddle, null);
                }
                else if (compChoice == LB)
                {
                    imgLeftBottom_Click(imgLeftBottom, null);
                }
                else if (compChoice == MB)
                {
                    imgMiddleBottom_Click(imgMiddleBottom, null);
                }
                else if (compChoice == RB)
                {
                    imgRightBottom_Click(imgRightBottom, null);
                }
            }
        }

        /// <summary>
        /// 
        ///     Easy mode tile selector logic.
        ///         Randomly choose a tile.
        /// 
        /// </summary>
        /// <returns> Returns the integer for the position in the tiles array. </returns>
        private int CompChoiceEasy()
        {
            eChoice = RandomTile();

            return eChoice;
        }

        /// <summary>
        /// 
        ///     Challenging mode tile selector logic.
        ///         Check where previous tile was placed.
        ///         Try to win by creating a line of Os.
        ///         If there were no previous tiles, randomly place one to start off.
        ///         
        ///         b = blank tile.
        ///         o = o tile.
        ///         x = x tile.
        ///         - = other tile positions (visual purposes).
        ///         
        ///         Example:
        ///         // - - -
        ///         // - - -
        ///         // b o o
        ///         
        ///         This checks if the bottom left tile is blank whilst
        ///         the bottom middle and bottom right tiles are Os. This
        ///         will place an O at the bottom left tile.
        /// 
        /// </summary>
        /// <returns> Returns the integer for the position in the tiles array. </returns>
        private int CompChoiceChallenging()
        {

            if (isFirstTile())
            {
                cChoice = RandomTile();

                return cChoice;
            }
            else
            {
                if (cChoice == LT)
                {
                    // o - -
                    // - - -
                    // - - -

                    if (tiles[MT] == 'o' && tiles[RT] == 'b')
                    {
                        // o o b
                        // - - -
                        // - - -

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'o' && tiles[MT] == 'b')
                    {
                        // o b o
                        // - - -
                        // - - -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[RB] == 'b')
                    {
                        // o - -
                        // - o -
                        // - - b

                        cChoice = RB;

                        return cChoice;
                    }
                    else if (tiles[RB] == 'o' && tiles[MM] == 'b')
                    {
                        // o - -
                        // - b -
                        // - - o

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'o' && tiles[LB] == 'b')
                    {
                        // o - -
                        // o - -
                        // b - -

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'o' && tiles[LM] == 'b')
                    {
                        // o - -
                        // b - -
                        // o - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else if (tiles[MT] == 'b' && tiles[RT] == 'b')
                    {
                        // o b b
                        // - - -
                        // - - -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[RB] == 'b')
                    {
                        // o - -
                        // - b -
                        // - - b

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'b' && tiles[LB] == 'b')
                    {
                        // o - -
                        // b - -
                        // b - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == MT)
                {
                    // - o -
                    // - - -
                    // - - -

                    if (tiles[LT] == 'o' && tiles[RT] == 'b')
                    {
                        // o o b
                        // - - -
                        // - - -

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'o' && tiles[LT] == 'b')
                    {
                        // b o o
                        // - - -
                        // - - -

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[MB] == 'b')
                    {
                        // - o -
                        // - o -
                        // - b -

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[MB] == 'o' && tiles[MM] == 'b')
                    {
                        // - o -
                        // - b -
                        // - o -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'b' && tiles[RT] == 'b')
                    {
                        // b o b
                        // - - -
                        // - - -

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[MB] == 'b')
                    {
                        // - o -
                        // - b -
                        // - b -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'b' && tiles[LT] == 'b')
                    {
                        // b o b
                        // - - -
                        // - - -

                        cChoice = RT;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == RT)
                {
                    // - - o
                    // - - -
                    // - - -

                    if (tiles[MT] == 'o' && tiles[LT] == 'b')
                    {
                        // b o o
                        // - - -
                        // - - -

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'o' && tiles[MT] == 'b')
                    {
                        // o b o
                        // - - -
                        // - - -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[LB] == 'b')
                    {
                        // - - o
                        // - o -
                        // b - -

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'o' && tiles[MM] == 'b')
                    {
                        // - - o
                        // - b -
                        // o - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'o' && tiles[RB] == 'b')
                    {
                        // - - o
                        // - - o
                        // - - b

                        cChoice = RB;

                        return cChoice;
                    }
                    else if (tiles[RB] == 'o' && tiles[RM] == 'b')
                    {
                        // - - o
                        // - - b
                        // - - o

                        cChoice = RM;

                        return cChoice;
                    }
                    else if (tiles[MT] == 'b' && tiles[LT] == 'b')
                    {
                        // b b o
                        // - - -
                        // - - -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[LB] == 'b')
                    {
                        // - - o
                        // - b -
                        // b - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'b' && tiles[RB] == 'b')
                    {
                        // - - o
                        // - - b
                        // - - b

                        cChoice = RM;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == LM)
                {
                    // - - -
                    // o - -
                    // - - -

                    if (tiles[LB] == 'o' && tiles[LT] == 'b')
                    {
                        // b - -
                        // o - -
                        // o - -

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'o' && tiles[LB] == 'b')
                    {
                        // o - -
                        // o - -
                        // b - -

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[RM] == 'b')
                    {
                        // - - -
                        // o o b
                        // - - -

                        cChoice = RM;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'o' && tiles[MM] == 'b')
                    {
                        // - - -
                        // o b o
                        // - - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'b' && tiles[LB] == 'b')
                    {
                        // b - -
                        // o - -
                        // b - -

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[RM] == 'b')
                    {
                        // - - -
                        // o b b
                        // - - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'b' && tiles[LT] == 'b')
                    {
                        // b - -
                        // o - -
                        // b - -

                        cChoice = LB;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == MM)
                {
                    // - - -
                    // - o -
                    // - - -

                    if (tiles[RB] == 'o' && tiles[LT] == 'b')
                    {
                        // b - -
                        // - o -
                        // - - o

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'o' && tiles[RB] == 'b')
                    {
                        // o - -
                        // - o -
                        // - - b

                        cChoice = RB;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'o' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - o -
                        // o - -

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'o' && tiles[LB] == 'b')
                    {
                        // - - o
                        // - o -
                        // b - -

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[MT] == 'o' && tiles[MB] == 'b')
                    {
                        // - o -
                        // - o -
                        // - b -

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[MB] == 'o' && tiles[MT] == 'b')
                    {
                        // - b -
                        // - o -
                        // - o -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'o' && tiles[LM] == 'b')
                    {
                        // - - -
                        // b o o
                        // - - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'o' && tiles[RM] == 'b')
                    {
                        // - - -
                        // o o b
                        // - - -

                        cChoice = RM;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'b' && tiles[RB] == 'b')
                    {
                        // b - -
                        // - o -
                        // - - b

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[MT] == 'b' && tiles[MB] == 'b')
                    {
                        // - b -
                        // - o -
                        // - b -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'b' && tiles[LB] == 'b')
                    {
                        // - - b
                        // - o -
                        // b - -

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'b' && tiles[RM] == 'b')
                    {
                        // - - -
                        // b o b
                        // - - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'b' && tiles[LM] == 'b')
                    {
                        // - - -
                        // b o b
                        // - - -

                        cChoice = RM;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'b' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - o -
                        // b - -

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[MB] == 'b' && tiles[MT] == 'b')
                    {
                        // - b -
                        // - o -
                        // - b -

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[RB] == 'b' && tiles[LT] == 'b')
                    {
                        // b - -
                        // - o -
                        // - - b

                        cChoice = RB;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == RM)
                {
                    // - - -
                    // - - o
                    // - - -

                    if (tiles[RB] == 'o' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - - o
                        // - - o

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'o' && tiles[RB] == 'b')
                    {
                        // - - o
                        // - - o
                        // - - b

                        cChoice = RB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[LM] == 'b')
                    {
                        // - - -
                        // b o o
                        // - - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'o' && tiles[MM] == 'b')
                    {
                        // - - -
                        // o b o
                        // - - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'b' && tiles[RB] == 'b')
                    {
                        // - - b
                        // - - o
                        // - - b

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[LM] == 'b')
                    {
                        // - - -
                        // b b o
                        // - - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RB] == 'b' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - - o
                        // - - b

                        cChoice = RB;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == LB)
                {
                    // - - -
                    // - - -
                    // o - -

                    if (tiles[MB] == 'o' && tiles[RB] == 'b')
                    {
                        // - - -
                        // - - -
                        // o o b

                        cChoice = RB;

                        return cChoice;
                    }
                    else if (tiles[RB] == 'o' && tiles[MB] == 'b')
                    {
                        // - - -
                        // - - -
                        // o b o

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - o -
                        // o - -

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'o' && tiles[MM] == 'b')
                    {
                        // - - o
                        // - b -
                        // o - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'o' && tiles[LT] == 'b')
                    {
                        // b - -
                        // o - -
                        // o - -

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'o' && tiles[LM] == 'b')
                    {
                        // o - -
                        // b - -
                        // o - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else if (tiles[MB] == 'b' && tiles[RB] == 'b')
                    {
                        // - - -
                        // - - -
                        // o b b

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - b -
                        // o - -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LM] == 'b' && tiles[LT] == 'b')
                    {
                        // b - -
                        // b - -
                        // o - -

                        cChoice = LM;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == MB)
                {
                    // - - -
                    // - - -
                    // - o -

                    if (tiles[RB] == 'o' && tiles[LB] == 'b')
                    {
                        // - - -
                        // - - -
                        // b o o

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'o' && tiles[RB] == 'b')
                    {
                        // - - -
                        // - - -
                        // o o b

                        cChoice = RB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[MT] == 'b')
                    {
                        // - b -
                        // - o -
                        // - o -

                        cChoice = MT;

                        return cChoice;
                    }
                    else if (tiles[MT] == 'o' && tiles[MM] == 'b')
                    {
                        // - o -
                        // - b -
                        // - o -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'b' && tiles[RB] == 'b')
                    {
                        // - - -
                        // - - -
                        // b o b

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[MT] == 'b')
                    {
                        // - b -
                        // - b -
                        // - o -

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RB] == 'b' && tiles[LB] == 'b')
                    {
                        // - - -
                        // - - -
                        // b o b

                        cChoice = RB;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
                if (cChoice == RB)
                {
                    // - - -
                    // - - -
                    // - - o

                    if (tiles[MB] == 'o' && tiles[LB] == 'b')
                    {
                        // - - -
                        // - - -
                        // b o o

                        cChoice = LB;

                        return cChoice;
                    }
                    else if (tiles[LB] == 'o' && tiles[MB] == 'b')
                    {
                        // - - -
                        // - - -
                        // o b o

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'o' && tiles[LT] == 'b')
                    {
                        // b - -
                        // - o -
                        // - - o

                        cChoice = LT;

                        return cChoice;
                    }
                    else if (tiles[LT] == 'o' && tiles[MM] == 'b')
                    {
                        // o - -
                        // - b -
                        // - - o

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'o' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - - o
                        // - - o

                        cChoice = RT;

                        return cChoice;
                    }
                    else if (tiles[RT] == 'o' && tiles[RM] == 'b')
                    {
                        // - - o
                        // - - b
                        // - - o

                        cChoice = RM;

                        return cChoice;
                    }
                    else if (tiles[MB] == 'b' && tiles[LB] == 'b')
                    {
                        // - - -
                        // - - -
                        // b b o

                        cChoice = MB;

                        return cChoice;
                    }
                    else if (tiles[MM] == 'b' && tiles[LT] == 'b')
                    {
                        // b - -
                        // - b -
                        // - - o

                        cChoice = MM;

                        return cChoice;
                    }
                    else if (tiles[RM] == 'b' && tiles[RT] == 'b')
                    {
                        // - - b
                        // - - b
                        // - - o

                        cChoice = RM;

                        return cChoice;
                    }
                    else
                    {
                        cChoice = RandomTile();

                        return cChoice;
                    }
                }
            }

            return cChoice;
        }

        /// <summary>
        /// 
        ///     Check if no tiles have been already placed as an O.
        ///         Run through tiles array.
        ///         Return false if an O is present.
        /// 
        /// </summary>
        /// <returns> Return false if O is present, true if not. </returns>
        private bool isFirstTile()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] == 'o')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        ///     Random tile selector.
        ///         Randomly generate a number.
        ///         Number corresponds to position in the tiles array.
        /// 
        /// </summary>
        /// <returns> Returns an integer for the tiles array. </returns>
        private int RandomTile()
        {
            var ran = new Random();

            return ran.Next(LT, RB + 1);
        }

        /// <summary>
        /// 
        ///     Check if X has won.
        ///         Go through each possible winning combination.
        ///         If X has won, set their X tiles to the winning tiles image.
        ///         Update their score.
        ///         Start round cleanup timer.
        /// 
        /// </summary>
        private void CheckWinnerX()
        {
            if (tiles[LT] == 'x' && tiles[MT] == 'x' && tiles[RT] == 'x')
            {
                // x x x
                // - - -
                // - - -

                imgLeftTop.Image = WinnerX;
                imgMiddleTop.Image = WinnerX;
                imgRightTop.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LM] == 'x' && tiles[MM] == 'x' && tiles[RM] == 'x')
            {
                // - - -
                // x x x
                // - - -

                imgLeftMiddle.Image = WinnerX;
                imgMiddleMiddle.Image = WinnerX;
                imgRightMiddle.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LB] == 'x' && tiles[MB] == 'x' && tiles[RB] == 'x')
            {
                // - - -
                // - - -
                // x x x

                imgLeftBottom.Image = WinnerX;
                imgMiddleBottom.Image = WinnerX;
                imgRightBottom.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LT] == 'x' && tiles[LM] == 'x' && tiles[LB] == 'x')
            {
                // x - -
                // x - -
                // x - -

                imgLeftTop.Image = WinnerX;
                imgLeftMiddle.Image = WinnerX;
                imgLeftBottom.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[MT] == 'x' && tiles[MM] == 'x' && tiles[MB] == 'x')
            {
                // - x -
                // - x -
                // - x -

                imgMiddleTop.Image = WinnerX;
                imgMiddleMiddle.Image = WinnerX;
                imgMiddleBottom.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[RT] == 'x' && tiles[RM] == 'x' && tiles[RB] == 'x')
            {
                // - - x
                // - - x
                // - - x

                imgRightTop.Image = WinnerX;
                imgRightMiddle.Image = WinnerX;
                imgRightBottom.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LT] == 'x' && tiles[MM] == 'x' && tiles[RB] == 'x')
            {
                // x - -
                // - x -
                // - - x

                imgLeftTop.Image = WinnerX;
                imgMiddleMiddle.Image = WinnerX;
                imgRightBottom.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[RT] == 'x' && tiles[MM] == 'x' && tiles[LB] == 'x')
            {
                // - - x
                // - x -
                // x - -

                imgRightTop.Image = WinnerX;
                imgMiddleMiddle.Image = WinnerX;
                imgLeftBottom.Image = WinnerX;

                p1Score++;
                lblP1Score.Text = Convert.ToString(p1Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
        }

        /// <summary>
        /// 
        ///     Check if O has won.
        ///         Go through each possible winning combination.
        ///         If O has won, set their O tiles to the winning tiles image.
        ///         Update their score.
        ///         Start round cleanup timer.
        /// 
        /// </summary>
        private void CheckWinnerO()
        {
            if (tiles[LT] == 'o' && tiles[MT] == 'o' && tiles[RT] == 'o')
            {
                // o o o
                // - - -
                // - - -

                imgLeftTop.Image = WinnerO;
                imgMiddleTop.Image = WinnerO;
                imgRightTop.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LM] == 'o' && tiles[MM] == 'o' && tiles[RM] == 'o')
            {
                // - - -
                // o o o
                // - - -

                imgLeftMiddle.Image = WinnerO;
                imgMiddleMiddle.Image = WinnerO;
                imgRightMiddle.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LB] == 'o' && tiles[MB] == 'o' && tiles[RB] == 'o')
            {
                // - - -
                // - - -
                // o o o

                imgLeftBottom.Image = WinnerO;
                imgMiddleBottom.Image = WinnerO;
                imgRightBottom.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LT] == 'o' && tiles[LM] == 'o' && tiles[LB] == 'o')
            {
                // o - -
                // o - -
                // o - -

                imgLeftTop.Image = WinnerO;
                imgLeftMiddle.Image = WinnerO;
                imgLeftBottom.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[MT] == 'o' && tiles[MM] == 'o' && tiles[MB] == 'o')
            {
                // - o -
                // - o -
                // - o -

                imgMiddleTop.Image = WinnerO;
                imgMiddleMiddle.Image = WinnerO;
                imgMiddleBottom.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[RT] == 'o' && tiles[RM] == 'o' && tiles[RB] == 'o')
            {
                // - - o
                // - - o
                // - - o

                imgRightTop.Image = WinnerO;
                imgRightMiddle.Image = WinnerO;
                imgRightBottom.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[LT] == 'o' && tiles[MM] == 'o' && tiles[RB] == 'o')
            {
                // o - -
                // - o -
                // - - o

                imgLeftTop.Image = WinnerO;
                imgMiddleMiddle.Image = WinnerO;
                imgRightBottom.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
            else if (tiles[RT] == 'o' && tiles[MM] == 'o' && tiles[LB] == 'o')
            {
                // - - o
                // - o -
                // o - -

                imgRightTop.Image = WinnerO;
                imgMiddleMiddle.Image = WinnerO;
                imgLeftBottom.Image = WinnerO;

                p2Score++;
                lblP2Score.Text = Convert.ToString(p2Score);
                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
        }

        /// <summary>
        /// 
        ///     Check if there is a draw..
        ///         Go through each tile and check if they aren't blank.
        ///         If all tiles are full and not blank, draw has been reached.
        ///         Start round cleanup timer.
        /// 
        /// </summary>
        private void CheckDraw()
        {
            if (tiles[LT] != 'b' && tiles[MT] != 'b' && tiles[RT] != 'b' &&
                tiles[LM] != 'b' && tiles[MM] != 'b' && tiles[RM] != 'b' &&
                tiles[LB] != 'b' && tiles[MB] != 'b' && tiles[RB] != 'b')
            {
                // - - -
                // - - -
                // - - -

                roundOver = true;

                rTimer.Tick += new EventHandler(NextRoundCleanUp);
                rTimer.Interval = 1000;
                rTimer.Start();

            }
        }

        /// <summary>
        /// 
        ///     Disable tiles.
        ///         Prevent player from choosing computer's tile while it decides.
        /// 
        /// </summary>
        private void DeactivateTiles()
        {
            imgLeftTop.Enabled = imgMiddleTop.Enabled = imgRightTop.Enabled =
            imgLeftMiddle.Enabled = imgMiddleMiddle.Enabled = imgRightMiddle.Enabled =
            imgLeftBottom.Enabled = imgMiddleBottom.Enabled = imgRightBottom.Enabled = false;
        }

        /// <summary>
        /// 
        ///     Enable tiles.
        ///         Allow player to choose a tile.
        /// 
        /// </summary>
        private void ActivateTiles()
        {
            imgLeftTop.Enabled = imgMiddleTop.Enabled = imgRightTop.Enabled =
            imgLeftMiddle.Enabled = imgMiddleMiddle.Enabled = imgRightMiddle.Enabled =
            imgLeftBottom.Enabled = imgMiddleBottom.Enabled = imgRightBottom.Enabled = true;
        }

        /// <summary>
        /// 
        ///     Round cleanup event.
        ///         Stop the timer.
        ///         Reset the game.
        /// 
        /// </summary>
        /// <param name="myObject"> TicTacToe game object. </param>
        /// <param name="myEventArgs"></param>
        private void NextRoundCleanUp(Object myObject, EventArgs myEventArgs)
        {
            rTimer.Stop();
            Reset();
        }

        /// <summary>
        /// 
        ///     Easy mode choice event.
        ///         Stop the timer.
        ///         Start next round of easy mode.
        /// 
        /// </summary>
        /// <param name="myObject"> TicTacToe game object. </param>
        /// <param name="myEventArgs"></param>
        private void ComputerChoiceEasy(Object myObject, EventArgs myEventArgs)
        {
            eTimer.Stop();
            BeginEasy();
        }

        /// <summary>
        /// 
        ///     Challenging mode choice event.
        ///         Stop the timer.
        ///         Start next round of challenging mode.
        /// 
        /// </summary>
        /// <param name="myObject"> TicTacToe game object. </param>
        /// <param name="myEventArgs"></param>
        private void ComputerChoiceChallenging(Object myObject, EventArgs myEventArgs)
        {
            cTimer.Stop();
            BeginChallenging();
        }
    }
}
