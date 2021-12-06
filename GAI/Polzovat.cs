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
    public partial class Polzovat : Form
    {
        Model1 db = new Model1();
        public Drivers driv { get; set; }
        public Polzovat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Polzovat_Load(object sender, EventArgs e)
        {
            driversBindingSource.DataSource = db.Drivers.ToList();

        }

        private void driversBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //Drivers driv = (Drivers)driversBindingSource.Current;
            //try
            //{
            //    if (driv.Photo != "")
            //    {
            //        string str = driv.Photo.Substring(1);
            //        Box.Image = Image.FromFile(str);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text.ToUpper();
            driversBindingSource.DataSource = db.Drivers.
            Where(p => p.LastName.ToUpper().Contains(s)).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            driversBindingSource.DataSource = db.Drivers.ToList<Drivers>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Redactpol frm = new Redactpol();
            frm.driv = null;
            DialogResult dr = frm.ShowDialog();
            // если пользователь DialogResut == OK
            if (dr == DialogResult.OK)
            {
                driversBindingSource.DataSource = null;
                driversBindingSource.DataSource = db.Drivers.ToList();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drivers driv = (Drivers)driversBindingSource.Current;
            Redactpol frm = new Redactpol();
            frm.driv = driv;
            this.Hide();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                driversBindingSource.DataSource = null;
                driversBindingSource.DataSource = db.Drivers.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Glavnoe_menu pmf = new Glavnoe_menu();
            pmf.Show();
            Hide();
        }
    }
}
