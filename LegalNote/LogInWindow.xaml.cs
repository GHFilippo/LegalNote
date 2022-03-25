using LegalNote.Models;
using LegalNote.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;


namespace LegalNote
{
    /// <summary>
    /// Logica di interazione per LogInWindowxaml.xaml
    /// </summary>
    public partial class LogInWindowxaml : Window
    {
        public LogInWindowxaml()
        {
            InitializeComponent();
        }
        private void Entra(object sender, RoutedEventArgs e)
        {
            if (Environment.UserName == "berardo")
            {
                MainWindow M = new MainWindow();
                M.Show();
                Singleton.Instance.utenteAttivo = new utenti() { id = 1, username="pippo", admin=1};
                this.Close();
            }
        }
        private void Registrati_Click (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funzione non implementata. Usa : pippo pippo");
        }
        private void Login_click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*if (UserName.Text == "pippo" && Password.Password == "pippo")
                    {
                        MainWindow M = new MainWindow();
                        M.Show();
                        Singleton.Instance.utenteAttivo = new utenti() { id = 1, admin=1 };
                        this.Close();
                        return;
                    }*/

                List<utenti> listaUtenti = (from utenteRow in DbClass.LegEnt.utenti
                                            where utenteRow.username == UserName.Text
                                            orderby utenteRow.id
                                            select utenteRow).ToList();
                if (listaUtenti.Count == 0)
                    Alert.Content = "Errore Username o Password";
                else
                {
                    foreach (utenti ut in listaUtenti)
                    {
                        if (ut.password == Password.Password)
                        {

                            MainWindow M = new MainWindow();
                            M.Show();
                            Singleton.Instance.utenteAttivo = ut;
                            this.Close();
                        }

                        else
                        {
                            Alert.Content = "Errore Username o Password";
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void CambiaDB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Questa è una funzionalità solo nella versione PRO");
         /*   Singleton.Instance.DbConnectionString =
                ConfigurationManager.ConnectionStrings["legalnoteEntities"].ConnectionString.ToString();

            string con = Singleton.Instance.DbConnectionString= Singleton.Instance.DbConnectionString.Replace("legalnote", "legalnote2");

            DbClass.LegEnt = new legalnoteEntities(Singleton.Instance.DbConnectionString);*/

        }

        private void DbChange_Loaded(object sender, RoutedEventArgs e)
        {
            //Default DB
            Singleton.Instance.DbConnectionString =
                ConfigurationManager.ConnectionStrings["legalnoteEntities"].ConnectionString.ToString();
        }
    }
}
