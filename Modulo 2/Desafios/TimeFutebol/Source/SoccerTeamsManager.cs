using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source.src;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        List<Team> teams;
        List<Player> players;

        private bool ValidParam(long param)
        {
            return (param < 0);
        }

        private bool ValidParam(decimal param)
        {
            return (param < 0);
        }

        private bool ValidParam(string param)
        {
            return (string.IsNullOrEmpty(param) || string.IsNullOrWhiteSpace(param));
        }

        private bool ValidParam(DateTime param)
        {
            return ((param == null));
        }

        private void ValidTeamFound(long teamId)
        {
            var listTeamns = teams.Where(x => x.Id == teamId).ToList();

            if (listTeamns.Count == 0)
                throw new TeamNotFoundException();
        }

        public SoccerTeamsManager()
        {
            teams = new List<Team>();
            players = new List<Player>();
        }

        // Realiza a inclusão de um novo time.
        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            // parâmetro obrigatório
            if (ValidParam(id) || ValidParam(name) || ValidParam(createDate) || ValidParam(mainShirtColor) || ValidParam(secondaryShirtColor))
            {
                throw new NotImplementedException();
            }

            // Caso o id já exista
            if (teams.Where(x => x.Id == id).Count() > 0)
            {
                throw new UniqueIdentifierException();
            }

            teams.Add(new Team(id, name, createDate, mainShirtColor, secondaryShirtColor));

        }

        // Realiza a inclusão de um novo jogador.
        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            // parâmetro obrigatório
            if (ValidParam(id) || ValidParam(teamId) || ValidParam(name) || ValidParam(birthDate) || ValidParam(skillLevel) || ValidParam(salary))
            {
                throw new NotImplementedException();
            }

            // Caso o id já exista
            if (players.Where(x => x.Id == id).Count() > 0)
            {
                throw new UniqueIdentifierException();
            }

            // Caso o time informado não exista
            if (teams.Where(x => x.Id == teamId).Count() == 0)
            {
                throw new TeamNotFoundException();
            }

            players.Add(new Player(id, teamId, name, birthDate, skillLevel, salary, false));

        }

        // Define um jogador como capitão do seu time. Um time deve ter apenas um capitão, por tanto o capitão anterior voltará a ser apenas jogador.
        public void SetCaptain(long playerId)
        {
            // parâmetro obrigatório
            if (ValidParam(playerId))
            {
                throw new NotImplementedException();
            }

            // Caso o jogador informado não exista, retornar
            var listPlay = players.Where(x => x.Id == playerId).ToList();
            if (listPlay.Count() == 0)
            {
                throw new PlayerNotFoundException();
            }

            var listPlayOld = players.Where(x => x.IsCaptain == true).ToList();

            if (listPlayOld.Count > 0)
                listPlayOld[0].IsCaptain = false;

            listPlay[0].IsCaptain = true;
        }

        // Mostra o id do capitão do time.
        public long GetTeamCaptain(long teamId)
        {
            // parâmetro obrigatório
            if (ValidParam(teamId))
            {
                throw new NotImplementedException();
            }

            ValidTeamFound(teamId);

            // Caso o time informado não tenha um capitão
            var listPlay = players.Where(x => x.TeamId == teamId || x.IsCaptain == true).ToList();

            if (listPlay.Count == 0)
                throw new CaptainNotFoundException();

            return listPlay[0].Id;
        }

        // Retorna o name do jogador.
        public string GetPlayerName(long playerId)
        {
            // parâmetro obrigatório
            if (ValidParam(playerId))
            {
                throw new NotImplementedException();
            }

            var listPlay = players.Where(x => x.Id == playerId).ToList();

            if (listPlay.Count == 0)
                throw new PlayerNotFoundException();

            return listPlay[0].Name;
        }

        // Retorna o name do time.
        public string GetTeamName(long teamId)
        {
            var listTeamns = teams.Where(x => x.Id == teamId).ToList();

            if (listTeamns.Count == 0)
                throw new TeamNotFoundException();

            return listTeamns[0].Name;
        }

        // Retorna a lista com o id de todos os jogadores do time, ordenada pelo id.
        public List<long> GetTeamPlayers(long teamId)
        {
            // parâmetro obrigatório
            if (ValidParam(teamId))
            {
                throw new NotImplementedException();
            }

            ValidTeamFound(teamId);

            var listPlay = players.Where(x => x.TeamId == teamId).ToList();

            if (listPlay.Count == 0)
                throw new PlayerNotFoundException();

            var returnList = new List<long>();
            foreach (var item in listPlay)
            {
                returnList.Add(item.Id);
            }

            returnList.Sort();
            return returnList;
        }

        // Retorna o id do melhor jogador do time. Utilizar o menor id como critério de desempate.
        public long GetBestTeamPlayer(long teamId)
        {
            // parâmetro obrigatório
            if (ValidParam(teamId))
            {
                throw new NotImplementedException();
            }

            ValidTeamFound(teamId);

            var listPlay = players.Where(x => x.TeamId == teamId).ToList();

            if (listPlay.Count == 0)
                throw new PlayerNotFoundException();

            var listPlayersOrder = listPlay.OrderByDescending(x => x.SkillLevel).ToList();

            int MaxSkillLevel = 0;
            long playerId = 0;
            foreach (var item in listPlayersOrder)
            {
                if (item.SkillLevel >= MaxSkillLevel)
                {
                    MaxSkillLevel = item.SkillLevel;

                    if(playerId == 0)
                    {
                        playerId = item.Id;
                    }
                    else
                    {
                        if(item.Id < playerId)
                            playerId = item.Id;
                    }
                }
            }            
            return playerId;
        }

        // Retorna o id do jogador mais velho do time. Usar o menor id como critério de desempate.
        public long GetOlderTeamPlayer(long teamId)
        {
            // parâmetro obrigatório
            if (ValidParam(teamId))
            {
                throw new NotImplementedException();
            }

            ValidTeamFound(teamId);

            var listPlay = players.Where(x => x.TeamId == teamId).ToList();

            if (listPlay.Count == 0)
                throw new PlayerNotFoundException();

            listPlay.OrderByDescending(x => x.BirthDate);

            DateTime MaxBirthDate = new DateTime(1900, 1, 1);
            long playerId = 0;
            foreach (var item in listPlay)
            {
                if (item.BirthDate >= MaxBirthDate)
                {
                    MaxBirthDate = item.BirthDate;

                    if (playerId == 0)
                    {
                        playerId = item.Id;
                    }
                    else
                    {
                        if (item.Id < playerId)
                            playerId = item.Id;
                    }
                }
            }

            return playerId;
        }

        // Retorna uma lista com o id de todos os times cadastrado, ordenada pelo id.
        // Retornar uma lista vazia caso não encontre times cadastrados.
        public List<long> GetTeams()
        {            
            if (teams.Count == 0)
                throw new TeamNotFoundException();

            //teams.OrderBy(x => x.Id).ToList();

            var returnList = new List<long>();
            foreach (var item in teams)
            {
                returnList.Add(item.Id);
            }

            returnList.Sort();
            return returnList;
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            // parâmetro obrigatório
            if (ValidParam(teamId))
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        // Retorna o salário do jogador.
        public decimal GetPlayerSalary(long playerId)
        {
            // parâmetro obrigatório
            if (ValidParam(playerId))
            {
                throw new NotImplementedException();
            }

            var listPlay = players.Where(x => x.Id == playerId).ToList();

            if (listPlay.Count == 0)
                throw new PlayerNotFoundException();

            return listPlay[0].Salary;
        }

        // Retorna uma lista com o id dos top melhores jogadores, utilizar o menor id como critério de desempate.
        public List<long> GetTopPlayers(int top)
        {
            // parâmetro obrigatório
            if (ValidParam(top))
            {
                throw new NotImplementedException();
            }

            var listPlay = players.Where(x => x.TeamId == top).ToList();

            if (listPlay.Count == 0)
                throw new PlayerNotFoundException();

            var listPlayersOrder = listPlay.OrderByDescending(x => x.SkillLevel).ToList();

            int MaxSkillLevel = 0;
            long playerId = 0;
            foreach (var item in listPlayersOrder)
            {
                if (item.SkillLevel >= MaxSkillLevel)
                {
                    MaxSkillLevel = item.SkillLevel;

                    if (playerId == 0)
                    {
                        playerId = item.Id;
                    }
                    else
                    {
                        if (item.Id < playerId)
                            playerId = item.Id;
                    }
                }
            }
            return new List<long>(); // ajustar
        }

        // Retorna a cor da camisa do time adversário. 
        // Caso a mainShirtColor do time da casa seja igual a mainShirtColor do time de fora, retornar 
        // secondaryShirtColor do time de fora. Caso a mainShirtColor do time da casa seja diferente da
        // mainShirtColor do time de fora, retornar mainShirtColor do time de fora.
        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            // parâmetro obrigatório
            if (ValidParam(teamId) || ValidParam(visitorTeamId))
            {
                throw new NotImplementedException();
            }

            if (teams.Count == 0)
                throw new TeamNotFoundException();

            var homeTeam = teams.Where(x => x.Id == teamId).ToList();
            if (homeTeam.Count() == 0)
            {
                throw new TeamNotFoundException();
            }

            var visitorTeam = teams.Where(x => x.Id == visitorTeamId).ToList();
            if (visitorTeam.Count() == 0)
            {
                throw new TeamNotFoundException();
            }           

            // Caso a mainShirtColor do time da casa seja igual a mainShirtColor do time de fora, retornar secondaryShirtColor do time de fora.
            if (homeTeam[0].MainShirtColor == visitorTeam[0].MainShirtColor)
                return visitorTeam[0].SecondaryShirtColor;

            // Caso a mainShirtColor do time da casa seja diferente da mainShirtColor do time de fora, retornar mainShirtColor do time de fora.
            if (homeTeam[0].MainShirtColor != visitorTeam[0].MainShirtColor)
                return visitorTeam[0].MainShirtColor;

            throw new NotImplementedException();
        }

    }
}
