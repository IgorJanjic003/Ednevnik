using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ednevnik
{
    public partial class Form1 : Form
    {
        DataTable tablickata = new DataTable();
        int trenutni = 0;
        SqlConnection veza;
        public Form1()
        {
            InitializeComponent();
        }

        private void vezujpuni()
        {
            string cs = @"Data source = DESKTOP-G6UU3BE; Initial catalog = ednevnik; Integrated security = true";
            veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM osoba", veza);
            adapter.Fill(tablickata);
        }
        private void punipuni()
        {
            if(trenutni == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
            if(trenutni == tablickata.Rows.Count-1)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
            textID.Text = tablickata.Rows[trenutni]["id"].ToString();
            textIme.Text = tablickata.Rows[trenutni]["ime"].ToString();
            textPrezime.Text = tablickata.Rows[trenutni]["prezime"].ToString();
            textAdresa.Text = tablickata.Rows[trenutni]["adresa"].ToString();
            textJMBG.Text = tablickata.Rows[trenutni]["jmbg"].ToString();
            textmail.Text = tablickata.Rows[trenutni]["email"].ToString();
            textLozinka.Text = tablickata.Rows[trenutni]["pass"].ToString();
            textUloga.Text = tablickata.Rows[trenutni]["uloga"].ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

                vezujpuni(); 
                punipuni();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            trenutni = 0;
            punipuni();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trenutni = tablickata.Rows.Count - 1;
            punipuni();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                trenutni--;
                punipuni();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
                trenutni++;
                punipuni();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vezujpuni();
            string funkcija = $"INSERT INTO osoba(ime, prezime, adresa, jmbg, email, pass, uloga) values('{textIme.Text}', '{textPrezime.Text}', '{textAdresa.Text}', '{textJMBG.Text}', '{textmail.Text}','{textLozinka.Text}', {textUloga.Text})";
            SqlCommand unesi = new SqlCommand(funkcija, veza);
            veza.Open();
            unesi.ExecuteNonQuery();
            veza.Close();
            tablickata.Clear();
            vezujpuni();
            punipuni();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vezujpuni();
            string funkcija = $"UPDATE osoba SET ime='{textIme.Text}', prezime='{textPrezime.Text}', adresa='{textAdresa.Text}', jmbg='{textJMBG.Text}', email='{textmail.Text}', pass='{textLozinka.Text}', uloga = {textUloga.Text} WHERE id={textID.Text}";
            SqlCommand menjanje = new SqlCommand(funkcija, veza);
            veza.Open();
            menjanje.ExecuteNonQuery();
            veza.Close();
            tablickata.Clear();
            vezujpuni();
            punipuni();
        }

        private void obrisibutton_Click(object sender, EventArgs e)
        {
            vezujpuni();
            SqlCommand brisanje = new SqlCommand("DELETE FROM osoba WHERE id= " + textID.Text, veza);
            veza.Open();
            brisanje.ExecuteNonQuery();
            veza.Close();
            tablickata.Clear();
            vezujpuni();
            if (trenutni >= tablickata.Rows.Count)
                trenutni = tablickata.Rows.Count - 1;
            punipuni();
        }
    }
}
