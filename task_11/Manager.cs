using System;

namespace task_11
{
    class Manager :
        Consultant, IManagerCanEdit
    {
        public Manager(Repository r):
            base(r)
        {

        }
        public void ChangeSurname(User userToEdit)
        {
            Console.Write("Введите новую фамилию клиента: ");
            userToEdit.Surname = Console.ReadLine();
            Change lastChange = new Change(InfoToChange.Surname, TypeOfChange.Editing, WorkerType.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangeName(User userToEdit)
        {
            Console.Write("Введите новое имя клиента: ");
            userToEdit.Name = Console.ReadLine();
            Change lastChange = new Change(InfoToChange.Name, TypeOfChange.Editing, WorkerType.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangePatronimic(User userToEdit)
        {
            Console.Write("Введите новое отчество клиента: ");
            userToEdit.Patronymic = Console.ReadLine();
            Change lastChange = new Change(InfoToChange.Patronymic, TypeOfChange.Editing, WorkerType.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public new void ChangePhoneNumber(User userToEdit)
        {
            //Console.Write("Введите новый номер клиента: ");
            //string phoneNumber = Console.ReadLine();
            //if (r.FindUserByPhoneNumber(phoneNumber).Name == "")
            //{
            //    userToEdit.PhoneNumber = new PhoneNumber(phoneNumber);
            //    Change lastChange = new Change(InfoToChange.PhoneNumber, TypeOfChange.Editing, WorkerType.Manager);
            //    lastChange.WriteLastChangeInFile();
            //    r.AllInFile();
            //    return;
            //}
            //else Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
        }
        public void ChangePassportInfo(User userToEdit)
        {
            Console.Write("Введите новую серию паспорта клиента: ");
            userToEdit.PassportSeries = Console.ReadLine();
            Console.Write("Введите новый номер паспорта клиента: ");
            userToEdit.PassportNumber = Console.ReadLine();
            Change lastChange = new Change(InfoToChange.PassportSeriesNumber, TypeOfChange.Editing, WorkerType.Consultant);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public User CreateUserFromConsole()
        {
            Console.WriteLine("Введите информацию о клиенте.\n");

            Console.Write("Ф.И.О: ");
            string fullName = Console.ReadLine();
            string[] fullNameArray = fullName.Split(' ');

            Console.Write("Номер телефона: ");
            string phoneNumber = Console.ReadLine();
            //if (r.FindUserByPhoneNumber(phoneNumber).Name != "")
            //{
            //    Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
            //    return new User();
            //}
            Console.Write("Серию паспорта: ");
            string passportSeries = Console.ReadLine();
            Console.Write("Номер паспорта: ");
            string passportNumber = Console.ReadLine();

            return new User(fullNameArray[0], fullNameArray[1], fullNameArray[2],
                phoneNumber, passportSeries, passportNumber);
        }
        public bool AddNewUser(User newUser)
        {
            if (r.FindUserByPhoneNumber(newUser.PhoneNumber).Name == "")
            {
                r.AddUser(newUser);
                Change lastChange = new Change(InfoToChange.AllAccount, TypeOfChange.Adding, WorkerType.Manager);
                lastChange.WriteLastChangeInFile();
                return true;
            }
            return false;
        }
    }
}