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

namespace task_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository r;
        StateMachine stm;
        public MainWindow()
        {
            InitializeComponent();
            r = new Repository("all_users.txt");
            stm = new StateMachine();

            string[] WorkerTypes = { "Консультант", "Менеджер" };
            cbWorkerType.ItemsSource = WorkerTypes;
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
            lClientInfo.ItemsSource = r.allUsers;
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

        private void bSortClientsC_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void bEditClientM_Click(object sender, RoutedEventArgs e)
        {
            stm.ChangeState(spClientInfoEditM);
        }

        private void bAddNewClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bDeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bReturnToMenuM_Click(object sender, RoutedEventArgs e)
        {
            lClientInfo.SelectedItem = null;
            stm.ChangeState(spManagerMenu);
        }

        private void bReturnToMenuC_Click(object sender, RoutedEventArgs e)
        {
            lClientInfo.SelectedItem = null;
            stm.ChangeState(spConsultantMenu);
        }

        private void bConfirmChangesM_Click(object sender, RoutedEventArgs e)
        {
            lClientInfo.Items.Refresh();
            r.AllInFile();
            stm.ChangeState(spManagerUserMenu);
        }

        private void bConfirmChangesC_Click(object sender, RoutedEventArgs e)
        {
            lClientInfo.Items.Refresh();
            r.AllInFile();
            stm.ChangeState(spConsultantUserMenu);
        }
    }
}
