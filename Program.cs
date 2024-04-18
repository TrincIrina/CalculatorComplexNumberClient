using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorComplexNumberClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Загружаем сборку
            Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("CalculatorComplexNumberLib.dll"));
            Console.WriteLine($"Загружена сборка: {asm.FullName}");
            // Получаем необходимый модуль этой сборки
            Module module = asm.GetModule("CalculatorComplexNumberLib.dll");
            Console.WriteLine($"Загружен модуль: {module.FullyQualifiedName}");
            // Выводим список типов данных
            Console.WriteLine("Объявленные типы данных:");
            foreach(Type t in module.GetTypes())
            {
                Console.WriteLine(t.FullName);
            }
            Console.WriteLine();

            // Создать объект 
            Type ComplexNumber = module.GetTypes()[0];
            object complexNumber = Activator.CreateInstance(ComplexNumber, new object[] { 12, 15 });
            Console.WriteLine($"Complex number: " +
                $"{ComplexNumber.GetMethod("ToString").Invoke(complexNumber, null)}");
            Console.WriteLine($"Complex number invert: " +
                $"{ComplexNumber.GetMethod("invert").Invoke(complexNumber, null)}");
            Console.WriteLine($"Complex number increment: " +
                $"{ComplexNumber.GetMethod("increment").Invoke(complexNumber, null)}");
            Console.WriteLine($"Complex number decrement: " +
                $"{ComplexNumber.GetMethod("decrement").Invoke(complexNumber, null)}");
            Console.WriteLine($"Complex number module: " +
                $"{ComplexNumber.GetMethod("module").Invoke(complexNumber, null)}");
            Console.WriteLine();

            Console.WriteLine("Operations on complex numbers:");
            object complexNumber1 = Activator.CreateInstance(ComplexNumber, new object[] { 5, 7 });
            object complexNumber2 = Activator.CreateInstance(ComplexNumber, new object[] { 3, 6 });
            Console.WriteLine($"Complex number1: " +
                $"{ComplexNumber.GetMethod("ToString").Invoke(complexNumber1, null)}");
            Console.WriteLine($"Complex number2: " +
                $"{ComplexNumber.GetMethod("ToString").Invoke(complexNumber2, null)}");
            Type OperationsNumbers = module.GetTypes()[1];
            object operations = Activator.CreateInstance(OperationsNumbers, 
                new object[] { complexNumber1, complexNumber2 });
            Console.WriteLine($"Operation sum: " +
                $"{OperationsNumbers.GetMethod("Sum").Invoke(operations, null)}");
            Console.WriteLine($"Operation subtraction: " +
                $"{OperationsNumbers.GetMethod("Sub").Invoke(operations, null)}");
            Console.WriteLine($"Operation multiplication: " +
                $"{OperationsNumbers.GetMethod("Mult").Invoke(operations, null)}");
            Console.WriteLine($"Operation division: " +
                $"{OperationsNumbers.GetMethod("Division").Invoke(operations, null)}");
        }
    }
}
