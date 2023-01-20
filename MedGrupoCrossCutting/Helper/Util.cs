using System;
using System.Collections.Generic;
using System.Text;

namespace MedGrupo.CrossCutting.Helper
{
    public static class Util
    {
        public static int CalculaIdade(DateTime dNascimento, DateTime dAtual)
        {
            int idDias = 0, idMeses = 0, idAnos = 0;
            DateTime dNascimentoCorrente = DateTime.Parse(dNascimento.Day.ToString() + "/" +
            dNascimento.Month.ToString() + "/" + (dAtual.Year - 1).ToString());
            int ta;
            if (dAtual < dNascimento)
            {
                return 0;
            }
            idAnos = dAtual.Year - dNascimento.Year;
            if (dAtual.Month < dNascimento.Month || (dAtual.Month ==
            dNascimento.Month && dAtual.Day < dNascimento.Day))
            {
                idAnos--;
            }
            idMeses = CalculaMeses(dAtual, dNascimento);
            idDias = CalculaDias(dAtual, dNascimento);

         
            return idAnos;
        }
        internal static int CalculaDias(DateTime dataAtual, DateTime dataOriginal)
        {
            int numeroDias = 0;
            if ((dataAtual.Month > dataOriginal.Month || dataAtual.Month <
            dataOriginal.Month) && (dataAtual.Day > dataOriginal.Day))
            {
                DateTime dUltima = DateTime.Parse(dataOriginal.Day.ToString() + "/" +
                (dataAtual.Month).ToString() + "/" + (dataAtual.Year).ToString());
                numeroDias = (dataAtual - dUltima).Days;
            }
            else if ((dataAtual.Month > dataOriginal.Month || dataAtual.Month <
            dataOriginal.Month) && (dataAtual.Day < dataOriginal.Day))
            {
                DateTime dUltima = DateTime.Parse(dataOriginal.Day.ToString() + "/" +
                (dataAtual.Month - 1).ToString() + "/" + (dataAtual.Year).ToString());
                numeroDias = (dataAtual - dUltima).Days;
            }
            else if (dataOriginal.Month == dataAtual.Month)
            {
                DateTime dUltima = DateTime.Parse(dataOriginal.Day.ToString() + "/" +
                (dataAtual.Month).ToString() + "/" + (dataAtual.Year).ToString());
                numeroDias = (dataAtual - dUltima).Days;
            }
            return numeroDias;
        }
        internal static int CalculaMeses(DateTime dataAtual, DateTime dataOriginal)
        {
            int numeroMeses = 0;
            if ((dataAtual.Month > dataOriginal.Month))
            {
                numeroMeses = dataAtual.Month - dataOriginal.Month;
            }
            else if ((dataAtual.Month < dataOriginal.Month))
            {
                if (dataAtual.Day > dataOriginal.Day)
                {
                    numeroMeses = (12 - dataOriginal.Month) + (dataAtual.Month);
                }
                else if (dataAtual.Day < dataOriginal.Day)
                {
                    numeroMeses = (12 - dataOriginal.Month) + (dataAtual.Month - 1);
                }
            }
            return numeroMeses;
        }
    }
}
