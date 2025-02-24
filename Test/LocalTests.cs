using Newtonsoft.Json;
using NUnit.Framework;

namespace Test
{
    public abstract class LocalTests
    {
        /// <summary>
        /// Given file in dat folder, returns its contents
        /// </summary>
        protected string getFileContent(string fileName, string pathToDataFolder = "..\\..\\..\\dat")
        {
            string folder = TestContext.CurrentContext.TestDirectory;

            folder = Path.Combine(folder, pathToDataFolder);

            string path = Path.Combine(folder, fileName);

            string content = File.ReadAllText(path);

            return content;
        }

        /// <summary>
        /// Asserts that JSON property gets deserialized properly
        /// </summary>
        protected void AssertAreEqual<T>(string f, object expected, Func<T,object> setProperty)
        {
            string json = getFileContent(f);

            var deserializedObject = JsonConvert.DeserializeObject<T>(json) ?? throw new ArgumentNullException("Failed to deserialize input JSON");

            var actual = setProperty(deserializedObject);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}