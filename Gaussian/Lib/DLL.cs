using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian.Lib
{
    public unsafe class DLL : IDisposable
    {
        WINAPI.HINSTANCE instance;

        private delegate int d_id(sbyte* id, int idLen);
        private d_id id;

        private const int MAX_ID_LEN = 256;

        public DLL(string path)
        {
            var pcstrPath = WINAPI.CPCSTR(path);
            instance = WINAPI.LoadLibraryA(pcstrPath);
            //WINAPI.FRPCSTR(pcstrPath);

            if (instance.IsNull)
            {
                throw new DllNotFoundException(
                    $"LoadLibraryA on \"{path}\" returned nullptr"
                    );
            }

            id = GetProc<d_id>("id");
        }

        public TDelegate GetProc<TDelegate>(string name) where TDelegate : Delegate
        {
            var pcstrName = WINAPI.CPCSTR(name);
            var proc = WINAPI.GetProcAddress(instance, pcstrName);
            //WINAPI.FRPCSTR(pcstrName);

            if (proc.IsNull)
            {
                throw new NullReferenceException(
                    $"GetProcAddress with \"{name}\" returned nullptr"
                    );
            }

            return proc.CreateDelegate<TDelegate>();
        }

        public string GetId()
        {
            var idArray = new sbyte[MAX_ID_LEN + 1];
            idArray[MAX_ID_LEN] = 0;

            fixed (sbyte* buf = idArray)
            {
                var code = id(buf, MAX_ID_LEN);

                if (code != 0)
                    throw new InternalBufferOverflowException($"DLL id(...) could not fit ID into {MAX_ID_LEN} bytes");

                int end = 0;
                while(end < (MAX_ID_LEN + 1) && buf[end] != 0)
                {
                    end++;
                }

                return new string(buf, 0, end);
            }
        }

        public void Dispose()
        {
            var disposeResult = WINAPI.FreeLibrary(instance);

            if (!disposeResult)
            {
                throw new SystemException("FreeLibrary returned nullptr");
            }
        }
    }



}
