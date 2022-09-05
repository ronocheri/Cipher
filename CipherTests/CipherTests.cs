using Cipher;
using Xunit;

namespace CipherTests
{
    public class CipherTests
    {
        private const string Key = "BCDEFGHIJKLMNOPQRSTUVWXYZA";

        [Theory]
        [InlineData("AAA", "BBB")]
        [InlineData("ZZZ", "AAA")]
        [InlineData("CYPHER", "DZQIFS")]
        public void EncryptionTest(string message, string expected)
        {
            ICodeValueCipher cipher = new CodeValueCipher();
            var result = cipher.Encrypt(message, Key);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("BBB", "AAA")]
        [InlineData("AAA", "ZZZ")]
        [InlineData("DZQIFS", "CYPHER")]
        public void DecryptionTest(string message, string expected)
        {
            ICodeValueCipher cipher = new CodeValueCipher();
            var result = cipher.Decrypt(message, Key);
            Assert.Equal(expected, result);
        }
    }
}
