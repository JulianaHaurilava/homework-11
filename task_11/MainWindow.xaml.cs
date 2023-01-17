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
            lClientInfo.ItemsSource = r.allUsers;
        }

        private void lClientInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spClientInfo.Visibility = Visibility.Visible;
        }

        private void cbWorkerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)cbWorkerType.SelectedItem == "Консультант")
            {
                stm.ChangeState(spConsultantMenu);
            }
            else stm.ChangeState(spManagerMenu);
        }

        private void bEditClientC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bSortClientsC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bEditClientM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bAddNewClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bDeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
