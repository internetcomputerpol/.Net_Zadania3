
namespace Zadanie1_Szyfrowanie
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        
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

        private void InitializeComponent()
        {
            TextDoZaszyfrowania_Button = new TextBox();
            label1 = new Label();
            Zaszyfruj_Button = new Button();
            Odszyfruj_Button = new Button();
            Wybor_algorytmuComboBox = new ComboBox();
            label2 = new Label();
            Klucz_TextBox = new TextBox();
            label3 = new Label();
            IV_TextBox = new TextBox();
            label4 = new Label();
            GenerujKlucz_Button = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            Cipher_TextBox = new TextBox();
            label6 = new Label();
            Cipher_HexTextBox = new TextBox();
            label7 = new Label();
            button4 = new Button();
            button5 = new Button();
            Odszyfrowanie_Label = new Label();
            Zaszyfrowanie_Label = new Label();
            SuspendLayout();
            // 
            // TextDoZaszyfrowania_Button
            // 
            TextDoZaszyfrowania_Button.Location = new Point(12, 114);
            TextDoZaszyfrowania_Button.Name = "TextDoZaszyfrowania_Button";
            TextDoZaszyfrowania_Button.Size = new Size(225, 27);
            TextDoZaszyfrowania_Button.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 91);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 1;
            label1.Text = "Tekst do Zaszyfrowania";
            // 
            // Zaszyfruj_Button
            // 
            Zaszyfruj_Button.Location = new Point(12, 218);
            Zaszyfruj_Button.Name = "Zaszyfruj_Button";
            Zaszyfruj_Button.Size = new Size(94, 29);
            Zaszyfruj_Button.TabIndex = 2;
            Zaszyfruj_Button.Text = "Zaszyfruj";
            Zaszyfruj_Button.UseVisualStyleBackColor = true;
            Zaszyfruj_Button.Click += Zaszyfruj_Button_Click_1;
            // 
            // Odszyfruj_Button
            // 
            Odszyfruj_Button.Location = new Point(112, 218);
            Odszyfruj_Button.Name = "Odszyfruj_Button";
            Odszyfruj_Button.Size = new Size(94, 29);
            Odszyfruj_Button.TabIndex = 3;
            Odszyfruj_Button.Text = "Odszyfruj";
            Odszyfruj_Button.UseVisualStyleBackColor = true;
            Odszyfruj_Button.Click += Odszyfruj_Button_Click_1;
            // 
            // Wybor_algorytmuComboBox
            // 
            Wybor_algorytmuComboBox.FormattingEnabled = true;
            Wybor_algorytmuComboBox.Items.AddRange(new object[] { "DES", "3DES" });
            Wybor_algorytmuComboBox.Location = new Point(12, 35);
            Wybor_algorytmuComboBox.Name = "Wybor_algorytmuComboBox";
            Wybor_algorytmuComboBox.Size = new Size(151, 28);
            Wybor_algorytmuComboBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 5;
            label2.Text = "Algorytm Szyfrowania";
            // 
            // Klucz_TextBox
            // 
            Klucz_TextBox.Location = new Point(341, 36);
            Klucz_TextBox.Name = "Klucz_TextBox";
            Klucz_TextBox.Size = new Size(355, 27);
            Klucz_TextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(341, 13);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 7;
            label3.Text = "Klucz";
            // 
            // IV_TextBox
            // 
            IV_TextBox.Location = new Point(341, 90);
            IV_TextBox.Name = "IV_TextBox";
            IV_TextBox.Size = new Size(355, 27);
            IV_TextBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(341, 67);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 9;
            label4.Text = "IV";
            // 
            // GenerujKlucz_Button
            // 
            GenerujKlucz_Button.Location = new Point(341, 135);
            GenerujKlucz_Button.Name = "GenerujKlucz_Button";
            GenerujKlucz_Button.Size = new Size(142, 34);
            GenerujKlucz_Button.TabIndex = 10;
            GenerujKlucz_Button.Text = "Generuj Klucz i IV";
            GenerujKlucz_Button.UseVisualStyleBackColor = true;
            GenerujKlucz_Button.Click += GenerujKlucz_Button_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 149);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 11;
            label5.Text = "Tekst Odszyfrowany";
            label5.Click += label5_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 172);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(225, 27);
            textBox4.TabIndex = 12;
            // 
            // Cipher_TextBox
            // 
            Cipher_TextBox.Location = new Point(341, 208);
            Cipher_TextBox.Name = "Cipher_TextBox";
            Cipher_TextBox.Size = new Size(355, 27);
            Cipher_TextBox.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(341, 179);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 14;
            label6.Text = "Cipher Text ASCI";
            // 
            // Cipher_HexTextBox
            // 
            Cipher_HexTextBox.Location = new Point(341, 283);
            Cipher_HexTextBox.Name = "Cipher_HexTextBox";
            Cipher_HexTextBox.Size = new Size(355, 27);
            Cipher_HexTextBox.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(341, 251);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 16;
            label7.Text = "Cipher Text HEX";
            // 
            // button4
            // 
            button4.Location = new Point(170, 321);
            button4.Name = "button4";
            button4.Size = new Size(163, 29);
            button4.TabIndex = 17;
            button4.Text = "Czas Odszyfrowania";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(170, 380);
            button5.Name = "button5";
            button5.Size = new Size(163, 29);
            button5.TabIndex = 18;
            button5.Text = "Czas Zaszyfrowania";
            button5.UseVisualStyleBackColor = true;
            // 
            // Odszyfrowanie_Label
            // 
            Odszyfrowanie_Label.AutoSize = true;
            Odszyfrowanie_Label.Location = new Point(426, 330);
            Odszyfrowanie_Label.Name = "Odszyfrowanie_Label";
            Odszyfrowanie_Label.Size = new Size(141, 20);
            Odszyfrowanie_Label.TabIndex = 19;
            Odszyfrowanie_Label.Text = "Czas Odszyfrowania";
            // 
            // Zaszyfrowanie_Label
            // 
            Zaszyfrowanie_Label.AutoSize = true;
            Zaszyfrowanie_Label.Location = new Point(426, 389);
            Zaszyfrowanie_Label.Name = "Zaszyfrowanie_Label";
            Zaszyfrowanie_Label.Size = new Size(138, 20);
            Zaszyfrowanie_Label.TabIndex = 20;
            Zaszyfrowanie_Label.Text = "Czas Zaszyfrowania";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(Zaszyfrowanie_Label);
            Controls.Add(Odszyfrowanie_Label);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label7);
            Controls.Add(Cipher_HexTextBox);
            Controls.Add(label6);
            Controls.Add(Cipher_TextBox);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(GenerujKlucz_Button);
            Controls.Add(label4);
            Controls.Add(IV_TextBox);
            Controls.Add(label3);
            Controls.Add(Klucz_TextBox);
            Controls.Add(label2);
            Controls.Add(Wybor_algorytmuComboBox);
            Controls.Add(Odszyfruj_Button);
            Controls.Add(Zaszyfruj_Button);
            Controls.Add(label1);
            Controls.Add(TextDoZaszyfrowania_Button);
            Name = "Form1";
            Text = "3_Zadanie1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox TextDoZaszyfrowania_Button; 
        private Label label1;                       
        private Button Zaszyfruj_Button;          
        private Button Odszyfruj_Button;        
        private ComboBox Wybor_algorytmuComboBox;
        private Label label2;
        private TextBox Klucz_TextBox;
        private Label label3;
        private TextBox IV_TextBox;
        private Label label4;
        private Button GenerujKlucz_Button;
        private Label label5;
        private TextBox textBox4;
        private TextBox Cipher_TextBox;
        private Label label6;
        private TextBox Cipher_HexTextBox;
        private Label label7;
        private Button button4;
        private Button button5;
        private Label Odszyfrowanie_Label;
        private Label Zaszyfrowanie_Label;



    }


}
