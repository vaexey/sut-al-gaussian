using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Gaussian.Lib.WINAPI;

namespace Gaussian.Lib
{
    // Credit: https://www.pinvoke.dev/
    public static class WINAPI
    {
        [DllImport("KERNEL32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern HMODULE LoadLibraryA(PCSTR lpLibFileName);

        [DllImport("KERNEL32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern bool FreeLibrary(HMODULE hLibModule);

        [DllImport("KERNEL32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern FARPROC GetProcAddress(
            HMODULE hModule,
            PCSTR lpProcName);

        [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
        public readonly unsafe struct PCSTR : IEquatable<PCSTR>
        {
            public readonly byte* Value;

            public PCSTR(byte* value) => Value = value;

            public static implicit operator byte*(PCSTR value) => value.Value;

            public static explicit operator PCSTR(byte* value) => new(value);

            public bool Equals(PCSTR other) => Value == other.Value;

            public override bool Equals(object obj) => obj is PCSTR other && Equals(other);

            public override int GetHashCode() => (int)Value;

            public int Length
            {
                get
                {
                    var p = Value;

                    if (p is null)
                        return 0;

                    while (*p != 0)
                        p++;

                    return checked((int)(p - Value));
                }
            }

            public override string ToString() => Value is null ? string.Empty : new string((sbyte*)Value, 0, Length, Encoding.Default);

            public ReadOnlySpan<byte> AsSpan() => Value is null ? default : new ReadOnlySpan<byte>(Value, Length);

            private string DebuggerDisplay => ToString();
        }

        public static unsafe PCSTR CPCSTR(string value)
        {
            var buffer = Encoding.ASCII.GetBytes(value);

            return new PCSTR(
                    (byte*)GCHandle.Alloc(buffer, GCHandleType.Pinned)
                    .AddrOfPinnedObject()
                );
        }

        public static unsafe void FRPCSTR(PCSTR pcstr)
        {
            GCHandle.FromIntPtr((nint)pcstr.Value).Free();
        }

        [DebuggerDisplay("{Value}")]
        public readonly struct HINSTANCE : IEquatable<HINSTANCE>
        {
            public readonly nint Value;

            public HINSTANCE(nint value) => Value = value;

            public static HINSTANCE Null => default;

            public bool IsNull => Value == default;

            public static implicit operator nint(HINSTANCE value) => value.Value;

            public static explicit operator HINSTANCE(nint value) => new(value);

            public static bool operator ==(HINSTANCE left, HINSTANCE right) => left.Value == right.Value;

            public static bool operator !=(HINSTANCE left, HINSTANCE right) => !(left == right);

            public bool Equals(HINSTANCE other) => Value == other.Value;

            public override bool Equals(object obj) => obj is HINSTANCE other && Equals(other);

            public override int GetHashCode() => Value.GetHashCode();

            public override string ToString() => $"0x{Value:x}";

            public static implicit operator HMODULE(HINSTANCE value) => new(value.Value);
        }

        [DebuggerDisplay("{Value}")]
        public readonly struct HMODULE : IEquatable<HMODULE>
        {
            public readonly nint Value;

            public HMODULE(nint value) => Value = value;

            public static HMODULE Null => default;

            public bool IsNull => Value == default;

            public static implicit operator nint(HMODULE value) => value.Value;

            public static explicit operator HMODULE(nint value) => new(value);

            public static bool operator ==(HMODULE left, HMODULE right) => left.Value == right.Value;

            public static bool operator !=(HMODULE left, HMODULE right) => !(left == right);

            public bool Equals(HMODULE other) => Value == other.Value;

            public override bool Equals(object obj) => obj is HMODULE other && Equals(other);

            public override int GetHashCode() => Value.GetHashCode();

            public override string ToString() => $"0x{Value:x}";

            public static implicit operator HINSTANCE(HMODULE value) => new(value.Value);
        }

        public struct FARPROC
        {
            public nint Value;

            public FARPROC(nint value) => Value = value;

            public static FARPROC Null => default;

            public bool IsNull => Value == default;

            public static implicit operator nint(FARPROC value) => value.Value;

            public static explicit operator FARPROC(nint value) => new(value);

            public static bool operator ==(FARPROC left, FARPROC right) => left.Value == right.Value;

            public static bool operator !=(FARPROC left, FARPROC right) => !(left == right);

            public bool Equals(FARPROC other) => Value == other.Value;

            public override bool Equals(object obj) => obj is FARPROC other && Equals(other);

            public override int GetHashCode() => Value.GetHashCode();

            public override string ToString() => $"0x{Value:x}";

            public TDelegate CreateDelegate<TDelegate>() where TDelegate : Delegate =>
                Marshal.GetDelegateForFunctionPointer<TDelegate>(Value);
        }
    }
}
