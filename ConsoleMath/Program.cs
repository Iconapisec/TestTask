Console.WriteLine("Input expression:");
var expression = Console.ReadLine().ToUpper();

try
{
    Stack<double> values = new();
    string[] items = expression.Split(new[] {'(', ')',','});
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
    Console.WriteLine($"Result: {values.Pop()}");
}
catch
{
    Console.WriteLine("Invalid expression.");
}
