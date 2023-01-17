namespace task_11
{
    interface IConsultantCanEdit
    {
        /// <summary>
        /// Меняет номер телефона клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        void ChangePhoneNumber(User userToEdit);
    }
}
