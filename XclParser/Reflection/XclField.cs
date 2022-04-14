﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

using XclParser.Parser;

namespace XclParser.Reflection
{
    [DebuggerDisplay("{Type} {Name}")]
    public class XclField : Symbol
    {
        internal XclField(string name, XclType type) : 
            base(Lexer.TokenType.Identifier, Tokenizer.TokenType.FieldName, name)
        {
            Type = type;
        }

        public XclType Type { get; }
    }
}
