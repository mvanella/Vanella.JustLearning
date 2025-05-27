using System.Reflection.Metadata;
using System.Text;

namespace Ropes.Ropes
{
    public class Rope
    {
        private static readonly int LEAF_LEN = 2;

        public Rope Left;
        public Rope Right;
        public Rope Parent;
        public List<char> Str;
        public int LCount;

        public Rope()
        {
            Str = [];
        }

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        public static Rope CreateRopeStructure(ref Rope node, Rope parent, string a, int l, int r)
        {
            Rope temp = new()
            {
                Left = null,
                Right = null,
                Parent = parent
            };

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

        public static Rope CreateRopeStructure(ref Rope node, Rope parent, string a)
        {
            return CreateRopeStructure(ref node, parent, a, 0, a.Length - 1);
        }

        public static Rope CreateRopeLeaf(ref Rope node, Rope parent, List<char> a)
        {
            node = new()
            {
                Left = null,
                Right = null,
                Parent = parent,
                LCount = a.Count
            };

            node.Str.AddRange(a);

            return node;
        }

        public static Rope ConcatenateRopes(Rope left, Rope right)
        {
            if (left == null || right == null)
            {
                return left ?? right;
            }

            var result = new Rope
            {
                Left = left,
                Right = right,
                LCount = left.Length()
            };

            left.Parent = result;
            right.Parent = result;

            return result;
        }

        public int Length()
        {
            return LCount + Right?.Length() ?? 0;
        }

        public override string ToString()
        {
            if (this == null) { return string.Empty; }
            var sb = new StringBuilder();
            AppendToStringBuilder(sb);
            return sb.ToString();
        }

        private void AppendToStringBuilder(StringBuilder sb)
        {
            if (Left == null && Right == null && Str != null)
            {
                sb.Append(Str.ToArray());
            }
            Left?.AppendToStringBuilder(sb);
            Right?.AppendToStringBuilder(sb);
        }

        public static char Search(Rope r, int i)
        {
            if (r.LCount < i && r.Right != null)
            {
                return Search(r.Right, i - r.LCount);
            }
            else if (r.Left != null)
            {
                return Search(r.Left, i);
            }
            return r.Str[i];
        }

        public (Rope, Rope) Split(int i)
        {
            if (i < LCount)
            {
                if (Left != null)
                {
                    var (leftSplit, rightSplit) = Left.Split(i);
                    return (leftSplit, new Rope
                    {
                        Left = rightSplit,
                        Right = Right
                    });
                }
                else
                {
                    return (
                        new Rope { Str = Str[..i] },
                        new Rope { Str = Str.Slice(i, Str.Count) }
                    );
                }
            }
            else if (Right != null)
            {
                var (leftSplit, rightSplit) = Right.Split(i - LCount);
                return (new Rope
                {
                    Left = Left,
                    Right = leftSplit
                }, rightSplit);
            }
            return (this, null);
        }
    }
}
