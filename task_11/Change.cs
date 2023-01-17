using System;
using System.IO;

enum InfoToChange { Surname, Name, Patronymic, PhoneNumber, PassportSeriesNumber, AllAccount }
enum TypeOfChange { Editing, Adding }
enum WorkerType { Consultant, Manager }

namespace task_11
{
    class Change
    {
        private DateTime dateTimeOfChange;
        private string changedInfo;
        private string typeOfChange;
        private string editor;


        public Change(InfoToChange changedInfo, TypeOfChange typeOfChange, WorkerType editor)
        {
            dateTimeOfChange = DateTime.Now;

            switch (changedInfo)
            {
                case InfoToChange.Surname:
                    this.changedInfo = "Фамилия";
                    break;
                case InfoToChange.Name:
                    this.changedInfo = "Имя";
                    break;
                case InfoToChange.Patronymic:
                    this.changedInfo = "Отчество";
                    break;
                case InfoToChange.PhoneNumber:
                    this.changedInfo = "Номер телефона";
                    break;
                case InfoToChange.PassportSeriesNumber:
                    this.changedInfo = "Паспортные данные";
                    break;
                case InfoToChange.AllAccount:
                    this.changedInfo = "Все данные";
                    break;
                default:
                    this.changedInfo = "Ошибка";
                    break;
            }

            switch (typeOfChange)
            {
                case TypeOfChange.Editing:
                    this.typeOfChange = "Редактирование";
                    break;
                case TypeOfChange.Adding:
                    this.typeOfChange = "Добавление новой записи";
                    break;
                default:
                    this.typeOfChange = "Ошибка";
                    break;
            }

            switch (editor)
            {
                case WorkerType.Consultant:
                    this.editor = "Консультант";
                    break;
                case WorkerType.Manager:
                    this.editor = "Менеджер";
                    break;
                default:
                    this.editor = "Ошибка";
                    break;
            }
        }

        /// <summary>
        /// Записывает информацию о последнем изменении в файл
        /// </summary>
        public void WriteLastChangeInFile()
        {
            using (StreamWriter stream = new StreamWriter("commited_changes.txt", true))
            {
                stream.WriteLine("Дата изменения записи: " + dateTimeOfChange.ToString("d"));
                stream.WriteLine("Время изменения записи: " + dateTimeOfChange.ToString("T"));
                stream.WriteLine("Тип измененных данных: " + changedInfo);
                stream.WriteLine("Тип изменений: " + typeOfChange);
                stream.WriteLine("Кто изменил данные: " + editor + "\n");
            }
        }
    }
}
