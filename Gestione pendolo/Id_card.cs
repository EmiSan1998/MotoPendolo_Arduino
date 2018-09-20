using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmiSan1998.CronoSystem.Utilities
{
    class Id_card
    {
        /// <summary>
        /// Questa funzione interpreta i dati relativi alla versione software trasmessi da Arduino.
        /// </summary>
        /// <param name="input">L'array da 4 byte ricevuto da Arduino alla richiesta della versione FW.</param>
        /// <returns>Una stringa facilmente leggibile che indica la versione FW.</returns>
        static public String getId(byte[] input) {      
            return input[0].ToString() + "." + BitConverter.ToInt16(input,1).ToString() + (char)input[3];
        }
    }
}
