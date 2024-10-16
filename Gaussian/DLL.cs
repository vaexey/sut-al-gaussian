using System;
using System.Collections.Generic;
using System.IO;
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
            //WINAPI.FRPCSTR(pcstrPath);

            if(instance.IsNull)
            {
                throw new DllNotFoundException(
                    $"LoadLibraryA on \"{path}\" returned nullptr"
                    );
            }
        }

        public TDelegate GetProc<TDelegate>(string name) where TDelegate : Delegate
        {
            var pcstrName = WINAPI.CPCSTR(name);
            var proc = WINAPI.GetProcAddress(instance, pcstrName);
            //WINAPI.FRPCSTR(pcstrName);

            if(proc.IsNull)
            {
                throw new NullReferenceException(
                    $"GetProcAddress with \"{name}\" returned nullptr"
                    );
            }

            return proc.CreateDelegate<TDelegate>();
        }

        public void Dispose()
        {
            var disposeResult = WINAPI.FreeLibrary(instance);
            
            if(!disposeResult)
            {
                throw new SystemException("FreeLibrary returned nullptr");
            }
        }
    }



}
