using System;
using System.Collections.Generic;
using System.Data;
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
            lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();
            AddLabelDay(firstDayAtFlNumber, totalDay);
            AddAppointmentToFlDay(firstDayAtFlNumber);
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
                    link.Text = item[2].ToString();
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
        }*/

        private void LinkOpenAct()
        {
            //LinkLabel link = sender as LinkLabel;
            //link.LinkVisited = true;
            //using (var db = new SkheduleDBEntities())
            //{
            //    var query = from ActTable in db.ActTables where ActTable.namaAct == link.Text select ActTable;
            //    var query2 = from ActDailyTable in db.ActDailyTables where ActDailyTable.namaDact == link.Text select ActDailyTable;
            //    foreach (var item in query)
            //    {
            //        ActForm aktivitas = new ActForm(item.namaAct, item.jenisAct, item.waktuAct, item.deskAct);
            //        aktivitas.ShowDialog();
            //    }
            //    foreach(var item in query2)
            //    {
            //        ActForm aktivitas = new ActForm(item.namaDact, item.jenisDact, item.waktuDact, item.deskDact);
            //        aktivitas.ShowDialog();
            //    }
            //}
        }

        private void GenerateDayPanel(int totalDays)
        {
            flDays.Controls.Clear();
            listFLDays.Clear();
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(136, 75);
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
                lbl.Margin = new Padding(0, 0, 0, 0);
                lbl.Size = new Size(136, 20);
                lbl.Text = i.ToString();
                listFLDays[(i - 1) + (StartDay - 1)].Controls.Add(lbl);
            }
        }
    }
}
