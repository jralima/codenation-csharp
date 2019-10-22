using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        [Fact]
        public void Should_Not_Accept_Null_When_Crypt()
        {            
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentNullException>(() => cypher.Crypt(null));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("d1e2f3g4h5i6j7k8l9m0", cypher.Crypt("a1b2c3d4e5f6g7h8i9j0"));
        }

        [Fact]
        public void Should_Must_Return_Empty_When_Empty_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal(string.Empty, cypher.Crypt(string.Empty));
        }
        /*
        [Fact]
        public void Should_Not_Accept_Special_Characteres_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Crypt("abcçáé"));
        }
        */

        [Fact]
        public void Should_Convert_To_Lower_Case_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("xyz", cypher.Decrypt("abc"));
        }

        [Fact]
        public void Should_Use_Cesar_Cypher_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("the quick brown fox jumps over the lazy dog", cypher.Decrypt("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj"));
        }

        [Fact]
        public void Should_Ensure_Letter_Or_Number_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("@abc#"));
        }

        [Fact]
        public void Should_Ensure_Letter_Or_Number_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Crypt("|abc@"));
        }
    }
}
