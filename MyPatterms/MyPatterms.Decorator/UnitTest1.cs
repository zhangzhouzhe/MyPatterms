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
            var chicken = new Chicken();

            var str1 = chicken.GetDesc();

            var roastFood = new RoastFood(chicken);

            var str2 = roastFood.GetDesc();

            var steamedFood = new SteamedFood(roastFood);

            var str3 = steamedFood.GetDesc();
        }


        [TestMethod]
        public void ChagePerson()
        {
            var persion = new Person() { Age = 10, Name = "Persion" };
            var staff = new Staff(persion);
            staff.Person.Age = 12;
       

            Console.WriteLine($"{persion.Age}");

        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public struct Staff
    {
        public Staff(Person p)
        {
            Person = p;
        }
        public Person Person { get; }
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
