using System;
using System.Threading;
//Ctrl + K + E - відсортує
//Ctrl + E - видалить лишні підключення

namespace Lesson_4
{
    class Program
    {
        class Point3D
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public override string ToString()
            {
                return $"({X}; {Y}; {Z})";
            }

            public static explicit operator Point(Point3D p)
            {
                return new Point(p.X, p.Y);
            }

            public static explicit operator double(Point3D p)
            {
                return Math.Sqrt((p.X + p.Y + p.Z));
            }
        }
        class Point
        {
            /*public class Point3D // - можна й так
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public override string ToString()
            {
                return $"({X}; {Y}; {Z})";
            }
        }*/

            #region Properties
            public int X { get; set; }
            public int Y { get; set; }
            #endregion

            public Point()
            {
                X = Y = 0;
            }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}; {Y})";
            }

            #region Unary operator
            public static Point operator -(Point p)
            {
                return new Point(-p.X, -p.Y);
            }

            public static Point operator ++(Point p)
            {
                p.X++;
                p.Y++;
                return p;
            }
            #endregion

            #region Binary
            public static Point operator +(Point p1, Point p2)
            {
                return new Point(p1.X + p2.X, p1.Y + p2.Y);
            }

            public static Point operator -(Point p1, Point p2)
            {
                return new Point(p1.X - p2.X, p1.Y - p2.Y);
            }

            public static Point operator *(Point p1, int num)
            {
                return new Point(p1.X * num, p1.Y * num);
            }

            public static Point operator *(int num, Point p1)
            {
                return p1 * num;
            }

            #endregion

            #region Logic operator
            public static bool operator <(Point p1, Point p2)
            {
                return p1.X < p2.X && p1.Y < p1.Y;
            }

            public static bool operator >(Point p1, Point p2)
            {
                return p1.X > p2.X && p1.Y > p1.Y;
            }

            //public bool Equals(Point p) // -- Object.Equals(p1, p2);

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is Point)) // перевірка приведення до типу, чи все ок
                    return false;
                else
                    return (this.X == ((Point)obj).X && this.Y == (obj as Point).Y);

                //if (this.X == ((Point)obj).X && this.Y == (obj as Point).Y) //as - приведення до типу
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }

            public override int GetHashCode()
            {//x = 12 // y = 4  12 = 00001100 ^ 00000100 = 0   0  0  0  1 0 0 0
             //                                     128 64 32 16 8 4 2 1
                return X ^ Y;
            }

            public static bool operator ==(Point p1, Point p2)
            {
                //return p1.X == p2.X && p1.Y == p1.Y; //- v1
                if (ReferenceEquals(p1, p2))
                    return true;
                return p1.Equals(p2);
            }

            public static bool operator !=(Point p1, Point p2)
            {
                //return p1.X != p2.X && p1.Y != p1.Y;  // - v1
                return !(p1 == p2);
            }

            public static bool operator true(Point p)
            {
                return p.X != 0 || p.Y != 0;
            }

            public static bool operator false(Point p)
            {
                return p.X == 0 && p.Y == 0;
            }

            public static Point operator &(Point p1, Point p2)
            {
                if (p1.X != 0 && p2.X != 0 && p1.Y != 0 && p2.Y != 0)
                {
                    return p2;
                }
                else
                {
                    return new Point();
                }
            }

            public static Point operator |(Point p1, Point p2)
            {
                if (p1.X != 0 || p2.X != 0 || p1.Y != 0 || p2.Y != 0)
                {
                    return p2;
                }
                else
                {
                    return new Point();
                }
            }

            #endregion

            //public static implicit\explicit operator бaжаний тип (вихфдний тип)
            //implicit - неявне
            //emplicit - явне


            public static implicit operator Point3D(Point p)
            {
                return new Point3D { X = p.X, Y = p.Y, Z = 0 };
            }

            public static implicit operator int(Point p)
            {
                return p.X + p.Y;
            }

            // Do Not override:
            // . ?: new = 
            //(+=, -=, /=) - auto override
            //typeof as is
            // && || 

            //We can override:
            //logic ( < > )( == != ) - логічні перенавантажуюються парою
            // true / false - критерії істиності вашого обєкту if(point == true) or if(point || point2)
            // | &

            public static Point operator --(Point p)
            {
                p.X--;
                p.Y--;
                return p;
            }
        }
        static void Main(string[] args)
        {
            //public static type_resalt operator +( args ...)

            #region OperatorsIncAndMultiplate
            Point p1 = new Point(10, 5);
            Point p2 = -p1;
            Console.WriteLine("p1, {0}", p1);
            Console.WriteLine("p2, {0}", p2);


            Console.WriteLine("p1++, {0}", p1++);
            Console.WriteLine("p1, {0}", p1);
            Console.WriteLine("++p1, {0}", ++p1);
            Console.WriteLine("p1, {0}", p1);

            Console.WriteLine();

            Console.WriteLine("p1--, {0}", p1--);
            Console.WriteLine("p1, {0}", p1);
            Console.WriteLine("--p1, {0}", p1);
            Console.WriteLine("p1, {0}", p1);

            Console.WriteLine();

            Point p3 = new Point(5, 0);
            p2 = p1 + p3;
            Console.WriteLine($"{p1} + {p3} = {p2}");
            Console.WriteLine();
            Console.WriteLine($"{p2} * {10} = {p2 * 10}");

            p1 -= p3; //автоматично надається компілятором, після перегрузки - 
            Console.WriteLine("After p1 -= p3: p1 = {0}", p1); //(6,6)
            p1 *= 2;
            Console.WriteLine();
            Console.WriteLine($"{5} * {p1} = {5 * p1}");
            #endregion

            Console.Clear();

            #region OperatorEquels
            Point p4 = p1;
            Point p5 = new Point(12, 12);
            Console.WriteLine("p1 {0}", p1);
            Console.WriteLine("p2 {0}", p2);
            Console.WriteLine("p3 {0}", p3);
            Console.WriteLine("p4 {0}", p4);
            Console.WriteLine("p5 {0}", p5);

            Console.WriteLine($"ReferenceEquals(p1,p2) = {ReferenceEquals(p1, p2)}");
            Console.WriteLine($"Equals(p1,p2) = {Equals(p1, p2)}");
            Console.WriteLine();
            Console.WriteLine($"ReferenceEquals(p1,p4) = {ReferenceEquals(p1, p4)}");
            Console.WriteLine($"Equals(p1,p4) = {Equals(p1, p4)}");
            Console.WriteLine($"Equals: { p1.Equals(p4)}");
            Console.WriteLine($"Equals: { p1.Equals(p5)}");

            Dog d = new Dog();
            Point test = null;
            Console.WriteLine($"Equals: { p1.Equals(d)}");
            Console.WriteLine($"Equals: { p1.Equals(test)}");

            if (p1 == p5)
            {
                Console.WriteLine("Points are equals");
            }
            else
            {
                Console.WriteLine("Points are not equals");
            }

            Console.WriteLine();

            p5 = new Point(5, 0);

            if (p5 && p1)
            {
                Console.Write(p5-- + "  ");
                Thread.Sleep(50);
            }
            Console.WriteLine();
            #endregion

            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

            #region PointToPoint3D
            Point3D p3d1 = p5;

            Console.WriteLine("p3d1: " + p3d1);

            #endregion

            #region Point3DToPoint
            Point3D p3d2 = new Point3D() { X = 1, Y = 2, Z = 3 };
            p5 = (Point)p3d2;
            Console.WriteLine("p3d2: " + p3d2);
            Console.WriteLine("p5: " + p5);
            #endregion

            #region ToInt
            int res = (int)p5;
            Console.WriteLine("Res = {0}", res);
            #endregion

            #region Point3DToDouble
            Point3D testDouble = new Point3D() { X = 4, Y = 8, Z = 4 };
            double rezalt = (double)testDouble;
            Console.WriteLine();
            Console.WriteLine("Resalt: " + rezalt);
            #endregion

        }

        class Dog
        {

        }
    }
}
