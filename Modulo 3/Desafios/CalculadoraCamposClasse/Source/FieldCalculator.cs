using System;
using System.Reflection;

namespace Codenation.Challenge
{
    public class FieldCalculator : ICalculateField
    {
        private decimal CalcMethod(object obj, bool onlyAdd, bool onlySubtract)
        {
            decimal valueReturn = 0;

            if (obj == null)
                return valueReturn;

            var properties = obj.GetType().GetTypeInfo().DeclaredFields;
            Object[] keys;
            foreach (var propertyInfo in properties)
            {
                TypeCode tipo = Type.GetTypeCode(propertyInfo.FieldType);

                if (tipo == TypeCode.Decimal)
                {
                    decimal value = 0;
                    if (onlyAdd)
                    {
                        keys = propertyInfo.GetCustomAttributes(typeof(AddAttribute), true);
                        
                        if (keys.Length != 0)
                        {
                            value = (decimal)propertyInfo.GetValue(obj);
                            valueReturn = valueReturn + (value);
                        }
                    }

                    if (onlySubtract)
                    {
                        keys = propertyInfo.GetCustomAttributes(typeof(SubtractAttribute), true);
                        if (keys.Length != 0)
                        {
                            value = (decimal)propertyInfo.GetValue(obj);
                            valueReturn = valueReturn - (value);
                        }
                    }
                }
            }

            return valueReturn;
        }

        /*
        Deverá retornar a soma de todos os campos do tipo decimal que tenham o atributo Add. 
        Caso não existam campos do tipo decimal com atributo Add, retornar 0 (zero).
        Por exemplo:
            se uma classe tem um campo de valor 10 e outro de valor 20 com o atributo Add o resultado deve ser 30.
            se uma classe tem um campo de valor -10 e outro de valor 20 com o atributo Add o resultado deve ser 10.              
        */
        public decimal Addition(object obj)
        {
            return CalcMethod(obj, true, false);
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
            return CalcMethod(obj, false, true);
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
            return CalcMethod(obj, true, true);
        }
    }
}
