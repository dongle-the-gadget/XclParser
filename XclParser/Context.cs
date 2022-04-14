﻿using System.IO;
using System.Threading.Tasks;

namespace XclParser
{
    public class Context
    {
        public Context()
        {
            TypeMap = new TypeMap(this);
            Parser = new Parser.Parser(this);
        }

        public TypeMap TypeMap { get; }

        internal Parser.Parser Parser { get; }

        public async Task<XclDocument> ParseDocumentAsync(TextReader input)
        {
            Parser.ResetPosition();
            var lexer = new Lexer.Lexer(input);
            var lexerTokens = await lexer.ParseAsync();
            var tokenizer = new Tokenizer.Tokenizer(lexerTokens);
            Parser.Data = tokenizer.Parse();
            return Parser.ParseDocument();
        }
    }
}
