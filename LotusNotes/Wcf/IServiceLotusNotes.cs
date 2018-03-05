using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Lotuslib.LotusModel;
using MaterialDesignThemes.Wpf;

namespace LotusNotes.Wcf
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceLotusNotes" в коде и файле конфигурации.
    [ServiceContract]
    
    public interface IServiceLotusNotes
    {

        [OperationContract]
        ModelComutator Col();
    }
}