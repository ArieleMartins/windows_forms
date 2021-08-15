
namespace CRUD
{
    partial class consultar_turma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(consultar_turma));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbTurma = new System.Windows.Forms.ComboBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.listTurma = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.turma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btConsultar = new System.Windows.Forms.Button();
            this.btSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(151, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Turma:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtId.Location = new System.Drawing.Point(69, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(76, 21);
            this.txtId.TabIndex = 2;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // cbTurma
            // 
            this.cbTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cbTurma.FormattingEnabled = true;
            this.cbTurma.Location = new System.Drawing.Point(219, 25);
            this.cbTurma.Name = "cbTurma";
            this.cbTurma.Size = new System.Drawing.Size(220, 23);
            this.cbTurma.TabIndex = 3;
            // 
            // btPesquisar
            // 
            this.btPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btPesquisar.Location = new System.Drawing.Point(445, 21);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(77, 29);
            this.btPesquisar.TabIndex = 4;
            this.btPesquisar.Text = "pesquisa";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // listTurma
            // 
            this.listTurma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listTurma.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.turma,
            this.horario});
            this.listTurma.FullRowSelect = true;
            this.listTurma.HideSelection = false;
            this.listTurma.Location = new System.Drawing.Point(6, 60);
            this.listTurma.MultiSelect = false;
            this.listTurma.Name = "listTurma";
            this.listTurma.Size = new System.Drawing.Size(533, 323);
            this.listTurma.TabIndex = 5;
            this.listTurma.UseCompatibleStateImageBehavior = false;
            this.listTurma.View = System.Windows.Forms.View.Details;
            this.listTurma.SelectedIndexChanged += new System.EventHandler(this.listTurma_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "ID";
            // 
            // turma
            // 
            this.turma.Text = "Turma";
            this.turma.Width = 303;
            // 
            // horario
            // 
            this.horario.Text = "Horario";
            this.horario.Width = 164;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listTurma);
            this.groupBox1.Controls.Add(this.cbTurma);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 389);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar";
            // 
            // btConsultar
            // 
            this.btConsultar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btConsultar.Location = new System.Drawing.Point(247, 407);
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(80, 34);
            this.btConsultar.TabIndex = 6;
            this.btConsultar.Text = "Consultar";
            this.btConsultar.UseVisualStyleBackColor = true;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // btSair
            // 
            this.btSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btSair.Location = new System.Drawing.Point(476, 407);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(80, 34);
            this.btSair.TabIndex = 7;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // consultar_turma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 450);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btConsultar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "consultar_turma";
            this.Text = "SpaceTech";
            this.Load += new System.EventHandler(this.consultar_turma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbTurma;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.ListView listTurma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btConsultar;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader turma;
        private System.Windows.Forms.ColumnHeader horario;
    }
}