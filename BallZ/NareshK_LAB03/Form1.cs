//*************************************************************
//Program: Lab03
//Description: Lab03
//Date: nov. 24/2023
//Author: Naresh Koirala
//Course: CMPE1666
//Class: CNT-A01
//**************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;


namespace NareshK_LAB03
{
    public delegate void print(int score);//intiazling 
    public enum level { Easy = 3, Medium = 4, Hard = 5 };//intiazling 
    public enum currentGame { Alive, Died };//intiazling 

    public partial class UI_MainForm : Form
    {
        static public int scoreAnima = 100;//intiazling 
        static int width = 800;//intiazling 
        static int height = 600;//intiazling 
        static int BallSize = 100;//intiazling 
        static int arrRows = width / BallSize;//intiazling 
        static int arrCols = height / BallSize;//intiazling 
        int playButt = 0;//intiazling 
        int currentScore = 0;//intiazling 
        int highscroce = 0;//intiazling 
        int popCounter = 0;//intiazling 

        static Form2 uI_DifficultyForm = new Form2();//intiazling 
        static Form3 UI_ScoreForm = new Form3();//intiazling 
        static Form4 uI_AnimationForm = new Form4();//intiazling 
        Form5 UI_HighScoreForm = null;//intiazling 

        print ScoreUpdate = new print(UI_ScoreForm.updateScore);//intiazling 
        public print Scoreanima = new print(getanimaValue);//intiazling 

        level userLevel = level.Easy;//intiazling 
        currentGame currentlyUser = currentGame.Alive;//intiazling 

        Color[,] savedColor = new Color[arrRows, arrCols];//intiazling 
        currentGame[,] ballState = new currentGame[arrRows, arrCols];//intiazling 
        CDrawer canvas = null;//intiazling 
        Random random = new Random();//intiazling 


        public UI_MainForm()
        {
            InitializeComponent();
        }

        //***********************************************************************************
        //Method:  private void UI_MainForm_Load(object sender, EventArgs e)
        //Purpose: load form crate a gdi window
        //*******************************************************************************
        private void UI_MainForm_Load(object sender, EventArgs e)
        {
            canvas = new CDrawer(width, height);
            uI_AnimationForm.trackValue = scoreAnima;
        }

        //***********************************************************************************
        //Method:  static private void getanimaValue(int i)
        //Purpose: to get the trackbar value
        //Parameters:to get the value
        //*******************************************************************************
        static private void getanimaValue(int i)
        {
            scoreAnima = i;
        }

        //***********************************************************************************
        //Method:  vprivate void Randomize()
        //Purpose: to get the random balls and color
        //*******************************************************************************
        private void Randomize()
        {
            Color[] diffColor = new Color[] { Color.AliceBlue, Color.Yellow, Color.Coral, Color.ForestGreen, Color.Pink };
            canvas.Clear();

            for (int i = 0; i < savedColor.GetLength(0); i++)
            {
                for (int j = 0; j < savedColor.GetLength(1); j++)
                {
                    savedColor[i, j] = diffColor[random.Next(0, (int)userLevel)];
                    ballState[i, j] = currentGame.Alive;
                }
            }
        }
        //***********************************************************************************
        //Method:   private void Display()
        //Purpose: to display in balls
        //*******************************************************************************
        private void Display()
        {
            canvas.Clear();

            for (int rows = 0; rows < width; rows += BallSize)
                for (int cols = 0; cols < height; cols += BallSize)
                {
                    if (ballState[rows / BallSize, cols / BallSize] == currentGame.Alive)
                        canvas.AddEllipse(rows, cols, BallSize, BallSize, savedColor[rows / BallSize, cols / BallSize]);
                }

            canvas.Render();
        }

        //***********************************************************************************
        //Method:  private int BallsAlive()
        //Purpose: to check for alive balls
        //*******************************************************************************
        private int BallsAlive()
        {
            int aliveCounter = 0;

            for (int rows = 0; rows < savedColor.GetLength(0); rows++)
                for (int cols = 0; cols < savedColor.GetLength(1); cols++)
                {
                    if (ballState[rows, cols] == currentGame.Alive)
                        aliveCounter++;
                }

            return aliveCounter;
        }

