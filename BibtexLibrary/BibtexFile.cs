using System.Collections.Generic;

namespace BibtexLibrary
{
    public class BibtexFile
    {
        public Dictionary<string, string> StringDefinitions { get; set; }

        public ICollection<string> Preamble { get; set; } 

        public ICollection<BibtexEntry> Entries { get; set; }
    }
}
