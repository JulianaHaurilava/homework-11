using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace task_11
{
    class Repository
    {

        private string fileName; // Имя файла

        private List<User> allUsers; // Коллекция клиентов банка

        public List<User> AllUsers
        {
            get => allUsers;
            set
            {
                allUsers = value;
            }
        }
        public Repository(string fileName)
        {
            this.fileName = fileName;
            AllUsers = new List<User>();
            ReadFile();
        }

        /// <summary>
        /// Ищет клиента по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public User FindUserByPhoneNumber(PhoneNumber newPhoneNumber)
        {
            foreach (User user in AllUsers)
            {
                if (user.PhoneNumber == newPhoneNumber)
                    return user;
            }
            return new User();
        }

        /// <summary>
        /// Считывает данные из файла
        /// </summary>
        private void ReadFile()
        {
            if (File.Exists(fileName))
            {
                using (StreamReader stream = new StreamReader(fileName, true))
                {
                    while (!stream.EndOfStream)
                    {
                        allUsers.Add(new User(stream.ReadLine()));
                    }
                }
            }
        }

        /// <summary>
        /// Перезаписывает информацию в файле
        /// </summary>
        public void AllInFile()
        {
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                foreach (User user in allUsers)
                {
                    stream.WriteLine(user.CreateStringForFile());
                }
            }
        }

        /// <summary>
        /// Выводит информацию обо всех клиентах
        /// </summary>
        /// <param name="workerType"></param>
        public void PrintAllUsers(WorkerType workerType)
        {
            if (allUsers.Count == 0) Console.WriteLine("Записей о клиентах нет.");
            else
            {
                Console.WriteLine("Клиенты банка\n");
                foreach (User user in allUsers)
                {
                    user.Print(workerType);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Добавляет нового клиента в репозиторий
        /// </summary>
        /// <param name="newUser"></param>
        public void AddUser(User newUser)
        {
            allUsers.Add(newUser);
            WriteUserInFile(newUser);
        }

        /// <summary>
        /// Записывает пользователя в конец файла
        /// </summary>
        /// <param name="newUser"></param>
        private void WriteUserInFile(User newUser)
        {
            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine(newUser.CreateStringForFile());
            }
        }

    }
}
