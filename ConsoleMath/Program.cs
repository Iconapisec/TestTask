Console.WriteLine("Input expression:");
var expression = Console.ReadLine().ToUpper();
string[] items = expression.Split(new[] {'(', ')',',',' '}, StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine($"Recursion result: {CalculateInRecursion()}");
CalculateInLoop();

double CalculateInRecursion(int i=0)
{
    if(double.TryParse(items[i],out double num))
    {
        return num;
    }
    else if(items[i] == "SUM")
    {
        return CalculateInRecursion(i+1) + CalculateInRecursion(i+2);
    }
    else if(items[i] == "MULTIPLY")
    {
        return CalculateInRecursion(i+1) * CalculateInRecursion(i+2);
    }
    else if(items[i] == "POWER")
    {
        return Math.Pow(CalculateInRecursion(i+1), CalculateInRecursion(i+2));
    }
    else if(items[i] == "NEGATIVE")
    {
        return -CalculateInRecursion(i+1);
    }
    return 0;
}

void CalculateInLoop()
{
    try
    {
        Stack<double> values = new();
        for(int i = items.Length-1; i >= 0; i--)
        {
            if(double.TryParse(items[i],out double num))
            {
                values.Push(num);
            }
            else if(items[i] == "SUM")
            {
                values.Push(values.Pop() + values.Pop());
            }
            else if(items[i] == "MULTIPLY")
            {
                values.Push(values.Pop() * values.Pop());
            }
            else if(items[i] == "POWER")
            {
                values.Push(Math.Pow(values.Pop(), values.Pop()));
            }
            else if(items[i] == "NEGATIVE")
            {
                values.Push(-values.Pop());
            }
        }
        Console.WriteLine($"Loop result: {values.Pop()}");
    }
    catch
    {
        Console.WriteLine("Invalid expression.");
    }
}