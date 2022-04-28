using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    class Hosting
    {
        [STAThread]
        static void Main(string[] args)
        {
            Launcher.LoadComponet();
        }
    }
}
