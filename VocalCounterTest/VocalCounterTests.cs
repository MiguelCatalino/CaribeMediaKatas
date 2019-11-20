using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VocalCounterTest
{
    [TestClass]
    public class VocalCounterTests
    {
        [TestMethod]
        public void ShortTextTest()
        {
            string text = "Hello world!";
            string result = "e → 1, o → 2";
            Evaluator(text, result);
        }

        [TestMethod]
        public void NotVocalTest()
        {
            string text = "MMMMMMMMM";
            string result = string.Empty;
            Evaluator(text, result);
        }
        [TestMethod]
        public void EmptyTextTest()
        {
            string text = "";
            string result = string.Empty;
            Evaluator(text, result);
        }
        [TestMethod]
        public void AccentsVocalTest()
        {
            string text = "Instituto Nacional de Protección de los Derechos del Consumidor (Pro Consumidor)";
            string result = "i → 6, u → 3, o → 11, a → 2, e → 6";
            Evaluator(text, result);
        }
        private void Evaluator(string text, string result)
        {
            var returnValue = VocalCounter.VocalCounter.Counter(text);
            Assert.AreEqual(result, returnValue);
        }
    }
}
