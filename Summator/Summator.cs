using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Summator
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Summator" в коде и файле конфигурации.
    public class Summator : ISummator
    {
        public void Ddd()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        public int GetSumm(int x, int y)
        {
            return x + y;
        }

        public int GetSusmm(int x, int y)
        {
            return x + y;
        }
    }
}
