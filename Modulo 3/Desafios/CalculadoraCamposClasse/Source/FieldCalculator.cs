using System;
using System.Reflection;

namespace Codenation.Challenge
{
    public class FieldCalculator : ICalculateField
    {
        private decimal _valor = 0;
        /*
        Deverá retornar a soma de todos os campos do tipo decimal que tenham o atributo Add. 
        Caso não existam campos do tipo decimal com atributo Add, retornar 0 (zero).
        Por exemplo:
            se uma classe tem um campo de valor 10 e outro de valor 20 com o atributo Add o resultado deve ser 30.
            se uma classe tem um campo de valor -10 e outro de valor 20 com o atributo Add o resultado deve ser 10.              
        */
        
        public decimal Addition(object obj)
        {

            Type fieldType = typeof(FieldCalculator);
            PropertyInfo addPropertyInfo = fieldType.GetProperty("_valor");
            decimal value = (decimal)addPropertyInfo.GetValue(null, null);

            //var assembly = typeof(FieldCalculator).Assembly;
            //Type calcType = assembly.GetType("Codenation.Challenge.FieldCalculator");
            //object calcInstance = Activator.CreateInstance(calcType);


            throw new System.NotImplementedException();
        }

        /*
        Deverá retornar a subtração de todos os campos do tipo decimal que tenham o atributo Subtract. 
        Caso não existam campos do tipo decimal com atributo Subtract, retornar 0 (zero).
        Por exemplo:
            se uma classe tem um campo de valor 10 e outro de valor 20 com o atributo Subtract o resultado deve ser 0 - 10 - 20 = -30.
            se uma classe tem um campo de valor -10 e outro de valor 20 com o atributo Subtract o resultado deve ser 0 - -10 - 20 = -10.  
        */
        public decimal Subtraction(object obj)
        {
            throw new System.NotImplementedException();
        }

        /*
        Deverá retornar soma de todos os campos do tipo decimal que tenham o atributo Add subtraídos de 
        todos os campos que tenham o atributo Subtract. Caso não existam campos do tipo decimal com atributo Add ou Subtract, retornar 0 (zero).
        Por exemplo:
            se uma classe tem um campo de valor -10 com Add, outro de valor 20 com Add, outro de valor -10 com Subtract e 
            outro de valor 20 com Subtract, o resultado deve ser 0 + -10 + 20 - -10 - 20 = 0 (zero)
        */
        public decimal Total(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
