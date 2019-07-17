using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFields
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country();
            Cultures cltr = new Cultures();
            
            int key;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Создать \n2. Изменить\n3. Удалить \n4. Операции с полем \n5. Поиск ");
                Console.SetCursorPosition(50, 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(country.GetName());
                Console.SetCursorPosition(50, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(country.GetCountryInfo());
                Console.SetCursorPosition(50, 3);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Культуры выращиваемые в стране: ");
                for (int i = 0; i < country.GetCltSize(); i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(60, 5 + i + i);
                    Console.WriteLine(country.GetCultures(i).GetTypeCulture());
                }
                Console.ResetColor();
                Console.SetCursorPosition(0, 6);
                if (int.TryParse(Console.ReadLine(), out key))
                {
                    switch (key)
                    {
                        case 1:
                            {
                                int value;
                                Console.WriteLine("1. Создать страну \n2. Создать поле");
                                if (int.TryParse(Console.ReadLine(), out value))
                                {
                                    switch (value)
                                    {
                                        case 1:
                                            {
                                                if(country.GetName() != null)
                                                {
                                                    Console.WriteLine("Ошибка, страна уже создана");
                                                }
                                                else
                                                {
                                                    string temp;
                                                    Console.WriteLine("Введите названия страны: ");
                                                    temp = Console.ReadLine();
                                                    country.SetName(temp);
                                                    Console.WriteLine("Введите информацию о вводимой стране: ");
                                                    temp = Console.ReadLine();
                                                    country.SetCountryInfo(temp);
                                                }                                               
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Введите количество культур выращиваемых в стране " + country.GetName());
                                                int cltSize = int.Parse(Console.ReadLine());
                                                country.SetCulturesCount(cltSize);
                                                country.SetCltSize(cltSize);
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {
                                                    Cultures tempory = new Cultures();
                                                    string temp;
                                                    Console.WriteLine("Введите название поля " + (i + 1) + " в стране " + country.GetName());
                                                    temp = Console.ReadLine();
                                                    tempory.SetTypeCulture(temp);
                                                    country.SetCultures(i, tempory);
                                                }
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка, неверная команда");
                                }
                                break;
                            }
                        case 2:
                            {
                                int value;
                                Console.WriteLine("1. Изменить данные о стране \n2. Изменить  размер поля \n3. Изменить название культур в поле");
                                if (int.TryParse(Console.ReadLine(), out value))
                                {
                                    switch (value)
                                    {
                                        case 1:
                                            {                                               
                                                    string temp;
                                                    Console.WriteLine("Введите новое название страны: ");
                                                    temp = Console.ReadLine();
                                                    country.SetName(temp);
                                                    Console.WriteLine("Введите информацию о вводимой стране: ");
                                                    temp = Console.ReadLine();
                                                    country.SetCountryInfo(temp);
                                                break;
                                            }
                                        case 2:
                                            { 
                                                Console.WriteLine("Введите новое количество культур выращиваемых в стране " + country.GetName());
                                                int newSize = int.Parse(Console.ReadLine());
                                                if (newSize > country.GetCltSize())
                                                {
                                                    country.SetCulturesCount(newSize);
                                                    for (int i = country.GetCltSize(); i < newSize; i++)
                                                    {
                                                        Cultures tempory = new Cultures();
                                                        string temp;
                                                        Console.Write("Введите название поля " + (i + 1) + " в стране " + country.GetName());
                                                        temp = Console.ReadLine();
                                                        tempory.SetTypeCulture(temp);
                                                        country.SetCultures(i, tempory);
                                                        country.SetCltSize(newSize);
                                                    }
                                                }
                                                else
                                                {
                                                    country.SetCltSize(newSize);
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Введите номер поля которое нужно изменить: ");
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {   
                                                    //для удобства пользователя я делаю + 1 чтобы индексация на экране была не с 0 а с 1
                                                    Console.WriteLine(i+1 + ". " + country.GetCultures(i).GetTypeCulture());
                                                }
                                                int count = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Введите новое название культуры выращиваемой в этом поле " + country.GetName());
                                                string temp = Console.ReadLine();
                                                Cultures tempory = new Cultures();
                                                tempory.SetTypeCulture(temp);
                                                //тут аналогично тому что выше, делаю -1 так как принял индекс +1
                                                country.SetCultures(count-1, tempory);
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка, неверная команда");
                                }
                                break;
                            }
                        case 3:
                            {
                                int value;
                                Console.WriteLine("1. Удалить поле \n2. Удалить растение с поля ");
                                if (int.TryParse(Console.ReadLine(), out value))
                                {
                                    switch (value)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Введите номер поля которое нужно удалить: ");
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {
                                                    //для удобства пользователя я делаю + 1 чтобы индексация на экране была не с 0 а с 1
                                                    Console.WriteLine(i + ". " + country.GetCultures(i).GetTypeCulture());                                                    
                                                }
                                                int index = int.Parse(Console.ReadLine());
                                                country.Remvove(country.GetCultures(index));
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Введите номер поля в котором нужно удалить растение: ");
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {
                                                    Console.WriteLine(i + ". " + country.GetCultures(i).GetTypeCulture());
                                                }
                                                int index = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < country.GetCultures(index).GetPlntSize(); i++)
                                                {
                                                    Console.WriteLine(i + ". " + country.GetCultures(index).GetPlant(i).GetNamePlant());
                                                }
                                                Console.WriteLine("Введите номер растения которое нужно удалить");
                                                int deleteItem = int.Parse(Console.ReadLine());
                                                country.GetCultures(index).Remvove(country.GetCultures(index).GetPlant(deleteItem));
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка, неверная команда");
                                }
                                break;
                            }
                        case 4:
                            {
                                int value;
                                Console.WriteLine("1. Добавить растения в поле \n2. Просмотр растений которые выращиваются в поле \n3. Просмотр плана полива");
                                if (int.TryParse(Console.ReadLine(), out value))
                                {
                                    switch (value)
                                    {
                                        case 1:
                                            {
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {
                                                    Console.WriteLine(i + ". " + country.GetCultures(i).GetTypeCulture());
                                                }
                                                Console.WriteLine("Введите номер поля куда добавляется растение: ");
                                                int count = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Введите количество добавляемых растений");
                                                int plantSize = int.Parse(Console.ReadLine());
                                                country.GetCultures(count).SetPlantsCount(plantSize);
                                                country.GetCultures(count).SetPlntSize(plantSize);
                                                for(int i = 0; i < country.GetCultures(count).GetPlntSize(); i++)
                                                {
                                                    Plant tempory = new Plant();
                                                    string temp;
                                                    Console.WriteLine("Введите название " + (i+1) + " растения которое будет посажено");
                                                    temp = Console.ReadLine();
                                                    tempory.SetNamePlant(temp);
                                                    country.GetCultures(count).SetPlnt(i, tempory);                                                  
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {
                                                    Console.WriteLine(i + ". " + country.GetCultures(i).GetTypeCulture());
                                                }
                                                Console.WriteLine("Введите номер поля для просмотра: ");
                                                int count = int.Parse(Console.ReadLine());
                                                Console.WriteLine("На поле " + country.GetCultures(count).GetTypeCulture() + " выращивают: ");
                                                for (int i = 0; i < country.GetCultures(count).GetPlntSize(); i++)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                    Console.WriteLine("\n" + country.GetCultures(count).GetPlant(i).GetNamePlant());
                                                }
                                                Console.ResetColor();
                                                    break;
                                            }
                                        case 3:
                                            {
                                                for (int i = 0; i < country.GetCltSize(); i++)
                                                {
                                                    Console.WriteLine(i + ". " + country.GetCultures(i).GetTypeCulture());
                                                }
                                                Console.WriteLine("Введите номер поля для просмотра палана полива: ");
                                                int count = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("Плановый полив поля " + country.GetCultures(count).GetTypeCulture()
                                                        + " каждый вторник с 09-00 до 12-30 по времени Астаны");
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка, неверная команда");
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Введите название растения для поиска");
                                string temp = Console.ReadLine();
                                for(int i = 0; i < country.GetCltSize(); i++)
                                {
                                    for (int j = 0; j < country.GetCultures(i).GetPlntSize(); j++)
                                    {
                                        if(country.GetCultures(i).GetPlant(j).GetNamePlant().Contains(temp))
                                        {
                                            Console.WriteLine("Искомое растение выращивается в поле " + country.GetCultures(i).GetTypeCulture());
                                        }
                                    }
                                }
                                break;
                            }
                        default:
                            Console.WriteLine("Введена неверная команда");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка, неверная команда!!!");
                }
                Console.ReadLine();
            } while (key != 0);
        }
    }
}
