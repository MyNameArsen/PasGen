using System;
using System.Linq;
using System.Windows.Forms;

namespace PasGen
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void GenBtn_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                Random rand = new Random();
                string chars = "";
                string s = "abcdefghijklmnopqrstuvwxyz";
                if (checkBox1.Checked) chars += s;
                if (checkBox2.Checked) chars += s.ToUpper();
                if (checkBox3.Checked) chars += "0123456789";
                if (checkBox4.Checked) chars += "!@#$%^&*()_+=-/\\<>|";
                string[] pas = new string[(int)numericUpDown1.Value];
                for (int i = 0; i < pas.Length; i++)
                {
                    string str = "";
                    while (str.Length < (int)numericUpDown2.Value)
                        str += chars.Substring(rand.Next(chars.Length), 1);
                    pas[i] = str;
                    pasList.Items.Add(pas[i]);
                }
            }
            else MessageBox.Show("Выберите допустимые символы");
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (pasList.SelectedItem != null)
            {
                Clipboard.SetText(pasList.SelectedItem.ToString());
                MessageBox.Show("Cкопировано в буфер обмена");
            }
            else MessageBox.Show("Выберите пароль!");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (pasList.Items.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                    System.IO.File.WriteAllLines(save.FileName, pasList.Items.OfType<string>());
            }
            else MessageBox.Show("Файл пуст!");
        }

        private void button1_Click(object sender, EventArgs e) => pasList.Items.Clear();

        private void toolStripMenuItem1_Click(object sender, EventArgs e) => CopyBtn.PerformClick();
    }
}
