using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace React.ViewModel
{
    public class ViewModel
    {
        public Model.Model Reactive { get; }

        public ViewModel()
        {
            Reactive = new Model.Model();
        }
    
}
}
