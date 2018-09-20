using System;
using System.Windows.Forms;
using EmiSan1998.CronoSystem.Utilities;

namespace EmiSan1998.CronoSystem.Gestione_pendolo
{
    public partial class Configurazione : Form
    {

        byte[] input = new byte[4]; //Buffer per i dati ricevuti da segnale

        public Configurazione() //Vengono inizializzati i controlli della finestra con le impostazioni correnti
        {
            InitializeComponent();
            setPorta.Text = Principale.nomePorta;
            setOscillazioni.Value = Principale.oscillazioni;
        }

        private void setPorta_DropDown(object sender, EventArgs e) //Qunado viene aperta la casella di selezione porta
        {
            String[] porte;
            porte = System.IO.Ports.SerialPort.GetPortNames(); //I nomi di tutte le porte disponibili vengono salvate in un array String vuoto
            this.setPorta.Items.Clear(); //Il vecchio elenco di porte disponibili, viene svuotato
            foreach (String porta in porte) //Per ogni porta disponibile...
            {
                portaTemp.PortName = porta;
                portaTemp.Open();
                portaTemp.InvocaComandoCronometro("ping"); //...prova ad inviare il comando ping al dispositivo connesso su quella porta...
                    System.Threading.Thread.Sleep(100);
                    if (portaTemp.BytesToRead > 0)
                    {
                        input[0]=(byte)portaTemp.ReadByte(); //...se c'è una risposta la copia nel buffer di input e interrompi il ciclo...
                    }
                portaTemp.Close();
                if (input[0] == 112) //...se il byte ricevuto come risposta ha valore 2 la porta è valida quindi viene aggiunta all'elenco.
                {
                    this.setPorta.Items.Add(porta);
                }
                Array.Clear(input,0,4); //Al termine dell'iterazione il buffer viene pulito
            }
            Application.DoEvents();
        }

        private void testBtn_Click(object sender, EventArgs e) //Gestione del pulsante di test
        {
            if (setPorta.Text != "") //Se è stata selezionata una porta...
            {
                try //...il programma tenta la connessione alla suddetta porta...
                {
                    portaTemp.PortName = setPorta.Text;
                    portaTemp.Open();
                    portaTemp.InvocaComandoCronometro("ping"); //...tenta il ping del dispositivo...
                    System.Threading.Thread.Sleep(100);
                        if (portaTemp.BytesToRead > 0)
                        {
                            input[0]=(byte)portaTemp.ReadByte(); //...se c'è una risposta la copia nel buffer di input e interrompi il ciclo...
                        }
                    if (input[0] == 112) //...se viene ricevuta una risposta valida...
                    {
                        portaTemp.InvocaComandoCronometro("firmware"); //...viene richiesta la versione del firmware installato su Arduino...
                        System.Threading.Thread.Sleep(200);
                        portaTemp.Read(input, 0, 4);
                        System.Windows.Forms.MessageBox.Show("Dispositivo connesso su " + setPorta.Text + " versione firmware " + Id_card.getId(input), "Info sul dispositivo");//...che viene interpretata dalla classe ID_card e comunicata all'utente traminte pop-up.
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Impossibile raggiungere il dispositivo, verificare che sia correttamente connesso al computer.", "Errore"); 
                    }
                    }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Eccezione");
                }
                finally
                {
                    portaTemp.DiscardInBuffer();
                    portaTemp.Close();
                    Array.Clear(input, 0, 4); //Indipendentemente dal percorso di esecuzione del comando il buffer viene pulito per evitare "interferenze" con le letture successive
                }
            }
        }

        private void ok_Click(object sender, EventArgs e) //Cliccando su ok le impostazioni vengono aggiornate
        {
            Principale.nomePorta = setPorta.Text;
            Principale.oscillazioni = Convert.ToInt16(Math.Round(setOscillazioni.Value, 0));
            this.Close();
        }

        private void annulla_Click(object sender, EventArgs e) //Cliccando su annulla la finestra di configurazione si chiude senza salvare le impostazioni inserite
        {
            this.Close();
        }

    }
}
