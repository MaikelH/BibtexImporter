using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using BibtexLibrary.Tokens;
using LexicalAnalyzer;

namespace BibtexLibrary.Tokenizer
{
    public class Tokenizer
    {
        private readonly ExpressionDictionary _dictionary;
        private readonly string _input;
        private int _counter;

        public Tokenizer(ExpressionDictionary dictionary, string input)
        {
            _dictionary = dictionary;
            _input = input;
        }

        public AbstractToken NextToken()
        {
            // Loop through all tokens and check if they match the input string
            foreach (KeyValuePair<Type, string> pair in _dictionary)
            {
                // TODO: See if substring does not impose a to harsh performance drop
                Match match = Regex.Match(_input.Substring(_counter), pair.Value);

                if (match.Success)
                {
                    _counter += match.Value.Length;

                    if (pair.Key.IsSubclassOf(typeof(AbstractToken)))
                    {
                        // Create new instance of the specified type with the found value as parameter
                        AbstractToken token = (AbstractToken)Activator.CreateInstance(pair.Key, new object[] { match.Value, _counter - match.Value.Length }, null);

                        return token;
                    }

                }
            }

            throw new MatchException(_input[_counter].ToString(CultureInfo.InvariantCulture), _counter);
        }

        public AbstractToken Peek()
        {
            return new NewLine();     
        }

        public IEnumerable<AbstractToken> GetAllTokens()
        {
            return new List<AbstractToken>();
        } 
    }
}
