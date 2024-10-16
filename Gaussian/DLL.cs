using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian
{
    public class DLL : IDisposable
    {
        WINAPI.HINSTANCE instance;

        public DLL(string path)
        {
            var pcstrPath = WINAPI.CPCSTR(path);
            instance = WINAPI.LoadLibraryA(pcstrPath);
            WINAPI.FRPCSTR(pcstrPath);

            if(instance.IsNull)
            {
                throw new DllNotFoundException($"LoadLibraryA on \"{path}\" returned nullptr");
            }
        }

        public void Dispose()
        {
            // TODO
        }
    }



}
