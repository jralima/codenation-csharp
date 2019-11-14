using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class SubmissionModelTest: ModelBaseTest
    {
        public SubmissionModelTest()
            : base(new CodenationContext())
        {            
            Model = "Codenation.Challenge.Models.Submission";
            Table = "submission";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Should_Has_Primary_Key()
        {
            AssertPrimaryKeys("user_id", "challenge_id");
        }

        [Theory]
        [InlineData("user_id", false, typeof(int), null)]
        [InlineData("challenge_id", false, typeof(int), null)]
        [InlineData("score", false, typeof(decimal), null)]
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Should_Has_Field(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            AssertField(fieldName, isNullable, fieldType, fieldSize);    
        }

        [Theory]
        [InlineData("user_id", "user", false, "id")]
        [InlineData("challenge_id", "challenge", false, "id")]
        public void Should_Has_Foreing_Key(string fieldName, string relatedTable, bool isNullable,  string relatedKey)
        {
            AssertForeignKey(fieldName, relatedTable, !isNullable, relatedKey);
        }

    }
}