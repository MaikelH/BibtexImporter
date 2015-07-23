using BibtexLibrary;
using BibtexLibrary.Parser;
using BibtexLibrary.Tokenizer;
using NUnit.Framework;

namespace BibtexImporter.Tests
{
    [TestFixture]
    class ParserTest
    {
        [Test]
        public void SimpleParserText()
        {
            Tokenizer tokenizer = new Tokenizer(new ExpressionDictionary(), @"@book{ aaker:1912,
                                                                                author = {David A. Aaker}
                                                                            }");
            BibtexParser parser = new BibtexParser(tokenizer);
            BibtexFile file = parser.Parse();
        }
    }
}
