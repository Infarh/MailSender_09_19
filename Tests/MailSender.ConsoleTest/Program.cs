using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using MailSender.ConsoleTest.Reports;
using System.Reflection;

namespace MailSender.ConsoleTest
{
    class Program
    {
        [Description("Entry point")]
        static void Main([Description("Command line attributes")] string[] args)
        {
            //var report = new Report
            //{
            //    Data1 = "Тестовые даныне",
            //    TimeValue = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 17))
            //};

            //const string report_file = "TestReport.docx";
            //report.CreatePackage(report_file);

            //for (var i = 0; i < 10; i++)
            //    Console.WriteLine(i);

            //Assembly
            //AssemblyName
            //Module

            //Type type = typeof(Program);
            //var program = new Program();
            //Type type = program.GetType();

            //MemberInfo
            //MethodInfo method = type.GetMethod("Main");
            //ParameterInfo paameter = method.GetParameters().FirstOrDefault();
            //ConstructorInfo
            //PropertyInfo
            //EventInfo
            //FieldInfo

            const string lib_file_name = "TestLib.dll";
            var lib_file_path = Path.GetFullPath(lib_file_name);

            var lib = Assembly.LoadFile(lib_file_path);

            //foreach (var type in lib.DefinedTypes)
            //    Console.WriteLine(type.FullName);

            var console_printer_type = lib.GetType("TestLib.ConsolePrinter");

            //foreach (var method in console_printer_type.GetMethods())
            //    Console.WriteLine("{0} {1}({2})",
            //        method.ReturnType.Name,
            //        method.Name,
            //        string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}")));

            var printer_ctor = console_printer_type.GetConstructor(new[] { typeof(string) });

            object printer_obj = printer_ctor.Invoke(new object[] { "PrinterPrefix> " });

            var print_method = console_printer_type.GetMethod("Print");

            print_method.Invoke(printer_obj, new object[] { "Data to print!" });

            var prefix_field = console_printer_type.GetField("_Prefix", BindingFlags.NonPublic | BindingFlags.Instance);

            string field_value = (string) prefix_field.GetValue(printer_obj);

            field_value += $"{DateTime.Now} |||";

            prefix_field.SetValue(printer_obj, field_value);

            var get_prefix_method = console_printer_type.GetMethod("GetPrefixLength", BindingFlags.Instance | BindingFlags.NonPublic);

            var result = (int) get_prefix_method.Invoke(printer_obj, new object[] {42, "Hello World!"});

            //dynamic printer = Activator.CreateInstance(console_printer_type, new object[] { "Hello World!" }, null);
            //printer.Print("QWE");

            var S1 = Sum("QWE", "123");
            Console.WriteLine(S1);

            var V1 = Sum(42, 54);
            Console.WriteLine(V1);

            var V2 = Sum(42, 3.141592653589793238);
            Console.WriteLine(V2);

            var V3 = Sum(42, "Hello World!");
            Console.WriteLine(V3);

            //var V4 = Sum(42, new List<int>());

            var data = new object[]
            {
                "Hello World!",
                42,
                3.141592653589793238,
                true,
                new List<int>()
            };
            Console.Clear();
            //ProcessData(data);

            Func<string, int> str_len = str => str.Length;
            Expression<Func<string, int>> expr = str => str.Length;

            Expression<Func<int, int, int>> summ_expr = (x, y) => x + y;

            var function = summ_expr.Compile();

            var value = function(3, 5);


            var parameter = Expression.Parameter(typeof(string), "Message");
            var body = Expression.Call(
                Expression.Constant(printer_obj),
                print_method,
                parameter);

            var print_expr = Expression.Lambda<Action<string>>(
                body,
                parameter);

            var print_action = print_expr.Compile();

            print_action("123");

            var list = new List<int>();


            Console.WriteLine(MemberName(list, l => l.Count));
            Console.WriteLine(MemberName(list, l => l.Capacity));
            Console.WriteLine(MemberName(list, l => l.Remove(5)));

            Console.ReadLine();
        }

        /*
         
        public virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
          if (this.PropertyChanged == null)
            return;
          string propertyName = ObservableObject.GetPropertyName<T>(propertyExpression);
          if (string.IsNullOrEmpty(propertyName))
            return;
          this.RaisePropertyChanged(propertyName);
        }
         
         */

        private static dynamic Sum(dynamic X, dynamic Y) { return X + Y; }


        private static void ProcessData(object[] data)
        {
            //foreach (var value in data)
            //    switch (value)
            //    {
            //        case string v: Process(v); break;
            //        case int v: Process(v); break;
            //        case double v: Process(v); break;
            //        case bool v: Process(v); break;
            //    }

            foreach (var value in data)
            {
                dynamic v = value;
                Process(v);
            }
        }

        private static void Process(string value) => Console.WriteLine("string: {0}", value);
        private static void Process(int value) => Console.WriteLine("int: {0}", value);
        private static void Process(double value) => Console.WriteLine("double: {0}", value);
        private static void Process(bool value) => Console.WriteLine("bool: {0}", value);
        private static void Process(object value) => Console.WriteLine("object: {0}", value);

        public static string MemberName<T, Q>(T Item, Expression<Func<T, Q>> Expr)
        {
            var body = Expr.Body;
            switch (body)
            {
                case MemberExpression member: return member.Member.Name;
            }

            return body.ToString();
        }
    }
}
