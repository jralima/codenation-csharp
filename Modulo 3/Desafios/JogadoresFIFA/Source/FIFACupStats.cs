using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Source;

namespace Codenation.Challenge
{
    public class FIFACupStats
    {
        #region Constantes
        const int COLUNA_ID = 0;
        const int COLUNA_FULL_NAME = 2;
        const int COLUNA_NATIONALITY = 14;
        const int COLUNA_CLUB = 3;
        const int COLUNA_EUR_RELEASE_CLAUSE = 18;
        const int COLUNA_BIRTH_DATE = 8;
        const int COLUNA_AGE = 6;
        const int COLUNA_EUR_WAGE = 17;
        #endregion

        public string CSVFilePath { get; set; } = "data.csv";
        public Encoding CSVEncoding { get; set; } = Encoding.UTF8;

        private readonly List<FifaObject> ListFifaObject;

        public void CarregarArquivo()
        {
            StreamReader stream = new StreamReader(CSVFilePath);

            string linha;
            stream.ReadLine();

            while ((linha = stream.ReadLine()) != null)
            {
                string[] coluna = linha.Split(',');
                var player = new FifaObject
                {
                    Eur_Release_Clause = -1,
                    Eur_Wage = -1,
                    Age = -1,
                    Id = -1,
                    Full_Name = coluna[COLUNA_FULL_NAME],
                    Nationality = coluna[COLUNA_NATIONALITY],
                    Club = coluna[COLUNA_CLUB]
                };

                #region Validações

                if (int.TryParse(coluna[COLUNA_ID], out int _Id))
                    player.Id = _Id;

                if (int.TryParse(coluna[COLUNA_AGE], out int _Age))
                    player.Age = _Age;

                if (DateTime.TryParse(coluna[COLUNA_BIRTH_DATE], out DateTime _birth_Date))
                    player.Birth_Date = _birth_Date;

                if (!string.IsNullOrEmpty(coluna[COLUNA_EUR_RELEASE_CLAUSE]))
                {
                    string _Eur_Release_Clause = coluna[COLUNA_EUR_RELEASE_CLAUSE].Replace('.', ',');
                    player.Eur_Release_Clause = Convert.ToDecimal(_Eur_Release_Clause);
                }

                if (!string.IsNullOrEmpty(coluna[COLUNA_EUR_RELEASE_CLAUSE]))
                {
                    string _Eur_Wage = coluna[COLUNA_EUR_WAGE].Replace('.', ',');
                    player.Eur_Wage = Convert.ToDecimal(_Eur_Wage);
                }
                #endregion

                ListFifaObject.Add(player);
            }
            stream.Close();
        }

        public FIFACupStats()
        {
            ListFifaObject = new List<FifaObject>();
            CarregarArquivo();
        }

        // Deve retornar quantas nacionalidades diferentes existem no arquivo. Deve se basear nos dados da coluna nationality do arquivo. 
        // Não considerar os registros sem a nacionalidade.
        public int NationalityDistinctCount()
        {
            return ListFifaObject.Where(x => x.Nationality != null && x.Nationality != "").GroupBy(c => c.Nationality).Distinct().ToList().Count();
        }

        // Deve retornar quantos clubes diferentes existem no arquivo. Deve se basear nos dados da coluna club do arquivo. Não considerar os registros sem o nome do clube.
        public int ClubDistinctCount()
        {
            return ListFifaObject.Where(x => x.Club != null && x.Club != "").GroupBy(c => c.Club).Distinct().ToList().Count();
        }

        // Deve retornar uma lista com o nome completo dos 20 primeiros jogadores. Deve se basear nos dados da coluna full_name do arquivo.
        public List<string> First20Players()
        {
            var listPlayers = ListFifaObject.Take(20).ToList();
            var listReturn = new List<string>();
            foreach (var item in listPlayers)
            {
                listReturn.Add(item.Full_Name);
            }
            return listReturn;
        }

        // Deve retornar quem são os 10 jogadores que possuem as maiores cláusulas de rescisão. 
        // Deve se basear nas colunas colunas full_name e eur_release_clause do arquivo.
        public List<string> Top10PlayersByReleaseClause()
        {
            var listPlayers = ListFifaObject.OrderByDescending(x => x.Eur_Release_Clause).ToList();
            var listReturn = new List<string>();
            foreach (var item in listPlayers)
            {
                listReturn.Add(item.Full_Name);
            }
            return listReturn.Take(10).ToList();
        }

        // Deve retornar quem são os 10 jogadores mais velhos. Deve se basear nos dados das colunas full_name e birth_date do arquivo. 
        // Utilize a coluna eur_wage, que representa o salário, como critério de desempate. Jogadores mais velhos que ganham mais têm a preferência.
        public List<string> Top10PlayersByAge()
        {
            var listOlder = ListFifaObject.Where(x => x.Birth_Date != null).OrderBy(x => x.Birth_Date).ToList();

            decimal playerEur_Wage = -1;
            DateTime MaxBirthDate = new DateTime(1900, 1, 1);
            var listReturn = new List<string>();
            foreach (var item in listOlder)
            {
                if (playerEur_Wage == -1)
                {
                    playerEur_Wage = item.Eur_Wage;
                    MaxBirthDate = item.Birth_Date;
                    listReturn.Add(item.Full_Name);
                }
                else
                {
                    if (item.Birth_Date >= MaxBirthDate)
                    {
                        playerEur_Wage = item.Eur_Wage;
                        MaxBirthDate = item.Birth_Date;
                        listReturn.Add(item.Full_Name);
                    }
                }
            }

            return listReturn.Take(10).ToList();
        }

        // Deve retornar um dicionário com a quantidade de jogadores por idade. Deve se basear nos dados da coluna age. 
        // Para isso, construa um dicionário em que as chaves são as diferentes idades e o valor a contagem de jogadores com aquela idade.
        public Dictionary<int, int> AgeCountMap()
        {
            var dicReturn = new Dictionary<int, int>();
            //var listOlder = ListFifaObject.OrderBy(c => c.Age).GroupBy(c => c.Age).ToList();

            var listOlder = ListFifaObject.OrderBy(p => p.Age).GroupBy(p => p.Age,
              (key, group) => new { Age = key, Count = group.Count() }).ToList();


            foreach (var item in listOlder)
            {
                dicReturn.Add(item.Age, item.Count);
            }

            return dicReturn;
        }
    }
}
