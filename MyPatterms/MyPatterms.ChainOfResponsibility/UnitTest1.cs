using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPatterms.ChainOfResponsibility
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var request = new PurchaseRequest()
            {
                Amount = 10
            };

            var manager = new Manager(new VP(null));

            manager.ProcessRequest(request);

            request.Amount = 900;

            manager.ProcessRequest(request);
        }
    }



    public class PurchaseRequest
    {
        public int Amount { get; set; }
    }

    public abstract class Approver
    {
        protected Approver _nextApprover;

        public string Name { get; set; }

        public abstract void ProcessRequest(PurchaseRequest request);
    }
    public class VP : Approver
    {
        public VP(Approver nextApprover)
        {
            base._nextApprover = nextApprover;
            base.Name = "VP";
        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            Console.WriteLine($"{Name}:开始处理");
            if (request.Amount < 1000)
            {
                Console.WriteLine($"{Name}:已处理");
            }
            else
            {
                Console.WriteLine($"{Name}:无法处理");

            }

            Console.WriteLine($"{Name}:结束处理");
        }
    }
    public class Manager : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            Console.WriteLine($"{Name}:开始处理");
            if (request.Amount < 100)
            {
                Console.WriteLine($"{Name}:已处理");
            }
            else
            {
                Console.WriteLine($"{Name}:转交处理");
                _nextApprover.ProcessRequest(request);
            }

            Console.WriteLine($"{Name}:结束处理");
        }

        public Manager(Approver nextApprover)
        {
            base._nextApprover = nextApprover;
            base.Name = "经理";
        }
    }

}
