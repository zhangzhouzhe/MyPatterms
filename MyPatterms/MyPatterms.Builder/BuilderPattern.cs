using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPatterms.Builder.Unitest2

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
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

    }


    public class Product
    {
        public void doSomething() { }
    }
    public abstract class Builder
    {
        public abstract void SetPart();
        public abstract Product Build();
    }

    public class ConcreteProduct : Builder
    {
        private Product product = new Product();
        public override Product Build()
        {
            return product;
        }

        public override void SetPart()
        {
            throw new NotImplementedException();
        }
    }

    public class Director
    {
        private Builder builder = new ConcreteProduct();
        public Product GetAProduct()
        {
            builder.SetPart();
            return builder.Build();
        }
    }
    /// <summary>
    /// 优点：1封装性：使用建造者模式可以是客户端不比知道产品内部组成细节
    ///      2创建者独立，容易扩展
    ///      3便于控制细节和控制风险  具体的构建者是独立的  因此构建者是可以逐步演进的，而不对其他的模块产生影响。
    /// 使用场景：
    ///     1.相同方法不同执行顺序产生不同的时间结果
    ///     2.多个部件或零件可以装配到一个对象的时候
    ///     3.产品类非常复杂，或者产品类中的调用顺序不同产生了不同的效能
    /// </summary>
   
}
    
