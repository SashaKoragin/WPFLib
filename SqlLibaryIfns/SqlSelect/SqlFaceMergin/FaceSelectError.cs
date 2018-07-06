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
       /// Добавление лица и вывод ошибки по лицу
       /// </summary>
       public static string AddFace =@"Declare @N1Old int =@Old
                                       Declare @N1New int =@New
                                       Declare @Error varchar(128) = NULL
                                       BEGIN TRY
                                          BEGIN TRAN
                                         If Exists(Select* From FN212 Where N1 = @N1Old)
                                            If @N1Old<> @N1New
                                               begin
                                                Insert into BDK77737751000070020000019757..Face (N1old, N1new, Messagee, DateFace) values(@N1Old, @N1New,'Слияние не начиналось!!!', NULL)
                                                Print 'Добавили лицо старое '+CONVERT(varchar(12),@N1Old) + ' слияние на новое '+CONVERT(varchar(12),@N1New)
                                               end
                                            else 
                                               begin
                                                Select @Error = 'Ошибка лицо с УН '+CONVERT(varchar(12),@N1Old) + ' не может совпадать с УН '+CONVERT(varchar(12),@N1New)
                                                RAISERROR(@Error,1, 2)
                                               end
                                         else 
                                            begin
                                              Select @Error = 'Ошибка старое лицо отсутствует в БД '+CONVERT(varchar(12),@N1Old)
                                              RAISERROR(@Error,1, 2)
                                            end
                                         COMMIT TRAN
                                       END TRY
                                       BEGIN CATCH
                                            WHILE @@TRANCOUNT > 0
		                                    ROLLBACK TRAN
                                       END CATCH";
       /// <summary>
       /// Выборка лиц по которым не прошло слияние в логе!!!
       /// </summary>
        public static readonly string FaceError = @"Select distinct Id, N1old, N1new,Messagee,N1,N18,N134,D3,FID_Entity From BDK77737751000070020000019757..Face FaceError
                                          Join FN212 on N1 = FaceError.N1old FOR XML AUTO,ROOT('Face')";

       public static string FaceDelete = @"use BDK77737751000070020000019757
                                            Declare @id int = @idint
                                            Delete From BDK77737751000070020000019757..Face
                                            Where id =@id
                                            Declare @i2 int =(SELECT max(id) From Face)
                                            DBCC CHECKIDENT(Face, RESEED, @i2)";
   }
}
