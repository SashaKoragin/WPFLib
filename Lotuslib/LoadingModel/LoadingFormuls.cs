using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Lotuslib.Formula.Otdel;
using Lotuslib.StatusZG;

namespace Lotuslib.LoadingModel
{
   public class LoadingFormuls
    {
        public static OtdelFormul Formuls()
        {
            OtdelFormul shemeformulotdel = new OtdelFormul();
            shemeformulotdel.ShemeOtdelFormul.Add(new OtdelFormul()
            {
                Index = 1,
                Name = "Отбор ЗГ",
                Discription = "Отбор ЗГ поступившие за период или день",
                //Formula = @"@Select(@Contains("+LotusItem.DbZgItem.Dept + ";\"{0}\") & ( @Date(@Created)>= @Date({1}) & @Date(@Created) <= @Date({2})))"
                Formula = @"@Select(@Contains(" + LotusItem.DbZgItem.Dept + ";\"{0}\") & ( @Date("+LotusItem.DbZgItem.DataReg+ ")>= @Date({1}) & @Date(" + LotusItem.DbZgItem.DataReg + ") <= @Date({2})))"
            });
            shemeformulotdel.ShemeOtdelFormul.Add(new OtdelFormul()
            {
                Index = 2,
                Name = "ЗГ со статусом",
                Discription = "ЗГ со статусом",
                Formula = @"@Select(@Contains(" + LotusItem.DbZgItem.Dept + ";\"{0}\")&( @Date(@Created)>= @Date({1}) & @Date(@Created) <= @Date({2}))&(@Contains(" + LotusItem.DbZgItem.StatusZg + ";\"{3}\")) )"
            });
            return shemeformulotdel;
        }
    }

    public class LoadStatus
    {
        public static Status Status()
        {
            Status status = new Status();
            status.StatusZgCollection.Add(new Status
            {
                Name = "Снятые",
                StatusZg = "X"
            });
            status.StatusZgCollection.Add(new Status
            {
                Name = "На контроле",
                StatusZg = "Exec"
            });
            return status;
        }
    }
}