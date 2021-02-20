using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class Departamento
    {
        private String _nomeDep;
        private int _IDdep;
        private String _localizacao;

        public String NomeDep
        {
            get { return _nomeDep; }
            set
            {
                _nomeDep = value;
            }

        }

        public int id_Dep
        {
            get { return _IDdep; }
            set
            {
                _IDdep = value;
            }

        }


        public String Dep_localizacao
        {
            get { return _localizacao; }
            set
            {
                _localizacao = value;
            }

        }
    }
}
