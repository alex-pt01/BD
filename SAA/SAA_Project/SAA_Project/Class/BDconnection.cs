using System;
using System.Data;
using System.Data.SqlClient;

namespace SAA_Project
{
    class BDconnection
    {
        private static SqlConnection cn = null;
        private static String _user = null;

        public static void start()
        {
            cn = getSGBDConnection();
        }

        private static SqlConnection getSGBDConnection()
        {

            return new SqlConnection("data source=tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p3g6; uid = p3g6; password = -1152996106@Bd");
        }

        public static SqlConnection getConnection()
        {
            return cn;
        }

        public static String user
        {
            get { return _user; }
            set { _user = value; }
        }

        public static bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

    }
}

