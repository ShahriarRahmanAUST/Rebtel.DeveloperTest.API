using System.Text;

namespace Rebtel.DeveloperTest.WarmUpTasks
{
    public static class LibraryUtility
    {
        public static bool IsBookIdPowerOfTwo(int bookId)
        {
            return (bookId != 0) && ((bookId & (bookId - 1)) == 0);
        }

        public static string ReverseBookTitle(string title)
        {
            var charArray = title.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string GenerateBookTitleReplicas(string title, int number)
        {
            var sb = new StringBuilder(title);
            for (var i = 1; i < number; i++)
            {
                sb.Append(title);
            }

            return sb.ToString();
        }

        public static List<int> AllOddNumberBetweenZeroToHundred()
        {
            return Enumerable.Range(0, 100).Where(x => x % 2 != 0).ToList();
        }
    }
}