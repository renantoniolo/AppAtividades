using System;
using Realms;

namespace AppAtividades.Model
{
    public class Atividade : RealmObject
    {
	    [Indexed]
        public int codigoatividade { get; set; }

        public string nomeatividade { get; set; }

        public string local { get; set; }

        public string horarioinicio { get; set; }

        public string horariofim { get; set; }

        public bool registrado { get; set; }

        public string cor { get; set; }
    }
}
