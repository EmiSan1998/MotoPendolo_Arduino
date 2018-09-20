namespace EmiSan1998.CronoSystem.Gestione_pendolo
{
    partial class Principale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.RichTextBox();
            this.inizio = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.configurazione = new System.Windows.Forms.Button();
            this.Pendolo = new System.IO.Ports.SerialPort(this.components);
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Log:";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 28);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(260, 93);
            this.log.TabIndex = 3;
            this.log.Text = "";
            // 
            // inizio
            // 
            this.inizio.Enabled = false;
            this.inizio.Location = new System.Drawing.Point(197, 127);
            this.inizio.Name = "inizio";
            this.inizio.Size = new System.Drawing.Size(75, 23);
            this.inizio.TabIndex = 4;
            this.inizio.Text = "inizio";
            this.inizio.UseVisualStyleBackColor = true;
            this.inizio.Click += new System.EventHandler(this.inizio_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(116, 127);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 5;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // configurazione
            // 
            this.configurazione.Location = new System.Drawing.Point(15, 127);
            this.configurazione.Name = "configurazione";
            this.configurazione.Size = new System.Drawing.Size(95, 23);
            this.configurazione.TabIndex = 6;
            this.configurazione.Text = "configurazione";
            this.configurazione.UseVisualStyleBackColor = true;
            this.configurazione.Click += new System.EventHandler(this.configurazione_Click);
            // 
            // Pendolo
            // 
            this.Pendolo.DtrEnable = true;
            this.Pendolo.RtsEnable = true;
            // 
            // grafico
            // 
            this.grafico.CausesValidation = false;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.Title = "ms";
            chartArea1.AxisY.Title = "rilevazioni";
            chartArea1.Name = "Rilevazioni";
            this.grafico.ChartAreas.Add(chartArea1);
            this.grafico.Location = new System.Drawing.Point(278, 12);
            this.grafico.Name = "grafico";
            series1.ChartArea = "Rilevazioni";
            series1.Name = "Series1";
            this.grafico.Series.Add(series1);
            this.grafico.Size = new System.Drawing.Size(503, 407);
            this.grafico.TabIndex = 7;
            this.grafico.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rilevazioni presenti nel grafico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "0";
            // 
            // Principale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 420);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grafico);
            this.Controls.Add(this.configurazione);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.inizio);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label2);
            this.Name = "Principale";
            this.Text = "Principale";
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Button inizio;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button configurazione;
        private System.IO.Ports.SerialPort Pendolo;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}