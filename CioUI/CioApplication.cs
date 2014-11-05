using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioUI
{
    public class CioApplication
    {
        private string renderModeName;
        private ICioApplication application;
        private bool isInitialized = false;

        public void Initialize(RenderMode renderMode)
        {
            string applicationTypeName;

            switch(renderMode)
            {
                case RenderMode.WinForms:
                    applicationTypeName = "CioUI.WinForms.WinFormsCioApplication, CioUI.WinForms";
                    break;
                case RenderMode.Wpf:
                    applicationTypeName = "CioUI.Wpf.WpfCioApplication, CioUI.Wpf";
                    break;
                default:
                    throw new NotSupportedException("The provided renderMode is not supported. Please provide a renderModeName and applicationTypeName in the Initialize(string, string) overload.");
            }

            this.Initialize(renderMode.ToString(), applicationTypeName);
        }

        public void Initialize(string renderModeName, string applicationTypeName)
        {
            Type applicationType = Type.GetType(applicationTypeName);

            this.application = (ICioApplication)Activator.CreateInstance(applicationType);
            
            this.isInitialized = true;
        }

        public void Start()
        {
            this.application.Start();
        }

        public string RenderModeName
        {
            get
            {
                return this.renderModeName;
            }
        }
    }
}
