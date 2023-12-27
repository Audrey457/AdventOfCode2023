using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day3
{
    public class TransformFile
    {
        private readonly string path;

        public TransformFile(string path)
        {
            this.path = path;
        }

        public char[][] ToTwoDimensionCharTab()
        {
            char[][] chars;
            int i = 0;
            using (var sr = new StreamReader(@path))
            {
                string file = sr.ReadToEnd();
                int size = file.ToCharArray().Where(c => c.Equals('\r')).Count();
                chars = new char[size+1][];
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!sr.EndOfStream)
                {
                    chars[i] = sr.ReadLine().ToCharArray();
                    i++;
                }
                sr.Close();
            }
            return chars;
        }

        public Dictionary<int, List<int>> ToIntDictionnary(int columnIdentifier)
        {
            Dictionary<int, List<int>> ints = new Dictionary<int, List<int>>();
            int i = 0;
            using (var sr = new StreamReader(@path))
            {
                int value;
                while (!sr.EndOfStream)
                {
                    ints[i] = new List<int>();
                    foreach (string element in sr.ReadLine().Split(':')[1].Split("|")[columnIdentifier].Split(' ')) {
                        if(Int32.TryParse(element, out value))
                        {
                            ints[i].Add(value);
                        }
                    }
                    i++;
                }
                sr.Close();
            }

            return ints;
        }
    }
}
