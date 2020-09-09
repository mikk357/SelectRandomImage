using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace SelectRandomImage
{
    class Program
    {
        private  static string[] extentions = {
            ".jpg", ".jpeg", ".png"
        };
        static void Main(string[] args)
        {
            string[] files;
            GetFiles(out files);

            if (files.Length > 0) {
                Console.WriteLine($"[{files.Length} files]");
                string selected = SelectFile(ref files);
                DisplayPath(selected);
                DisplayImage(selected);
            } else {
                Console.WriteLine("not finded any images");
            }
        }
        private static void GetFiles(out string[] files) {
            string path = Directory.GetCurrentDirectory();
            files = Directory
                .EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(file => extentions.Contains(Path.GetExtension(file)))
                .ToArray();
        }

        private static string SelectFile(ref string[] files) {
            Random rnd = new Random();
            int index = rnd.Next(0, files.Length);
            return files[index];
        }

        private static void DisplayImage(string file) {
            using (Process proc = new Process()) {
                proc.StartInfo = new ProcessStartInfo() {
                    FileName = file,
                    UseShellExecute = true
                };
                proc.Start();
            }
        }

        private static void DisplayPath(string path) {
            string[] parts = path.Split(Path.DirectorySeparatorChar);
            int fin = parts.Length - 1;
            for (int i = 0; i < parts.Length; i++) {
                Console.WriteLine(
                    "{0}{1}{2}",
                    new string(' ', 2 * i),
                    parts[i],
                    (i != fin) ? @"\" : ""
                );
            }
        }
    }
}
