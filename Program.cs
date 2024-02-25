using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //ЧАСТЬ 1
            Console.WriteLine("               ЧАСТЬ 1               ");

            Console.WriteLine("          БЕЗ ПАРАМЕТРА               ");

            ChessboardCell cell1 = new ChessboardCell(); // без параметра
            cell1.Horizontal = 4;//через свойства задаём значения
            cell1.Vertical = 5;
            Console.WriteLine("Клетка 1:");
            cell1.Show();

            Console.WriteLine("          С ПАРАМЕТРОМ               ");
            ChessboardCell cell2 = new ChessboardCell(4, 5); //с параметром
            Console.WriteLine("Клетка 2:");
            cell2.Show();

            Console.WriteLine("          КОНСТРУКТОР КОПИРОВАНИЯ              ");
            ChessboardCell cellCopy = new ChessboardCell(cell1); //конструктор копирования 
            Console.WriteLine("Скопированная клетка:");
            cellCopy.Show();

            Console.WriteLine("\nВыполнение задания: сравнение клетки 1 и скопированной клетки");
            bool sameColorStaticCopy = ChessboardCell.SameColor(cell1, cellCopy); //статический метод(сначала указываем класс, потом саму функцию и затем какие она требует параметры)
            Console.WriteLine("Являются ли они одного цвета (используя статический метод)? " + sameColorStaticCopy);

            bool sameColorCopy = cellCopy.SameColor(cell1);//нестатический(метод класса имеет доступ к полям -> обращаемся к полю класса)
            Console.WriteLine("Являются ли они одного цвета (используя нестатический метод)? " + sameColorCopy);

            Console.WriteLine($" \n Всего создано {ChessboardCell.Count} объектов \n");

            //ЧАСТЬ 2
            Console.WriteLine("               ЧАСТЬ 2               ");
            ChessboardCell cell3 = new ChessboardCell(8, 1);
            Console.Write("Клетка с коордиатами: ");
            cell3.Show();
            Console.Write("Координаты после применения унарной операции (++): ");
            cell3++;
            cell3.Show();

            ChessboardCell cell4 = new ChessboardCell(8, 3);
            Console.Write("Клетка с коордиатами: ");
            cell4.Show();
            Console.Write("Координаты после применения унарной операции (!): ");
            _ = !cell4;
            cell4.Show();

            Console.Write("Сумма координат: ");
            Console.WriteLine((int)cell4); //явная операция приведения
            Console.Write("Цвет клетки на шахматной доске: ");
            Console.WriteLine(cell4); //неявная операция приведения

            Console.Write("Клетка 5 с коордиатами: ");
            ChessboardCell cell5 = new ChessboardCell(6, 5);
            cell5.Show();
            Console.Write("Клетка 6 с коордиатами: ");
            ChessboardCell cell6 = new ChessboardCell(6, 5);
            cell6.Show();
            Console.WriteLine("Возможен ли ход коня из клетки 5 в клетку 6?");
            Console.WriteLine(cell5 == cell6);
            Console.WriteLine("Клетки 5 и 6 находятся на разных вертикалях?");
            Console.WriteLine(cell5 != cell6);

            Console.WriteLine("Клетка 5 и 6 одна и так же");
            Console.WriteLine(cell5.Equals(cell6)); //cell5 - текущий объект



            //ЧАСТЬ 3
            Console.WriteLine("               ЧАСТЬ 3               ");
            //Создание массива при помощи клавиатуры
            Console.WriteLine("Введите желаемое количество объектов массива: ");
            bool isCorrect;
            int size;
            do
            {
                string input = Console.ReadLine();
                isCorrect = int.TryParse(input, out size);
                if (!isCorrect)
                    Console.WriteLine("Неверно задано число");
            } while (!isCorrect);

            ChessboardCell[] array = new ChessboardCell[size];

            for (int i = 0; i < size; i++)
            {
                int horizontal;
                Console.WriteLine("Введите координату горизонтальной клетки");
                do
                {
                    string input = Console.ReadLine();
                    isCorrect = int.TryParse(input, out horizontal);
                    if (!isCorrect)
                        Console.WriteLine("Неверно задано число");
                } while (!isCorrect);
                int vertical;
                Console.WriteLine("Введите координату вертикальной клетки");
                do
                {
                    string input = Console.ReadLine();
                    isCorrect = int.TryParse(input, out vertical);
                    if (!isCorrect)
                        Console.WriteLine("Неверно задано число");
                } while (!isCorrect);
                array[i] = new ChessboardCell(horizontal, vertical);
            }

            ChessboardCellArray arr1 = new ChessboardCellArray(array);
            //arr1.ShowArray();

            //Создание массива через рандомное заполнение
            Random random = new Random();
            Console.WriteLine("Введите желаемое количество объектов массива: ");
            do
            {
                string input = Console.ReadLine();
                isCorrect = int.TryParse(input, out size);
                if (!isCorrect)
                    Console.WriteLine("Неверно задано число");
            } while (!isCorrect);

            ChessboardCellArray arr2 = new ChessboardCellArray(size, random);
            Console.WriteLine("Рандомный массив:");
            arr2.ShowArray();

            //Создание пустого массива
            ChessboardCellArray arr3 = new ChessboardCellArray();
            arr3.ShowArray();

            // Глубокое копирование
            ChessboardCellArray arr4 = new ChessboardCellArray(arr2);
            Console.WriteLine("\nСкопированный с arr2 массив:");
            arr4.ShowArray();



            Console.WriteLine("Запись объекта в несущ. индекс массива arr4");
            arr4[-1] = new ChessboardCell(6, 6);
            arr4.ShowArray();

            Console.WriteLine("Получение объекта с несущ. индексом массива arr4");
            ChessboardCell cell7 = arr4[-1];
            cell7.Show();

            Console.WriteLine("Нахождение ближайшей клетки к началу координат");
            FindMin(arr2);

            Console.WriteLine($" \n Всего создано {ChessboardCellArray.ArrayCount} объектов \n");
            Console.WriteLine($" \n Всего создано {ChessboardCellArray.ObjectsCount} объектов \n");
        }

        static void FindMin(ChessboardCellArray arr)
        {
            int minValue = int.MaxValue;
            ChessboardCell minCell = new ChessboardCell();
            int size = arr.ArrayLength();
            for (int i = 0; i < size; i++)
            {
                if ((int)arr[i] < minValue)
                {
                    minValue = (int)arr[i];
                    minCell = arr[i];
                }
            }
            minCell.Show();
        }

    }
}
