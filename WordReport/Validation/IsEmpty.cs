using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReport.Validation
{
   public class IsEmpty
    {

       public static bool IsEmptys(DataSet dataSet)
        {

            foreach (DataTable table in dataSet.Tables)
            { 
                if (table.Rows.Count == 0)
                { return false;}
            }
            return true;
        }
    }
}
