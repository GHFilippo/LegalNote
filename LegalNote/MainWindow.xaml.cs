using LegalNote.Models;
using LegalNote.ViewModels;
using LegalNote.Views;
using System.Windows;
using System.Windows.Input;

namespace LegalNote
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public void showUc (string ucDaMostrare)
        {
            foreach(UIElement uie in MainDockPanel.Children)
            {
                MainDockPanel.Children.Remove(uie);
                break;
            }
            

            switch (ucDaMostrare)
            {
                default:
                    break;
                case "Accounts":
                    UCAccounts uca = new UCAccounts();
                    uca.Width = MainDockPanel.Width;
                    uca.Height = MainDockPanel.Height;
                    MainDockPanel.Children.Add(uca);
                    break;
                case "Clienti":
                    UCClienti ucc = new UCClienti();
                    ucc.Width = MainDockPanel.Width;
                    ucc.Height = MainDockPanel.Height;
                    MainDockPanel.Children.Add(ucc);
                    break;
                case "Cause":
                    UCCause ucca = new UCCause();
                    ucca.Width = MainDockPanel.Width/2;
                    ucca.Height = MainDockPanel.Height;
                    MainDockPanel.Children.Add(ucca);
                    break;
            }
        }

        private void Accounts_Click(object sender, RoutedEventArgs e)
        {
            showUc("Accounts");
        }

        private void Clienti_Click(object sender, RoutedEventArgs e)
        {
            showUc("Clienti");
        }

        public void CauseButton_Click(object sender, RoutedEventArgs e)
        {
            showUc("Cause");
        }
        public ICommand showCauseCommand
        {
            get { return (ICommand)GetValue(showCauseProperty); }
            set { SetValue(showCauseProperty, value); }
        }

        public static readonly DependencyProperty showCauseProperty =
            DependencyProperty.Register("showCauseCommand", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(null));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
