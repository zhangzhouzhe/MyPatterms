using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyPatterms.Decorator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }


    public abstract class Food
    {
        protected string desc;
        public abstract string GetDesc();
    }
    public class Chicken : Food
    {
        public Chicken()
        {
            desc = "Chicken";
        }
        public override string GetDesc()
        {
            return desc;
        }
    }
    public class Duck : Food
    {
        public Duck()
        {
            desc = "Duck";
        }
        public override string GetDesc()
        {
            return desc;
        }
    }

    public abstract class FoodDecorator : Food
    {

    }

    public class RoastFood : FoodDecorator
    {
        private Food _food;
        public RoastFood(Food food)
        {
            _food = food;
        }
        public override string GetDesc()
        {
            return "烤" + _food.GetDesc();
        }
    }
    public class SteamedFood : FoodDecorator
    {
        private Food _food;
        public SteamedFood(Food food)
        {
            _food = food;
        }
        public override string GetDesc()
        {
            return "蒸" + _food.GetDesc();
        }
    }
}
