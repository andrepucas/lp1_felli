namespace Felli
{
    /// <summary>
    /// <c>Position</c> Class.
    /// Contains a single method that converts coordinates.
    /// </summary>
    public class Position
    {
        public int Row {get;}
        public int Col {get;}

        /// <summary>
        /// Sets receiving coordinates as <c>Position</c> board coordinates.
        /// </summary>
        /// <param name="row">Integer with value of row.</param>
        /// <param name="col">Integer with value of column.</param>
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}