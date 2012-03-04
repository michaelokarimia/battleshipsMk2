namespace Battleships
{
    public class Board
    {
        private readonly int height;
        private readonly int width;
        private GridValues[,] array;

        public Board(int width, int height)
        {
            this.height = height;
            this.width = width;
            array = new GridValues[width, height];
        }


        public int Width()
        {
            return width;
        }

        public int Height()
        {
            return height;
        }


        public GridValues GetCellValue(int height, int width)
        {
            return array[height,width];
        }

        public void FireShot(int x, int y)
        {
            if (array[x,y].Equals(GridValues.EMPTY_CELL_VALUE))
            {
                array[x, y] = GridValues.MISSED_SHOT;
            }
        }
    }
}