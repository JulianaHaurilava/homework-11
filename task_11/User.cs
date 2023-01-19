using System;
using System.Collections.Generic;

namespace task_11
{
    class User
    {
        static public ulong ID { get; set; }
        static User()
        {
            string stringID = (DateTime.Now.Year % 100).ToString() + DateTime.Now.Month.ToString("00") +
                              DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") +
                              DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
            ID = ulong.Parse(stringID);
        }
        static ulong GetNextID()
        {
            return ++ID;
        }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public Department Department { get; set; }

        public string PassportSeries { get; set; }

        public int PassportNumber { get; set; }

        public string HiddenPassportSeries
        {
            get => "**";
            set => HiddenPassportSeries = value;
        }

        public string HiddenPassportNumber
        {
            get => "*******";
            set => HiddenPassportSeries = value;
        }

        public User()
        {
            Surname = "";
            Name = "";
            Patronymic = "";
            PhoneNumber = new PhoneNumber();
            Department = new Department();
            PassportSeries = "";
            PassportNumber = 0;
        }

        public User(string userInfo)
        {
            string[] userInfoArray = userInfo.Split(' ');
            ID = ulong.Parse(userInfoArray[0]);
            Surname = userInfoArray[1];
            Name = userInfoArray[2];
            Patronymic = userInfoArray[3];
            PhoneNumber = new PhoneNumber(userInfoArray[4]);
            Department = new Department(userInfoArray[5]);
            PassportSeries = userInfoArray[6];
            PassportNumber = int.Parse(userInfoArray[7]);
        }

        public User(string surname, string name, string patronymic,
            string phoneNumber, string departmentName, string passportSeries, int passportNumber)
        {
            ID = GetNextID();
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = new PhoneNumber(phoneNumber);
            Department = new Department(departmentName);
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
        }

        public override string ToString()
        {
            return ID + " " + Surname + " " + Name + " " + Patronymic + " " + PhoneNumber.ReturnSimpleNumber() +
                " " + Department + " " + PassportSeries + " " + PassportNumber;
        }
    }
}
