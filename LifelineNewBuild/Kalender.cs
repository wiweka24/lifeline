using LifelineNewBuild.Controller;
using Npgsql;
using System;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class Kalender : Form
    {
        private string currentUser;
        private NpgsqlConnection con;
        private NpgsqlCommand cmd;

        public Kalender()
        {
            InitializeComponent();
        }

        public Kalender(string userLogin, string userName)
        {
            InitializeComponent();
            currentUser = userLogin;
            lblUsername.Text = userName;
        }

        private void InitializeConnection()
        {
            Connection newConnection = new Connection();
            (con, cmd) = newConnection.InitializeConnection();
        }

        private void Kalender_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            GenerateUpcomingActPanel(4);
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
            ActForm newAct = new ActForm(currentUser);
            newAct.ShowDialog();
            DisplayCurrentDate();
        }

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
