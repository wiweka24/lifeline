using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace LifelineNewBuild
{
    public partial class Kalender : Form
    {
        private NpgsqlConnection con;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader dr;
        private DataTable activity;

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
        }

        private void GetActivityTable()
        {
            try
            {
                con.Open();
                cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM activity";

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    activity = new DataTable();
                    activity.Load(dr);
                }
                con.Dispose();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
