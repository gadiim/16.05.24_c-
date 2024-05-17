using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Тема: Вступ до LINQ
//Модуль 13. Частина 2


namespace _16._05._24_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Завдання 1:
            //Для масиву цілих чисел реалізуйте користувацьке сортування.
            //Сортування має працювати за сумою цифр числа(за зростанням
            //та зменшенням).Наприклад, якщо сортування проводиться за
            //зменшенням, потрібно повернути числа з максимальною сумою
            //в порядку зменшення суми. Наприклад, якщо масив містить 121,
            //75, 81, після сортування за зменшенням ми отримаємо 75, 81, 121.
            //Такий результат, тому що 7 + 5 = 12, 8 + 1 = 9, 1 + 2 + 1 = 4.

            Console.WriteLine($"Task 1\n");

            int[] original_array = { 121, 75, 81 };

            Console.Write("original array:\t\t\t");
            Display(original_array);

            Console.Write("ascending array:\t\t");
            var ascending_array = original_array.OrderBy(i => i.ToString().ToCharArray()
                                                .Sum(c =>c - 'O')).ToArray();
            Display(ascending_array);

            Console.Write("descending array:\t\t");
            var descending_array = original_array.OrderByDescending(i => i.ToString().ToCharArray()
                                                .Sum(c => c - 'O')).ToArray();
            Display(descending_array);
        
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 2:
            //Для двох масивів країн реалізуйте такі запити:
            // Отримати різницю двох масивів(елементи першого масиву,
            //яких немає у другому).
            // Отримати перетин масивів(спільні елементи для обох
            //масивів).
            // Отримати об'єднання масивів (елементи обох масивів без
            //дублікатів).
            // Отримати вміст першого масиву без повторень.

            Console.WriteLine($"Task 2\n");

            string[] arab_countries = { "Algeria", "Egypt", "Saudi Arabia", "Iraq", "Kuwait" };
            string[] african_countries = { "Algeria", "Cameroon", "Gabon", "Egypt", "South Africa" };
            Console.Write($"arab countries:\t\t\t");
            Display(arab_countries);
            Console.Write($"african countries:\t\t");
            Display(african_countries);

            Console.Write($"except countries:\t\t");
            string[] except_countries = arab_countries.Except(african_countries).ToArray();
            Display(except_countries);

            Console.Write($"intersect countries:\t\t");
            string[] intersect_countries = arab_countries.Intersect(african_countries).ToArray();
            Display(intersect_countries);

            Console.Write($"union countries:\t\t");
            string[] union_countries = arab_countries.Union(african_countries).ToArray();
            Display(union_countries);

            Console.Write($"union all countries:\t\t");
            string[] union_all_countries = arab_countries.Concat(african_countries).ToArray();
            Display(union_all_countries);

            Console.Write($"distinct arab countries:\t");
            string[] distinct_countries = arab_countries.Distinct().ToArray();
            Display(distinct_countries);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 3:
            //Створіть користувацький тип «Пристрій», який зберігатиме таку
            //інформацію:
            // назва пристрою;
            // виробник пристрою;
            // вартість.
            //Для двох масивів пристроїв реалізуйте операції:
            // різниця масивів;
            // перетин масивів;
            // об'єднання масивів.
            //Критерій для проведення операцій — виробник пристрою.

            Console.WriteLine($"Task 3\n");

            Device[] good_store = new Device[]
            {
            new Device("Laptop", "Dell", 800),
            new Device("Smartphone", "Apple", 1200),
            new Device("Tablet", "Samsung", 600),
            new Device("Smartwatch", "Garmin", 300),
            new Device("Smartwatch", "Samsung", 600)
            };
            Device[] excellent_store = new Device[]
            {
            new Device("Tablet", "Dell", 800),
            new Device("Smartphone", "Samsung", 600),
            new Device("Tablet", "Samsung", 600),
            new Device("Smartwatch", "Apple", 1200),
            new Device("Laptop", "Samsung", 600)
            };

            Console.WriteLine("good store:\t");
            Display(good_store);
            Console.WriteLine("excellent store:\t");
            Display(excellent_store);

            Console.WriteLine("\nNext . . .");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Task 3\n");

            Console.Write("manufacturer exceptions:\t");
            var manufacturer_exceptions = good_store.Select(c => c.Manufacturer)
                                                    .Except(excellent_store
                                                    .Select(c => c.Manufacturer))
                                                    .ToArray();
            Display(manufacturer_exceptions);

            Console.Write("manufacturer intersection:\t");
            var manufacturer_intersection = good_store.Select(c => c.Manufacturer)
                                                    .Intersect(excellent_store
                                                    .Select(c => c.Manufacturer))
                                                    .ToArray();
            Display(manufacturer_intersection);

            Console.Write("union intersection:\t\t");
            var union_intersection = good_store.Select(c => c.Manufacturer)
                                                    .Union(excellent_store
                                                    .Select(c => c.Manufacturer))
                                                    .ToArray();
            Display(union_intersection);

            Console.WriteLine();

        }
        static void Display<T>(T [] values)
        {
            foreach(var value in values)
            {
                Console.Write($"{value}; ");
            }
            Console.WriteLine();
        }

        static void Display(Device[] values)
        {
            foreach (var value in values)
            {
                Console.Write(value);
            }
            Console.WriteLine();
        }

    }
    class Device
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Cost { get; set; }

        public Device(string name, string manufacturer, int cost)
        {
            Name = name;
            Manufacturer = manufacturer;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"name: {Name};\tmanufacturer: \"{Manufacturer}\";\tcost: {Cost}.\n";
        }
    }

}
