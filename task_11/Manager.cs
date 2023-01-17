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
            Console.Write("Введите новый номер клиента: ");
            string phoneNumber = Console.ReadLine();
            if (r.FindUserByPhoneNumber(phoneNumber).Name == "")
            {
                userToEdit.PhoneNumber = new PhoneNumber(phoneNumber);
                Change lastChange = new Change(InfoToChange.PhoneNumber, TypeOfChange.Editing, WorkerType.Manager);
                lastChange.WriteLastChangeInFile();
                r.AllInFile();
                return;
            }
            else Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
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
            if (r.FindUserByPhoneNumber(phoneNumber).Name != "")
            {
                Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
                return new User();
            }
            Console.Write("Серию паспорта: ");
            string passportSeries = Console.ReadLine();
            Console.Write("Номер паспорта: ");
            string passportNumber = Console.ReadLine();

            return new User(fullNameArray[0], fullNameArray[1], fullNameArray[2],
                phoneNumber, passportSeries, passportNumber);
        }
        public void AddNewUser(User newUser)
        {
            if (newUser.Name != "")
            {
                r.AddUser(newUser);
                Change lastChange = new Change(InfoToChange.AllAccount, TypeOfChange.Adding, WorkerType.Manager);
                lastChange.WriteLastChangeInFile();
            }
        }

        /// <summary>
        /// Метод меню редактирования данных о клиенте
        /// </summary>
        /// <param name="userToEdit"></param>
        protected void ChangeUserInfo(User userToEdit)
        {
            if (userToEdit.Name != "")
            {
                Console.WriteLine("    Какое поле вы хотите редактировать?\n\n" +
                                "1 - фамилия\n" +
                                "2 - имя\n" +
                                "3 - отчество\n" +
                                "4 - номер телефона\n" +
                                "5 - серия и номер паспорта\n" +
                                "0 - выйти\n");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        ChangeSurname(userToEdit);
                        break;
                    case '2':
                        ChangeName(userToEdit);
                        break;
                    case '3':
                        ChangePatronimic(userToEdit);
                        break;
                    case '4':
                        ChangePhoneNumber(userToEdit);
                        break;
                    case '5':
                        ChangePassportInfo(userToEdit);
                        break;
                    case '0':
                        return;
                }
            }
            else Console.Write("Клиент с таким номером телефона не найден!\n");
        }

        /// <summary>
        /// Метод пользовательского меню менеджера
        /// </summary>
        public new void LogIn()
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - изменить информацию о клиенте\n" +
                                "3 - добавить нового клиента\n" +
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        r.PrintAllUsers(WorkerType.Manager);
                        break;
                    case '2':
                        Console.Clear();
                        ChangeUserInfo(FindUserByPhoneNumber());
                        break;
                    case '3':
                        Console.Clear();
                        AddNewUser(CreateUserFromConsole());
                        break;
                    case '0':
                        return;
                }

                Console.WriteLine("\nДля того, чтобы выйти в главное меню, нажмите любую клавишу...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}