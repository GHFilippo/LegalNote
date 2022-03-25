using LegalNote.Models;
using LegalNote.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LegalNote.ViewModels
{
    class UCCLientiVM : BaseViewModel
    {
        
        public UCCLientiVM()
        {
            LoadClienti();    
        }

        private void LoadClienti() {
            List<anagrafica> listaClienti = (from clienteRow in DbClass.LegEnt.anagrafica
                                             where clienteRow.id >= 0 && clienteRow.idUtente == Singleton.Instance.utenteAttivo.id
                                             orderby clienteRow.id
                                             select clienteRow).ToList();


            ClientiList = new ObservableCollection<anagrafica>(listaClienti);
        }
        private ObservableCollection<anagrafica> clientiList;
        public ObservableCollection<anagrafica> ClientiList
        {
            get
            {
                return clientiList;
            }
            set
            {
                clientiList = value;
                RaisePropertyChanged("ClientiList");
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
        private ICommand eliminaCliente;
        public ICommand EliminaCliente
        {
            get
            {
                if (eliminaCliente == null)
                    eliminaCliente = new RelayCommand(o => EliminaCli());
                return eliminaCliente;
            }
        }

        private void EliminaCli()
        {
            if (MessageBox.Show("Vuoi davvero eliminare il cliente : " + ClienteScelto.ragionesociale + "?", "Attenzione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DbClass.LegEnt.anagrafica.Remove(ClienteScelto);
                List<cause> listaCause = (from causaRow in DbClass.LegEnt.cause
                                          where causaRow.idcliente == ClienteScelto.id && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                          orderby causaRow.idcause
                                          select causaRow).ToList();
                ObservableCollection<cause> CauseList = new ObservableCollection<cause>(listaCause);

                foreach(cause c in CauseList)
                {
                    CancellaDocs(c.idcause, Singleton.Instance.utenteAttivo.id);
                    DbClass.LegEnt.cause.Remove(c);
                }

                //alla fine
                DbClass.LegEnt.SaveChanges();
                LoadClienti();

            }
        }

        private void CancellaDocs(int idcausa, int idutente)
        {
            List<cause_doc> listaCauseDoc = (from causadocRow in DbClass.LegEnt.cause_doc
                                             where causadocRow.idcausa == idcausa 
                                             orderby causadocRow.idcause_doc
                                             select causadocRow).ToList();

            ObservableCollection<cause_doc> CauseDoc = new ObservableCollection<cause_doc>(listaCauseDoc);
            foreach(cause_doc c in CauseDoc)
            {
                DbClass.LegEnt.cause_doc.Remove(c);
            }
        }

        private anagrafica clienteScelto;
        public anagrafica ClienteScelto
        {
            get
            {
                if (clienteScelto == null)
                    Singleton.Instance.SetIDCliente(-1);
                return clienteScelto;
            }
            set
            {
                clienteScelto = value;
                if (value!=null)
                    Singleton.Instance.SetIDCliente(value.id);
                RaisePropertyChanged("ClienteScelto");
            }
        }
        private void salvaDati()
        {
            foreach (anagrafica cliente in clientiList)
            {
                bool trovato = false;
                foreach (anagrafica clienteDB in DbClass.LegEnt.anagrafica)
                {
                    if (cliente.id == clienteDB.id)
                    {
                        trovato = true;
                        break;
                    }
                }
                if (trovato == false) // se non è nel db lo aggiungo
                {
                    cliente.idUtente = Singleton.Instance.utenteAttivo.id;
                    DbClass.LegEnt.anagrafica.Add(cliente);
                }

            }

            DbClass.LegEnt.SaveChanges();
        }
    }
}

       
