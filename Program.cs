using System;

namespace StructsPractice
{
    // =========================================================================
    // СТРУКТУРА (Значущий тип даних - Value Type, зберігається у стеку)
    // =========================================================================
    struct StructPoint
    {
        public int X;
        public int Y;

        // ДОМАШНЄ ЗАВДАННЯ: Конструктор із параметрами
        // У структурах конструктор із параметрами зобов'язаний ініціалізувати ВСІ поля
        public StructPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        /*
         * ПЕРЕВІРКА ОБМЕЖЕННЯ ДЛЯ СТАРИХ ВЕРСІЙ C# (Домашнє завдання):
         * У версіях мови до C# 10 (включно з Mono) заборонено оголошувати 
         * явний конструктор без параметрів усередині структури:
         * 
         * public StructPoint() { X = 0; Y = 0; }
         * 
         * ТЕКСТ ПОМИЛКИ КОМПІЛЯТОРА:
         * error CS0568: Structs cannot contain explicit parameterless constructors
         * (Компілятор сам автоматично генерує конструктор без параметрів, 
         * який зануляє всі поля структури).
         */

        public void Print(string label)
        {
            Console.WriteLine(label + ": StructPoint(" + X + ", " + Y + ")");
        }
    }

    // =========================================================================
    // КЛАС (Посилальний тип даних - Reference Type, зберігається у купі)
    // =========================================================================
    class ClassPoint
    {
        public int X;
        public int Y;

        public ClassPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Print(string label)
        {
            Console.WriteLine(label + ": ClassPoint(" + X + ", " + Y + ")");
        }
    }

    // =========================================================================
    // ГОЛОВНИЙ КЛАС ПРОГРАМИ
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== 1. ПОВЕДІНКА СТРУКТУРИ (Value Type) ПРИ ПРИСВОЄННІ ===");
            StructPoint sp1 = new StructPoint(10, 20);
            
            // Копіюється саме значення (створюється повна незалежна копія у стеку)
            StructPoint sp2 = sp1;
            sp2.X = 999; // Змінюємо лише копію sp2

            sp1.Print("Оригінал sp1 (не змінився)");
            sp2.Print("Копія sp2 (змінилася)   ");

            Console.WriteLine("\n=== 2. ПОВЕДІНКА КЛАСУ (Reference Type) ПРИ ПРИСВОЄННІ ===");
            ClassPoint cp1 = new ClassPoint(10, 20);
            
            // Копіюється лише посилання (обидві змінні вказують на один об'єкт у купі)
            ClassPoint cp2 = cp1;
            cp2.X = 999; // Змінюємо об'єкт через посилання cp2

            cp1.Print("Оригінал cp1 (ЗМІНИВСЯ!)");
            cp2.Print("Посилання cp2           ");

            Console.WriteLine("\n=== 3. ПЕРЕДАЧА СТРУКТУРИ У ФУНКЦІЮ (Копіювання за значенням) ===");
            TryModifyStruct(sp1);
            sp1.Print("Після виклику функції оригінал sp1 все одно залишився");
        }

        // Функція отримує локальну копію структури
        static void TryModifyStruct(StructPoint p)
        {
            p.X = 555;
            p.Y = 777;
            p.Print("Усередині функції (змінилася лише локальна копія)");
        }
    }
}
