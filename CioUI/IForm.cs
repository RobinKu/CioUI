using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CioUI
{
    public interface IForm
    {
        void Show();

        ICommandManager CommandManager
        {
            get;
            set;
        }
    }
}
