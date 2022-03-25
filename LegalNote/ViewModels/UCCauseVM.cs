using LegalNote.Models;
using LegalNote.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LegalNote.ViewModels
{
    class UCCauseVM : BaseViewModel
    {
        private int idCliente;
        public int IdCliente { get => Singleton.Instance.GetIdCliente(); set => idCliente = value; }
        public UCCauseVM()
        {
            CercaData = Convert.ToDateTime("01/01/2000");
            LoadDataGridData();
        }

        private void LoadDataGridData()
        {
            if (IdCliente < 0)
            {
                List<cause> listaCause = (from causaRow in DbClass.LegEnt.cause
                                          where causaRow.idcause >= 0 && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                          orderby causaRow.idcause
                                          select causaRow).ToList();
                CauseList = new ObservableCollection<cause>(listaCause);
            }
            else
            {
                List<cause> listaCause = (from causaRow in DbClass.LegEnt.cause
                                          where causaRow.idcliente == IdCliente && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                          orderby causaRow.idcause
                                          select causaRow).ToList();
                CauseList = new ObservableCollection<cause>(listaCause);

                setLabel();
            }
        }
        private void LoadDataGridData(int tipoRicerca, string param)
        {
            if (String.IsNullOrEmpty(param) == false)
            {
                List<cause> listaCause = new List<cause>();
                
                switch (tipoRicerca)
                {
                    case 0: // per nome cliente
                            //Trovo lista clienti possibili
                        List<anagrafica> listaAna = new List<anagrafica>();
                        listaAna = (from anaRow in DbClass.LegEnt.anagrafica
                                        where anaRow.ragionesociale.Contains(param) || anaRow.nome.Contains(param) || anaRow.cognome.Contains(param) && anaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                    orderby anaRow.ragionesociale
                                        select anaRow).ToList();

                        foreach (anagrafica a in listaAna)
                        {
                            try
                            {
                                cause c = (from causaRow in DbClass.LegEnt.cause
                                           where causaRow.idcliente == a.id && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                           orderby causaRow.idcause
                                           select causaRow).First();
                                if (c != null)
                                {
                                    listaCause.Add(c);
                                }
                            }
                            catch (Exception s)
                            {
                                Debug.WriteLine(s);
                            }

                           
                        }
                        CauseList = new ObservableCollection<cause>(listaCause);
                        break;
                    case 1: // per nome causa

                        listaCause = (from causaRow in DbClass.LegEnt.cause
                                            where causaRow.nomecausa.Contains(param) && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                      orderby causaRow.idcause
                                            select causaRow).ToList();
                        CauseList = new ObservableCollection<cause>(listaCause);
                        break;
                    case 2: // per data
                        if (IdCliente > 0)
                        {
                            DateTime dt = Convert.ToDateTime(param);
                            listaCause = (from causaRow in DbClass.LegEnt.cause
                                          where causaRow.datainiziocausa >= dt && causaRow.idcliente == IdCliente && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                          orderby causaRow.idcause
                                          select causaRow).ToList();
                            CauseList = new ObservableCollection<cause>(listaCause);
                        }
                        else
                        {
                            DateTime dt = Convert.ToDateTime(param);
                            listaCause = (from causaRow in DbClass.LegEnt.cause
                                          where causaRow.datainiziocausa >= dt && causaRow.idUtente == Singleton.Instance.utenteAttivo.id
                                          orderby causaRow.idcause
                                          select causaRow).ToList();
                            CauseList = new ObservableCollection<cause>(listaCause);
                        }
                        break;
                }
            }
            else
            {
                Singleton.Instance.SetIDCliente(-1);
                LoadDataGridData();
            }

        }
        private void setLabel()
        {
            anagrafica an = DbClass.LegEnt.anagrafica.Find(new object[] { Singleton.Instance.GetIdCliente() });
            LabelCausa = an.ragionesociale;
            if (String.IsNullOrEmpty(an.nome) == false)
                labelCausa += " - " + an.nome;
            if (String.IsNullOrEmpty(an.cognome) == false)
                labelCausa += " " + an.cognome;
        }
        private ObservableCollection<cause> causeList;
        public ObservableCollection<cause> CauseList
        {
            get
            {
                return causeList;
            }
            set
            {
                causeList = value;
                RaisePropertyChanged("CauseList");
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
        
        private ICommand openDoc;
        public ICommand OpenDoc
        {
            get
            {
                if (openDoc == null)
                    openDoc = new RelayCommand(o => openDocs());
                return openDoc;
            }
        }

        private ICommand aggDoc;
        public ICommand AggDoc
        {
            get
            {
                if (aggDoc == null)
                    aggDoc = new RelayCommand(o => AggiungiDoc());
                return aggDoc;
            }
        }

        private void AggiungiDoc()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
               
                File.ReadAllText(openFileDialog.FileName);
                cause_doc c = new cause_doc();
                c.idcausa = CausaScelta.idcause;
                c.filename = openFileDialog.FileName;
                FileInfo f = new FileInfo(c.filename);
                c.filetype = f.Extension;

                DbClass.LegEnt.cause_doc.Add(c);
                DbClass.LegEnt.SaveChanges();
                CaricaDocs();
            }
        }
        private ICommand delDoc;
        public ICommand DelDoc
        {
            get
            {
                if (delDoc == null)
                    delDoc = new RelayCommand(o => CancellaDoc());
                return delDoc;
            }
        }
        private ICommand nuovaCausa;
        public ICommand NuovaCausa
        {
            get
            {
                if (nuovaCausa == null)
                    nuovaCausa = new RelayCommand(o => nuovacausa());
                return nuovaCausa;
            }
        }

        private void nuovacausa()
        {
            if (Singleton.Instance.GetIdCliente() > 0)
            {
                NumberToCustomerConverter n = new NumberToCustomerConverter();
                if (MessageBox.Show("Vuoi creare una causa per il cliente : " + n.TrovaNomeCliente(Singleton.Instance.GetIdCliente()) + "?", "Atenzione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cause c = new cause();
                    c.idcliente = Singleton.Instance.GetIdCliente();
                    c.datainiziocausa = DateTime.Now;
                    c.nomecausa = "NUOVA CAUSA";
                    c.idUtente = Singleton.Instance.utenteAttivo.id;
                    DbClass.LegEnt.cause.Add(c);
                    DbClass.LegEnt.SaveChanges();
                    LoadDataGridData();

                }
            }
            else
                MessageBox.Show("Scegliere un cliente.");
        }
        private ICommand eliminaCausa;
        public ICommand EliminaCausa
        {
            get
            {
                if (eliminaCausa == null)
                    eliminaCausa = new RelayCommand(o => eliminacausa());
                return eliminaCausa;
            }
        }

        private void eliminacausa()
        {
            if (CausaScelta.idcause > 0)
            {
                if (MessageBox.Show("Vuoi eliminare la causa : " + causaScelta.nomecausa + "?", "Atenzione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    EliminaDocs(CausaScelta.idcause);
                    DbClass.LegEnt.cause.Remove(CausaScelta);
                    DbClass.LegEnt.SaveChanges();
                    LoadDataGridData();
                }
            }
            else
                MessageBox.Show("Scegliere un cliente.");
        }

        private void EliminaDocs(int idcausa)
        {
            List<cause_doc> listaCauseDoc = (from causadocRow in DbClass.LegEnt.cause_doc
                                             where causadocRow.idcausa == idcausa
                                             orderby causadocRow.idcause_doc
                                             select causadocRow).ToList();

            ObservableCollection<cause_doc> CauseDoc = new ObservableCollection<cause_doc>(listaCauseDoc);
            foreach (cause_doc c in CauseDoc)
            {
                DbClass.LegEnt.cause_doc.Remove(c);
            }
        }

        private void CancellaDoc()
        {
            if (MessageBox.Show("Vuoi veramente cancellare il documento?", "Atenzione",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DbClass.LegEnt.cause_doc.Remove(DocScelto);
                DbClass.LegEnt.SaveChanges();
                CaricaDocs();
            }
            
        }

        private void openDocs()
        {
            Process.Start(DocScelto.filename);
        }

        private cause_doc docScelto;
        public cause_doc DocScelto
        {
            get
            {
                return docScelto;
            }
            set
            {
                docScelto = value;
                RaisePropertyChanged("DocScelto");
            }
        }

        private string cercaCliente;
        public string CercaCliente
        {
            get
            {
                return cercaCliente;
            }
            set
            {
                cercaCliente = value;
                RaisePropertyChanged("CercaCliente");
                LoadDataGridData(0,cercaCliente);

            }
        }
        private string cercaNome;
        public string CercaNome
        {
            get
            {
                return cercaNome;
            }
            set
            {
                cercaNome = value;
                RaisePropertyChanged("CercaNome");
                LoadDataGridData(1, cercaNome);
            }
        }
        private DateTime cercaData;
        public DateTime CercaData
        {
            get
            {
                return cercaData;
            }
            set
            {
                cercaData = value;
                RaisePropertyChanged("CercaData");
                    LoadDataGridData(2, cercaData.ToLongDateString());
            }
        }
        

        private string labelCausa;
        public string LabelCausa
        {
            get
            {
                return labelCausa;
            }
            set
            {
                labelCausa = value;
                RaisePropertyChanged("labelCausa"); 
            }
        }
       
        private cause causaScelta;
        public cause CausaScelta
        {
            get
            {
                return causaScelta;
            }
            set
            {
                causaScelta = value;
                RaisePropertyChanged("causaScelta");
                if (value != null)
                {
                    Singleton.Instance.SetIDCliente((value as cause).idcliente);
                    setLabel();
                    CaricaDocs();
                }
            }
        }

        private void CaricaDocs()
        {
            List<cause_doc> listaCauseDoc = (from causadocRow in DbClass.LegEnt.cause_doc
                                             where causadocRow.idcausa == causaScelta.idcause
                                             orderby causadocRow.idcause_doc
                                             select causadocRow).ToList();

            CauseDoc = new ObservableCollection<cause_doc>(listaCauseDoc);
        }

        private ObservableCollection<cause_doc> causeDoc;
        public ObservableCollection<cause_doc> CauseDoc
        {
            get
            {
                return causeDoc;
            }
            set
            {
                causeDoc = value;
                RaisePropertyChanged("CauseDoc");
            }
        }

        private void salvaDati()
        {
            foreach (cause causa in causeList)
            {
                bool trovato = false;
                foreach (cause causaDB in DbClass.LegEnt.cause)
                {
                    if (causa.idcause == causaDB.idcause)
                    {
                        trovato = true;
                        break;
                    }
                }
                if (trovato == false) // se non è nel db lo aggiungo
                {
                    DbClass.LegEnt.cause.Add(causa);
                }
            }
            DbClass.LegEnt.SaveChanges();
        }
    }
}

       
