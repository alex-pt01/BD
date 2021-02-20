using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class Falta_Nota
    {
        private String _ID_Nota;
        private String _Nota;
        private String _ID_Registo;
        private String _ID_Falta;
        private String _tipoFalta;

        public String ID_Nota
        {
            get { return _ID_Nota; }
            set { _ID_Nota = value; }
        }

        public String Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        public String ID_Registo
        {
            get { return _ID_Registo; }
            set { _ID_Registo = value; }
        }

        public String ID_Falta
        {
            get { return _ID_Falta; }
            set { _ID_Falta = value; }
        }

        public String tipoFalta
        {
            get { return _tipoFalta; }
            set { _tipoFalta = value; }
        }
    }
}
