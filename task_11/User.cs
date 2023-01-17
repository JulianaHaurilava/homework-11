using System;

namespace task_11
{
    class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public string PassportSeries { get; set; }

        public string PassportNumber { get; set; }

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
            PassportSeries = "";
            PassportNumber = "";
        }

        public User(string userInfo)
        {
            string[] userInfoArray = userInfo.Split(' ');
            Surname = userInfoArray[0];
            Name = userInfoArray[1];
            Patronymic = userInfoArray[2];
            PhoneNumber = new PhoneNumber(userInfoArray[3]);
            PassportSeries = userInfoArray[4];
            PassportNumber = userInfoArray[5];
        }

        public User(string surname, string name, string patronymic,
            string phoneNumber, string passportSeries, string passportNumber)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = new PhoneNumber(phoneNumber);
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
        }

        /// <summary>
        /// Выводит информацию обо всех клиентах
        /// </summary>
        /// <param name="workerType"></param>
        public void Print(WorkerType workerType)
        {
            Console.Write($"Ф.И.О: {Surname + " " + Name + " " + Patronymic}\n" +
                $"Номер телефона: {PhoneNumber}\n");
            if (!String.IsNullOrEmpty(PassportSeries))
                switch (workerType)
                {
                    case WorkerType.Consultant:
                        Console.Write($"Серия и номер паспорта: *********\n");
                        break;
                    case WorkerType.Manager:
                        Console.Write($"Серия и номер паспорта: {PassportSeries + PassportNumber}\n");
                        break;
                    default:
                        break;
                }
            else Console.Write($"Серия и номер паспорта: данные не указаны\n");
        }

        /// <summary>
        /// Конвертирует информацию о клиенте в строку для записи в файл
        /// </summary>
        /// <returns></returns>
        public string CreateStringForFile()
        {
            return Surname + " " + Name + " " + Patronymic + " " + PhoneNumber.CreateStringForFile() +
                " " + PassportSeries + " " + PassportNumber;
        }
    }
}
