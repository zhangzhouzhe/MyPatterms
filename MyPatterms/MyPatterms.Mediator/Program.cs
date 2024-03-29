﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace 中介者模式
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId},Name:{CallContext.GetData("Name")}");
            CallContext.SetData("Name", "zzz");
            CallContext.LogicalSetData("Age", "12");
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId},Name:{CallContext.GetData("Name")}");
                    Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId},Age:{CallContext.LogicalGetData("Age")}");
                });

            }
            Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId},Name:{CallContext.GetData("Name")}");






            //TestMethod1();
            Console.Read();
        }
        public static void TestMethod1()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            var ops = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 100
            };
            Parallel.ForEach(list, ops, (i) =>
            {
                ParalleTest();
            });




        }
        public static void ParalleTest()
        {
            var list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            var ops = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 100
            };
            Parallel.ForEach(list, ops, (i) =>
            {
                Console.WriteLine($"任务Id:{i},ThreadId:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });
        }

    }




    /// <summary>
    /// 联合国机构抽象类
    /// 抽象中介者
    /// </summary>
    abstract class UnitedNations
    {
        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message">声明信息</param>
        /// <param name="colleague">声明国家</param>
        public abstract void Declare(string message, Country colleague);
    }
    /// <summary>
    /// 联合国安全理事会,它继承 联合国机构抽象类
    /// 具体中介者
    /// </summary>
    class UnitedNationsSecurityCouncil : UnitedNations
    {
        //美国 具体国家类1
        private USA colleague1;
        //伊拉克 具体国家类2
        private Iraq colleague2;

        public USA Colleague1
        {
            set { colleague1 = value; }
        }
        public Iraq Colleague2
        {
            set { colleague2 = value; }
        }
        //重写声明函数
        public override void Declare(string message, Country colleague)
        {
            //如果美国发布的声明，则伊拉克获取消息
            if (colleague == colleague1)
            {
                colleague2.GetMessage(message);
            }
            else//反之亦然
            {
                colleague1.GetMessage(message);
            }
        }
    }
    /// <summary>
    /// 国家抽象类
    /// </summary>
    abstract class Country
    {
        //联合国机构抽象类
        protected UnitedNations mediator;

        public Country(UnitedNations mediator)
        {
            this.mediator = mediator;
        }
    }
    /// <summary>
    /// 美国 具体国家类
    /// </summary>
    class USA : Country
    {
        public USA(UnitedNations mediator)
            : base(mediator)
        {
        }
        //声明方法，将声明内容较给抽象中介者 联合国
        public void Declare(string message)
        {
            //通过抽象中介者发表声明
            //参数：信息+类
            mediator.Declare(message, this);
        }
        //获得消息
        public void GetMessage(string message)
        {
            Console.WriteLine("美国获得对方信息：" + message);
        }
    }
    /// <summary>
    /// 伊拉克 具体国家类
    /// </summary>
    class Iraq : Country
    {
        public Iraq(UnitedNations mediator)
            : base(mediator)
        {
        }
        //声明方法，将声明内容较给抽象中介者 联合国
        public void Declare(string message)
        {
            //通过抽象中介者发表声明
            //参数：信息+类
            mediator.Declare(message, this);
        }
        //获得消息
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方信息：" + message);
        }
    }
}