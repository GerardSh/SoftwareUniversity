public class Index
{
    public Index(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public Index(string input)
    {
        var elements = input.Split(",");

        Row = int.Parse(elements[0]);
        Column = int.Parse(elements[1]);
    }

    public int Row { get; set; }

    public int Column { get; set; }

    public override bool Equals(object? obj)
    {
        var otherIndex = obj as Index;

        return Row == otherIndex.Row &&
            Column == otherIndex.Column;
    }

    public override string ToString()
    {
        return $"{Row},{Column}";
    }
}