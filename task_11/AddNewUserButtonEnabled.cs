namespace task_11
{
    class AddNewUserButtonEnabled
    {
        private bool surnameNotEmpty;
        public bool SurnameNotEmpty
        {
            set
            {
                surnameNotEmpty = value;
            }
        }

        private bool nameNotEmpty;
        public bool NameNotEmpty
        {
            set
            {
                nameNotEmpty = value;
            }
        }

        private bool patronymicNotEmpty;
        public bool PatronymicNotEmpty
        {
            set
            {
                patronymicNotEmpty = value;
            }
        }

        private bool phoneNumberNotEmpty;
        public bool PhoneNumberNotEmpty
        {
            set
            {
                phoneNumberNotEmpty = value;
            }
        }

        private bool seriesNotEmpty;
        public bool SeriesNotEmpty
        {
            set
            {
                seriesNotEmpty = value;
            }
        }

        private bool numberNotEmpty;
        public bool NumberNotEmpty
        {
            set
            {
                numberNotEmpty = value;
            }
        }

        public AddNewUserButtonEnabled()
        {
            surnameNotEmpty = false;
            nameNotEmpty = false;
            patronymicNotEmpty = false;
            phoneNumberNotEmpty = false;
            seriesNotEmpty = false;
            numberNotEmpty = false;
        }
        public bool ButtonIsEnabled()
        {
            return surnameNotEmpty && nameNotEmpty && patronymicNotEmpty &&
                phoneNumberNotEmpty && numberNotEmpty && seriesNotEmpty;
        }
    }
}
