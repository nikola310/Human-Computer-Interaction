using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows;

namespace HCI_projekat2.Help
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        Window prozor;
        public JavaScriptControlHelper(Window w)
        {
            prozor = w;
        }

        public void RunFromJavascript(string param)
        {
            //prozor.doThings(param);
        }
    }
}