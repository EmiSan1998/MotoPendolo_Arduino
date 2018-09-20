using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmiSan1998.FrequencyChart;

namespace EmiSan1998.CronoSystem.Gestione_pendolo
{
    public partial class Principale : Form
    {
        public static String nomePorta; //Nome della porta attiva
        public static short oscillazioni; //Numero di oscillazioni misurate
        public List<int> rilevazioni = new List<int>(); //Lista tempi rilevati

        int ko; //Durante le misurazioni tracia i tentativi di ricevere un tempo falliti, se vengono raggiunti 10 errori consecutivi il test viene interrotto.

        const int col = 30; //Numero colonne desiderate nel grafico (più ce ne sono migliore è la risoluzione del grafico ma serviranno più misurazioni per avere una gaussiana apprezzabile)

        public Principale() //Il costruttore inizializza la finestra principale con i valori di default
        {
            oscillazioni = 10;
            nomePorta = "";
            InitializeComponent();
        }

        private void inizio_Click(object sender, EventArgs e) //Questa funzione gestisce gli esperimenti
        {
            byte[] input = new byte[2]; //Viene creato un nuovo input buffer
            if (Pendolo.IsOpen) //Se nessuna porta non è aperta...
            {
                Pendolo.Close();
            }
            Pendolo.PortName = nomePorta; //...viene configurata e aperta la porta selezionata nelle impostazioni...
            Pendolo.Open();
            Pendolo.DiscardInBuffer();
            inizio.Enabled = false; //...i pulsanti vengono bloccati e la finestra viene aggiornata...
            reset.Enabled = false;
            configurazione.Enabled = false;
            Application.DoEvents();
            ko = 0;
            while (Pendolo.BytesToRead < 2 && ko < 10)
            { //...si attende l'arrivo dei primi due bytes (un tempo espresso come un intero a 16 bit)...
                System.Threading.Thread.Sleep(100);
                ko++;
            }
            if (ko < 200)
            {
                Pendolo.Read(input, 0, 2); //...che vengono letti quindi scartati (si presume che il primo tempo è relativo quando il grave viene lanciato quindi non è un'oscillazione regolare.
                for (int i = 0; i < oscillazioni && ko < 20; i++) //Per ogni oscillazione...
                {
                    ko = 0; //La variabile ko viene azzerata
                    while (Pendolo.BytesToRead < 2 && ko < 10) //...si attende l'arrivo di due bytes...
                    {
                        System.Threading.Thread.Sleep(100);
                        ko++;
                    }
                    if (ko < 20)
                    {
                        Pendolo.Read(input, 0, 2); //...che vengono letti.
                        if (oscillazioni % 2 == 0)
                        {  //Se si tratta di oscillazioni pari (quelle dispari vengono saltate per avere misurazioni più regolari possibili ed evitare la formazione di una doppia gaussiana)...
                            log.AppendText(Convert.ToString(BitConverter.ToInt16(input, 0)) + " ");  //...vengono mostrate all'utente nella sezione Log dell'interfaccia...
                            rilevazioni.Add(BitConverter.ToInt16(input, 0)); //...vengono aggiunte alla lista di rilevazioni effettuate...
                            label3.Text = grafico.FDupdate("Series1", rilevazioni, col).ToString(); //...con le quali si ridisegna il grafico aggiornato...
                            Application.DoEvents(); //...che viene mostrato al reset dell'interfaccia.
                        }
                    }
                    else //Se vengono fatti 20 tentativi infruttuosi di leggere dati da seriale (1 sec. senza rilevazioni) l'esperimento viene interrotto
                    {
                        MessageBox.Show("Non è stato possibile completare il numero di rilevazioni previste.", "Errore");
                    }
                }
            }
            else //Se vengono fatti 200 tentativi infruttuosi di leggere dati da seriale (1 sec. senza rilevazioni) l'esperimento viene annullato
            {
                MessageBox.Show("Nessun tempo rilevato, l'esperimento verrà interrotto.", "Errore");
            }
            Pendolo.Close(); //La porta viene chiusa e l'interfaccia viene riportata allo stato originario. 
            inizio.Enabled = true;
            reset.Enabled = true;
            configurazione.Enabled = true;
        }

        private void configurazione_Click(object sender, EventArgs e)
        {
            Configurazione configurazione = new Configurazione(); //Crea e mostra una nuova finestra di configurazione
            configurazione.ShowDialog();
            if (nomePorta != "") //Quando la finestra viene chiusa il programma verifica: se è stata specificata una porta il tasto "inizio" viene sbloccato altrimenti viene bloccato
            {
                inizio.Enabled = true;
            }
            else
            {
                inizio.Enabled = false;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            rilevazioni.Clear(); //Viene svuotato l'elenco delle misurazioni e grafico e TextBox vengono aggiornati di conseguenza
            label3.Text = grafico.FDupdate("Series1", rilevazioni, col).ToString();
            log.Clear();
        }
    }
}
