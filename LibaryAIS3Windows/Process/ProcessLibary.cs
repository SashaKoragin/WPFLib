using AutoIt;

namespace LibraryAIS3Windows.Process
{
   public class ProcessLibary
   {
        /// <summary>
        /// Закрытие процесса
        /// </summary>
        /// <param name="nameproces">Наименование процеса пример "AcroRd32.exe",
        /// "FoxitPhantom.exe"
        /// </param>
        /// <param name="timer">Время ожидания процесса</param>
        public static void Process(string nameproces,int timer)
       {
            AutoItX.ProcessWait(nameproces, timer);
            AutoItX.Sleep(2000); //Можно контролить  процесс
            while (true)
            {
                if (AutoItX.ProcessExists(nameproces) > 0)
                {
                    AutoItX.ProcessClose(nameproces);
                }
                if (AutoItX.ProcessExists(nameproces) == 0)
                {
                    break;
                }
            }
        }
   }
}
