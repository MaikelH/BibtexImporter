using System.Collections.Generic;

namespace BibtexLibrary
{
    public class BibtexEntry
    {
        public string Type { get; set; }

        public string Key { get; set; }

        public Dictionary<string, string> Tags {get; set;}

    }
}
