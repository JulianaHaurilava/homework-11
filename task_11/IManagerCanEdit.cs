namespace task_11
{
    interface IManagerCanEdit:
        IConsultantCanEdit
    {

        void ChangeSurname(User userToEdit, string newSurname);

        void ChangeName(User userToEdit, string newName);

        void ChangePatronimic(User userToEdit, string newPatronymic);

        new bool ChangePhoneNumber(User userToEdit, string newPhoneNumber);

        void ChangeSeries(User userToEdit, string newSeries);

        void ChangeNumber(User userToEdit, int newNumber);

        bool AddNewUser(User newUser);
    }
}
