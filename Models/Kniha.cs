using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammerIssueTracking.Models
{
    public class Kniha
    {
        public int ID { get; set; }
        public DateTime datumcas { get; set; }
        public int ID_OddeleniVzniku { get; set; }
        public int ID_Oddeleni { get; set; }
        public int ID_OdkudEskalovano { get; set; }
        public int ID_OddeleniEskalace { get; set; }
        public int ID_Eskalace { get; set; }
        public int ID_EskalaceTam { get; set; }
        public int ID_EskalaceZpet { get; set; }
        public int ID_KategorieProblemu { get; set; }
        public int ID_StupenRizika { get; set; }
        public int PrectenoZpravaTechZmeny { get; set; }
        public int Informovat { get; set; }
    }
}
