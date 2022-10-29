using Npgsql;
using System.Configuration;
using System.Data;

namespace Lifeline
{
    public partial class Kalender : Form
    {
        private List<FlowLayoutPanel> listFLDays = new List<FlowLayoutPanel>();
        private List<LinkLabel> listLabel = new List<LinkLabel>();
        private DataTable activity;
        private DateTime currentDate = DateTime.Today;

        /// Kalender Load dan beberapa tombol untuk mengakses fungsi
        public Kalender()
        {
            InitializeComponent();
            var uriString = ConfigurationManager.AppSettings["postgres://szhlblek:O4cczwKuCRX3ta_f_n4K8KjTvvfeSFZW@satao.db.elephantsql.com/szhlblek"] ?? "postgres://postgres:7064@localhost/lifeline";
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);

            NpgsqlConnection con = new NpgsqlConnection(connStr);

            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM activity";
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt = new DataTable();
                dt.Load(dr);
            }
            con.Dispose();
            con.Close();
        }

        private void Kalender_Load_1(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            AddLabelDay(5, 31);
            DisplayCurrentDate();
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayCurrentDate();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate();
        }

        private void btnNewAct_Click(object sender, EventArgs e)
        {
            //ActForm aktBaru = new ActForm();
            //aktBaru.ShowDialog();
            //DisplayCurrentDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCurrentDate();
        }

        /// Fungsi yang digunakan oleh kode kode diatas
        private int GetFirstDayOfWeekOfCurrentDate()
        {
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            return (int)(firstDayOfMonth.DayOfWeek + 1);
        }

        private int GetTotalDaysOfCurrentDate()
        {
            DateTime firstDayOfCurrentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            return firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day;
        }

        private void DisplayCurrentDate()
        {
            lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();
            AddLabelDay(firstDayAtFlNumber, totalDay);
            AddAppointmentToFlDay(firstDayAtFlNumber);
            //AddAppointmentDailyToFlDay(firstDayAtFlNumber);
        }

        private void AddAppointmentToFlDay(int startDayAtFlNumber)
        {
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            int DayInterval = 1;

            while (startDate <= endDate)
            {
                string date = startDate.ToString("dd-MM-yyyy");
                DataRow[] query = activity.Select("act_date = '" + date + "'");
                foreach (DataRow item in query)
                {
                    DateTime appDay = startDate;
                    LinkLabel link = new LinkLabel();
                    link.Text = item[1].ToString();
                    /*link.Click += new EventHandler(link_Clicked);*/
                    link.LinkColor = Color.Black;
                    listLabel.Add(link);
                    listFLDays[(appDay.Day - 1) + (startDayAtFlNumber - 1)].Controls.Add(link);
                }

                if (startDate == DateTime.Today)
                {
                    listFLDays[(startDate.Day - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Orange;
                }
                startDate = startDate.AddDays(DayInterval);
            }
        }

        /*
        private void AddAppointmentDailyToFlDay(int startDayAtFlNumber)
        {
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            int DayInterval = 1;
            string[] hari = { "Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu"};
            string hariIni;

            while (startDate <= endDate)
            {
                for(int i = 0; i < 7; i++)
                {
                    if ((int)startDate.DayOfWeek == i)
                    {
                        hariIni = hari[i];
                        using (var db = new SkheduleDBEntities())
                        {
                            var query = from ActDailyTable in db.ActDailyTables where ActDailyTable.waktuDact == hariIni select ActDailyTable;
                            foreach (var item in query)
                            {
                                DateTime appDay = startDate;
                                LinkLabel link = new LinkLabel();
                                link.Text = item.namaDact;
                                link.Click += new EventHandler(link_Clicked);
                                listLabel.Add(link);
                                listFLDays[(appDay.Day - 1) + (startDayAtFlNumber - 1)].Controls.Add(link);
                            }
                        }
                    }
                }
                startDate = startDate.AddDays(DayInterval);
            }
        }

        private void link_Clicked(object sender, EventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            link.LinkVisited = true;
            using (var db = new SkheduleDBEntities())
            {
                var query = from ActTable in db.ActTables where ActTable.namaAct == link.Text select ActTable;
                var query2 = from ActDailyTable in db.ActDailyTables where ActDailyTable.namaDact == link.Text select ActDailyTable;
                foreach (var item in query)
                {
                    ActForm aktivitas = new ActForm(item.namaAct, item.jenisAct, item.waktuAct, item.deskAct);
                    aktivitas.ShowDialog();
                }
                foreach(var item in query2)
                {
                    ActForm aktivitas = new ActForm(item.namaDact, item.jenisDact, item.waktuDact, item.deskDact);
                    aktivitas.ShowDialog();
                }
            }
        }*/

        private void GenerateDayPanel(int totalDays)
        {
            flDays.Controls.Clear();
            listFLDays.Clear();
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(160, 80);
                fl.Margin = new Padding(5, 5, 5, 5);
                fl.BackColor = Color.White;
                fl.BorderStyle = BorderStyle.FixedSingle;
                flDays.Controls.Add(fl);
                listFLDays.Add(fl);
            }
        }

        private void AddLabelDay(int StartDay, int totalDayInMonth)
        {
            foreach (FlowLayoutPanel fl in listFLDays)
            {
                fl.Controls.Clear();
                fl.BackColor = Color.White;
            }

            for (int i = 1; i <= totalDayInMonth; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.BackColor = Color.AliceBlue;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Margin = new Padding(0, 0, 0, -10);
                lbl.Size = new Size(160, 20);
                lbl.Text = i.ToString();
                listFLDays[(i - 1) + (StartDay - 1)].Controls.Add(lbl);
            }
        }
    }
}
