using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class Main : Form
    {
        private TrueFalseDatabase database;

        public Main()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Add("Замля круглая?", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                database.Save();
            }
            catch
            {
                SaveFileDialog dlg = new SaveFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    database = new TrueFalseDatabase(dlg.FileName);
                    database.Add(tbQuestion.Text, cbTrue.Created);
                    database.Save();
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = 1;
                    nudNumber.Value = 1;
                }
            }
            
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(database != null)
                {
                    tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                    cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
                }
            }
            catch { MessageBox.Show("Необходимо создать/открыть файл!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                database.Add($"#{database.Count + 1}", true);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
            }
            catch
            {
                MessageBox.Show("Необходимо создать/открыть файл!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (database.Count > 1)
                {
                    database.Remove((int)nudNumber.Value - 1);
                    nudNumber.Maximum--;
                    nudNumber.Value--;
                }
            }
            catch
            {
                if(database == null)
                    MessageBox.Show("Необходимо создать/открыть файл!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
            catch { MessageBox.Show("Необходимо создать/открыть файл!", "TrueFalseEditor", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo pi in typeof(DateTime).GetProperties())
                sb.Append("\n" + pi.PropertyType + "\t\t" + pi.Name);

            MessageBox.Show($"Свойства DateTime: \n{ sb}");
        }
    }
}
