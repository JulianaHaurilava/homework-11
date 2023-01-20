using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task_11.UserControls
{
    /// <summary>
    /// Interaction logic for AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : UserControl
    {
        Repository r;
        Manager m;
        AddNewUserButtonEnabled anu;
        class AddNewUserButtonEnabled
        {
            private bool surnameNotEmpty;
            public bool SurnameNotEmpty
            {
                set => surnameNotEmpty = value;
            }

            private bool nameNotEmpty;
            public bool NameNotEmpty
            {
                set => nameNotEmpty = value;
            }

            private bool patronymicNotEmpty;
            public bool PatronymicNotEmpty
            {
                set => patronymicNotEmpty = value;
            }

            private bool phoneNumberNotEmpty;
            public bool PhoneNumberNotEmpty
            {
                set => phoneNumberNotEmpty = value;
            }

            private bool departmentNotEmpty;
            public bool DepartmentNotEmpty
            {
                set => departmentNotEmpty = value;
            }

            private bool seriesNotEmpty;
            public bool SeriesNotEmpty
            {
                set
                => seriesNotEmpty = value;
            }

            private bool numberNotEmpty;
            public bool NumberNotEmpty
            {
                set
                => numberNotEmpty = value;
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

        public AddNewClient()
        {
            InitializeComponent();
            r = new Repository("all_users.txt", "all_departments.txt");
            anu = new AddNewUserButtonEnabled();
            m = new Manager(r);

            string[] WorkerTypes = { "Консультант", "Менеджер" };
            cbDepartment.ItemsSource = r.AllDepartments;
        }

        private void bAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User(tbSurname.Text, tbName.Text, tbPatronymic.Text,
                tbPhoneNumber.Text, cbDepartment.Text, tbSeries.Text, int.Parse(tbNumber.Text));

            if (!m.AddNewUser(newUser))
            {
                tbError.Visibility = Visibility.Visible;
                return;
            }
        }

        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbName.Text.Length != 0)
                anu.NameNotEmpty = true;
            else anu.NameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbPatronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbDepartment_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbSeries_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }

        private void tbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bAddNewClient.IsEnabled = anu.ButtonIsEnabled();
        }
    }
}
