// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int prev = 0;
int next = prev+1;
int limit = 20;
int sum;
Console.WriteLine(prev);
Console.WriteLine(next);

for (int i = -1;i < limit; i++)
{
   

    sum = prev + next;
    prev = next;
    next = sum;
    Console.Write($", {sum}");
    

}