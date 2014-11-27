namespace HorlogeSto
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelHorloge = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioFull = new System.Windows.Forms.RadioButton();
            this.radioDay = new System.Windows.Forms.RadioButton();
            this.radioTime = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelHorloge
            // 
            this.LabelHorloge.AutoSize = true;
            this.LabelHorloge.Location = new System.Drawing.Point(563, 145);
            this.LabelHorloge.Name = "LabelHorloge";
            this.LabelHorloge.Size = new System.Drawing.Size(35, 13);
            this.LabelHorloge.TabIndex = 0;
            this.LabelHorloge.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioTime);
            this.groupBox1.Controls.Add(this.radioDay);
            this.groupBox1.Controls.Add(this.RadioFull);
            this.groupBox1.Location = new System.Drawing.Point(312, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affichage";
            // 
            // RadioFull
            // 
            this.RadioFull.AutoSize = true;
            this.RadioFull.Location = new System.Drawing.Point(31, 45);
            this.RadioFull.Name = "RadioFull";
            this.RadioFull.Size = new System.Drawing.Size(138, 17);
            this.RadioFull.TabIndex = 2;
            this.RadioFull.TabStop = true;
            this.RadioFull.Text = "JJ/MM/AAAA hh:mm:ss";
            this.RadioFull.UseVisualStyleBackColor = true;
            this.RadioFull.CheckedChanged += new System.EventHandler(this.RadioFull_CheckedChanged);
            // 
            // radioDay
            // 
            this.radioDay.AutoSize = true;
            this.radioDay.Location = new System.Drawing.Point(238, 45);
            this.radioDay.Name = "radioDay";
            this.radioDay.Size = new System.Drawing.Size(91, 17);
            this.radioDay.TabIndex = 3;
            this.radioDay.TabStop = true;
            this.radioDay.Text = "JJ/MM/AAAA";
            this.radioDay.UseVisualStyleBackColor = true;
            this.radioDay.CheckedChanged += new System.EventHandler(this.radioDay_CheckedChanged);
            // 
            // radioTime
            // 
            this.radioTime.AutoSize = true;
            this.radioTime.Location = new System.Drawing.Point(415, 45);
            this.radioTime.Name = "radioTime";
            this.radioTime.Size = new System.Drawing.Size(69, 17);
            this.radioTime.TabIndex = 4;
            this.radioTime.TabStop = true;
            this.radioTime.Text = "hh:mm:ss";
            this.radioTime.UseVisualStyleBackColor = true;
            this.radioTime.CheckedChanged += new System.EventHandler(this.radioTime_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 606);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LabelHorloge);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelHorloge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioTime;
        private System.Windows.Forms.RadioButton radioDay;
        private System.Windows.Forms.RadioButton RadioFull;
    }
}

