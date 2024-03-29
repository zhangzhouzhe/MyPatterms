﻿using System;

namespace 中介者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化 具体中介者 联合国安理会
            UnitedNationsSecurityCouncil UNSC = new UnitedNationsSecurityCouncil();

            //实例化一个美国
            USA c1 = new USA(UNSC);
            //实例化一个里拉开
            Iraq c2 = new Iraq(UNSC);

            //将两个对象赋值给安理会
            //具体的中介者必须知道全部的对象
            UNSC.Colleague1 = c1;
            UNSC.Colleague2 = c2;

            //美国发表声明，伊拉克接收到
            c1.Declare("不准研制核武器，否则要发动战争！");
            //伊拉克发表声明，美国收到信息
            c2.Declare("我们没有核武器，也不怕侵略。");

            Console.Read();
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