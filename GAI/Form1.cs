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
    public partial class Form1 : Form
    {
        byte schert = 3;   // счетчик для количества попыток
        byte seconds = 60;   // переменная для определения оставшегося времени до разблокировки
        public static Regi US { get; set; }
        Model1 db = new Model1();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            byte schert = 3;
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
            erorrM.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (loginTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Нужно задать логин, пароль и роль!");
                return;
            }
            Regi usr = db.Regi.Find(loginTextBox.Text);
            if ((usr != null) && (usr.Password == passwordTextBox.Text))
            {
                US = usr;
                if (usr.Dolsh == "Инспектор")
                {
                    Glavnoe_menu frm = new Glavnoe_menu();
                    frm.Show();
                    this.Hide();
                    schert = 3;
                    erorrM.Text = "";
                }

                else
                {
                    schert -= 1;
                    erorrM.Text = "Неверно введен логин или пароль" +
                             "\n" + "    Попыток осталось " + schert;
                    passwordTextBox.Text = "";
                    if (schert < 1)
                    {
                        loginTextBox.Text = "";
                        loginTextBox.Enabled = false;
                        passwordTextBox.Enabled = false;
                        button2.Enabled = false;
                        block.Enabled = true;
                        sec.Enabled = true;

                    }
                }
            }
           
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)   // нажатие enter
            {

                if ((loginTextBox.Text == "") && (passwordTextBox.Text == ""))
                {
                    MessageBox.Show("Нужно задать логин и пароль!");
                    return;
                }
                Regi usr = db.Regi.Find(loginTextBox.Text);
                if ((usr != null) && (usr.Password == passwordTextBox.Text))
                {
                    Glavnoe_menu NextForm = new Glavnoe_menu();    //  для перехода
                    NextForm.Show();                 //   на следующую форму
                    schert = 3;  // одновление счетчика
                    erorrM.Text = "";  // очистка поля ошибки, ведь логин пароль верны
                }
                else
                {
                    schert -= 1;   // с каждой неверной попытки уменьшение счетчика попыток
                    erorrM.Text = "Неверно введен логин или пароль" +
                             "\n" + "    Попыток осталось " + schert;  // текст ошибки с выведение количества оставшихся попыток
                    passwordTextBox.Text = "";  // очищение поля пароль
                    if (schert < 1)   // если количество попыток меньше 1, то блокировка
                    {
                        loginTextBox.Text = "";  // очищаем поле логин (поле пароль очищено выше)
                        loginTextBox.Enabled = false;
                        passwordTextBox.Enabled = false;
                        button2.Enabled = false;  // блокируем поля и кнопку
                        block.Enabled = true;  // включаем счетчик, считает 1мин и выключает себя и секундный таймер
                        sec.Enabled = true;    // секундный таймер. отсчитывает каждую секунду секунду

                    }
                }
            }
        }

        private void block_Tick(object sender, EventArgs e)
        {
            sec.Enabled = false;      // отключает секундный таймер
            erorrM.Text = "";    // очищает поле ошибки
            loginTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
            button2.Enabled = true;  // разблокирывает поля и кнопку
            schert = 3;  // востанавливает кол-во попыток
            seconds = 60;  // востанавливает кол-во времени до разблокировки (на будущее)
            block.Enabled = false;  // выключает секундный таймер 
        }

        private void sec_Tick(object sender, EventArgs e)
        {
            seconds -= 1;   // от переменной отнимаем 1 каждый раз как срабатывает счетчик

            erorrM.Text = "     Превышен лимит попыток" +
                     "\n" + "До зарблокировки осталось " + seconds + " сек";
            // выводим сообщение об ошибке(блокировки) со значением оставшегося времени
        }

        private void loginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)    // нажатие enter
                passwordTextBox.Focus();                      // получение фокуса строке логина
        }
    }
}
