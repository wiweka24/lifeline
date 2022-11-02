using System;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class ActForm : Form
    {
        private string currentAct;
        private string currentUser;

        public ActForm(string userLogin)
        {
            InitializeComponent();
            InitializeConnection();

            currentUser = userLogin;
        }

        public ActForm(string nama, string jenisAct, string tanggal, string desk, string act_id, string userLogin)
        {
            InitializeComponent();
            InitializeConnection();

            string[] date = tanggal.Split('-');
            int[] date_int = Array.ConvertAll(date, int.Parse);

            tbNama.Text = nama;
            tbDesk.Text = desk;
            clTanggal.Value = new DateTime(date_int[2], date_int[1], date_int[0]);

            currentAct = act_id;
            currentUser = userLogin;    
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            if (tbNama.Text == "")
            {
                MessageBox.Show("Nama Aktivitas Kosong");
            }
            else
            {
                TambahData();
                MessageBox.Show("Aktivitas Berhasil Ditambahkan");
                Close();
            }
        }

        private void btnEdt_Click(object sender, EventArgs e)
        {
            if (tbNama.Text == "")
            {
                MessageBox.Show("Nama Aktivitas Kosong");
            }
            else
            {
                EditData();
                MessageBox.Show("Aktivitas Berhasil Diubah");
                Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("Apakah Anda yakin menghapus {0}", tbNama.Text), "Konfirmasi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteData();
                MessageBox.Show("Aktivitas Berhasil Dihapus");
                Close();
            }
        }
    }
}
