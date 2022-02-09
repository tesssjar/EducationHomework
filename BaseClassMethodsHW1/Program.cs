using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using FileWork;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            List<TextFiles> textFiles = new List<TextFiles>();
            List<Pictures> pictures = new List<Pictures>();
            List<Movies> movies = new List<Movies>();

            List<string> source = new List<string>();
            

            Console.WriteLine("Enter a string:");
            
            string str = Console.ReadLine();

            do
            {
                source.Add(str);
                str = Console.ReadLine();
            } while (str.Length != 0);

            foreach (var varstring in source)
            {
                FileConstruct.FileConstructor(varstring, textFiles, pictures, movies);
            }

            Console.WriteLine("Text files:");
            TextFiles.SortFiles(textFiles);

            foreach (var file in textFiles) 
            {
                Console.WriteLine($"        {file.Name}");
                Console.WriteLine($"                Extention: {file.Extension}");
                Console.WriteLine($"                Size: {file.SizeStringed}");
                Console.WriteLine($"                Content: ''{file.Content}''");
            }

            Console.WriteLine("Movies:");
            Movies.SortFiles(movies);

            foreach (var file in movies)
            {
                Console.WriteLine($"        {file.Name}");
                Console.WriteLine($"                Extention: {file.Extension}");
                Console.WriteLine($"                Size: {file.SizeStringed}");
                Console.WriteLine($"                Resolution: {file.Resolution}");
                Console.WriteLine($"                Length: {file.Length}");
            }

            Console.WriteLine("Images:");
            Pictures.SortFiles(pictures);

            foreach (var file in pictures)
            {
                Console.WriteLine($"        {file.Name}");
                Console.WriteLine($"                Extention: {file.Extension}");
                Console.WriteLine($"                Size: {file.SizeStringed}");
                Console.WriteLine($"                Resolution: {file.Resolution}");
            }
        }
    }
}