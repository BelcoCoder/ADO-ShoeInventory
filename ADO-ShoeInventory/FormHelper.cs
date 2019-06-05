using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_ShoeInventory
{
    static class FormHelper
    {
        public static Form Create(Type t)
        {
            Form f = Application.OpenForms[t.Name];
            if (f == null)
                f = (Form)Activator.CreateInstance(t);
            return f;
        }
    }
}
