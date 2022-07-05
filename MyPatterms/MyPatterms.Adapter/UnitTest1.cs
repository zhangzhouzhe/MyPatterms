using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPatterms.Adapter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            ParalleTest();

        }


        public void ParalleTest()
        {
            var list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            var ops = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 10
            };
            Parallel.ForEach(list, ops, (i) =>
            {
                Console.WriteLine($"任务Id:{i},ThreadId:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            });
        }
    }


    public interface IMediaPlayer
    {
        void Play();
    }

    public class AudioPlayer : IMediaPlayer
    {
        public void Play()
        {
            Console.WriteLine("");
        }
    }
}
