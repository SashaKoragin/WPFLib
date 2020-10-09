using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLib.ModelTestAutoit.PublicModel.TemplateModel
{
    public class TemplateModel
    {

        private ObservableCollection<AisPoco.Ifns51.ToAis.TemplateModel> _templateModelServer =
            new ObservableCollection<AisPoco.Ifns51.ToAis.TemplateModel>();

        public ObservableCollection<AisPoco.Ifns51.ToAis.TemplateModel> TemplateModelServer { get; set; } =
            new ObservableCollection<AisPoco.Ifns51.ToAis.TemplateModel>();


        public ObservableCollection<AisPoco.Ifns51.ToAis.TemplateModel> Model
        {
            get { return _templateModelServer; }
            set { _templateModelServer = value; }
        }

    }

    public class ServerModel : TemplateModel
    {
        /// <summary>
        /// Объявление класса
        /// </summary>
        public ServerModel()
        {
        }

        /// <summary>
        /// Объявление класса
        /// </summary>
        public ServerModel(List<AisPoco.Ifns51.ToAis.TemplateModel> arrayModels)
        {
            foreach (var templateModel in arrayModels)
            {
                TemplateModelServer.Add(templateModel);
            }
        }

        ///// <summary>
        ///// Выбираем Статус C
        ///// </summary>
        ///// <param name="param">Объект выбора</param>
        //public void SelectStatusAddC(object param)
        //{
        //    System.Windows.Controls.CheckBox parame = (System.Windows.Controls.CheckBox)param;
        //    Model.Add(new ParamQbe() { Num = Convert.ToInt32(parame.Content), ColorNum = parame.Background });
        //}
        ///// <summary>
        ///// Удаляем сататус C
        ///// </summary>
        ///// <param name="param">Объект выбора</param>
        //public void DeleteStatusAddC(object param)
        //{
        //    System.Windows.Controls.CheckBox parame = (System.Windows.Controls.CheckBox)param;
        //    C.Remove(C.Single(parameter => parameter.Num == Convert.ToInt32(parame.Content)));
        //}

    }
}
