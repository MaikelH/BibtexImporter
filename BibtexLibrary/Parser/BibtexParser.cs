﻿using System;
using System.Collections.Generic;
using BibtexLibrary.Parser.Nodes;
using BibtexLibrary.Tokens;

namespace BibtexLibrary.Parser
{
    public class BibtexParser
    {
        private readonly Tokenizer.Tokenizer _tokenizer;

        public BibtexParser(Tokenizer.Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public BibtexFile Parse()
        {
            ParseNode node = ParseInput(_tokenizer);
            BibtexFile fileObject = convertParseNode(node);

            return fileObject;
        }

        private BibtexFile convertParseNode(ParseNode node)
        {
            return new BibtexFile();
        }

        private ParseNode ParseInput(Tokenizer.Tokenizer tokenizer)
        {
            Nodes.BibtexFile file = new Nodes.BibtexFile();

            while (!tokenizer.EndOfInput)
            {
                AbstractToken token = tokenizer.NextToken();

                if (token.GetType() == typeof (At))
                {
                    file.Entries.Add(Entry(tokenizer));    
                }
            }

            return file;
        }

        private Entry Entry(Tokenizer.Tokenizer tokenizer)
        {
            Entry entry = new Entry();

            entry.Type = Text(tokenizer);
            OpeningBrace(tokenizer);
            entry.Key = Text(tokenizer);
            Comma(tokenizer);
            entry.Tags = Tags(tokenizer);
            ClosingBrace(tokenizer);

            return entry;
        }

        private String Text(Tokenizer.Tokenizer tokenizer)
        {
            AbstractToken token = tokenizer.NextToken();

            if (token.GetType() == typeof (Text))
            {
                Text text = (Text) token;
                return text.GetValue();
            }

            throw new ParseException("Expected type Text but found: " + token.GetType());
        }

        private void OpeningBrace(Tokenizer.Tokenizer tokenizer)
        {
            AbstractToken token = tokenizer.NextToken();

            if (token.GetType() == typeof(OpeningBrace))
            {
                return;
            }

            throw new ParseException("Expected type OpeningBrace but found: " + token.GetType());    
        }

        private void ClosingBrace(Tokenizer.Tokenizer tokenizer)
        {
            AbstractToken token = tokenizer.NextToken();

            if (token.GetType() == typeof(ClosingBrace))
            {
                return;
            }

            throw new ParseException("Expected type OpeningBrace but found: " + token.GetType());
        }

        private void Comma(Tokenizer.Tokenizer tokenizer)
        {
            AbstractToken token = tokenizer.NextToken();

            if (token.GetType() == typeof(Comma))
            {
                return;
            }

            throw new ParseException("Expected type OpeningBrace but found: " + token.GetType());
        }

        private ICollection<Tag> Tags(Tokenizer.Tokenizer tokenizer)
        {
            List<Tag> tags = new List<Tag>();

            while (tokenizer.Peek().GetType() != typeof (ClosingBrace))
            {
                Tag tag = new Tag();
                tag.Key = Text(tokenizer);
                Equals(tokenizer);
                OpeningBrace(tokenizer);
                tag.Value = Text(tokenizer);
                ClosingBrace(tokenizer);

                tags.Add(tag);
            }

            return tags;            
        }

        private void Equals(Tokenizer.Tokenizer tokenizer)
        {
            AbstractToken token = tokenizer.NextToken();

            if (token.GetType() == typeof(Equals))
            {
                return;
            }

            throw new ParseException("Expected type Equals but found: " + token.GetType());
        }
    }
}
