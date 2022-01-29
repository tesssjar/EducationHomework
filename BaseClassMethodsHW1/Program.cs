using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace DelegatesGenerics
{
    delegate void Message<T>(T item);

    delegate T Magic<T>(T item1, T item2);
    
    public class Person<T>
    {
        public T id { get; set; }
        public string Name { get; set; }

        private Action<T> NewDelegate;

        public Person(T id, string name, Action<T> paramDelegate)
        {
            this.id = id;
            this.Name = name;
            this.NewDelegate = paramDelegate;
        }

        public void Execute(T item)
        {
            NewDelegate.Invoke(item);
        }
    }

    public class DelegatesGenerics
    {
        public void Main()
        {
            Message<string> mes;

            Magic<string> fullname;

            void SayHello(string name)
            {
                Console.WriteLine($"Hi, {name}");
            }

            string FullName(string name, string surname)
            {
                return $"({name} {surname})";
            }
            
            mes = SayHello;

            fullname = FullName;

            Magic<int> count = (int x, int y) => { return (x + y) / ((x + y) / 2); };
            
            public static IEnumerable<int> values = Enumerable.Range(2, 8);

            static IEnumerable<TOut> CollectionMethod<TOut>(Func<int, TOut> finder, Func<int, TOut> selector)
            {
                List<TOut> result = new List<TOut>();
                foreach (var number in values)
                {
                    result.Add(selector(number));
                }

                foreach (var number in values)
                {
                    result.Add(finder(number));
                }

                return result;
            }
        }
    }
}