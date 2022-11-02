using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class LoginForm : Form
    {
        NpgsqlConnection con;
        NpgsqlCommand cmd;
        private NpgsqlDataReader dr;
        private DataTable user;
        private string userLoginID;

        public LoginForm()
        {
            InitializeComponent();
            InitializeConnection();
            GetAllUser();
        }

        private void InitializeConnection()
        {
            var uriString = "postgres://szhlblek:O4cczwKuCRX3ta_f_n4K8KjTvvfeSFZW@satao.db.elephantsql.com/szhlblek";
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);

            con = new NpgsqlConnection(connStr);
            cmd = new NpgsqlCommand();
        }

        private void GetAllUser()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM users";

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                user = new DataTable();
                user.Load(dr);
            }
            con.Dispose();
            con.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            int check = CheckUser();
            if (check == 0)
            {
                this.Hide();
                Kalender cal = new Kalender(userLoginID);
                cal.ShowDialog();
            }
        }

        private void signBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm signUp = new SignUpForm();
            signUp.ShowDialog();
        }


        private int CheckUser()
        {
            DataRow[] user_query = user.Select("user_name = '" + tbUsername.Text + "'");
            userLoginID = user_query[0]["user_id"].ToString();
            string username = user_query[0]["user_name"].ToString();
            string password = user_query[0]["user_password"].ToString();
            
            if (username == "")
            {
                MessageBox.Show("Username tidak Ditemukan");
                return 1;
            }
            else
            {
                if (password != tbPassword.Text)
                {
                    MessageBox.Show("Password yang Dimasukkan Salah");
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}