using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioUI
{
    public interface IFormManager
    {
        void AddForm(IForm form);

        void RemoveForm(IForm form);
    }
}
