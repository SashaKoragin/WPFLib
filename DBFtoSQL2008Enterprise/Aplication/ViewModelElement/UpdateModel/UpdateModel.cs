using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using DBFtoSQL2008Enterprise.Aplication.Commands;
using DBFtoSQL2008Enterprise.Aplication.Page;
using DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel;

namespace DBFtoSQL2008Enterprise.Aplication.ViewModelElement.UpdateModel
{
   public class UpdateModel
   {
        public void UpdateModelProgressBarProgress(ConvertDbFtoSql xamlconvert, string name, float procent)
        {
            ModelProgressBar model = (ModelProgressBar)xamlconvert.Resources["ProgressBar"];
            model.NameTable = "Обработка DBF файла " + name;
            model.ProcentObr += (int)(procent * 100.0f);
        }
        public void UpdateModelProgressBarProgress(ConvertDbFtoSql xamlconvert)
        {
            ModelProgressBar model = (ModelProgressBar)xamlconvert.Resources["ProgressBar"];
            if (model.ProcentObr ==0)
            { 
            model.NameTable = "Начали обрабатывать!!!";
            model.ProcentObr =0;
            }
            else
            {
                model.NameTable = "Закончили обрабатывать!!!";
                model.ProcentObr = 0;
            }
        }
    }
}
