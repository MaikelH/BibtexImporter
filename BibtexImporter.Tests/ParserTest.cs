using System.Linq;
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

            Assert.AreEqual(1, file.Entries.Count);
            Assert.AreEqual("aaker:1912", file.Entries.First().Key);
            Assert.AreEqual("book", file.Entries.First().Type);
            Assert.AreEqual(1, file.Entries.First().Tags.Count);
            Assert.AreEqual("author", file.Entries.First().Tags.First().Key);
            Assert.AreEqual("David A. Aaker", file.Entries.First().Tags.First().Value);
        }

        [Test]
        public void MultipleTagsTest()
        {
            Tokenizer tokenizer = new Tokenizer(new ExpressionDictionary(), @"@book{ aaker:1912,
                                                                                author = {David A. Aaker},
                                                                                title = {Multivariate statistics}
                                                                            }");
            BibtexParser parser = new BibtexParser(tokenizer);
            BibtexFile file = parser.Parse();

            Assert.AreEqual(1, file.Entries.Count);
            Assert.AreEqual("aaker:1912", file.Entries.First().Key);
            Assert.AreEqual("book", file.Entries.First().Type);
            Assert.AreEqual(1, file.Entries.First().Tags.Count);
            Assert.AreEqual("author", file.Entries.First().Tags.First().Key);
            Assert.AreEqual("David A. Aaker", file.Entries.First().Tags.First().Value);
        }
    }
}
