using System;
using System.Collections.Generic;
using System.Text;

namespace Calendario
{
    public class Data
    {
        public struct StrTempo
        {
            public string NM_DIA { get; set; }
            public int NR_DIAS { get; set; }
            public int NR_MESES { get; set; }
            public int NR_ANOS { get; set; }
        }

        //METODO QUE RETORNA UMA STRING COM O NOME DO MÊS ATUAL
        public static string RetornaDescMes(int pMes, bool pMes3Digitos = false)
        {
            string vMes = Convert.ToString(pMes.ToString());

            switch (vMes)
            {
                case "1":
                    vMes = "Janeiro";
                    break;

                case "2":
                    vMes = "Fevereiro";
                    break;

                case "3":
                    vMes = "Março";
                    break;

                case "4":
                    vMes = "Abril";
                    break;

                case "5":
                    vMes = "Maio";
                    break;

                case "6":
                    vMes = "Junho";
                    break;

                case "7":
                    vMes = "Julho";
                    break;

                case "8":
                    vMes = "Agosto";
                    break;

                case "9":
                    vMes = "Setembro";
                    break;

                case "10":
                    vMes = "Outubro";
                    break;

                case "11":
                    vMes = "Novembro";
                    break;

                case "12":
                    vMes = "Dezembro";
                    break;
            }

            if ((!string.IsNullOrEmpty(vMes)) && (pMes3Digitos))
                vMes = vMes.PadLeft(3, ' ').Substring(0, 3);

            return vMes;
        }

        //Retorna a quantidade de dias de cada mês, inclusive o mês de fevereiro para ano bissexto.
        public static string DiasMes(DateTime pDataSimulacao)
        {
            string[] vDias = new string[13];

            vDias.SetValue("31", 1); vDias.SetValue("28", 2); vDias.SetValue("31", 3); vDias.SetValue("30", 4);
            vDias.SetValue("31", 5); vDias.SetValue("30", 6); vDias.SetValue("31", 7); vDias.SetValue("31", 8);
            vDias.SetValue("30", 9); vDias.SetValue("31", 10); vDias.SetValue("30", 11); vDias.SetValue("31", 12);

            if (pDataSimulacao.Month == 2)
            {
                if (DateTime.IsLeapYear(pDataSimulacao.Year))
                    return "29";
                else
                    return "28";
            }

            return vDias[pDataSimulacao.Month];
        }

        /// <summary>
        /// Método que recebe uma data e retorna o último dia do mês
        /// </summary>
        /// <param name="pData"></param>
        /// <returns>Retorna o último dia do mês</returns>
        public static DateTime DataFimMes(DateTime pData)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR");

            DateTime vData = pData;

            vData = vData.AddMonths(1);
            vData = Convert.ToDateTime("01/" + vData.ToString("MM/yyyy"));
            vData = vData.AddDays(-1);
            return vData;
        }

        public static StrTempo CalculaPeriodo(DateTime pDtInicial, DateTime pDtFinal)
        {
            StrTempo vTempo = new StrTempo();

            int vAnos = 0, vMeses = 0, vDias = 0;
            int vAnoFim = pDtFinal.Year, vMesFim = pDtFinal.Month, vDiaFim = pDtFinal.Day;
            int vAnoIni = pDtInicial.Year, vMesIni = pDtInicial.Month, vDiaIni = pDtInicial.Day;

            System.TimeSpan diferenca = pDtInicial - pDtFinal;
            var b = diferenca.TotalDays;
            if (vMesIni < vMesFim)
            {
                var vDataFimAnoAtual = Convert.ToDateTime($"31/12/{vAnoFim}");
                System.TimeSpan vDiasAnoAtual = vDataFimAnoAtual - pDtFinal;
                vDias = (int)vDiasAnoAtual.TotalDays;

                var vDataProximoAno = Convert.ToDateTime($"01/01/{vAnoFim + 1}");
                System.TimeSpan vDiasProximoAno = new DateTime(vAnoFim + 1, vMesIni, vDiaIni) - vDataProximoAno;
                vDias = vDias + (int)vDiasProximoAno.TotalDays + 1;
            }
            else
            {
                System.TimeSpan vDiasTotal = pDtInicial - pDtFinal;
                vDias = (int)vDiasTotal.TotalDays;
            }

            if (DateTime.IsLeapYear(vAnoFim))
            {
                vDias = vDias + 1;
            }

            vTempo.NR_DIAS = vDias;
            vTempo.NR_MESES = vMeses;
            vTempo.NR_ANOS = vAnos;

            return vTempo;
        }

        public static string RetornaDiaSemana(DateTime pData)
        {
            string vRetorno = string.Empty;

            switch (pData.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    vRetorno = "Domingo";
                    break;
                case DayOfWeek.Monday:
                    vRetorno = "Segunda-feira";
                    break;
                case DayOfWeek.Tuesday:
                    vRetorno = "Terça-feira";
                    break;
                case DayOfWeek.Wednesday:
                    vRetorno = "Quarta-feira";
                    break;
                case DayOfWeek.Thursday:
                    vRetorno = "Quinta-feira";
                    break;
                case DayOfWeek.Friday:
                    vRetorno = "Sexta-feira";
                    break;
                case DayOfWeek.Saturday:
                    vRetorno = "Sábado";
                    break;
            }

            return vRetorno;
        }
    }
}
