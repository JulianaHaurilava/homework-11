using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace task_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class StateMachine
        {
            private StackPanel spCurrentPanel;

            public void ChangeState(StackPanel chosenMenu)
            {
                if (spCurrentPanel != null)
                {
                    spCurrentPanel.Visibility = Visibility.Hidden;
                }
                chosenMenu.Visibility = Visibility.Visible;
                spCurrentPanel = chosenMenu;
            }
        }
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

        Repository r;
        StateMachine stm;
        AddNewUserButtonEnabled anu;

        Manager m;
        Consultant c;
        public MainWindow()
        {
            InitializeComponent();
            r = new Repository("all_users.txt", "all_departments.txt");
            stm = new StateMachine();
            anu = new AddNewUserButtonEnabled();

            m = new Manager(r);
            c = new Consultant(r);

            string[] WorkerTypes = { "Консультант", "Менеджер" };
            cbWorkerType.ItemsSource = WorkerTypes;
            cbDepartment.ItemsSource = r.AllDepartments;
            cbDepartmentAdd.ItemsSource = r.AllDepartments;
        }

        private void lClientInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((string)cbWorkerType.SelectedItem)
            {
                case "Консультант":
                    stm.ChangeState(spConsultantUserMenu);
                    break;
                case "Менеджер":
                    stm.ChangeState(spManagerUserMenu);
                    break;
            }
        }

        private void cbWorkerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bdMainBorder.Visibility = Visibility.Visible;
            lClientInfo.ItemsSource = r.AllUsers;
            switch ((string)cbWorkerType.SelectedItem)
            {
                case "Консультант":
                    gvcPassportSeries.DisplayMemberBinding = new Binding("HiddenPassportSeries");
                    gvcPassportNumber.DisplayMemberBinding = new Binding("HiddenPassportNumber");
                    stm.ChangeState(spConsultantMenu);
                    break;
                case "Менеджер":
                    gvcPassportSeries.DisplayMemberBinding = new Binding("PassportSeries");
                    gvcPassportNumber.DisplayMemberBinding = new Binding("PassportNumber");
                    stm.ChangeState(spManagerMenu);
                    break;
            }
        }

        private void bEditClientC_Click(object sender, RoutedEventArgs e)
        {
            stm.ChangeState(spClientInfoEditC);
        }

        private void SortClients(object sender, RoutedEventArgs e)
        {
            IOrderedEnumerable<User> result = from user in r.AllUsers
                                              orderby user.Surname, user.Name, user.Patronymic
                                              select user;
            r.AllUsers = result.ToList();
            lClientInfo.Items.Refresh();
            r.AllInFile();
        }

        private void ConfirmChangesC(object sender, RoutedEventArgs e)
        {
            lClientInfo.Items.Refresh();
            stm.ChangeState(spConsultantUserMenu);
            r.AllInFile();
        }

        private void ReturnToMenuC(object sender, RoutedEventArgs e)
        {
            lClientInfo.SelectedItem = null;
            stm.ChangeState(spConsultantMenu);
        }


        private void bEditClientM_Click(object sender, RoutedEventArgs e)
        {
            stm.ChangeState(spClientInfoEditM);
        }

        private void bAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            stm.ChangeState(spAddClientM);
        }

        private void bDeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnToMenuM(object sender, RoutedEventArgs e)
        {
            lClientInfo.SelectedItem = null;
            stm.ChangeState(spManagerMenu);
        }

        private void ReturnToMenuM_ClearInfo(object sender, RoutedEventArgs e)
        {
            lClientInfo.SelectedItem = null;
            stm.ChangeState(spManagerMenu);
            ClearAllAddingTextBoxes();
        }

        private void ConfirmChangesM(object sender, RoutedEventArgs e)
        {
            lClientInfo.Items.Refresh();
            r.AllInFile();
            stm.ChangeState(spManagerUserMenu);
        }

        private void SaveNewClientM(object sender, RoutedEventArgs e)
        {
            User newUser = new User(tbSurname.Text, tbName.Text, tbPatronymic.Text,
                tbPhoneNumber.Text, cbDepartmentAdd.Text, tbSeries.Text, int.Parse(tbNumber.Text));

            if (!m.AddNewUser(newUser))
            {
                tbxPhoneNumberError.Visibility = Visibility.Visible;
                return;
            }
            tbxPhoneNumberError.Visibility = Visibility.Hidden;
            lClientInfo.Items.Refresh();
            ClearAllAddingTextBoxes();
        }




        private void SurnameTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSurname.Text.Length != 0)
                anu.SurnameNotEmpty = true;
            else anu.SurnameNotEmpty = false;

            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
        }
        private void NameTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbName.Text.Length != 0)
                anu.NameNotEmpty = true;
            else anu.NameNotEmpty = false;

            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
        }
        private void PatronymicTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPatronymic.Text.Length != 0)
                anu.PatronymicNotEmpty = true;
            else anu.PatronymicNotEmpty = false;

            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
        }
        private void PhoneNumberTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPhoneNumber.Text.Length != 0)
                anu.PhoneNumberNotEmpty = true;
            else anu.PhoneNumberNotEmpty = false;

            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
            tbxPhoneNumberError.Visibility = Visibility.Hidden;
        }
        private void SeriesTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSeries.Text.Length != 0)
                anu.SeriesNotEmpty = true;
            else anu.SeriesNotEmpty = false;

            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
        }
        private void NumberTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbNumber.Text.Length != 0)
                anu.NumberNotEmpty = true;
            else anu.NumberNotEmpty = false;

            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
        }
        private void DepartmentTextChanged(object sender, TextChangedEventArgs e)
        {
            anu.DepartmentNotEmpty = true;
            bSaveNewClientM.IsEnabled = anu.ButtonIsEnabled();
        }

        private void ClearAllAddingTextBoxes()
        {
            tbSurname.Clear();
            tbName.Clear();
            tbPatronymic.Clear();
            tbPhoneNumber.Clear();
            tbSeries.Clear();
            tbNumber.Clear();
        }

        private void DepartmentTextChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
