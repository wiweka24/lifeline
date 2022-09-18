using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LifelineWinForm
{
    class Activity
    {
        //Instance
        private int _actID;
        private string _actName;
        private string _actType;
        private string _actDesc;
        private DateOnly _actDate;
        private TimeOnly _actTime;

        //Property
        public int ActID
        {
            get { return _actID; }
        }

        public string ActName
        {
            get { return _actName; }
            set { _actName = value; }
        }

        public string ActType
        {
            get { return _actType; }
            set { _actType = value; }
        }

        public string ActDesc
        {
            get { return _actDesc; }
            set { _actDesc = value; }
        }

        public DateOnly ActDate
        {
            get { return _actDate; }
            set { _actDate = value; }
        }

        public TimeOnly ActTime
        {
            get { return _actTime; }
            set { _actTime = value; }
        }

        //Method
        public void SetName()
        {

        }

        public void SetType()
        {

        }

        public void SetDesc()
        {

        }

        public void SetDate()
        {
            _actDate = new DateOnly();
        }

        public void SetTime()
        {
            _actTime = new TimeOnly();
        }
    }

    class CalendarAct : Activity
    {
        //Method
        public void DisplayCalendar()
        {

        }

        public void GetActiveActivity(string ActName, DateOnly ActDate, TimeOnly ActTime)
        {

        }

        public void DisplayActivity(string ActName, string ActType, DateOnly ActDate, TimeOnly ActTime)
        {

        }
    }

    class Reminder : Activity
    {
        //Instance
        private bool _isActive;
        private DateOnly _remDate;
        private TimeOnly _remTime;

        //Property
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public DateOnly RemDate
        {
            get { return _remDate; }
            set {_remDate = value; }
        }

        public TimeOnly RemTime
        {
            get { return _remTime; }
            set { _remTime = value; }
        }

        //Method
        public void GetActiveActivity(string ActName, DateOnly ActDate, TimeOnly ActTime)
        {

        }

        public void SetStatus(DateOnly RemDate, TimeOnly RemTime)
        {

        }
    }
}
