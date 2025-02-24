using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ChatRequestTests
    {

        [TestCase("chatRequest.00.json", "c6f2d009-77ca-40d9-9de5-6d19716e1b4d")]
        public void Id(string f, string expected)
        {
            string actual = "";
            Assert.That(actual, Is.EqualTo(expected));
        }


    }  
}
