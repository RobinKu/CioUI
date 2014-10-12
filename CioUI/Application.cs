using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioUI
{
    public partial class Application
    {
        public IRenderer Renderer
        {
            get;
            set;
        }

        public IFormStore FormStore
        {
            get;
            set;
        }

        public void Start()
        {
            IForm form = Renderer.CreateStartupForm();

            Renderer.Start(form);
        }
    }
}
