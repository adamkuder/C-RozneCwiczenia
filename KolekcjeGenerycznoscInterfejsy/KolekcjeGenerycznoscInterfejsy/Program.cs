using System;
using System.Collections;
using System.Collections.Generic;

namespace KolekcjeGenerycznoscInterfejsy
{
    public interface ISpeakable //Duże I przed nazwa
    {
        void GiveVoice();
    }

    public class Human : ISpeakable
    {
        public string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }

        public void GiveVoice()
        {
            Console.WriteLine("Hej");
        }
    }
    public class Klasa<T1,T2,T3,T4> // przykładowe różne ograniczenia
        where T1 : struct
        where T3 : class
    {

    }
    class Program
    {
        //metoda Generyczna
        public static void Swap<TIn>(ref TIn a, ref TIn b)
            where TIn : struct //przykładowo ograniczamy go do wszystkich typów prostych, mozliwe jest dowolna ilosc interface ale wszystkie ograniczenia musza być spełnione
            // jeśli np where TIn : class, ISpeakable    to bedziemy mieli dostep to metody GiveVoice() 
        {
            TIn temp = b;
            b = a;
            a = temp;
        }
        static void Main(string[] args)
        {
            ISpeakable adam = new Human("Adam"); // konwencja instancje z małej litery
            ISpeakable hubert = new Human("Hubert"); 
            adam.GiveVoice();
            int a = 4;
            int b = 3;
            #region Generyczosc

            Console.WriteLine($"a: {a}, b: {b}");

            Swap(ref a, ref b);

            Console.WriteLine($"a: {a}, b: {b}");


            var klasa = new Klasa<int, char, string, double>();

            #endregion

            #region Kolekcje Nie Generyczne

            ArrayList arrayList = new ArrayList();
            arrayList.Add(1); // opakowanie int w obiekt
            arrayList.Add(0);
            arrayList.Add(2);
            arrayList.Add("Tekst");
            arrayList.Add(adam);

            foreach (var al in arrayList)
            {
                Console.WriteLine($"Elemnt: {al}");

            }

            //foreach (var al in arrayList)
            //{
            //    var @var = (int)al + 5; // musimy rzutować i niestety przy stringu juz nie daje rady
            //    Console.WriteLine(@var); // taka wada arraylisty
            //}


            SortedList sl = new SortedList(); // musi posiadać unikalne klucze
            sl.Add("Switf", "Suzuki");
            sl.Add("148", "Alfa Romeo");
            sl.Add("Uno", "Fiat");
            //sl.Add(adam, "nope"); // jesli stringi to stringi

            foreach (var elem in sl)
            {
                //Console.WriteLine($"Marki:{elem}"); // ten sposób nie działa
                var elem2 = (DictionaryEntry)elem;
                Console.WriteLine($"Marki:{elem2.Value}, Model: {elem2.Key}");
            }

            Stack st = new Stack(); // kolekcja LIFO last in first out
            st.Push("C#");
            st.Push("C++");
            st.Push("Java");
            st.Push("C");
            st.Push("PHP");

            foreach (var elem in st)
            {
                Console.WriteLine(elem);
            }
            // aby dostac sie do konkretnego elemntu np.3 
            st.Pop();
            st.Pop();
            var elem4 = (string)st.Pop();
            Console.WriteLine(elem4);

            Queue que = new Queue(); // FIFO first in first out

            que.Enqueue("Niemcy");
            que.Enqueue("Polska");
            que.Enqueue("Hiszpania");
            que.Enqueue("Francja");
            que.Enqueue("Wielka Brytania");

            foreach (var elem in que)
            {
                Console.WriteLine($"Kraje: {elem}");
            }
            // aby dostać się do konkretnego elemntu po koleii trzeba z rzucać
            var elem5 = (string)que.Dequeue();

            Console.WriteLine(elem5);
            #endregion

            #region Kolekcje Generyczne

            Queue<Human> KolejkaLudzi = new Queue<Human>();
            Queue ZwyklaKolejka = new Queue();

            var adam1 = new Human("Adam");
            var hubert1 = new Human("Hubert");
            KolejkaLudzi.Enqueue(adam1);
            KolejkaLudzi.Enqueue(hubert1);
            ZwyklaKolejka.Enqueue(adam1);
            ZwyklaKolejka.Enqueue(hubert1);

            foreach (var elem in ZwyklaKolejka)
            {
                Console.WriteLine(elem);// wyswietla krzaki
            }

            foreach (var elem in KolejkaLudzi)
            {
                Console.WriteLine(elem); // wyswietla elementy
            }

            var dict = new Dictionary<string, int>();

            dict.Add("A", 1);
            dict.Add("a", 2);
            dict.Add("B", 3);
            dict.Add("b", 4);

            var listaNazwisk = new List<string>
            {
                "Kowalski",
                "Nowak",
                "Wolodyjowski"
            };
            listaNazwisk.AddRange(new List<string>
            {
                "Gryc",
                "Góral"
            });

            listaNazwisk[listaNazwisk.Count - 1] = "Mroz";
            listaNazwisk.RemoveAt(3);
            foreach (var elem in listaNazwisk)
            {
                Console.WriteLine(elem);
            }


            var haszowanyZbior = new HashSet<String>();
            haszowanyZbior.Add("LG");
            haszowanyZbior.Add("Sony");
            haszowanyZbior.Add("Sony");// zdublowane wartosci sie nie dodaja
            haszowanyZbior.Add("Samsung");
            haszowanyZbior.Add("Lenovo");
            haszowanyZbior.Add("HP");

            
            foreach (var elem in haszowanyZbior)
            {
                Console.WriteLine(elem);
            }

            #endregion


        }
    }
}
