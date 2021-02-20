using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA_Project
{
    class Table
    {
        private String _TABLE_NAME;

        public String TABLE_NAME
        {
            get { return _TABLE_NAME; }
            set { _TABLE_NAME = value; }
        }

        public override String ToString()
        {
            return _TABLE_NAME;
        }

    }
}