        //***********************************************************************************
        //Method:  private void UI_buttonMainPlay_Click(object sender, EventArgs e)
        //Purpose: for the main button
        //*******************************************************************************
        private void UI_buttonMainPlay_Click(object sender, EventArgs e)
        {
            if (uI_DifficultyForm.ShowDialog() == DialogResult.OK)
            {
                userLevel = (level)uI_DifficultyForm.mainLevel;
                currentlyUser = currentGame.Alive;
                HighscoreUp();
                Randomize();
                Display();
                playButt = 1;
                UI_buttonMainPlay.Enabled = false;
                UI_timer.Enabled = true;
            }
            else
            {
                currentlyUser = currentGame.Died;
            }
        }

        //***********************************************************************************
        //Method:  private void Score()
        //Purpose: the score checkmark
        //*******************************************************************************
        private void Score()
        {
            if (UI_ScoreForm.DialogResult == DialogResult.Cancel && UI_checkBoxScore.Checked)
            {
                UI_checkBoxScore.Checked = false;
                UI_ScoreForm.DialogResult = DialogResult.None;
            }

            else if (UI_checkBoxScore.Checked && playButt == 1)
            {
                try
                {
                    UI_ScoreForm.Show();
                    UI_ScoreForm.DialogResult = DialogResult.OK;
                }
                catch
                {
                    UI_ScoreForm = new Form3();
                    ScoreUpdate = new print(UI_ScoreForm.updateScore);
                    UI_ScoreForm.Show();
                    UI_ScoreForm.DialogResult = DialogResult.OK;
                }
            }
        }
        //***********************************************************************************
        //Method:  private void animaTion()
        //Purpose: the animation checkmark
        //*******************************************************************************
        private void animaTion()
        {
            if (uI_AnimationForm.DialogResult == DialogResult.Cancel && UI_checkBoxAnima.Checked)
            {
                UI_checkBoxAnima.Checked = false;
                uI_AnimationForm.DialogResult = DialogResult.None;
            }

            else if (UI_checkBoxAnima.Checked && playButt == 1)
            {
                try
                {
                    uI_AnimationForm.Show();
                    uI_AnimationForm.DialogResult = DialogResult.OK;
                } catch
                {
                    uI_AnimationForm = new Form4();
                    Scoreanima = new print(getanimaValue);
                    uI_AnimationForm.trackValue = scoreAnima;
                    uI_AnimationForm.Show();
                    uI_AnimationForm.DialogResult = DialogResult.OK;
                }

            }
        }

        //***********************************************************************************
        //Method:  vprivate int CheckBalls(int x, int y, Color oldColor )
        //Purpose: the mathod that check for the array of the color that need to be deleted
        //*******************************************************************************
        private int CheckBalls(int x, int y, Color oldColor )
        {
            if (x < 0 || y < 0 || x >= (width / BallSize) || y >= (height / BallSize) || savedColor[x, y] == Color.Empty)
                return 0;

            if (savedColor[x, y] != oldColor)
                return 0;

            savedColor[x, y] = Color.Empty;
            ballState[x, y] = currentGame.Died;
            popCounter++;

            CheckBalls(x + 1, y, oldColor);
            CheckBalls(x - 1, y, oldColor);
            CheckBalls(x, y + 1, oldColor);
            CheckBalls(x, y - 1, oldColor);

            return popCounter;
        }

        //***********************************************************************************
        //Method:  private void UI_timer_Tick(object sender, EventArgs e)
        //Purpose: the main timer of the program
        //*******************************************************************************
        private void UI_timer_Tick(object sender, EventArgs e)
        {
            Score();
            animaTion();

            if (BallsAlive() == 0)
                currentlyUser = currentGame.Died;

            if(!UI_checkBoxScore.Checked)
                UI_ScoreForm.Close();

            if (!UI_checkBoxAnima.Checked)
                uI_AnimationForm.Close();

            if (currentlyUser == currentGame.Alive)
            {
                currentScore = Pick();
                ScoreUpdate.Invoke(currentScore);
            }
            else
            {
                UI_timer.Enabled = false;
                canvas.AddText("Game Over", 100, Color.Blue);
                HighscoreUp();
                playButt = 0;
                UI_checkBoxAnima.Checked = false;
                UI_checkBoxScore.Checked = false;
                Score();
                animaTion();
                currentScore = 0;
                UI_buttonMainPlay.Enabled = true;
            }
        }


        string key = null;
        string value = null;

