using System.Windows.Forms;

namespace LibaryAIS3Windows.ExitLogica
{
    /// <summary>
    /// Класс при завершении работы автомата
    /// </summary>
   public class Exit : ExitClass
    {

        /// <summary>
        /// Логика завершения работы автомата
        /// </summary>
        /// <param name="count">Колличество отработтаных</param>
        /// <param name="length">Всего колличество</param>
        /// <param name="status">Статус </param>
        /// <returns>Статус делаем выводы остановлена или закончена</returns>
        public ExitClass Exitfunc(int count, int length,bool status)
        {
            ExitClass stat = new ExitClass();
            if (count == length)
            {
                MessageBox.Show(Status.StatusAis.Status3);
                stat.IsCount = 0;
                stat.IsWork = true;
                stat.Stat = "onstop";
            }
            if (!status)
            {
                MessageBox.Show(Status.StatusAis.Status2);
                stat.IsCount = 0;
                stat.IsWork = true;
                stat.Stat = "stop";
            }
            return stat;
        }
    }
}
