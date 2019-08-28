using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPatterms.Builder
{
    /// <summary>
    /// 　在软件编程的过程我们是否也会遇到类似电脑组装这类的问题呢？
    /// 　当然是会的。组装一个电脑我们就一次，那岂不是要累死了。
    /// 　类似于这种组装算法固定但是各个部分又不稳定经常变化的情况。
    /// 　并且对象组装较为复杂。
    /// 　为了面对解决这种情况。所以有建造者模式
    /// 　将一个复杂对象的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
    /// 　
    ///   抽象建造者：抽象建造者为创建复杂产品对象的各个部分指定抽象创建接口
    ///   具体建造者：继承抽象建造者，实现抽象创建接口 指定创建的类型，创建各个具体的部分
    ///   产品角色：复杂产品对象，将各个部分组成产品的 接口
    ///   指挥者：调用各个部分 按固定的算法创建  不涉及居图的产品类的信息。仅仅负责各个部分的完整创建
    /// 
    /// 
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Commander commander = new Commander();
            //指定具体产品
            Builder builder = new LenovoBuilder();
            //组装构建产品
            commander.Construct(builder);
            //构建完成展示产品
            Computer computer = builder.GetComputer();
            computer.Show();


            //指定具体产品
            builder = new HPBuilder();
            //组装构建产品
            commander.Construct(builder);
            //构建完成展示产品
            computer = builder.GetComputer();
            computer.Show();

            Console.ReadLine();
        }
    }

    public class Computer
    {
        private string Type { get; set; }
        private List<string> Computers = new List<string>();
        public Computer(string type)
        {
            Type = type;
        }
        public void Add(string part)
        {
            Computers.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("电脑组装正式开始：");
            foreach (var item in Computers)
            {
                Console.WriteLine("配件——" + item + "已装好");
            }
            Console.WriteLine(Type + "电脑组装完成了");
        }
    }

    public abstract class Builder
    {
        public abstract void CreateCpu();
        public abstract void CreateMotherboard();
        public abstract void CreateGraphicsCard();
        public abstract Computer GetComputer();
    }
    public class LenovoBuilder : Builder
    {
        Computer lenovo = new Computer("联想");
        public override void CreateCpu()
        {
            lenovo.Add("联想CPU");
        }
        public override void CreateMotherboard()
        {
            lenovo.Add("联想主板");
        }
        public override void CreateGraphicsCard()
        {
            lenovo.Add("联想显卡");
        }

        public override Computer GetComputer()
        {
            return lenovo;
        }
    }
    public class HPBuilder : Builder
    {
        Computer hp = new Computer("惠普");
        public override void CreateCpu()
        {
            hp.Add("惠普CPU");
        }
        public override void CreateMotherboard()
        {
            hp.Add("惠普主板");
        }
        public override void CreateGraphicsCard()
        {
            hp.Add("惠普显卡");
        }

        public override Computer GetComputer()
        {
            return hp;
        }
    }
    public class Commander
    {
        public void Construct(Builder builder)
        {
            builder.CreateMotherboard();
            builder.CreateCpu();
            builder.CreateGraphicsCard();
        }
    }
}
