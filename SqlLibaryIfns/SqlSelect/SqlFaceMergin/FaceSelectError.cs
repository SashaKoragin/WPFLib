using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.SqlFaceMergin
{
   public class FaceSelectError
   {
       /// <summary>
       /// Выборка лиц по которым не прошло слияние в логе!!!
       /// </summary>
       public string FaceError = @"Select N1old,N1new,Messagee,N1,N18,N134,D3,FID_Entity From BDK77737751000070020000019757..Face FaceError
                                   Join FN212 on N1 = FaceError.N1old FOR XML AUTO, ROOT('Face')";
   }
}
