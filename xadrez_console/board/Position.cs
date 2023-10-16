namespace board
{
    class Position
    {

        public int Line { get; set; }
        public int Column { get; set; }


        public Position(int line, int Column)
        {
            this.Line = line;
            this.Column = Column;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }

    }
}
