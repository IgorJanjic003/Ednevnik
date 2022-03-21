using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ednevnik
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 osoba = new Form1();
            osoba.Show();
        }

        private void Meni_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Meni_Load(object sender, EventArgs e)
        {
            label1.Text = Program.ime + " " + Program.prezime;
            label2.Text = Program.uloga.ToString();
        }
    }
}
