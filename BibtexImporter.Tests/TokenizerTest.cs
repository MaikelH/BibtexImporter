using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BibtexLibrary.Tokenizer;
using BibtexLibrary.Tokens;
using NUnit.Framework;
using Text = BibtexLibrary.Tokens.Text;

namespace BibtexImporter.Tests
{
    [TestFixture]
    public class TokenizerTest
    {
        [Test]
        public void TestTokenizer1()
        {
            Tokenizer tokenizer = new Tokenizer(new ExpressionDictionary(), "test");

            Assert.AreEqual(new BibtexLibrary.Tokens.Text("test"),tokenizer.NextToken());
        }

        [Test]
        public void TestTokenizerSimple()
        {
            Tokenizer tokenizer = new Tokenizer(new ExpressionDictionary(), "@book{ }");
            List<AbstractToken> tokens = tokenizer.GetAllTokens().ToList();

            Assert.AreEqual(4, tokens.Count());
            Assert.AreEqual(new At("@"), tokens[0]);
            Assert.AreEqual(new Text("book", 1), tokens[1]);
            Assert.AreEqual(new OpeningBrace("{", 5), tokens[2]);
            Assert.AreEqual(new ClosingBrace(" }" ,6), tokens[3]);
        }

        public void TestTokenizer2()
        {
            Tokenizer tokenizer = new Tokenizer(new ExpressionDictionary(), @"@book{ aaker:1981a,
                                                                                  author = {David A. Aaker},
                                                                                  title = {Multivariate Analysis in Marketing},
                                                                                  edition = {2},
                                                                                  publisher = {The Scientific Press},
                                                                                  year = {1981},
                                                                                  address = {Palo Alto},
                                                                                  topic = {multivariate-statistics;market-research;}
                                                                                 }");

            Assert.AreEqual(new BibtexLibrary.Tokens.Text("test"),tokenizer.NextToken());
        }
    }
}
