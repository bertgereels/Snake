using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Snake
{
    public partial class SnakeForm : Form
    {
        private List<Circle> SnakeBody = new List<Circle>();
        private Circle food = new Circle();
        private Settings gameSettings;
        public SnakeForm()
        {
            InitializeComponent();
            gameSettings = new Settings();
            timer1.Interval = 1000 / gameSettings.GetSpeed();
            timer1.Tick += UpdateScreen;
            timer1.Start();

            StartGame();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {

        }

        private void StartGame()
        {

            SnakeBody.Clear();
            Circle headOfSnake = new Circle(10, 5);
            SnakeBody.Add(headOfSnake);
            GenerateFood();
        }

        private void MovePlayer()
        {
            int maxXpos = pictureBox1.Size.Width / gameSettings.GetWidth();
            int maxYpos = pictureBox1.Size.Height / gameSettings.GetHeight();

            for (int i = SnakeBody.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (gameSettings.GetDirection())
                    {
                        case Directions.Right:
                            SnakeBody[i].SetXCoordinate(SnakeBody[i].GetXCoordinate() + 1);
                            break;
                        case Directions.Left:
                            SnakeBody[i].SetXCoordinate(SnakeBody[i].GetXCoordinate() - 1);
                            break;
                        case Directions.Up:
                            SnakeBody[i].SetYCoordinate(SnakeBody[i].GetYCoordinate() - 1);
                            break;
                        case Directions.Down:
                            SnakeBody[i].SetYCoordinate(SnakeBody[i].GetYCoordinate() + 1);
                            break;

                    }

                    CheckCollisionWithBorder(maxXpos, maxYpos, SnakeBody[i]);

                    CheckCollisionWithSelf(SnakeBody[i]);

                    CheckCollisionWithFood();

                }
                else
                {

                    MoveSnake(SnakeBody[i], SnakeBody[i - 1]);
                }
            }
        }

        private void CheckCollisionWithBorder(int maxXPos, int maxYPos, Circle snakePart)
        {

            if (snakePart.GetXCoordinate() < 0 || snakePart.GetYCoordinate() < 0 ||
                snakePart.GetXCoordinate() > maxXPos || snakePart.GetYCoordinate() > maxYPos)
            {
                Die();
            }

        }

        private void CheckCollisionWithSelf(Circle snakePart)
        {
            for (int j = 1; j < SnakeBody.Count; j++)
            {
                if (snakePart.GetXCoordinate() == SnakeBody[j].GetXCoordinate() &&
                    snakePart.GetYCoordinate() == SnakeBody[j].GetYCoordinate())
                {
                    Die();
                }
            }
        }

        private void CheckCollisionWithFood()
        {
            if (SnakeBody[0].GetXCoordinate() == food.GetXCoordinate() &&
                SnakeBody[0].GetYCoordinate() == food.GetYCoordinate())
            {
                Eat();
            }
        }

        private void MoveSnake(Circle snakePart, Circle previousSnakePart)
        {
            snakePart.SetXCoordinate(previousSnakePart.GetXCoordinate());
            snakePart.SetYCoordinate(previousSnakePart.GetYCoordinate());
        }

        private void Die()
        {
            gameSettings.SetGameOver(true);
        }

        private void Eat()
        {
            Circle newPart = new Circle(SnakeBody[SnakeBody.Count - 1].GetXCoordinate(),
                                        SnakeBody[SnakeBody.Count - 1].GetYCoordinate());

            SnakeBody.Add(newPart);
            gameSettings.SetScore(gameSettings.GetScore() + gameSettings.GetPoints());
            ScoreLabel.Text = gameSettings.GetScore().ToString();

            GenerateFood();
        }

        private void GenerateFood()
        {
            int maxXpos = pictureBox1.Size.Width / gameSettings.GetWidth();
            int maxYpos = pictureBox1.Size.Height / gameSettings.GetHeight();

            Random rnd = new Random();
            food = new Circle(rnd.Next(0, maxXpos), rnd.Next(0, maxYpos));
        }

        private void Keyisdown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            Console.WriteLine("Pressed " + e.KeyCode + " key!");
        }

        private void Keyisup(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (gameSettings.GetGameOver() == false)
            {
                Brush snakeColour;

                foreach (Circle snakePart in SnakeBody)
                {
                    if (snakePart == SnakeBody.First())
                    {
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        snakeColour = Brushes.Green;
                    }

                    canvas.FillEllipse(Brushes.Red, new Rectangle(
                        snakePart.GetXCoordinate() * gameSettings.GetWidth(),
                        snakePart.GetYCoordinate() * gameSettings.GetHeight(),
                        gameSettings.GetWidth(),
                        gameSettings.GetHeight()));

                    canvas.FillEllipse(Brushes.Red, new Rectangle(
                        food.GetXCoordinate() * gameSettings.GetWidth(),
                        food.GetYCoordinate() * gameSettings.GetHeight(),
                        gameSettings.GetWidth(),
                        gameSettings.GetHeight()));
                }

            }
            else
            {
                GameOverLabel.Text = "Game Over!";
            }



        }
    }
}
