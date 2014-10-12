using CioUI.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioUI
{
    public partial class Application
    {
        public static void StartFromXml(Stream xml)
        {
            StartFromFormStore(new XmlFormStore(xml));
        }

        public static void StartFromFormStore(IFormStore formStore)
        {
            Application app = new Application();

            app.FormStore = formStore;
            app.Renderer = CreateRenderer(formStore.GetRenderType());
            app.Renderer.Store = formStore;
            app.Start();
        }

        private static IRenderer CreateRenderer(string renderType)
        {
            string rendererTypeName;

            switch (renderType)
            {
                case "Winforms":
                    rendererTypeName = "CioUI.Winforms.Renderer, CioUI.Winforms";
                    break;
                case "Wpf":
                    rendererTypeName = "CioUI.Wpf.Renderer, CioUI.Wpf";
                    break;
                default:
                    rendererTypeName = renderType;
                    break;
            }

            Type rendererType = Type.GetType(rendererTypeName, true);

            try
            {
                return (IRenderer)Activator.CreateInstance(rendererType);
            }
            catch (InvalidCastException ex)
            {
                throw new NotARendererException(rendererType, ex);
            }
        }
    }
}
