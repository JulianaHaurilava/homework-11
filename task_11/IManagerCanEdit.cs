namespace task_11
{
    interface IManagerCanEdit:
        IConsultantCanEdit
    {
        /// <summary>
        /// Меняет фамилию клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        /// 
        void ChangeSurname(User userToEdit);

        /// <summary>
        /// Меняет имя клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        void ChangeName(User userToEdit);

        /// <summary>
        /// Меняет отчество клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        void ChangePatronimic(User userToEdit);

        /// <summary>
        /// Меняет номер телефона клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        new void ChangePhoneNumber(User userToEdit);

         /// <summary>
        /// Меняет паспортные данные клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        void ChangePassportInfo(User userToEdit);

        /// <summary>
        /// Добавляет нового клиента в репозиторий
        /// </summary>
        /// <param name="newUser"></param>
        bool AddNewUser(User newUser);
    }
}
