using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp2;
using System.Security.Policy;
namespace UnitTestLab9_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod0()//констурктор без параметра
        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 1); //ожидаемо
            //Act
            ChessboardCell cell2 = new ChessboardCell(); //собираемся проверять
            //Assert
            Assert.AreEqual(cell1.Horizontal, cell2.Horizontal); //сравнение
            Assert.AreEqual(cell1.Vertical, cell2.Vertical);

        }
        [TestMethod]
        public void TestMethod1()//конструктор с параметром
        {
            //Arrange
            ChessboardCell expected = new ChessboardCell(2, 2); //ожидаемо
            //Act
            int vertical = 2;
            int horizontal = 2;
            ChessboardCell actual = new ChessboardCell(horizontal, vertical); //собираемся проверять
            //Assert
            Assert.AreEqual(expected.Horizontal, actual.Horizontal); //сравнение
            Assert.AreEqual(expected.Vertical, actual.Vertical);
        }

        [TestMethod]
        public void TestMethod2()//констурктор копирования
        {
            //Arrange
            ChessboardCell cell = new ChessboardCell(1, 2); //ожидаемо
            //Act
            ChessboardCell cellCopy = new ChessboardCell(cell); //собираемся проверять
            //Assert
            Assert.AreEqual(cell.Horizontal, cellCopy.Horizontal); //сравнение
            Assert.AreEqual(cell.Vertical, cellCopy.Vertical);

        }

        [TestMethod]
        public void TestMethod3()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 2); //ожидаемо
            ChessboardCell cell2 = new ChessboardCell(2, 5);
            //Act
            bool sameColorStaticCopy = ChessboardCell.SameColor(cell1, cell2); //собираемся проверять
            //Assert
            Assert.AreEqual(sameColorStaticCopy, true); //сравнение
        }

        [TestMethod]
        public void TestMethod4()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 2); //ожидаемо
            ChessboardCell cell2 = cell1++;
            //Act
            ChessboardCell cellTest = new ChessboardCell(2, 3); //собираемся проверять
            //Assert
            Assert.AreEqual(cell2.Horizontal, cellTest.Horizontal); //сравнение
            Assert.AreEqual(cell2.Vertical, cellTest.Vertical);
        }

        [TestMethod]
        public void TestMethod5()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 2); //ожидаемо
            ChessboardCell cell2 = !cell1;
            //Act
            ChessboardCell cellTest = new ChessboardCell(2, 1); //собираемся проверять
            //Assert
            Assert.AreEqual(cell2.Horizontal, cellTest.Horizontal); //сравнение
            Assert.AreEqual(cell2.Vertical, cellTest.Vertical);
        }

        [TestMethod]
        public void TestMethod6()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 2); //ожидаемо
            int n = (int)cell1;
            //Assert
            Assert.AreEqual(n, 3); //сравнение
        }

        [TestMethod]
        public void TestMethod7()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(8, 1); //ожидаемо
            string str = "белая";
            //Assert
            Assert.AreEqual(str, (cell1)); //сравнение
        }

        [TestMethod]
        public void TestMethod8()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 2); //ожидаемо
            ChessboardCell cell2 = new ChessboardCell(2, 4);
            //Act
            bool i = cell1 == cell2; //собираемся проверять
                                     //Assert
            Assert.AreEqual(i, true); //сравнение
        }

        [TestMethod]
        public void TestMethod9()

        {
            //Arrange
            ChessboardCell cell1 = new ChessboardCell(1, 2); //ожидаемо
            ChessboardCell cell2 = new ChessboardCell(2, 4);
            //Act
            bool i = cell1 != cell2; //собираемся проверять
                                     //Assert
            Assert.AreEqual(i, true); //сравнение
        }



        //Для части 3
        [TestMethod]
        public void TestEmptyArray()
        {
            // Arrange
            ChessboardCellArray array = new ChessboardCellArray();
            //Act
            int length = array.Length;
            // Assert
            Assert.AreEqual(0, length);
        }

        [TestMethod]
        public void TestInputArray()
        {
            //Arrange
            int size = 1;
            int vertical = 2;
            int horizontal = 2;
            ChessboardCell[] cells = new ChessboardCell[size];
            cells[0] = new ChessboardCell(horizontal, vertical);
            ChessboardCellArray array = new ChessboardCellArray(cells);
            //Assert
            //Assert.AreEqual(size, array.Length);
            Assert.AreEqual(horizontal, array[0].Horizontal);
            Assert.AreEqual(vertical, array[0].Vertical);
        }

        [TestMethod]
        public void TestCopyArray()
        {
            //Arrange
            int size = 1;
            int vertical = 2;
            int horizontal = 2;
            ChessboardCell[] cells = new ChessboardCell[size];
            cells[0] = new ChessboardCell(horizontal, vertical);
            ChessboardCellArray array = new ChessboardCellArray(cells);
            //Act
            ChessboardCellArray copy = new ChessboardCellArray(array);
            bool result = copy.Equals(array);
            //Assert
            Assert.AreEqual(1, array.Length); // проверка длины нового массива  
        }

        [TestMethod]
        public void SetValidIndexTest()
        {
            //Arrange
            int size = 1;
            ChessboardCell[] cells = new ChessboardCell[size];
            ChessboardCellArray array = new ChessboardCellArray(cells);
            //Act
            array[0] = new ChessboardCell(1, 8);
            //Assert
            Assert.AreEqual(1, array[0].Horizontal);
            Assert.AreEqual(8, array[0].Vertical);
        }

        [TestMethod]
        public void SetInvalidIndexTest()
        {
            //Arrange
            int size = 1;
            int vertical = 2;
            int horizontal = 2;
            ChessboardCell[] cells = new ChessboardCell[size];
            cells[0] = new ChessboardCell(vertical, horizontal);
            ChessboardCellArray array = new ChessboardCellArray(cells);
            //Act
            ChessboardCell cell = array[0];
            //Assert
            Assert.AreEqual(horizontal, cell.Horizontal);
            Assert.AreEqual(vertical, cell.Vertical);
        }

        [TestMethod]
        public void ReturnLengthTest()
        {
            //Arrange
            int size = 6;
            ChessboardCell[] cells = new ChessboardCell[size];
            ChessboardCellArray array = new ChessboardCellArray(cells);
            //Act
            int length = array.ArrayLength();
            //Assert
            Assert.AreEqual(size, length);
        }

        [TestMethod]
        public void TestGet1()
        {
            //Arrange
            ChessboardCellArray cells = new ChessboardCellArray(5);
            //Asseert
            Assert.ThrowsException<Exception>(() => { new ChessboardCell(cells[10]); });
        }

        [TestMethod]
        public void SetInvalidIndexTest1()
        {
            //Arrange
            Random random = new Random();
            int length = 2;
            ChessboardCellArray array = new ChessboardCellArray(length, random);
            //Assert
            Assert.ThrowsException<Exception>(() => { new ChessboardCell(array[-1]); });

        }



    }
}
