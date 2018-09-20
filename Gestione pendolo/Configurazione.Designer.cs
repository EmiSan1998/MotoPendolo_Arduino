namespace EmiSan1998.CronoSystem.Gestione_pendolo
{
    partial class Configurazione
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
            this.setOscillazioni = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.annulla = new System.Windows.Forms.Button();
            this.setPorta = new System.Windows.Forms.ComboBox();
            this.portaTemp = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.setOscillazioni)).BeginInit();
            this.SuspendLayout();
            // 
            // setOscillazioni
            // 
            this.setOscillazioni.Location = new System.Drawing.Point(236, 37);
            this.setOscillazioni.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.setOscillazioni.Name = "setOscillazioni";
            this.setOscillazioni.Size = new System.Drawing.Size(36, 20);
            this.setOscillazioni.TabIndex = 3;
            this.setOscillazioni.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oscillazioni per prova:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Porta:";
            // 
            // testBtn
            // 
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.testBtn.Location = new System.Drawing.Point(223, 6);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(49, 23);
            this.testBtn.TabIndex = 8;
            this.testBtn.Text = "test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // ok
            // 
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ok.Location = new System.Drawing.Point(197, 63);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 10;
            this.ok.Text = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // annulla
            // 
            this.annulla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.annulla.Location = new System.Drawing.Point(116, 63);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(75, 23);
            this.annulla.TabIndex = 11;
            this.annulla.Text = "annulla";
            this.annulla.UseVisualStyleBackColor = true;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // setPorta
            // 
            this.setPorta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.setPorta.FormattingEnabled = true;
            this.setPorta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.setPorta.Location = new System.Drawing.Point(64, 8);
            this.setPorta.Name = "setPorta";
            this.setPorta.Size = new System.Drawing.Size(153, 21);
            this.setPorta.Sorted = true;
            this.setPorta.TabIndex = 12;
            this.setPorta.DropDown += new System.EventHandler(this.setPorta_DropDown);
            // 
            // Configurazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 90);
            this.Controls.Add(this.setPorta);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setOscillazioni);
            this.Controls.Add(this.label1);
            this.Name = "Configurazione";
            this.Text = "Configurazione";
            ((System.ComponentModel.ISupportInitialize)(this.setOscillazioni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown setOscillazioni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button annulla;
        private System.Windows.Forms.ComboBox setPorta;
        private System.IO.Ports.SerialPort portaTemp;
    }
}