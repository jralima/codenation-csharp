using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManagerTest
    {      
        [Fact]
        public void Should_Be_Unique_Ids_For_Teams()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            Assert.Throws<UniqueIdentifierException>(() =>
                manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2"));
        }
 
        [Fact]
        public void Should_Be_Valid_Player_When_Set_Captain()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);
            manager.SetCaptain(1);
            Assert.Equal(1, manager.GetTeamCaptain(1));
            Assert.Throws<PlayerNotFoundException>(() =>
                manager.SetCaptain(2));
        }

        [Fact]
        public void Should_Ensure_Sort_Order_When_Get_Team_Players()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() {15, 2, 33, 4, 13};
            for(int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", DateTime.Today, 0, 0);

            playersIds.Sort();
            Assert.Equal(playersIds, manager.GetTeamPlayers(1));
        }

        [Theory]
        [InlineData("10,20,300,40,50", 2)]
        [InlineData("50,240,3,1,50", 1)]
        [InlineData("10,22,24,3,24", 2)]
        public void Should_Choose_Best_Team_Player(string skills, int bestPlayerId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var skillsLevelList = skills.Split(',').Select(x => int.Parse(x)).ToList();
            for(int i = 0; i < skillsLevelList.Count(); i++)
                manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, skillsLevelList[i], 0);

            Assert.Equal(bestPlayerId, manager.GetBestTeamPlayer(1));
        }

        [Theory]
        [InlineData("Azul;Vermelho", "Azul;Amarelo", "Amarelo")]
        [InlineData("Azul;Vermelho", "Amarelo;Laranja", "Amarelo")]
        [InlineData("Azul;Vermelho", "Azul;Vermelho", "Vermelho")]
        public void Should_Choose_Right_Color_When_Get_Visitor_Shirt_Color(string teamColors, string visitorColors, string visitorMatchColor)
        {
            long teamId = 1;
            long visitorTeamId = 2;
            var teamColorList = teamColors.Split(";");
            var visitorColorList = visitorColors.Split(";");

            var manager = new SoccerTeamsManager();
            manager.AddTeam(teamId, $"Time {teamId}", DateTime.Now, teamColorList[0], teamColorList[1]);
            manager.AddTeam(visitorTeamId, $"Time {visitorTeamId}", DateTime.Now, visitorColorList[0], visitorColorList[1]);

            Assert.Equal(visitorMatchColor, manager.GetVisitorShirtColor(teamId, visitorTeamId));
        }

        [Theory]
        [InlineData("7,50,33,2,70", 10, "7,12,8,5,13,2,10,3,11,14")]
        [InlineData("10,240,73,1,50", 5, "7, 12, 8, 5, 10")]
        public void Should_Sort_All_Players_By_Skill_When_Get_Top_Players(String skillsMap, Int32 top, String topPlayersIds)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var skillsLevelList = skillsMap.Split(',').Select(x => int.Parse(x)).ToList();
            var topListId = topPlayersIds.Split(',').Select(x => int.Parse(x)).ToList();

            for (int i = 0; i < skillsLevelList.Count(); i++)
                manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, skillsLevelList[i], 0);
                       
            Assert.True(topListId.Equals(manager.GetTopPlayers(top)));
        }

        [Theory]
        [InlineData("1509.10;200.20;3300;450020.11;50.0", 3)]
        [InlineData("15090;45000;3300;2000;5000", 1)]
        public void Should_Choose_Higher_Salary_Player(String salaries, Int32 highSalaryPlayerId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var salariesList = salaries.Split(';').Select(x => decimal.Parse(x)).ToList();

            for (int i = 0; i < salariesList.Count(); i++)
                manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, 0, salariesList[i]);

            Assert.Equal(highSalaryPlayerId, manager.GetHigherSalaryPlayer(1));
        }


        [Theory]
        [InlineData("17,22,50,33,50", 2)]
        [InlineData("50,24,13,15,16", 0)]
        [InlineData("15,20,33,11,50", 4)]
        public void Should_Choose_Older_Team_Player(String ages, Int32 olderPlayerId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var agesList = ages.Split(',').Select(x => int.Parse(x)).ToList();

            for (int i = 0; i < agesList.Count(); i++)
            {

                DateTime nasc = DateTime.Today.AddYears(-agesList[i]);
                manager.AddPlayer(i, 1, $"Jogador {i}", nasc, 0, 0);
            }

            Assert.Equal(olderPlayerId, manager.GetHigherSalaryPlayer(1));
        }

        [Theory]
        [InlineData("301,781,397,882,121,344,463,688,908,547", "121,301,344,397,463,547,688,781,882,908")]
        [InlineData("51,22,23,42,5,1", "1,5,22,23,42,51")]
        public void Should_Ensure_Sort_Order_When_Get_Teams(String teams, String teamsOrd)
        {
            var manager = new SoccerTeamsManager();
            var teamsList = teams.Split(',').Select(x => int.Parse(x)).ToList();
            var teamsListord = teamsOrd.Split(',').Select(x => int.Parse(x)).ToList();

            for (int i = 0; i < teamsList.Count(); i++)
            {
                manager.AddTeam(i, $"Time {i}", DateTime.Now, "cor 1", "cor 2");                               
            }
            for (int i = 0; i < teamsList.Count(); i++)
            {
                Assert.True(teamsListord.Equals(manager.GetOlderTeamPlayer(teamsList[i])));
            }
        }      
    }
}
