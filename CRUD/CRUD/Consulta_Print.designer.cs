
namespace CRUD
{
    partial class Consulta_Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta_Print));
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rdFunc = new System.Windows.Forms.RadioButton();
            this.rdAluno = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btImprimi = new System.Windows.Forms.Button();
            this.imprimirDocumento = new System.Drawing.Printing.PrintDocument();
            this.print = new System.Windows.Forms.PrintPreviewDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.printFunc = new System.Windows.Forms.PrintPreviewDialog();
            this.ImprimirDocument2 = new System.Drawing.Printing.PrintDocument();
            this.maskCPF = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(88, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "IMPRIMIR DADOS";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(258, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdFunc
            // 
            this.rdFunc.AutoSize = true;
            this.rdFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rdFunc.Location = new System.Drawing.Point(44, 65);
            this.rdFunc.Name = "rdFunc";
            this.rdFunc.Size = new System.Drawing.Size(123, 21);
            this.rdFunc.TabIndex = 10;
            this.rdFunc.TabStop = true;
            this.rdFunc.Text = "FUNCIIONARIO";
            this.rdFunc.UseVisualStyleBackColor = true;
            // 
            // rdAluno
            // 
            this.rdAluno.AutoSize = true;
            this.rdAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rdAluno.Location = new System.Drawing.Point(210, 65);
            this.rdAluno.Name = "rdAluno";
            this.rdAluno.Size = new System.Drawing.Size(74, 21);
            this.rdAluno.TabIndex = 11;
            this.rdAluno.TabStop = true;
            this.rdAluno.Text = "ALUNO";
            this.rdAluno.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(26, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "NOME:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(41, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "CPF:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtNome.Location = new System.Drawing.Point(85, 103);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(221, 23);
            this.txtNome.TabIndex = 14;
            // 
            // btImprimi
            // 
            this.btImprimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btImprimi.Location = new System.Drawing.Point(121, 203);
            this.btImprimi.Name = "btImprimi";
            this.btImprimi.Size = new System.Drawing.Size(84, 30);
            this.btImprimi.TabIndex = 16;
            this.btImprimi.Text = "Imprimir";
            this.btImprimi.UseVisualStyleBackColor = true;
            this.btImprimi.Click += new System.EventHandler(this.btImprimi_Click);
            // 
            // imprimirDocumento
            // 
            this.imprimirDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.imprimirDocumento_PrintPage);
            // 
            // print
            // 
            this.print.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.print.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.print.ClientSize = new System.Drawing.Size(400, 300);
            this.print.Enabled = true;
            this.print.Icon = ((System.Drawing.Icon)(resources.GetObject("print.Icon")));
            this.print.Name = "print";
            this.print.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "----------------------------";
            // 
            // printFunc
            // 
            this.printFunc.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printFunc.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printFunc.ClientSize = new System.Drawing.Size(400, 300);
            this.printFunc.Enabled = true;
            this.printFunc.Icon = ((System.Drawing.Icon)(resources.GetObject("printFunc.Icon")));
            this.printFunc.Name = "printFunc";
            this.printFunc.Visible = false;
            // 
            // ImprimirDocument2
            // 
            this.ImprimirDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ImprimirDocument2_PrintPage);
            // 
            // maskCPF
            // 
            this.maskCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maskCPF.Location = new System.Drawing.Point(85, 140);
            this.maskCPF.Mask = "000.000.000-00";
            this.maskCPF.Name = "maskCPF";
            this.maskCPF.Size = new System.Drawing.Size(120, 23);
            this.maskCPF.TabIndex = 18;
            // 
            // Consulta_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 250);
            this.Controls.Add(this.maskCPF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btImprimi);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdAluno);
            this.Controls.Add(this.rdFunc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consulta_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpaceTech";
            this.Load += new System.EventHandler(this.Consulta_Print_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdFunc;
        private System.Windows.Forms.RadioButton rdAluno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btImprimi;
        private System.Drawing.Printing.PrintDocument imprimirDocumento;
        private System.Windows.Forms.PrintPreviewDialog print;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PrintPreviewDialog printFunc;
        private System.Drawing.Printing.PrintDocument ImprimirDocument2;
        private System.Windows.Forms.MaskedTextBox maskCPF;
    }
}