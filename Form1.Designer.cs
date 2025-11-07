namespace JogoPalavra
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Palavra = new Label();
            lbl_Dica = new Label();
            txt_Entrada = new TextBox();
            lbl_Tentadas = new Label();
            btn_Teste = new Button();
            SuspendLayout();
            // 
            // lbl_Palavra
            // 
            lbl_Palavra.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Palavra.Location = new Point(50, 100);
            lbl_Palavra.MaximumSize = new Size(700, 100);
            lbl_Palavra.Name = "lbl_Palavra";
            lbl_Palavra.Size = new Size(700, 50);
            lbl_Palavra.TabIndex = 0;
            lbl_Palavra.Text = "Palavra";
            lbl_Palavra.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Dica
            // 
            lbl_Dica.Font = new Font("Segoe UI", 12F);
            lbl_Dica.Location = new Point(50, 50);
            lbl_Dica.Name = "lbl_Dica";
            lbl_Dica.Size = new Size(700, 50);
            lbl_Dica.TabIndex = 1;
            lbl_Dica.Text = "Dica da palavra";
            lbl_Dica.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_Entrada
            // 
            txt_Entrada.Font = new Font("Segoe UI", 14F);
            txt_Entrada.Location = new Point(200, 250);
            txt_Entrada.Name = "txt_Entrada";
            txt_Entrada.Size = new Size(250, 39);
            txt_Entrada.TabIndex = 2;
            txt_Entrada.TextChanged += txt_Entrada_TextChanged;
            // 
            // lbl_Tentadas
            // 
            lbl_Tentadas.AutoSize = true;
            lbl_Tentadas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Tentadas.Location = new Point(200, 200);
            lbl_Tentadas.Name = "lbl_Tentadas";
            lbl_Tentadas.Size = new Size(69, 28);
            lbl_Tentadas.TabIndex = 3;
            lbl_Tentadas.Text = "Letras";
            // 
            // btn_Teste
            // 
            btn_Teste.Cursor = Cursors.Help;
            btn_Teste.Location = new Point(500, 250);
            btn_Teste.Name = "btn_Teste";
            btn_Teste.Size = new Size(100, 39);
            btn_Teste.TabIndex = 4;
            btn_Teste.Text = "Verificar";
            btn_Teste.UseVisualStyleBackColor = true;
            btn_Teste.Click += btn_Teste_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(btn_Teste);
            Controls.Add(lbl_Tentadas);
            Controls.Add(txt_Entrada);
            Controls.Add(lbl_Dica);
            Controls.Add(lbl_Palavra);
            Name = "Form1";
            Text = "Descubra qual é a Palavra Secreta!";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Palavra;
        private Label lbl_Dica;
        private TextBox txt_Entrada;
        private Label lbl_Tentadas;
        private Button btn_Teste;
    }
}
