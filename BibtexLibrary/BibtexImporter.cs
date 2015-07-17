using System.IO;

namespace BibtexLibrary
{
    public class BibtexImporter
    {
        public static BibtexFile FromString(string text) {
            return new BibtexFile();
        }

        public static BibtexFile FromStream(StreamReader reader)
        {
            return new BibtexFile();
        }
    }
}
