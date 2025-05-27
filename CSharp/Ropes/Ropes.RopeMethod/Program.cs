using Ropes.Ropes;

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

        Rope.CreateRopeStructure(ref ropeA, null, a, 0, an1 - 1);
        Rope.CreateRopeStructure(ref ropeB, null, b, 0, bn1 - 1);

        Console.WriteLine("RopeA:");
        Console.WriteLine(ropeA.ToString());

        Console.WriteLine("RopeB:");
        Console.WriteLine(ropeB.ToString());

        var ropeC = Rope.ConcatenateRopes(ropeA, ropeB);
        Console.WriteLine("RopeC:");        
        Console.WriteLine(ropeC.ToString());

        Console.ReadKey();
    }

    //private static Rope ConcatenateRopes(Rope left, Rope right)
    //{
    //    if (left == null || right == null)
    //    {
    //        return left ?? right;
    //    }

    //    var result = new Rope
    //    {
    //        Left = left,
    //        Right = right,
    //        LCount = GetRopeLength(left)
    //    };

    //    left.Parent = result;
    //    right.Parent = result;

    //    return result;
    //}

    //private static int GetRopeLength(Rope rope)
    //{
    //    if (rope == null) { return 0; }
    //    return rope.LCount + GetRopeLength(rope.Right);
    //}

    //private static Rope CreateRopeStructure(ref Rope node, Rope parent, string a, int l, int r)
    //{
    //    Rope temp = new()
    //    {
    //        Left = null,
    //        Right = null,
    //        Parent = parent
    //    };

    //    if ((r - l) > LEAF_LEN)
    //    {
    //        temp.Str = null;
    //        temp.LCount = (int)Math.Floor((r - l) / 2.0);
    //        node = temp;
    //        int m = (int)Math.Floor((l + r) / 2.0);
    //        node.Left = CreateRopeStructure(ref node.Left, node, a, l, m);
    //        node.Right = CreateRopeStructure(ref node.Right, node, a, m + 1, r);
    //    }
    //    else
    //    {
    //        node = temp;
    //        temp.LCount = (r - l);
    //        for (int i = l; i <= r; i++)
    //        {
    //            temp.Str.Add(a[i]);
    //        }
    //    }

    //    return node;
    //}

    //private static void PrintString(Rope r)
    //{
    //    if (r == null)
    //    {
    //        return;
    //    }
    //    if (r.Left == null && r.Right == null)
    //    {
    //        foreach (var c in r.Str)
    //        {
    //            Console.Write(c);
    //        }
    //    }
    //    PrintString(r.Left);
    //    PrintString(r.Right);
    //}
}

//internal class Rope
//{
//    public Rope Left;
//    public Rope Right;
//    public Rope Parent;
//    public List<char> Str;
//    public int LCount;

//    public Rope()
//    {
//        //Left = null;
//        //Right = null;
//        //Parent = null;
//        Str = [];
//        //LCount = 0;
//    }
//}