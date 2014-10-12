using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CioUI.Winforms
{
    internal class CioForm : IForm
    {
        private Lazy<Form> form = new Lazy<Form>();

        public CioForm()
        {
        }

        public Form RenderedForm
        {
            get
            {
                return form.Value;
            }
        }

        object IForm.RenderedForm
        {
            get
            {
                return this.RenderedForm;
            }
        }
    }
}
