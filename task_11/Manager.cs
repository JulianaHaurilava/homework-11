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
        public void ChangeSurname(User userToEdit, string newSurname)
        {
            userToEdit.Surname = newSurname;
            Change lastChange = new Change(InfoToChange.Surname,
                TypeOfChange.Editing, WorkerType.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangeName(User userToEdit, string newName)
        {
            userToEdit.Name = newName;
            Change lastChange = new Change(InfoToChange.Name,
                TypeOfChange.Editing, WorkerType.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangePatronimic(User userToEdit, string newPatronymic)
        {
            userToEdit.Patronymic = newPatronymic;
            Change lastChange = new Change(InfoToChange.Patronymic,
                TypeOfChange.Editing, WorkerType.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public new bool ChangePhoneNumber(User userToEdit, string newPhoneNumber)
        {
            PhoneNumber phoneNumber = new PhoneNumber(newPhoneNumber);
            if (r[phoneNumber].Name == "")
            {
                userToEdit.PhoneNumber = phoneNumber;
                Change lastChange = new Change(InfoToChange.PhoneNumber,
                    TypeOfChange.Editing, WorkerType.Manager);
                lastChange.WriteLastChangeInFile();
                r.AllInFile();
                return true;
            }
            return false;
        }
        public void ChangeSeries(User userToEdit, string newSeries)
        {
            userToEdit.PassportSeries = newSeries;
            Change lastChange = new Change(InfoToChange.PassportSeriesNumber,
                TypeOfChange.Editing, WorkerType.Consultant);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangeNumber(User userToEdit, int newNumber)
        {
            userToEdit.PassportNumber = newNumber;
            Change lastChange = new Change(InfoToChange.PassportSeriesNumber,
                TypeOfChange.Editing, WorkerType.Consultant);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public bool AddNewUser(User newUser)
        {
            if (r[newUser.PhoneNumber].Name == "")
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