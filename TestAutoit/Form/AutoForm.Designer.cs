namespace TestAutoit.Form
{
    partial class AutoForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Kol = new System.Windows.Forms.Label();
            this.Otch = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SnuOnePage = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Forvirovanie = new System.Windows.Forms.Integration.ElementHost();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SnuOnePage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Kol
            // 
            this.Kol.AutoSize = true;
            this.Kol.Location = new System.Drawing.Point(3, 126);
            this.Kol.Name = "Kol";
            this.Kol.Size = new System.Drawing.Size(44, 13);
            this.Kol.TabIndex = 1;
            this.Kol.Text = "Кол-во:";
            // 
            // Otch
            // 
            this.Otch.AutoSize = true;
            this.Otch.Location = new System.Drawing.Point(3, 150);
            this.Otch.Name = "Otch";
            this.Otch.Size = new System.Drawing.Size(71, 13);
            this.Otch.TabIndex = 2;
            this.Otch.Text = "Обработано:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Печать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(247, 172);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Проставить выборку";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.SnuOnePage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1109, 522);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Kol);
            this.tabPage1.Controls.Add(this.Otch);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1101, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SnuOnePage
            // 
            this.SnuOnePage.Controls.Add(this.button3);
            this.SnuOnePage.Location = new System.Drawing.Point(4, 22);
            this.SnuOnePage.Name = "SnuOnePage";
            this.SnuOnePage.Padding = new System.Windows.Forms.Padding(3);
            this.SnuOnePage.Size = new System.Drawing.Size(1101, 496);
            this.SnuOnePage.TabIndex = 1;
            this.SnuOnePage.Text = "Формирование СНУ для единичной печати";
            this.SnuOnePage.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(6, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 26);
            this.button3.TabIndex = 1;
            this.button3.Text = "Старт автомат!!!";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.OneZayvkiSnu);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Forvirovanie);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1101, 496);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Формирование списка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Forvirovanie
            // 
            this.Forvirovanie.Location = new System.Drawing.Point(4, 4);
            this.Forvirovanie.Name = "Forvirovanie";
            this.Forvirovanie.Size = new System.Drawing.Size(1089, 489);
            this.Forvirovanie.TabIndex = 0;
            this.Forvirovanie.Text = "Forvirovanie";
            this.Forvirovanie.Child = null;
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 546);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "AutoForm";
            this.Text = "Тест Net Autoit";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PressButon);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.SnuOnePage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label Kol;
        internal System.Windows.Forms.Label Otch;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage SnuOnePage;
        internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Integration.ElementHost Forvirovanie;
    }
}

