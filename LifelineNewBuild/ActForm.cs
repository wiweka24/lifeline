using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class ActForm : Form
    {
        NpgsqlConnection con;
        NpgsqlCommand cmd;

        public ActForm()
        {
            InitializeComponent();
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

        public ActForm(string nama, string jenisAct, string tanggal, string desk)
        {
            InitializeComponent();

            string[] date = tanggal.Split('-');
            int[] date_int = Array.ConvertAll(date, int.Parse);

            tbNama.Text = nama;
            tbDesk.Text = desk;
            clTanggal.Value = new DateTime(date_int[2], date_int[1], date_int[0]);
        }
        private void TambahData()
        {
            // act user id
            int act_user_id = 1;
            // act name
            string act_name = tbNama.Text;
            // act date (string)
            DateTime act_date_datetime = clTanggal.Value.Date;
            string act_date_string = act_date_datetime.ToString("dd-MM-yyyy");
            // act desc
            string act_desc = tbDesk.Text;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = string.Format(
                "INSERT INTO activity(act_user_id, act_name, act_desc, act_date)" +
                "VALUES ({0}, '{1}', '{2}', '{3}');", act_user_id, act_name, act_desc, act_date_string);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aktivitas Berhasil Ditambahkan");
            TambahData();
            Close();
            //int cekJenis = checkNama(tbNama.Text);
            //if (tbNama.Text == "")
            //{
            //    MessageBox.Show("Nama Aktivitas Kosong");
            //}
            //else
            //{
            //    if (cekJenis == 2)
            //    {
            //        MessageBox.Show("Aktivitas Berhasil Ditambahkan");
            //        TambahData();
            //        Close();
            //    }
            //    else
            //        MessageBox.Show("Nama Aktivitas Sama, Silahkan Ganti");
            //}
        }


        //private int checkNama(string nama)
        //{
        //    using (var db = new SkheduleDBEntities())
        //    {
        //        var query = from ActTable in db.ActTables select ActTable;
        //        foreach (var item in query)
        //        {
        //            if (item.namaAct == nama)
        //                return 1;
        //        }
        //        return 2;
        //    }
        //}

        private void btnEdt_Click(object sender, EventArgs e)
        {
            //using (var db = new SkheduleDBEntities())
            //{
            //    var query = from ActTable in db.ActTables select ActTable;
            //    foreach (var item in query)
            //    {
            //        if (item.namaAct == aktivitas.namaAct)
            //        {
            //            int cekJenis = checkNama(tbNama.Text);
            //            if (tbNama.Text == "")
            //            {
            //                MessageBox.Show("Nama Aktivitas Kosong");
            //            }
            //            else
            //            {
            //                if (cekJenis == 2)
            //                {
            //                    item.jenisAct = jenis;
            //                    item.namaAct = tbNama.Text;
            //                    item.waktuAct = clTanggal.Value.Date;
            //                    item.deskAct = tbDesk.Text;
            //                    MessageBox.Show("Aktivitas berhasil diperbarui");
            //                    Close();
            //                }
            //                else
            //                    MessageBox.Show("Nama Aktivitas Sama, Silahkan Ganti");
            //            }
            //        }
            //    }
            //    db.SaveChanges();
            //}
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //using (var db = new SkheduleDBEntities())
            //{
            //    var query = from ActTable in db.ActTables select ActTable;
            //    foreach (var item in query)
            //    {
            //        if (item.namaAct == aktivitas.namaAct)
            //            db.ActTables.RemoveRange(db.ActTables.Where(a => a.namaAct == aktivitas.namaAct));
            //    }
            //    db.SaveChanges();
            //    MessageBox.Show("Aktivitas berhasil dihapus");
            //    Close();
            //}
        }
    }
}
