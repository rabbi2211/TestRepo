using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingPro
{
    

    public class MyThread
    { 



        IList<string> test = new List<string>();
        public int count;
        // public string ThreadName;
        public Thread thread;
        public MyThread(string Name,int num)
        {
            count = 0;
            thread = new Thread(this.Run);
            thread.Name = Name;
            thread.Start(num);
            thread.Priority = ThreadPriority.Normal;


        }
        public void Run(Object num)
        {
            Console.WriteLine("Thread Startring.." + thread.Name);
            do
            {
                Thread.Sleep(5000);
                Console.WriteLine("In " + thread.Name + ".. Count:" + count);
                count++;

            } while (count < (int)num);
            Console.WriteLine("Thread:" + thread.Name + " is Terminating..");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Starting..");
            MyThread thrd1 = new MyThread("ChildThread_1",5);
            MyThread thrd2 = new MyThread("ChildThread_2",6);
            MyThread thrd3 = new MyThread("ChildThread_3",1);

            Console.WriteLine(thrd1.thread.Name + "  is to Joine..");
            thrd1.thread.Join();
            Console.WriteLine(thrd1.thread.Name+" Joined..");

            Console.WriteLine(thrd2.thread.Name + "  is to Joine..");
            thrd2.thread.Join();
            Console.WriteLine(thrd2.thread.Name + " Joined..");


            Console.WriteLine(thrd3.thread.Name + "  is to Joine..");
            thrd3.thread.Join();
            Console.WriteLine(thrd3.thread.Name + " Joined..");

            Console.WriteLine("Main thread Joined...");

            Console.ReadKey();
        }
    }
}

