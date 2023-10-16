namespace board
{
    class Position
    {

        public int Line { get; set; }
        public int Column { get; set; }


        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        // Função que define os valores de uma posição
        public void DefineValues(int line, int column)
        {
            Line = line;
            Column = column;
        }

        // ToString
        public override string ToString()
        {
            return Line + ", " + Column;
        }

    }
}
