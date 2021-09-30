
namespace Aula2809Crud
{
    partial class Desafio
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
            this.txtNomeDesafio = new System.Windows.Forms.TextBox();
            this.btnNovoDesafio = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeDesafio
            // 
            this.txtNomeDesafio.Location = new System.Drawing.Point(61, 50);
            this.txtNomeDesafio.Name = "txtNomeDesafio";
            this.txtNomeDesafio.Size = new System.Drawing.Size(158, 20);
            this.txtNomeDesafio.TabIndex = 0;
            // 
            // btnNovoDesafio
            // 
            this.btnNovoDesafio.Location = new System.Drawing.Point(63, 12);
            this.btnNovoDesafio.Name = "btnNovoDesafio";
            this.btnNovoDesafio.Size = new System.Drawing.Size(75, 23);
            this.btnNovoDesafio.TabIndex = 1;
            this.btnNovoDesafio.Text = "Novo";
            this.btnNovoDesafio.UseVisualStyleBackColor = true;
            this.btnNovoDesafio.Click += new System.EventHandler(this.btnNovoDesafio_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(144, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            // 
            // Desafio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 80);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovoDesafio);
            this.Controls.Add(this.txtNomeDesafio);
            this.Name = "Desafio";
            this.Text = "Desafio";
            this.Load += new System.EventHandler(this.Desafio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeDesafio;
        private System.Windows.Forms.Button btnNovoDesafio;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
    }
}