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
            this.SaveState.Location = new System.Drawing.Point(12, 41);
            this.SaveState.Name = "SaveState";
            this.SaveState.Size = new System.Drawing.Size(149, 23);
            this.SaveState.TabIndex = 21;
            this.SaveState.Text = "Guardar estado";
            this.SaveState.UseVisualStyleBackColor = true;
            this.SaveState.Click += new System.EventHandler(this.SaveState_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(295, 41);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 22;
            this.UpButton.Text = "UP";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 84);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(175, 486);
            this.treeView1.TabIndex = 24;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 582);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.SaveState);
            this.Controls.Add(this.FileSelectorButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button FileSelectorButton;
        private System.Windows.Forms.Button SaveState;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.TreeView treeView1;
    }
}