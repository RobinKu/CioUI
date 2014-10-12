using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioUI
{
    public class NotARendererException : Exception
    {
        public NotARendererException(Type wrongType, Exception innerException)
            : base(GetMessage(wrongType), innerException)
        {
        }

        private static string GetMessage(Type wrongType)
        {
            if (wrongType == null)
            {
                throw new ArgumentNullException("wrongType");
            }

            return string.Format("The type {0} does not implement the interface {1}", wrongType, typeof(IRenderer));
        }
    }
}
