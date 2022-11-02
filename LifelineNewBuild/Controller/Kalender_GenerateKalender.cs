using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class Kalender : Form
    {
        private List<FlowLayoutPanel> listFLDays = new List<FlowLayoutPanel>();
        private List<LinkLabel> listLabel = new List<LinkLabel>();
        private DateTime currentDate = DateTime.Today;

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
            InitializeConnection();
            GetActivityTable();

            lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();

            AddLabelDay(firstDayAtFlNumber, totalDay);
            AddAppointmentAndToday(firstDayAtFlNumber);
        }

        private void AddAppointmentAndToday(int startDayAtFlNumber)
        {
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            int DayInterval = 1;

            while (startDate <= endDate)
            {
                if (activity != null)
                {
                    AddAppointmentToFlDay(startDate, startDayAtFlNumber);
                }

                if (startDate == DateTime.Today)
                {
                    listFLDays[(startDate.Day - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Orange;
                }

                startDate = startDate.AddDays(DayInterval);
            }
        }

        private void AddAppointmentToFlDay(DateTime startDate, int startDayAtFlNumber)
        {
            string date = startDate.ToString("dd-MM-yyyy");
            DataRow[] query = activity.Select("act_date = '" + date + "'");
            foreach (DataRow item in query)
            {
                DateTime appDay = startDate;
                LinkLabel link = new LinkLabel();
                link.Text = item["act_name"].ToString();
                link.Click += new EventHandler(link_Clicked);
                link.LinkColor = Color.Black;
                listLabel.Add(link);
                listFLDays[(appDay.Day - 1) + (startDayAtFlNumber - 1)].Controls.Add(link);
            }
        }

        private void LinkOpenAct(object sender)
        {
            LinkLabel link = sender as LinkLabel;
            link.LinkVisited = true;
            string actName = link.Text;

            DataRow[] query = activity.Select("act_name = '" + actName + "'");

            foreach (DataRow item in query)
            {
                ActForm aktivitas = new ActForm(item["act_name"].ToString(), item["act_type"].ToString(), item["act_date"].ToString(), item["act_desc"].ToString(), item["act_id"].ToString(), currentUser);
                aktivitas.ShowDialog();
            }
        }

        private void GenerateDayPanel(int totalDays)
        {
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(136, 75);
                fl.Margin = new Padding(5, 5, 5, 5);
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
                fl.BorderStyle = BorderStyle.None;
            }

            for (int i = 1; i <= totalDayInMonth; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.BackColor = Color.AliceBlue;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Margin = new Padding(0, 0, 0, 0);
                lbl.Size = new Size(136, 20);
                lbl.Text = i.ToString();

                listFLDays[(i - 1) + (StartDay - 1)].Controls.Add(lbl);
                listFLDays[(i - 1) + (StartDay - 1)].BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
