namespace task_11
{
    class PhoneNumber
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

        public PhoneNumber()
        {
            countryCode = "";
            cityCode = "";
            number = "";
        }

        public string ReturnSimpleNumber()
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
            return outCountryCode + " (" + cityCode + ") " + string.Format("{0:###-##-##}", int.Parse(number));
        }

        public static bool operator ==(PhoneNumber phn_1, PhoneNumber phn_2)
        {
            return phn_1.countryCode == phn_2.countryCode &&
                phn_1.cityCode == phn_2.cityCode &&
                phn_1.number == phn_2.number;
        }

        public static bool operator !=(PhoneNumber phn_1, PhoneNumber phn_2)
        {
            return !(phn_1 == phn_2);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) ? true : ReferenceEquals(obj, null) ? false : throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
