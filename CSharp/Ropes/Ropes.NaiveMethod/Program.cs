public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please specify two strings to concatenate.");
            return;
        }

        char[] a = args[0].ToCharArray();
        char[] b = args[1].ToCharArray();
        int n1 = a.Length;
        int n2 = b.Length;

        char[] c = new char[n1 + n2];
        Concatenate(a, b, c, n1, n2);

        Console.WriteLine("First as an array: ");
        for (int i = 0; i < n1 + n2; i++)
        {
            Console.Write(c[i]);
        }
        Console.Write(Environment.NewLine);

        Console.WriteLine("Now as a string: ");
        Console.WriteLine(c);

        Console.WriteLine("Thanks, bye");
        Console.ReadKey();
        return;
    }

    /// <summary>
    /// Concatenates two strings (a[...] and b[...]) and stores the result in c[]
    /// </summary>
    /// <param name="a">Input string</param>
    /// <param name="b">Input string</param>
    /// <param name="c">Output string</param>
    /// <param name="n1">Length of the first array</param>
    /// <param name="n2">Length of the second array</param>
    public static void Concatenate(char[] a, char[] b, char[] c, int n1, int n2)
    {
        int i;
        for (i = 0; i < n1; i++)
        {
            c[i] = a[i];
        }
        for (int j = 0; j < n2; j++)
        {
            c[i++] = b[j];
        }
    }
}