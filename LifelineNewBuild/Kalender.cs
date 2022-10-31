using System;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class Kalender : Form
    {
        public Kalender()
        {
            InitializeComponent();
        }

        // Awal Load Calender
        private void Kalender_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
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

        // Klik Aktivitas Baru -> Buka Form Aktivitas
        private void btnNewAct_Click(object sender, EventArgs e)
        {
            ActForm newAct = new ActForm();
            newAct.ShowDialog();
            DisplayCurrentDate();
        }

        // Klik Link di Aktivitas
        private void link_Clicked(object sender, EventArgs e)
        {
            LinkOpenAct(sender);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCurrentDate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
