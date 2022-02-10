using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork
{
    public class FileConstruct 
    {
        public static void FileConstructor(string source, List<TextFiles> textFiles, List<Pictures> pictures, List<Movies> movies)
        { 
            string filetype;

            char symbol = '0';

            using (StringReader sr = new StringReader(source))
            {
                List<char> fileInfo = new List<char>();

                while (symbol != ':')
                {
                    symbol = (char)sr.Read();
                    fileInfo.Add(symbol);
                }

                filetype = String.Concat<char>(fileInfo);

                switch (filetype)
                {
                    case "Text:":

                        TextFiles file = new TextFiles();
                        file.DataType = filetype;

                        fileInfo.Clear();

                        while (symbol != '(')
                        {
                            symbol = (char)sr.Read();
                            fileInfo.Add(symbol);
                        }

                        fileInfo.Remove('(');

                        file.Name = String.Concat<char>(fileInfo);

                        fileInfo.Clear();

                        while (symbol != ')')
                        {
                            symbol = (char)sr.Read();
                            fileInfo.Add(symbol);
                        }

                        fileInfo.Remove(')');

                        file.SizeStringed = String.Concat<char>(fileInfo);

                        sr.Read();

                        file.Content = sr.ReadToEnd();

                        file.Size = SizeCounter(file.SizeStringed);

                        file.Extension = "txt";

                        textFiles.Add(file);

                        break;

                    case "Image:":

                        Pictures pic = new Pictures();
                        pic.DataType = filetype;

                        fileInfo.Clear();

                        while (symbol != '(')
                        {
                            symbol = (char)sr.Read();
                            fileInfo.Add(symbol);
                        }

                        fileInfo.Remove('(');

                        pic.Name = String.Concat<char>(fileInfo);

                        fileInfo.Clear();

                        while (symbol != ')')
                        {
                            symbol = (char)sr.Read();
                            fileInfo.Add(symbol);
                        }

                        fileInfo.Remove(')');

                        pic.SizeStringed = String.Concat<char>(fileInfo);

                        sr.Read();

                        pic.Resolution = sr.ReadToEnd();

                        pic.Size = SizeCounter(pic.SizeStringed);

                        pic.Extension = "bmp";

                        pictures.Add(pic);

                        break;

                    case "Movie:":

                        Movies mov = new Movies();
                        mov.DataType = filetype;

                        fileInfo.Clear();

                        while (symbol != '(')
                        {
                            symbol = (char)sr.Read();
                            fileInfo.Add(symbol);
                        }

                        fileInfo.Remove('(');

                        mov.Name = String.Concat<char>(fileInfo);

                        fileInfo.Clear();

                        while (symbol != ')')
                        {
                            symbol = (char)sr.Read();
                            fileInfo.Add(symbol);
                        }

                        fileInfo.Remove(')');

                        mov.SizeStringed = String.Concat<char>(fileInfo);

                        sr.Read();

                        fileInfo.Clear();

                        while (symbol != ';')
                        {
                            fileInfo.Add(symbol);
                            symbol = (char)sr.Read();
                        }

                        fileInfo.Remove(';');
                        fileInfo.Remove(';');
                        fileInfo.Remove(')');

                        mov.Resolution = String.Concat<char>(fileInfo);

                        mov.Length = sr.ReadToEnd();

                        mov.Size = SizeCounter(mov.SizeStringed);

                        mov.Extension = "mkv";

                        movies.Add(mov);

                        break;
                }
            }
        }

        public static int SizeCounter(string sizeStringed) 
        {
            using (StringReader sr = new StringReader(sizeStringed)) 
            {
                List<char> nums = new List<char>();
                char symbol = '0';
                while (Char.IsDigit(symbol)) 
                {
                    symbol = (char)sr.Read();
                    nums.Add(symbol);
                }

                nums.Remove(symbol);

                int num = int.Parse(String.Concat<char>(nums));

                string letters = symbol + sr.ReadToEnd();

                switch (letters) 
                {
                    case "B":
                        return num;

                    case "KB":
                        return num * 1024;

                    case "MB":
                        return num * (1024 * 1024);

                    case "GB":
                        return num * (1024 * 1024 * 1024);

                    case "TB":
                        return (num * 1024 * 1024 * 1024 * 1024);

                    default:
                        throw new Exception("Incorrect file size");
                }
            }
        }
    }

    public abstract class Files
    {
        public string DataType { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string SizeStringed { get; set; }
        public int Size { get; set; }
        
    }

    public class TextFiles : Files
    {
        public string Content { get; set; }

        public static void SortFiles(List<TextFiles> files)
        {
            var sortedFiles = from f in files
                              orderby f.Size
                              select f;
        }

    }

    public class Pictures : Files 
    {
        public string Resolution { get; set; }

        public static void SortFiles(List<Pictures> files)
        {
            var sortedFiles = from f in files
                              orderby f.Size
                              select f;
        }
    }

    public class Movies : Files 
    {
        public string Resolution { get; set; }
        public string Length { get; set; }


        public static void SortFiles(List<Movies> files)
        {
            var sortedFiles = from f in files
                              orderby f.Size
                              select f;
        }
    }
}
