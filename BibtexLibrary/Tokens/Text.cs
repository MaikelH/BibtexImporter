﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibtexLibrary.Tokens
{
    public class Text : AbstractToken
    {
        public Text(String Value) :base(Value) { }
        public Text(String Value, int Postion) : base(Value, Postion) { }
    }
}
