namespace Zachitect_RH
{
    partial class FormSuperExport
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
            this.button_Save = new System.Windows.Forms.Button();
            this.listbox_ExportFiles = new System.Windows.Forms.ListBox();
            this.button_Proceed = new System.Windows.Forms.Button();
            this.combobox_Format = new System.Windows.Forms.ComboBox();
            this.label_Count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listbox_FullPath = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(196, 232);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(96, 23);
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "Export As";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // listbox_ExportFiles
            // 
            this.listbox_ExportFiles.FormattingEnabled = true;
            this.listbox_ExportFiles.Location = new System.Drawing.Point(12, 28);
            this.listbox_ExportFiles.Name = "listbox_ExportFiles";
            this.listbox_ExportFiles.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listbox_ExportFiles.Size = new System.Drawing.Size(280, 95);
            this.listbox_ExportFiles.TabIndex = 1;
            // 
            // button_Proceed
            // 
            this.button_Proceed.Location = new System.Drawing.Point(12, 310);
            this.button_Proceed.Name = "button_Proceed";
            this.button_Proceed.Size = new System.Drawing.Size(280, 23);
            this.button_Proceed.TabIndex = 2;
            this.button_Proceed.Text = "Proceed";
            this.button_Proceed.UseVisualStyleBackColor = true;
            this.button_Proceed.Click += new System.EventHandler(this.button_SelObj_Click);
            // 
            // combobox_Format
            // 
            this.combobox_Format.FormattingEnabled = true;
            this.combobox_Format.Location = new System.Drawing.Point(54, 233);
            this.combobox_Format.Name = "combobox_Format";
            this.combobox_Format.Size = new System.Drawing.Size(136, 21);
            this.combobox_Format.TabIndex = 3;
            this.combobox_Format.SelectedIndexChanged += new System.EventHandler(this.combobox_Format_SelectedIndexChanged);
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.ForeColor = System.Drawing.Color.Crimson;
            this.label_Count.Location = new System.Drawing.Point(12, 9);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(117, 13);
            this.label_Count.TabIndex = 4;
            this.label_Count.Text = "Num. of Items Selected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(12, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Format";
            // 
            // listbox_FullPath
            // 
            this.listbox_FullPath.FormattingEnabled = true;
            this.listbox_FullPath.Location = new System.Drawing.Point(12, 129);
            this.listbox_FullPath.Name = "listbox_FullPath";
            this.listbox_FullPath.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listbox_FullPath.Size = new System.Drawing.Size(280, 95);
            this.listbox_FullPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "• Last used export settings will be used\r\n• Do a normal export to change settings" +
    "";
            // 
            // FormSuperExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 345);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listbox_FullPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Count);
            this.Controls.Add(this.combobox_Format);
            this.Controls.Add(this.button_Proceed);
            this.Controls.Add(this.listbox_ExportFiles);
            this.Controls.Add(this.button_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSuperExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSuperExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ListBox listbox_ExportFiles;
        private System.Windows.Forms.Button button_Proceed;
        private System.Windows.Forms.ComboBox combobox_Format;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listbox_FullPath;
        private System.Windows.Forms.Label label2;
    }
}