using LifelineNewBuild.Controller;
using Npgsql;
using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LifelineNewBuild
{
    public partial class LoginForm : Form
    {
        NpgsqlConnection con;
        NpgsqlCommand cmd;
        private NpgsqlDataReader dr;
        private DataTable user;
        private string userID;
        private string username;
        private string password;

        public LoginForm()
        {
            InitializeComponent();
            InitializeConnection();
            GetAllUser();
        }

        private void InitializeConnection()
        {
            Connection newConnection = new Connection();
            (con, cmd) = newConnection.InitializeConnection();
        }

        private void GetAllUser()
        {
            try
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
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void loginBtn_Click(object sender, EventArgs e)
        {
            int check = CheckUser();
            if (check == 0)
            {
                this.Hide();
                Kalender cal = new Kalender(userID, username);
                cal.ShowDialog();
            }
            //else
            //{
            //    MessageBox.Show("Username tidak Ditemukan");
            //}
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
            if (user_query.Length > 0)
            {
                userID = user_query[0]["user_id"].ToString();
                username = user_query[0]["user_name"].ToString();
                password = user_query[0]["user_password"].ToString();
                
                if (password != tbPassword.Text || password == null)
                {
                    MessageBox.Show("Password yang dimasukkan salah!");
                    return 1;
                }
            }
            else
            {
                if (username == "" || username == null)
                {
                    MessageBox.Show("Username tidak ditemukan!");
                    return 1;
                }
            }
            return 0;
        }

        private void loginBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                loginBtn_Click(sender, e);
            }
        }
    }
}