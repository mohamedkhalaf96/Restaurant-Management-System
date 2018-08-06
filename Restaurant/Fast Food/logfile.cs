using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Food
{
    public class logfile
    {
        public bool logfilee(string sqlcommend)
        {
            try
            {
                using (System.IO.StreamWriter logfile =
                    new System.IO.StreamWriter(@"D:\my faculty\logfile.txt", true))
                    //MessageBox.Show("logfile created");
                    logfile.WriteLine(sqlcommend + DateTime.Now);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
