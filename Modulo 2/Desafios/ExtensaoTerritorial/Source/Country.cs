using System;
using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {
        private readonly State[] states;

        private void CriarListaDeEstados()
        {

            states.SetValue(new State("Acre", "AC", 164123.040M), 0);
            states.SetValue(new State("Alagoas", "AL", 27778.506M), 1);
            states.SetValue(new State("Amapá", "AP", 142828.521M), 2);
            states.SetValue(new State("Amazonas", "AM", 1559159.148M), 3);
            states.SetValue(new State("Bahia", "BA", 564733.177M), 4);
            states.SetValue(new State("Ceará", "CE", 148920.472M), 5);
            states.SetValue(new State("Distrito Federal", "DF", 5779.999M), 6);
            states.SetValue(new State("Espírito Santo", "ES", 46095.583M), 7);
            states.SetValue(new State("Goiás", "GO", 340111.783M), 8);
            states.SetValue(new State("Maranhão", "MA", 331937.450M), 9);
            states.SetValue(new State("Mato Grosso", "MT", 903366.192M), 10);
            states.SetValue(new State("Mato Grosso do Sul", "MS", 357145.532M), 11);
            states.SetValue(new State("Minas Gerais", "MG", 586522.122M), 12);
            states.SetValue(new State("Pará", "PA", 1247954.666M), 13);
            states.SetValue(new State("Paraíba", "PB", 56585.000M), 14);
            states.SetValue(new State("Paraná", "PR", 199307.922M), 15);
            states.SetValue(new State("Pernambuco", "PE", 98311.616M), 16);
            states.SetValue(new State("Piauí", "PI", 251577.738M), 17);
            states.SetValue(new State("Rio de Janeiro", "RJ", 43780.172M), 18);
            states.SetValue(new State("Rio Grande do Norte", "RN", 52811.047M), 19);
            states.SetValue(new State("Rio Grande do Sul", "RS", 281730.223M), 20);
            states.SetValue(new State("Rondônia", "RO", 237590.547M), 21);
            states.SetValue(new State("Roraima", "RR", 224300.506M), 22);
            states.SetValue(new State("Santa Catarina", "SC", 95736.165M), 23);
            states.SetValue(new State("São Paulo", "SP", 248222.362M), 24);
            states.SetValue(new State("Sergipe", "SE", 21915.116M), 25);
            states.SetValue(new State("Tocantins", "TO", 277720.520M), 26);
        }

        public Country()
        {
            this.states = new State[27];
            CriarListaDeEstados();
        }

        public State[] Top10StatesByArea()
        {
            State[] stateLocal = states.OrderByDescending(x => x.TerritorialExtension).Take(10).ToArray();

            return stateLocal;
        }
    }
}
