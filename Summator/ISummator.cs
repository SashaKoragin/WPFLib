using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Summator
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ISummator" в коде и файле конфигурации.
    [ServiceContract]
    public interface ISummator
    {
        [OperationContract]
        int GetSumm(int x, int y);
        [OperationContract]
        int GetSusmm(int x, int y);

        [OperationContract]
        void Ddd();
    }
}
