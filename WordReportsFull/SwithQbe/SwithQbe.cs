using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordReportsFull.Trige.UregTrig;

namespace WordReportsFull.SwithQbe
{
    class SwithQbe
    {

        public static void SwithQ(TrigVisibl trig,  string nameqbe)
        {
            switch (nameqbe)
            {
                case "SummNedoim.docx":
                    trig.Innvisibl = true;
                    trig.Kbkvisibl = true;
                    trig.Godvisibl = false;
                    break;
                case "NDflFl.docx":
                    trig.Innvisibl = true;
                    trig.Godvisibl = true;
                    trig.Kbkvisibl = false;
                    break;
            }

        }

    }
}