        //***********************************************************************************
        //Method:  private void HighscoreUp()
        //Purpose: check the file and write in the file
        //*******************************************************************************
        private void HighscoreUp()
        {
            string[] text; 
            string path = $@"{userLevel}.txt";

            if (currentlyUser == currentGame.Alive)
            {
                try
                {
                    text = File.ReadAllLines(path);
                    highscroce = 0;
                    foreach (string text1 in text)
                    {
                        string[] parts = text1.Split('=');
                        key = parts[1]; 
                        value = parts[0];

                        if (int.Parse(key) > highscroce)
                            highscroce = int.Parse(key);
                    }
                }
                catch
                {
                    FileStream fs = File.Create(path);
                    highscroce = 0;
                }
            }
            else
            {
                if (highscroce < currentScore)
                {
                    UI_HighScoreForm = new Form5();

                    if (UI_HighScoreForm.ShowDialog() == DialogResult.OK)
                    {
                        using (var file = File.CreateText(path))
                            file.WriteLine($"{UI_HighScoreForm.name} = {currentScore}");

                        canvas.AddText($"New HighScore({userLevel}): {currentScore} \nBY: {UI_HighScoreForm.name}", 10, 300, 50, 200, 50, Color.Green);
                    }
                    else
                    {
                        canvas.AddText($"New HighScore (Not Saved.......)", 10, 300, 50, 200, 50, Color.Green);
                    }
                }
                canvas.AddText($"Past HighScore({userLevel}): {key} \nBY: {value}", 10, 300, 400, 200, 50, Color.Green);
            }

        }

        //***********************************************************************************
        //Method: private int Pick()
        //Purpose: the left click detected
        //*******************************************************************************
        private int Pick()
        {
            Point leftclick = new Point(-1, -1);
            int x = -1;
            int y = -1;

            if (canvas.GetLastMouseLeftClickScaled(out leftclick))
            {
                x = leftclick.X/BallSize;
                y = leftclick.Y/BallSize;

                popCounter = CheckBalls(x, y, savedColor[x, y]);

                currentScore += (int)Math.Pow((double)(popCounter), 2);

                Display();
                FallDown();

                popCounter = 0;
                
                return currentScore;
            }
            else 
                return currentScore;

        }

        //***********************************************************************************
        //Method: private int StepDown()
        //Purpose: checkes each rows and make it drop
        //*******************************************************************************
        private int StepDown()
        {
            int ballDropped = 0;

            for (int rows = 0; rows < ballState.GetLength(0); rows++)
                for (int cols = 0; cols < ballState.GetLength(1); cols++)
                {
                    if (ballState[rows, cols] == currentGame.Died && cols > 0)
                    {
                        if (ballState[rows, cols - 1] == currentGame.Alive)
                        {
                            ballState[rows, cols] = ballState[rows, cols - 1];
                            savedColor[rows, cols] = savedColor[rows, cols - 1];
                            ballState[rows, cols - 1] = currentGame.Died;
                            savedColor[rows, cols - 1] = Color.Empty;
                            ballDropped++;
                            Thread.Sleep(scoreAnima);
                            Display();
                        }
                    }
                }

            return ballDropped;
        }
        //***********************************************************************************
        //Method: private int FallDown() 
        //Purpose: loops and call for the stepdown until we have everything dropped
        //*******************************************************************************
        private int FallDown() 
        {
            int ballDropped = 0;

            while (StepDown() != 0)
            {
                ballDropped++;
            }
            return ballDropped;
        }
      
    }
}


/*
    to update score to the new form
    
     ScoreUpdate.Invoke(currentScore);
 */

/*

        private void OneAtTimeCols()
        {
            int yFake;

            for (int i = savedColor.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = savedColor.GetLength(1) - 1; j >= 0; j--)
                {
                    if (savedColor[i, j] == Color.Empty)
                    {
                        for (int y = 0; y <= j; y++)
                        {
                            yFake = j;

                            if (savedColor[i, y] != Color.Empty)
                            {
                                while (true)
                                {
                                    if (savedColor[i, yFake] != Color.Empty)
                                        break;

                                    yFake--;
                                }
                                while (yFake < j)
                                {
                                    yFake++;
                                    savedColor[i, yFake] = savedColor[i, yFake - 1];
                                    savedColor[i, yFake - 1] = Color.Empty;
                                    Thread.Sleep(scoreAnima);
                                    Display();
                                }
                                j--;
                            }
                        }
                    }
                }
            }
        }
*/
