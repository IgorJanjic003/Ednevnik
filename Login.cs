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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textuser.Text == "" || textsifra.Text == "")
            {
                MessageBox.Show("Molim Vas da unesete podatke");
            }
            else
            {
                try
                {
                    string cs = @"Data source = DESKTOP-G6UU3BE; Initial catalog = ednevnik; Integrated security = true";
                    SqlConnection veza = new SqlConnection(cs);
                    SqlCommand komanda = new SqlCommand($"select * from osoba where email = '{textuser.Text}'", veza);
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    if(tabela.Rows.Count == 1)
                    {
                        if(tabela.Rows[0]["pass"].ToString() == textsifra.Text)
                        {
                            MessageBox.Show("Uspesno ste se ulogovali");
                            this.Hide();
                            Program.uloga = Convert.ToInt32(tabela.Rows[0]["uloga"]);
                            Program.ime = tabela.Rows[0]["ime"].ToString();
                            Program.prezime = tabela.Rows[0]["prezime"].ToString();
                            Meni forma_meni = new Meni();
                            forma_meni.Show();
                        }
                        else
                        {
                            MessageBox.Show("Neispravna lozinka");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nepostojeci email");
                    }
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                    
                }
            }
        }
    }
}
