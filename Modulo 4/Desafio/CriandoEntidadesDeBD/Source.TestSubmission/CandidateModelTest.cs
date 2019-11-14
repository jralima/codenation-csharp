using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class CandidateModelTest: ModelBaseTest
    {
        public CandidateModelTest()
            : base(new CodenationContext())
        {            
            Model = "Codenation.Challenge.Models.Candidate";
            Table = "candidate";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Should_Has_Primary_Key()
        {
            AssertPrimaryKeys("user_id", "acceleration_id", "company_id");
        }

        [Theory]
        [InlineData("user_id", false, typeof(int), null)]
        [InlineData("acceleration_id", false, typeof(int), null)]
        [InlineData("company_id", false, typeof(int), null)]
        [InlineData("status", false, typeof(int), null)]
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Should_Has_Field(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            AssertField(fieldName, isNullable, fieldType, fieldSize);    
        }

        [Theory]
        [InlineData("user_id", "user", false, "id")]
        [InlineData("acceleration_id", "acceleration", false, "id")]
        [InlineData("company_id", "company", false, "id")]
        public void Should_Has_Foreing_Key(string fieldName, string relatedTable, bool isNullable,  string relatedKey)
        {
            AssertForeignKey(fieldName, relatedTable, !isNullable, relatedKey);
        }

    }
}