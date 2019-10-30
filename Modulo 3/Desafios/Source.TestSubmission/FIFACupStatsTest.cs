using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Codenation.Challenge
{
    public class FIFACupStatsTest
    {
        [Fact]
        public void Should_Return_Right_Nationality_Distinct_Count()
        {
            var cup = new FIFACupStats();
            Assert.Equal(164, cup.NationalityDistinctCount());            
        }

        [Fact]
        public void Should_Return_Right_Club_Distinct_Count()
        {
            var cup = new FIFACupStats();
            Assert.Equal(647, cup.ClubDistinctCount());            
        }

        [Fact]
        public void Shoud_Return_20_Itens_When_Get_Top_Players()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.First20Players();
            Assert.NotNull(topPlayers);
            Assert.Equal(20, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_Right_Top_20_Players()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.First20Players();
            Assert.NotNull(topPlayers);
            
            var expected = new List<string>() {
                "C. Ronaldo dos Santos Aveiro",
				"Lionel Messi",
				"Neymar da Silva Santos Jr.",
				"Luis Suárez",
				"Manuel Neuer",
				"Robert Lewandowski",
				"David De Gea Quintana",
				"Eden Hazard",
				"Toni Kroos",
				"Gonzalo Higuaín",
				"Sergio Ramos García",
				"Kevin De Bruyne",
				"Thibaut Courtois",
				"Alexis Sánchez",
				"Luka Modrić",
				"Gareth Bale",
				"Sergio Agüero",
				"Giorgio Chiellini",
				"Gianluigi Buffon",
				"Paulo Dybala"                
            };
            Assert.Equal(expected, topPlayers);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Release_Clause()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByReleaseClause();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_Right_Top_10_Players_By_Release_Clause()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByReleaseClause();
            Assert.NotNull(topPlayers);
            
            var expected = new List<string>() {
                "Neymar da Silva Santos Jr.",
				"Lionel Messi",
				"Luis Suárez",
				"C. Ronaldo dos Santos Aveiro",
				"Eden Hazard",
				"Toni Kroos",
				"Kevin De Bruyne",
				"Antoine Griezmann",
				"Robert Lewandowski",
				"Gareth Bale"
            };
            Assert.Equal(expected, topPlayers);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Age()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByAge();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_Right_Top_10_Players_By_Age()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByAge();
            Assert.NotNull(topPlayers);
            
            var expected = new List<string>() {
                "Barry Richardson",
				"Essam El Hadary",
				"Óscar Pérez",
				"Jimmy Walker",
				"Danny Coyne",
				"Chris Day",
				"Joaquim Manuel Sampaio Silva",
				"Kjetil Wæhler",
				"Timmy Simons",
				"Benjamin Nivet"
            };
            Assert.Equal(expected, topPlayers);
        }

        [Fact]
        public void Shoud_Be_16_The_Minimum_Age_In_Get_Age_Count_Map()
        {
            var cup = new FIFACupStats();
            var ageMap = cup.AgeCountMap();
            Assert.NotNull(ageMap);
            Assert.Equal(16, ageMap.Keys.Min());
        }

        [Fact]
        public void Shoud_Be_47_The_Maximum_Age_When_Get_Age_Count_Map()
        {
            var cup = new FIFACupStats();
            var ageMap = cup.AgeCountMap();
            Assert.NotNull(ageMap);
            Assert.Equal(47, ageMap.Keys.Max());
        }

        [Fact]
        public void Shoud_Return_Right_Age_Count_Map()
        {
            var cup = new FIFACupStats();
            var ageMap = cup.AgeCountMap();
            Assert.NotNull(ageMap);
            
            var expected = new Dictionary<int, int>();
            expected.Add(16, 18);
			expected.Add(17, 270);
			expected.Add(18, 682);
			expected.Add(19, 1088);
			expected.Add(20, 1252);
			expected.Add(21, 1275);
			expected.Add(22, 1324);
			expected.Add(23, 1395);
			expected.Add(24, 1321);
			expected.Add(25, 1515);
			expected.Add(26, 1199);
			expected.Add(27, 1153);
			expected.Add(28, 1053);
			expected.Add(29, 1127);
			expected.Add(30, 807);
			expected.Add(31, 666);
			expected.Add(32, 506);
			expected.Add(33, 610);
			expected.Add(34, 271);
			expected.Add(35, 188);
			expected.Add(36, 137);
			expected.Add(37, 69);
			expected.Add(39, 18);
			expected.Add(38, 38);
			expected.Add(40, 4);
			expected.Add(41, 3);
			expected.Add(43, 2);
			expected.Add(44, 2);
			expected.Add(47, 1);
            Assert.Equal(expected, ageMap);
        }

    }
}
