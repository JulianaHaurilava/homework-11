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
        public bool ChangePhoneNumber(User userToEdit, string phoneNumber)
        {
            PhoneNumber newPhoneNumber = new PhoneNumber(phoneNumber);
            if (r[newPhoneNumber].Name == "")
            {
                userToEdit.PhoneNumber = newPhoneNumber;
                Change lastChange = new Change(InfoToChange.PhoneNumber,
                    TypeOfChange.Editing, WorkerType.Consultant);
                lastChange.WriteLastChangeInFile();
                r.AllInFile();
                return true;
            }
            return false;
        }
    }
}
