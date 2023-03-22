int num;
Console.WriteLine("Input number between 1 and 1000:");
while(true)
{
    int.TryParse(Console.ReadLine(), out num);
    if(num > 0 && num <= 1000)
    {
        break;
    }
    Console.WriteLine("Invalid number.");
}

int previous = 1;
Console.Write("Result:");
for(int i = 0; i <= num ; i += previous)
{
    Console.Write($" {i} ");
    if(i == 0)
    {
        continue;
    }
    previous = i - previous;
}