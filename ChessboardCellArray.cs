using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ChessboardCellArray
    {
        private ChessboardCell[] array;
        private static int objectsCount;
        private static int arrayCount;

        public int Length
        {
            get => array.Length;
        }

        public ChessboardCellArray(int length)
        {
            array = new ChessboardCell[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = new ChessboardCell();
            }
        }
        

        public ChessboardCellArray()
        {
            array = new ChessboardCell[0];
            arrayCount++;
        }

        //Конструктор формирования массива (рандом)
        public ChessboardCellArray(int length, Random random)
        {
            array = new ChessboardCell[length];
            arrayCount++;

            for (int i = 0; i < length; i++)
            {
                array[i] = new ChessboardCell(random.Next(1,8), random.Next(1,8));
                objectsCount++;
            }
        }

        //Конструктор по формированию массива вручную
        public ChessboardCellArray(ChessboardCell[] source)
        {
            array = (ChessboardCell[])source.Clone();
            arrayCount++;
            objectsCount += array.Length;
        }

        //Конструктор глубокого копирования 
        public ChessboardCellArray(ChessboardCellArray source)
        {
            arrayCount++;
            this.array = new ChessboardCell[source.Length]; //создаём новый массив аналогичной длины
            for (int i = 0; i < source.Length; i++)
            {
                this.array[i] = new ChessboardCell(source.array[i]);
                objectsCount++;
            }
        }

        public void ShowArray()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст");;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"Координаты клетки {i + 1}: ");
                    array[i].Show();
                }
            }
        }   

        //Метод для реализации индексатора
        public ChessboardCell this[int index]
        {
            get
            {
               
                    if (index < 0 || index >= array.Length)
                    {
                        throw new Exception("Индекс выходит за пределы массива");
                    }

                    return array[index];
                
                
            }
            set
            {
              
                    if (index < 0 || index >= array.Length)
                    {
                        throw new ArgumentException("Индекс выходит за пределы массива");
                    }

                    array[index] = value;
                
            }
        }


        public static int ArrayCount
        {
            get { return arrayCount; }
        }

        public static int ObjectsCount
        {
            get { return objectsCount; }
        }

        public int ArrayLength()
        {
            return array.Length;
        }
    }
}
