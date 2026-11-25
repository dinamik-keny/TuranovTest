using System;
using System.Collections.Generic;
using LibraryLib;

namespace LibraryTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Проверяем получение названия и текущего главного библиотекаря
            Console.WriteLine("Библиотека: " + LibraryFunctions.GetLibraryName());
            Console.WriteLine("Главный библиотекарь: " + LibraryFunctions.GetChiefLibrarian());
            Console.WriteLine();

            // Выводим исходный список сотрудников
            Console.WriteLine("Текущий список сотрудников:");
            PrintStaff(LibraryFunctions.GetStaff());
            Console.WriteLine();

            // Пробуем назначить главным библиотекарем человека не из списка
            bool resultFail = LibraryFunctions.SetChiefLibrarian("Смирнов К.О.");
            Console.WriteLine("Попытка назначить Смирнова К.О. (нет в списке): " + resultFail);
            Console.WriteLine("Текущий главный библиотекарь: " + LibraryFunctions.GetChiefLibrarian());
            Console.WriteLine();

            // Назначаем главным библиотекарем действующего сотрудника (точное совпадение строки)
            bool resultSuccess = LibraryFunctions.SetChiefLibrarian("Петров П.С.");
            Console.WriteLine("Попытка назначить Петрова П.С. (есть в списке): " + resultSuccess);
            Console.WriteLine("Новый главный библиотекарь: " + LibraryFunctions.GetChiefLibrarian());
            Console.WriteLine();

            // Проверяем добавление новых сотрудников (оба варианта вызова)
            LibraryFunctions.AddStaff("Новиков Д.А.");
            LibraryFunctions.AddStaff();
            Console.WriteLine("Список сотрудников после добавления:");
            PrintStaff(LibraryFunctions.GetStaff());
            Console.WriteLine();

            // Проверяем генерацию кода книги со случайным номером
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);
            string bookCode = LibraryFunctions.GenerateBookCode("fic", randomNumber);
            Console.WriteLine("Сгенерированный код книги: " + bookCode);

            Console.ReadKey();
        }

        // Вспомогательный метод для красивого вывода списка в консоль
        static void PrintStaff(List<string> staff)
        {
            foreach (string person in staff)
            {
                Console.WriteLine("- " + person);
            }
        }
    }
}
