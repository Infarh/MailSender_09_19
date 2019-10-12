using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public class ConsolePrinter
    {
        private string _Prefix;

        public ConsolePrinter(string Prefix) => _Prefix = Prefix;

        public void Print(string message)
        {
            Console.WriteLine("{0}{1}", _Prefix, message);
        }

        private int GetPrefixLength(int Offset, string Str) => _Prefix?.Length ?? -1 + Offset + Str?.Length ?? 0;
    }

    internal class PrivatePrinter
    {
        private int _Data;

        private PrivatePrinter(int data) { _Data = data; }

        public void Print(string Message) => Console.WriteLine("{0} - {1}", Message, _Data);
    }
}
