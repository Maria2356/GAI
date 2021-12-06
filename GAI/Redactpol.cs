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
    public partial class Redactpol : Form
    {
        Model1 db = new Model1();
        public Drivers driv { get; set; }
        public Redactpol()
        {
            InitializeComponent();
        }

        private void Redactpol_Load(object sender, EventArgs e)
        {
            driversBindingSource.DataSource = db.Drivers.ToList<Drivers>();
            if (driv == null)

            {
                driversBindingSource.AddNew();
                this.Text = "Добавление новой книги";
            }
            else
            {
                driversBindingSource.Add(driv);
                this.Text = "Корректировка данных о книгах " + driv.LastName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (driv == null)
            { // если создан новый объект, то получаем его промеж. объекта
                Drivers driv = (Drivers)driversBindingSource.Current;
                // сохраняем созданный и заполненный объект в коллекции
                db.Drivers.Add(driv);
               

            }
            try
            {
                db.SaveChanges();

                // если задать значение свойству DialogResult, то форма закроется

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            { // если возникла ошибка, то показываем сообщение
                MessageBox.Show("Ошибка" + ex.Message);
                // если DialogResult значение не задано, форма не закрывается
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Polzovat frm = new Polzovat();
            this.Close();
            frm.Show();
        }
    }
}
