//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LegalNote
{
    using System;
    using System.Collections.Generic;
    
    public partial class cause
    {
        public int idcause { get; set; }
        public int idcliente { get; set; }
        public string nomecausa { get; set; }
        public System.DateTime datainiziocausa { get; set; }
        public Nullable<System.DateTime> datafinecausa { get; set; }
        public string descrizione { get; set; }
        public int idUtente { get; set; }
    }
}
