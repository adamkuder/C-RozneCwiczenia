using System;

namespace Delegaty
{
    /// <summary>
    /// Delegat odpowiada za zwrot danych, z metod klas. Przydatne w Programowaniu wielowatkowym.
    /// Nastepnie skócona wersja Delegatu poprzez wykorzystanie lambdy
    /// Na koniec delegaty wbudowane takie Func Action Predicate 
    /// </summary>
    class Program
    {
        #region Pierwsze Delegaty
        //    public delegate void SomeMethodDelegate();
        //    static void Main(string[] args)
        //    {
        //        SomeMethodDelegate someDelegate = SomeMethod;
        //        someDelegate.Invoke();

        //        SomeLongRunningData sm = new SomeLongRunningData();
        //        sm.SomeMethod(CallBackMethod);
        //        Console.ReadKey();
        //    }

        //    static void SomeMethod()
        //    {
        //        Console.WriteLine("The First Delegate it works");
        //    }

        //    static void CallBackMethod(int i)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        //class SomeLongRunningData
        //{
        //    public delegate void CallBack(int i);
        //    public void SomeMethod(CallBack obj) // przyjmujemy wskazujemy delegata jakie ma w danej chwili wartosci
        //    {
        //        for (int i = 0; i < 2500; i++) 
        //        {
        //            obj(i);
        //        }


        //        Console.ReadKey();
        //    }
        //}
        #endregion

        #region Skrocony delegat
        //delegate double CalculateAreaPointer(double r);

        //static void Main(string[] args)
        //{
        //    CalculateAreaPointer cpointer = r => Math.PI * r * r; //skrócona wersja użycia delegatu za pomocą lambdy: =>  oraz zawarta w nim metoda anonimowa
        //    double area = cpointer(20);
        //}
        #endregion

        #region Delegaty Wbudowane

        static void Main(string[] args)
        {
            Func<double, double> cpointer = r => Math.PI * r * r;// moze przyjmowac do 16 zmiennych i zwaraca zmienna, prosty jednolinijkowy delegat
            double area = cpointer(15);
            Console.WriteLine(area);

            Action<string> MyAction = somestring => Console.WriteLine(somestring); // moze przyjąć do 16 zmiennych i nie zwraca nic
            MyAction("Adam");

            Predicate<string> CheckIfStringIsLessThen7 = sometext => sometext.Length < 7; // zwraca tylko prawde i fausz
            Console.WriteLine(CheckIfStringIsLessThen7("seventico"));

        }

        #endregion
    }
}
