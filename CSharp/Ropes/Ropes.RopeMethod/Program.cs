using System;
using System.Collections.Generic;

public class Program
{
    // Maximum length of a leaf string
    public static readonly int LEAF_LEN = 2;

    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please specify two strings to concatenate.");
            return;
        }

        var a = args[0];
        var b = args[1];
        var an1 = a.Length;
        var bn1 = b.Length;

        Rope ropeA = null;
        Rope ropeB = null;

        ropeA = CreateRopeStructure(ref ropeA, null, a, 0, an1 - 1);
        ropeB = CreateRopeStructure(ref ropeB, null, b, 0, bn1 - 1);

        Console.ReadKey();
    }

    private static Rope CreateRopeStructure(ref Rope node, Rope parent, string a, int l, int r)
    {
        Rope temp = new Rope();
        //temp.Left = temp.Right = null; // redundant...
        temp.Parent = parent;
        if ((r - l) > LEAF_LEN)
        {
            temp.Str = null;
            temp.LCount = (int)Math.Floor((r - l) / 2.0);
            node = temp;
            int m = (int)Math.Floor((l + r) / 2.0);
            node.Left = CreateRopeStructure(ref node.Left, node, a, l, m);
            node.Right = CreateRopeStructure(ref node.Right, node, a, m + 1, r);
        }
        else
        {
            node = temp;
            temp.LCount = (r - l);
            for (int i = l; i <= r; i++)
            {
                temp.Str.Add(a[i]);
            }
        }

        return node;
    }
}

internal class Rope {
    public Rope Left;
    public Rope Right;
    public Rope Parent;
    public List<char> Str;
    public int LCount;

    public Rope()
    {
        //Left = null;
        //Right = null;
        //Parent = null;
        Str = new List<char>();
        //LCount = 0;
    }
}