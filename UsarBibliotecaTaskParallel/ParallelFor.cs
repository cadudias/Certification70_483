using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsarBibliotecaTaskParallel
{
    public class ParallelForExample
    {
        public static void GetFilesTotalSizeFromDirectory()
        {
            long totalSize = 0;
            String[] files = Directory.GetFiles("c:\\windows\\");
            
            Parallel.For(0, files.Length,
                index =>
                {
                    FileInfo fi = new FileInfo(files[index]);
                    long size = fi.Length;
                    //chama o Interlocked.Add para que a adição seja realizada como uma operação atômica (deve ser executada completamente em caso de sucesso, ou ser abortada completamente em caso de erro).
                    //Caso contrário, várias tarefas podem tentar atualizar a variável totalSize simultaneamente.
                    Interlocked.Add(ref totalSize, size);
                });

            Console.WriteLine("Directory '{0}':", "c:\\windows\\");
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
            Console.ReadLine();
        }
        
    }
}
