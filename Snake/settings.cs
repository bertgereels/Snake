using System;

namespace Snake
{
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    };

    class Settings
    {
        private int width;

        public int GetWidth()
        {
            return width;
        }

        public void SetWidth(int value)
        {
            width = value;
        }

        private int height;

        public int GetHeight()
        {
            return height;
        }

        public void SetHeight(int value)
        {
            height = value;
        }

        private int speed;

        public int GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(int newValue)
        {
            if (newValue > 0)
            {
                speed = newValue;
            }
        }

        private int score;

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int value)
        {
            score = value;
        }

        private int points;

        public int GetPoints()
        {
            return points;
        }

        public void SetPoints(int value)
        {
            points = value;
        }

        private bool gameOver;

        public bool GetGameOver()
        {
            return gameOver;
        }

        public void SetGameOver(bool value)
        {
            gameOver = value;
        }

        private Directions direction;

        public Directions GetDirection()
        {
            return direction;
        }

        public void SetDirection(Directions value)
        {
            direction = value;
        }

        public Settings()
        {
            Console.WriteLine("Settings constructor called!");
            SetWidth(16);
            SetHeight(16);
            SetSpeed(20);
            SetScore(0);
            SetPoints(100);
            SetGameOver(false);
            SetDirection(Directions.Down);
        }

    }
}
