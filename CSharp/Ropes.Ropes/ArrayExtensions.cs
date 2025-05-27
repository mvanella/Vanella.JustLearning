namespace Ropes.Ropes
{
    public static class ArrayExtensions
    {
        public static void Split(this char[] arr, int i, out char[] a1, out char[] a2)
        {
            a1 = arr.Take(i).ToArray();
            a2 = arr.Skip(i).ToArray();
        }

        public static void Split(this List<char> arr, int i, out List<char> a1, out List<char> a2)
        {
            a1 = arr.Take(i).ToList();
            a2 = arr.Skip(i).ToList();
        }
    }
}
