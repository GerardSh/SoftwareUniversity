class MyClass
{
    static void Main()
    {
        string dataType = Console.ReadLine();
        string value = Console.ReadLine();

        if (dataType == "int")
        {
            Console.WriteLine(DataTypeManipulator(int.Parse(value)));
        }
        else if (dataType == "real")
        {
            Console.WriteLine($"{DataTypeManipulator(double.Parse(value)):f2}");
        }
        else
        {
            Console.WriteLine(DataTypeManipulator(value));
        }
    }

    /// <summary>
    /// Returns modified value according to its type.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static int DataTypeManipulator(int value)
    {
        return value * 2;
    }

    /// <summary>
    /// Returns modified value according to its type.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static double DataTypeManipulator(double value)
    {
        return value * 1.5;
    }

    /// <summary>
    /// Returns modified value according to its type.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static string DataTypeManipulator(string value)
    {
        return $"${value}$";
    }
}




//2
class MyClass
{
    static void Main()
    {
        string value = Console.ReadLine();
        string dataType = Console.ReadLine();


        if (int.TryParse(dataType, out int valueInt))
        {
            valueInt = DataTypeManipulator(valueInt);
            Console.WriteLine(valueInt);

        }
        else if (double.TryParse(dataType, out double valueDouble))
        {
            valueDouble = DataTypeManipulator(valueDouble);
            Console.WriteLine($"{valueDouble:f2}");
        }
        else
        {
            dataType = DataTypeManipulator(dataType);
            Console.WriteLine($"{dataType:f2}");
        }
    }

    /// <summary>
    /// Manipulates the value according to the data type.
    /// </summary>
    /// <param name="dataType"></param>
    /// <returns></returns>
    static string DataTypeManipulator(string dataType)
    {
        return $"${dataType:f2}$";
    }

    /// <summary>
    /// Manipulates the value according to the data type.
    /// </summary>
    /// <param name="dataType"></param>
    /// <returns></returns>
    static int DataTypeManipulator(int dataType)
    {
        return dataType * 2;
    }

    /// <summary>
    /// Manipulates the value according to the data type.
    /// </summary>
    /// <param name="dataType"></param>
    /// <returns></returns>
    static double DataTypeManipulator(double dataType)
    {
        return dataType * 1.5;
    }
}