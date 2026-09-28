using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrency
{
    public class Converter
    {
        private Dictionary<string, double> currencyPrices = new Dictionary<string, double>();

        /// <summary>
        /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
        /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
        /// bliver den gamle værdi overskrevet af den nye værdi
        /// </summary>
        /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
        /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
        public void SetPricePerUnit(String currencyName, double price)
        {
            if(price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            currencyPrices[currencyName] = price; // if doesnt exist, add it, if exist, update it
        }

        /// <summary>
        /// Så jeg kan hente prisen for en kryptovaluta. Der bliver ikke taget højde for hvorvidt den findes, da det bare bruges til at teste op imod
        /// </summary>
        /// <param name="currencyName">Navnet på den kryptovaluta vi ønsker at få prisen på</param>
        /// <returns>prisen på den angivne kryptovaluta</returns>
        public double GetPricePerUnit(String currencyName)
        {
            return currencyPrices[currencyName];
        }

        /// <summary>
        /// Konverterer fra en kryptovaluta til en anden. 
        /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
        /// 
        /// </summary>
        /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
        /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
        /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
        /// <returns>Værdien af beløbet i toCurrencyName</returns>
        public double Convert(String fromCurrencyName, String toCurrencyName, double amount)
        {
            if (!currencyPrices.ContainsKey(fromCurrencyName))
            {
                throw new ArgumentException("From currency not found");
            }

            if (!currencyPrices.ContainsKey(toCurrencyName))
            {
                throw new ArgumentException("To currency not found");
            }

            double fromCurrencyPrice = currencyPrices[fromCurrencyName];
            double toCurrencyPrice = currencyPrices[toCurrencyName];

            // formular: amount * the currency price we want to convert from / the currency price we want to convert to
            double result = amount * fromCurrencyPrice / toCurrencyPrice;
            return result;
        }
    }
}
