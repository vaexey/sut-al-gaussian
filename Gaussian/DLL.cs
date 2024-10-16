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
        //[DllImport("KERNEL32.dll", ExactSpelling = true, SetLastError = true)]
        //[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        //public static extern HMODULE LoadLibraryW(PCWSTR lpLibFileName);

        public DLL(string path)
        {

        }

        public void Dispose()
        {

        }
    }



}
