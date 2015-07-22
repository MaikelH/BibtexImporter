using System;
using System.Collections.Generic;
using BibtexLibrary.Tokens;

namespace BibtexLibrary.Tokenizer
{
    public class ExpressionDictionary : Dictionary<Type, String>
    {
        private Dictionary<Type, string> _mapping;

        public ExpressionDictionary()
        {
            init();
        }

        private void init()
        {
            Add(typeof(At), "^(\\s)*@");
            Add(typeof(Preamble), "(\\s)*Preamble");
            Add(typeof(NewLine), "^(\\s)*$");
            Add(typeof(OpeningBrace), "^(\\s)*{");
            Add(typeof(ClosingBrace), "^(\\s)*}");
            Add(typeof(Comma), "^\\s*,");
            Add(typeof(Equals), "^\\s*=");
            Add(typeof(Text), "^\\s*[A-z0-9:.\\s]+");
        }
    }
}
