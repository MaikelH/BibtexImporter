using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibtexLibrary.Tokens
{
    public class AbstractToken
    {
        protected string Value;
        private int _position;

        public AbstractToken(String value)
        {
            Value = value;
        }

        public AbstractToken(String value, int Position)
        {
            Value = value;
            _position = Position;
        }

        public String GetValue()
        {
            return Value;
        }

        public int Position
        {
            get { return _position; }
        }
    }
}
