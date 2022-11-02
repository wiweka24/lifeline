using LifelineNewBuild.Controller;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class SignUpForm : Form
    {
        NpgsqlConnection con;
        NpgsqlCommand cmd;

        public SignUpForm()
        {
            InitializeComponent();
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            Connection newConnection = new Connection();
            (con, cmd) = newConnection.InitializeConnection();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void signBtn_Click(object sender, EventArgs e)
        {
            int check = CheckField();
            if (check == 0)
            {
                CreateNewUser();
                this.Hide();
                LoginForm login = new LoginForm();
                login.ShowDialog();
            }
        }

        private void CreateNewUser()
        {
            string firstName = tbFirst.Text;
            string lastName = tbLast.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = string.Format(
                "INSERT INTO users(user_name, user_password, user_firstname, user_lastname)" +
                "VALUES ('{0}', '{1}', '{2}', '{3}');", username, password, firstName, lastName);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("User berhasil terdaftar");
        }

        private int CheckField()
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                MessageBox.Show("Username tidak boleh kosong");
                return 1;
            }
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong");
                return 1;
            }
            else if (string.IsNullOrEmpty(tbFirst.Text))
            {
                MessageBox.Show("Firstname tidak boleh kosong");
                return 1;
            }
            else if (string.IsNullOrEmpty(tbLast.Text))
            {
                MessageBox.Show("Lastname tidak boleh kosong");
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}