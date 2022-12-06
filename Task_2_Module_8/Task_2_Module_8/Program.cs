namespace Task_2_Module_8
{
    internal class Program
    {
        static string dirName = @"C:\Users\user\Desktop\IT\OldDir";
        static void Main(string[] args)
        {
            long size = CheckSize(dirName);
            Console.WriteLine(size);
        }
        static long CheckSize(string dir)
        {
            long size = 0;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                FileInfo[] files = dirInfo.GetFiles();
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in files)
                    {
                        Console.WriteLine(file.FullName);
                        size = size + file.Length;
                    }

                    foreach (DirectoryInfo directoryInfo in dirs)
                    {
                        CheckSize(directoryInfo.FullName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return size;
        }
    }
}