using GrokSharp.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Test
{
    public abstract class LocalTests
    {

        protected string getFileContent(string fileName)
        {
            string folder = TestContext.CurrentContext.TestDirectory;

            folder = Path.Combine(folder, "..\\..\\..\\dat");

            string path = Path.Combine(folder, fileName);

            string content = File.ReadAllText(path);

            return content;
        }

        protected void AssertAreEqual<T>(string f, object expected, Func<T,object> setProperty)
        {
            string json = getFileContent(f);

            var deserializedObject = JsonConvert.DeserializeObject<T>(json);

            var actual = setProperty(deserializedObject);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}