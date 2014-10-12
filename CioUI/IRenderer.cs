using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioUI
{
    public interface IRenderer
    {
        IFormStore Store
        {
            get;
            set;
        }

        IForm CreateStartupForm();

        void Start(IForm form);
    }
}
