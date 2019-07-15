namespace Snake
{
    class Circle
    {
        private int xCoordinate;

        public int GetXCoordinate()
        {
            return xCoordinate;
        }

        public void SetXCoordinate(int value)
        {
            xCoordinate = value;
        }

        private int yCoordinate1;

        public int GetYCoordinate()
        {
            return yCoordinate1;
        }

        public void SetYCoordinate(int value)
        {
            yCoordinate1 = value;
        }

        public Circle()
        {
            SetXCoordinate(0);
            SetYCoordinate(0);
        }

        public Circle(int xCoordinate, int yCoordinate)
        {
            SetXCoordinate(xCoordinate);
            SetYCoordinate(yCoordinate);
        }

    }
}
