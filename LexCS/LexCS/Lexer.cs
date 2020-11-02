using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LexCS
{
    public static class Lexer
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackDelegate(int val, IntPtr str);

        [DllImport("./LexDll.dll", EntryPoint = "mainloop", CallingConvention = CallingConvention.StdCall)]
        public static extern int mainloop(CallbackDelegate func);

        public static string PtrToStringUtf8(IntPtr ptr) // aPtr is nul-terminated
        {
            if (ptr == IntPtr.Zero)
                return "";
            int len = 0;
            while (System.Runtime.InteropServices.Marshal.ReadByte(ptr, len) != 0)
                len++;
            if (len == 0)
                return "";
            byte[] array = new byte[len];
            System.Runtime.InteropServices.Marshal.Copy(ptr, array, 0, len);
            return System.Text.Encoding.UTF8.GetString(array);
        }
    }
}
