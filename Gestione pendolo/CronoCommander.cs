using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmiSan1998.CronoSystem.Utilities
{
    static class CronoCommands
    {
        /// <summary>
        /// Metodo di estensione della classe SerialPort che facilita l'invio di comandi al dispositivo di cronometraggio
        /// traducendo i comandi da stringhe facilmente memorizzabili a char da trasmettere al dispositivo.
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <param name="comando">Il comando da invocare su Arduino.</param>
        public static void InvocaComandoCronometro(this System.IO.Ports.SerialPort dispositivo, String comando)
        {

            try
            {
                if (comandiDisponibili.ContainsKey(comando))
                {
                    dispositivo.Write(byteDaInviare, comandiDisponibili[comando], 1);
                }
                else
                {
                    throw new ArgumentException("Comando non valido.", "comando");
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (System.IO.IOException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Errore");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*Passare tramite dizionario da una stringa all'indice di un array che contiene l'effettivo valore da mandare può sembrare
         ridondante ma è un workaround necessario visto che l'attuale versione della Base Class Library di .NET permette l'invio via
         seriale di bytes solo se provengono da un array, spero che in futuro ciò non sarà più necessario.*/
        private static readonly Dictionary<String, byte> comandiDisponibili = new Dictionary<String, byte>()
        {
            ["blink"] = 0,  //0 -> 98 -> ASCII 'b'
            ["firmware"] = 1,  //1 -> 102 -> ASCII 'f'
            ["ping"] = 2   //2 -> 112 -> ASCII 'p'
        };

        private static readonly byte[] byteDaInviare = { 98, 102, 112 };
    }
}
