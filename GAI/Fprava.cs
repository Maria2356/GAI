using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAI
{
    public partial class Fprava : Form
    {
        Model1 db = new Model1();
        public Fprava()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Fprava_Load(object sender, EventArgs e)
        {
            pravaBindingSource.DataSource = db.Prava.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Glavnoe_menu pmf = new Glavnoe_menu();
            pmf.Show();
            Hide();
        }
    }
}
