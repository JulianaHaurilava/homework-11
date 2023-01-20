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
        

        Repository r;
        StateMachine stm;


        public MainWindow()
        {
            InitializeComponent();
            r = new Repository("all_users.txt", "all_departments.txt");
            stm = new StateMachine();

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

        private void ConfirmChangesM(object sender, RoutedEventArgs e)
        {
            lClientInfo.Items.Refresh();
            r.AllInFile();
            stm.ChangeState(spManagerUserMenu);
        }


        
    }
}
