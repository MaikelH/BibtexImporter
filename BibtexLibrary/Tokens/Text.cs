using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibtexLibrary.Tokens
{
    public class Text : AbstractToken
    {
        private readonly string _value;

        public Text(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
