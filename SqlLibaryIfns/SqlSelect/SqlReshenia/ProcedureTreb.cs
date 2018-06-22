using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.SqlReshenia
{
   public class ProcedureTreb
   {
        /// <summary>
        /// Процедура AddTreb
        /// </summary>
        public readonly string ProcedureAddTreb = "AddTreb";
        /// <summary>
        /// Процедура StartTreb
        /// </summary>
        public readonly string ProcedureStartTreb = "StartTreb";
        /// <summary>
        /// Процедура StartIncass
        /// </summary>
        public readonly string ProcedureStartIncass = "StartIncass";

       public SqlCommand CreateCommandProcedureParametr<TKey,TValue>(SqlConnection conectionstring, string procedure, Dictionary<TKey,TValue> listparametr )
       {
            return new SqlCommand(procedure, conectionstring)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 300,
                Parameters =
                {
                  ParameterSqlProcedure(listparametr)
                }
            };
        }

        public SqlCommand CreateCommandProcedure(SqlConnection conectionstring, string procedure)
        {
            return new SqlCommand(procedure, conectionstring)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 300
            };
        }

        public List<SqlParameter> ParameterSqlProcedure<TKey, TValue>(Dictionary<TKey, TValue> listparametr)
        {
            List<SqlParameter> paramprocedure = new List<SqlParameter>();
           foreach (KeyValuePair<TKey, TValue> keyvalue in listparametr)
           {
               paramprocedure.Add(new SqlParameter(keyvalue.Key.ToString(),TypeParam(keyvalue.Value), 256){Value = keyvalue.Value});
                
           }
            return paramprocedure;
        }

       internal SqlDbType TypeParam<TValue>(TValue type)
       {
           var t = type.GetType();
   

           return SqlDbType.BigInt;
       }




   }
}
