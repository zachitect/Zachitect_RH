using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zachitect_RH
{
    public partial class FormSuperExport : Form
    {
        public List<String> ExFormats = new List<String>();
        public int ItemCount { get; set; }
        public List<String> SelectedItemNames { get; set; }
        public int selectedformat { get; set; }
        public String spath { get; set; }
        public String sname { get; set; }
        public String sext { get; set; }
        public List<String> FullPath = new List<string>();


        public FormSuperExport()
        {
            InitializeComponent();
            ExFormats.Add("AutoCAD|*.dwg");
            ExFormats.Add("ACIS|*.sat");
            foreach(String i in ExFormats)
            {
                combobox_Format.Items.Add(i);
            }
            combobox_Format.SelectedIndex = 0;
            selectedformat = 0;
            button_Proceed.Enabled = false;

            Shown += FormSuperExport_Shown;
        }
        private void FormSuperExport_Shown(object sender, EventArgs e)
        {
            listbox_ExportFiles.Items.Clear();
            label_Count.Text = String.Format("{0} objects selected to be exported:", ItemCount.ToString());
            if (SelectedItemNames != null)
            {
                foreach (String i in SelectedItemNames)
                {
                    listbox_ExportFiles.Items.Add(i);
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            FullPath.Clear();
            listbox_FullPath.Items.Clear();
            SaveFileDialog SF = new SaveFileDialog();
            SF.Title = "Location for Individual Batch Export:";
            SF.Filter = ExFormats[selectedformat];
            if(SF.ShowDialog() == DialogResult.OK)
            {
                spath = Path.GetDirectoryName(SF.FileName) + "\\";
                sname = Path.GetFileNameWithoutExtension(SF.FileName);
                sext = Path.GetExtension(SF.FileName);
                for (int i = 0; i < ItemCount; i++)
                {
                    String indname = sname + "_" + i.ToString();
                    String indfile = spath + indname + sext;
                    listbox_FullPath.Items.Add(indfile);
                    FullPath.Add(indfile);
                    button_Proceed.Enabled = true;
                }
            }
        }
        private void combobox_Format_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedformat = this.combobox_Format.SelectedIndex;
        }
        private void button_SelObj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
