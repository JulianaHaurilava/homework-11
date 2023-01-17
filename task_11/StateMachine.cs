using System.Windows;
using System.Windows.Controls;

namespace task_11
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
}
