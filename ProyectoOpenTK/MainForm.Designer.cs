namespace ProyectoOpenTK
{
    partial class MainForm
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
            this.FileSelectorButton = new System.Windows.Forms.Button();
            this.SaveState = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.degressValueNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.incDecValNum = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.movementValNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.selectLibreto = new System.Windows.Forms.Button();
            this.PlayLibreto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.degressValueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incDecValNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movementValNum)).BeginInit();
            this.SuspendLayout();
            // 
            // FileSelectorButton
            // 
            this.FileSelectorButton.Location = new System.Drawing.Point(12, 12);
            this.FileSelectorButton.Name = "FileSelectorButton";
            this.FileSelectorButton.Size = new System.Drawing.Size(149, 23);
            this.FileSelectorButton.TabIndex = 10;
            this.FileSelectorButton.Text = "Seleccionar Archivo";
            this.FileSelectorButton.UseVisualStyleBackColor = true;
            this.FileSelectorButton.Click += new System.EventHandler(this.FileSelectorButton_Click);
            // 
            // SaveState
            // 
            this.SaveState.Location = new System.Drawing.Point(12, 70);
            this.SaveState.Name = "SaveState";
            this.SaveState.Size = new System.Drawing.Size(149, 23);
            this.SaveState.TabIndex = 21;
            this.SaveState.Text = "Guardar estado";
            this.SaveState.UseVisualStyleBackColor = true;
            this.SaveState.Click += new System.EventHandler(this.SaveState_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(425, 172);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 22;
            this.UpButton.Text = "Mover";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 100);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(175, 486);
            this.treeView1.TabIndex = 24;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // degressValueNum
            // 
            this.degressValueNum.Location = new System.Drawing.Point(479, 24);
            this.degressValueNum.Name = "degressValueNum";
            this.degressValueNum.Size = new System.Drawing.Size(120, 20);
            this.degressValueNum.TabIndex = 25;
            this.degressValueNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.degressValueNum.ValueChanged += new System.EventHandler(this.degressValueNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Grados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Porcentaje Inc/Dec";
            // 
            // incDecValNum
            // 
            this.incDecValNum.DecimalPlaces = 2;
            this.incDecValNum.Location = new System.Drawing.Point(479, 58);
            this.incDecValNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.incDecValNum.Name = "incDecValNum";
            this.incDecValNum.Size = new System.Drawing.Size(120, 20);
            this.incDecValNum.TabIndex = 28;
            this.incDecValNum.Value = new decimal(new int[] {
            111,
            0,
            0,
            131072});
            this.incDecValNum.ValueChanged += new System.EventHandler(this.incDecValNum_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(326, 153);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Mover X";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(326, 176);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 17);
            this.checkBox2.TabIndex = 30;
            this.checkBox2.Text = "Mover Y";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(326, 199);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 31;
            this.checkBox3.Text = "Mover Z";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // movementValNum
            // 
            this.movementValNum.DecimalPlaces = 1;
            this.movementValNum.Location = new System.Drawing.Point(479, 89);
            this.movementValNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.movementValNum.Name = "movementValNum";
            this.movementValNum.Size = new System.Drawing.Size(120, 20);
            this.movementValNum.TabIndex = 33;
            this.movementValNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.movementValNum.ValueChanged += new System.EventHandler(this.movementValNum_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Movimiento";
            // 
            // selectLibreto
            // 
            this.selectLibreto.Location = new System.Drawing.Point(12, 41);
            this.selectLibreto.Name = "selectLibreto";
            this.selectLibreto.Size = new System.Drawing.Size(149, 23);
            this.selectLibreto.TabIndex = 34;
            this.selectLibreto.Text = "Seleccionar Libreto";
            this.selectLibreto.UseVisualStyleBackColor = true;
            this.selectLibreto.Click += new System.EventHandler(this.selectLibreto_Click);
            // 
            // PlayLibreto
            // 
            this.PlayLibreto.Location = new System.Drawing.Point(167, 41);
            this.PlayLibreto.Name = "PlayLibreto";
            this.PlayLibreto.Size = new System.Drawing.Size(75, 23);
            this.PlayLibreto.TabIndex = 35;
            this.PlayLibreto.Text = "Play";
            this.PlayLibreto.UseVisualStyleBackColor = true;
            this.PlayLibreto.Click += new System.EventHandler(this.PlayLibreto_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 622);
            this.Controls.Add(this.PlayLibreto);
            this.Controls.Add(this.selectLibreto);
            this.Controls.Add(this.movementValNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.incDecValNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.degressValueNum);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.SaveState);
            this.Controls.Add(this.FileSelectorButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.degressValueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incDecValNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movementValNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button FileSelectorButton;
        private System.Windows.Forms.Button SaveState;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.NumericUpDown degressValueNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown incDecValNum;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.NumericUpDown movementValNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectLibreto;
        private System.Windows.Forms.Button PlayLibreto;
    }
}