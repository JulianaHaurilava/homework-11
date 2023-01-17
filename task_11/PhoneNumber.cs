namespace task_11
{
    struct PhoneNumber
    {
        string countryCode;
        string cityCode;
        string number;

        public PhoneNumber(string phoneNumber)
        {
            number = phoneNumber.Substring(phoneNumber.Length - 7);
            phoneNumber = phoneNumber.Remove(phoneNumber.Length - 7);
            cityCode = phoneNumber.Substring(phoneNumber.Length - 2);
            phoneNumber = phoneNumber.Remove(phoneNumber.Length - 2);
            countryCode = phoneNumber;
        }

        public string CreateStringForFile()
        {
            return countryCode + cityCode + number;
        }

        public override string ToString()
        {
            string outCountryCode;
            switch (countryCode.Length)
            {
                case 5:
                    outCountryCode = string.Format("{0:+#-###}", int.Parse(countryCode.Substring(1)));
                    break;
                default:
                    outCountryCode = countryCode;
                    break;
            }
            return outCountryCode + " ("+ cityCode + ") " + string.Format("{0:###-##-##}", int.Parse(number));
        }

        public static bool operator ==(PhoneNumber phoneNumber_1, PhoneNumber phoneNumber_2)
        {
            return phoneNumber_1.countryCode == phoneNumber_2.countryCode &&
                phoneNumber_1.cityCode == phoneNumber_2.cityCode &&
                phoneNumber_1.number == phoneNumber_2.number;
        }

        public static bool operator !=(PhoneNumber phoneNumber_1, PhoneNumber phoneNumber_2)
        {
            return !(phoneNumber_1 == phoneNumber_2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
