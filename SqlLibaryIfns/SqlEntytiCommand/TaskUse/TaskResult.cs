using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlEntytiCommand.TaskUse
{
   public class TaskResult
    {

        public async Task<string> TaskSqlProcedure(string connection, int id, int d270 = 0)
        {
            switch (id)
            {
                case 1:
                    return await Task.Factory.StartNew(()=>
                    {

                        return "sds";
                    });
                case 2:
                    return null;
                case 3:
                    return null;
            }
            return null;
        }

    }
}
