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
            Add(typeof(Text), "");
            Add(typeof(NewLine), "$");
        }
    }
}
