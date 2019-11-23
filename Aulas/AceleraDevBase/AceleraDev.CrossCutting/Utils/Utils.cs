﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AceleraDev.CrossCutting.Utils
{
    public static class Utils
    {
        public static bool ValidaCPF(string cpf)
        {
            cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            if (!stringValida(cpf))
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            //if (igual || cpf == "12345678909")
            //    return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        private static bool stringValida(string cpf)
        {
            if (cpf == "12345678909")
                return false;

            var valid = true;

            for (int i = 0; valid && i < 11; i++)
            {
                if (cpf == obterString(i.ToString()))
                    valid = false;
            }

            if (!valid)
                return false;

            return true;
        }

        private static string obterString(string stringBase)
        {
            var result = "";
            for (int i = 0; i < 11; i++)
            {
                result += i.ToString(); 
            }
            return result;
        }
    }
}