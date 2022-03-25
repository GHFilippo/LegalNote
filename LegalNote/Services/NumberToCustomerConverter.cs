using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Data;

namespace LegalNote.Services
{
    public class NumberToCustomerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ((int)value >= 0)
                    return TrovaNomeCliente((int)value);
                else
                    return
                        "White";
            }
            catch (NullReferenceException)
            {
                return "";
            }
            catch
            {
                return "";
            }
        }
        public string TrovaNomeCliente(int idcliente)
        {
            if (idcliente != -1)
            {
                List<anagrafica> listaClienti = (from anaRow in DbClass.LegEnt.anagrafica
                                                 where anaRow.id == idcliente
                                                 select anaRow).ToList();

                string nomeCliente = listaClienti[0].ragionesociale;
                if (String.IsNullOrEmpty(listaClienti[0].nome) == false)
                    nomeCliente += " - " + listaClienti[0].nome;
                if (String.IsNullOrEmpty(listaClienti[0].cognome) == false)
                    nomeCliente += " " + listaClienti[0].cognome;

                return nomeCliente;
            }
            else
                return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
