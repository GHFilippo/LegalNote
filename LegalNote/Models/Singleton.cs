using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LegalNote.Models
{
    public sealed class Singleton
    {
        private int IdCliente = -1;
        private static readonly Object s_lock = new Object();
        private static Singleton instance = null;
        private bool isSelected = false;
        public utenti utenteAttivo;
        public string DbConnectionString;
        

        private Singleton()
        {
        }
        public void SetIDCliente(int id)
        {
            IdCliente = id;
        }
        public int GetIdCliente()
        {
            return IdCliente;
        }
        public static Singleton Instance
        {
            get
            {
                if (instance != null) return instance;
                Monitor.Enter(s_lock);
                Singleton temp = new Singleton();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(s_lock);
                return instance;
            }
        }

        public bool IsSelected { get => isSelected; set => isSelected = value; }
    }

}
