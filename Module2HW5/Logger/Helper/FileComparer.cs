using System.Collections;
using System.IO;

namespace Logger.Helper
{
    public class FileComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var firstItem = x as string;
            var secondItem = y as string;
            return File.GetCreationTimeUtc(firstItem).CompareTo(File.GetCreationTimeUtc(secondItem));
        }
    }
}
