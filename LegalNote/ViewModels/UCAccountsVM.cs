using LegalNote.Models;
using LegalNote.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LegalNote.ViewModels
{
    class UCAccountsVM : BaseViewModel
    {
        
        public UCAccountsVM()
        {
            if (Singleton.Instance.utenteAttivo.admin == 1)
            {
                List<utenti> listaUtenti = (from recordset in DbClass.LegEnt.utenti
                                            where recordset.id >= 0
                                            orderby recordset.id
                                            select recordset).ToList();


                AccountsList = new ObservableCollection<utenti>(listaUtenti);
            }
            else
            {
                List<utenti> listaUtenti = (from recordset in DbClass.LegEnt.utenti
                                            where recordset.id >= Singleton.Instance.utenteAttivo.id
                                            orderby recordset.id
                                            select recordset).ToList();


                AccountsList = new ObservableCollection<utenti>(listaUtenti);
            }
        }

        private ObservableCollection<utenti> accountsList;
        public ObservableCollection<utenti> AccountsList
        {
            get
            {
                return accountsList;
            }
            set
            {
                accountsList = value;
                RaisePropertyChanged("AccountsList");
            }
        }

        private ICommand saveData;
        public ICommand SaveData
        {
            get
            {
                if (saveData == null)
                    saveData = new RelayCommand(o => salvaDati());
                return saveData;
            }
        }

        private void salvaDati()
        {
            if (Singleton.Instance.utenteAttivo.admin == 1)
            {
                foreach (utenti utente in accountsList)
                {
                    bool trovato = false;
                    foreach (utenti utenteDB in DbClass.LegEnt.utenti)
                    {
                        if (utente.id == utenteDB.id)
                        {
                            trovato = true;
                            break;
                        }
                    }
                    if (trovato == false) // se non è nel db lo aggiungo
                    {
                        DbClass.LegEnt.utenti.Add(utente);
                    }

                }
                DbClass.LegEnt.SaveChanges();
            }
            
        }
    }
}
