using System;

namespace task_11
{
    class Consultant :
        IConsultantCanEdit
    {
        protected Repository r;

        public Consultant(Repository r)
        {
            this.r = r;
        }

        /// <summary>
        /// Ищет клиента по номеру телефона
        /// </summary>
        /// <returns></returns>
        protected User FindUserByPhoneNumber()
        {
            //Console.Write("Введите номер телефона клиента: ");
            //string phoneNumber = Console.ReadLine();
            //Console.WriteLine();
            //return r.FindUserByPhoneNumber(phoneNumber);
            return new User();
        }

        /// <summary>
        /// Меняет номер телефона клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        public void ChangePhoneNumber(User userToEdit)
        {
            //Console.Write("Введите новый номер клиента: ");
            //string phoneNumber = Console.ReadLine();
            //if (r.FindUserByPhoneNumber(phoneNumber).Name == "")
            //{
            //    userToEdit.PhoneNumber = new PhoneNumber(phoneNumber);
            //    Change lastChange = new Change(InfoToChange.PhoneNumber, TypeOfChange.Editing, WorkerType.Consultant);
            //    lastChange.WriteLastChangeInFile();
            //    r.AllInFile();
            //    return;
            //}
            //else Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
        }

        /// <summary>
        /// Метод пользовательского меню консультанта
        /// </summary>
        public void LogIn()
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - изменить номер телефона клиента\n" +
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        r.PrintAllUsers(WorkerType.Consultant);
                        break;
                    case '2':
                        Console.Clear();
                        User userToEdit = FindUserByPhoneNumber();
                        if (userToEdit.Name != "")
                            ChangePhoneNumber(userToEdit);
                        else Console.Write("Клиент с таким номером телефона не найден!\n");
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
