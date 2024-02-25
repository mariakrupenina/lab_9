using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ChessboardCell
    {
        private int horizontal; //закрытые атрибуты
        private int vertical;

        public static int count = 0;

        //свойства атрибутов
        public int Horizontal
        {
            get => horizontal; //return
            set
            {
                try
                {
                    if (value < 1 || value > 8)
                        throw new ArgumentException("Координата клетки по горизонтали должна быть от 1 до 8");
                    else
                        horizontal = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    horizontal = 1;
                }
            }
        }

        public int Vertical//название метода. Метод, который задаёт свойство атрибута
        {
            get => vertical; //return
            set
            {
                try
                {
                    if (value < 1 || value > 8)
                        throw new ArgumentException("Координата клетки по вертикали должна быть от 1 до 8");
                    else
                        vertical = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    vertical = 1;
                }
            }
        }

        public ChessboardCell() //конструктор без параметра
        {
            this.horizontal = 1;//ссылаемся на текущий экземпляр класса(private int horizontal)
            this.vertical = 1;
            count++;
        }

        public ChessboardCell(int horizontal, int vertical) //конструктор с параметром
        {
            try
            {
                if (horizontal < 1 || horizontal > 8 || vertical < 1 || vertical > 8)
                    throw new ArgumentException("Координаты клетки должнs быть от 1 до 8");
                else
                {
                    this.horizontal = horizontal;
                    this.vertical = vertical;
                }
                count++;
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                this.horizontal = 1;
                this.vertical = 1;
                count++;
            }
        }

        public ChessboardCell(ChessboardCell cell) //конструктор копирования
        {
            this.horizontal = cell.Horizontal; //в новую контекстную координату горизонтали присваивается через гет значение другой клетки(ту, у которой копируем)
            this.vertical = cell.Vertical;
            count++;
        }

        public static int Count => count;  //=get{ return count; }

        public void Show()
        {
            Console.WriteLine($"горизонтальная: {Horizontal} вертикальная: {Vertical}");
        }

        public static bool SameColor(ChessboardCell cell1, ChessboardCell cell2) //статическая функция(вызывается через имя класса, не имеет доступа напрямую к атрибутам)
        {
            return (cell1.Horizontal + cell1.Vertical) % 2 == (cell2.horizontal + cell2.vertical) % 2;
        }

        public bool SameColor(ChessboardCell cell) //метод класса(есть доступ к закрытым атрибутам, достаточно просто обращаться к объекту)
        {
            return (this.horizontal + this.vertical) % 2 == (cell.horizontal + cell.vertical) % 2;
        }



        //ЧАСТЬ 2
        //унарные операции
        public static ChessboardCell operator ++(ChessboardCell cell) //Унарная операция: ++ увеличение обеих координат клетки на 1;
        {
            cell.Horizontal++;
            cell.Vertical++;
            return cell;
        }
        public static ChessboardCell operator !(ChessboardCell cell)//смена координат
        {
            if (cell.Horizontal + cell.Vertical != 9)
            {
                int temp = cell.Horizontal;
                cell.Horizontal = cell.Vertical;
                cell.Vertical = temp;
            }
            return cell;
        }

        //операции приведения
        public static explicit operator int(ChessboardCell cell)//типа: int (явная) – результатом является сумма координат клетки шахматной доски;
        {
            return cell.Horizontal + cell.Vertical;
        }

        public static implicit operator string(ChessboardCell cell)//string (неявная) – результатом является цвет клетки на шахматной доске («чёрная» или «белая»)
        {
            if ((int)cell % 2 == 0)
                return "чёрная";
            return "белая";
        }

        //бинарные операции
        public static bool operator ==(ChessboardCell cc1, ChessboardCell cc2)
        {
            return Math.Abs(cc1.horizontal - cc2.horizontal) == 1 && Math.Abs(cc1.vertical - cc2.vertical) == 2 ||
            Math.Abs(cc1.horizontal - cc2.horizontal) == 2 && Math.Abs(cc1.vertical - cc2.vertical) == 1;
        }

        public static bool operator !=(ChessboardCell cc1, ChessboardCell cc2)
        {
            return cc1.Vertical != cc2.Vertical;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((ChessboardCell)obj).Horizontal == Horizontal && ((ChessboardCell)obj).Vertical == Vertical;
        }
    }
}