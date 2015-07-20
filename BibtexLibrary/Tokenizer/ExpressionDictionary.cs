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
            Add(typeof(At), "(\\s)*@");
            Add(typeof(Preamble), "(\\s)*Preamble");
            Add(typeof(NewLine), "(\\s)*$");
            Add(typeof(Text), "");
        }
    }
}
