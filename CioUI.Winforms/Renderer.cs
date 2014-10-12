using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace CioUI.Winforms
{
    internal class Renderer : IRenderer
    {
        public IFormStore Store
        {
            get;
            set;
        }

        public IForm CreateStartupForm()
        {
            string formName = Store.GetRenderType();

            return CreateForm(formName);
        }

        public IForm CreateForm(string name)
        {
            return new CioForm();
        }

        public void Start(IForm form)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run((Form)form.RenderedForm);
        }
    }
}
