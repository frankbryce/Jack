using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jack.Entity;
using Jack.Model;

namespace Jack.Test
{
    [TestClass]
    public class CompositeJackTest
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        private void AssertAreIdentical(BaseJack e1, BaseJack e2)
        {
            e1.Reset();
            e2.Reset();
            for (var i = 0; i < 200; i++)
            {
                var @in = new IntelligenceInput<int>
                {
                    Contentment = random.NextDouble(),
                    Object = random.Next()
                };
                e1.Step(@in);
                e2.Step(@in);
                Assert.AreEqual(e1.State, e2.State);
            }
        }

        [TestMethod]
        public void InputCompositeIsTheSameAsInput()
        {
            var e1 = new InputJack();
            var e2 = new CompositeJack(new InputJack());
            var e3 = new CompositeJack(new CompositeJack(new InputJack()));
            AssertAreIdentical(e1, e2);
            AssertAreIdentical(e2, e3);
            AssertAreIdentical(e1, e3);
        }

        [TestMethod]
        public void OutputCompositeIsTheSameAsOutput()
        {
            var e1 = new OutputJack();
            var e2 = new CompositeJack(new OutputJack());
            var e3 = new CompositeJack(new CompositeJack(new OutputJack()));
            AssertAreIdentical(e1, e2);
            AssertAreIdentical(e2, e3);
            AssertAreIdentical(e1, e3);
        }

        [TestMethod]
        public void InputOutputCompositeIsTheSameAsInputOutput()
        {
            var e1 = new InputOutputJack();
            var e2 = new CompositeJack(new InputOutputJack());
            var e3 = new CompositeJack(new CompositeJack(new InputOutputJack()));
            AssertAreIdentical(e1, e2);
            AssertAreIdentical(e2, e3);
            AssertAreIdentical(e1, e3);
        }

        [TestMethod]
        public void InOutMemoryCompositeIsTheSameAsInOutMemory()
        {
            var e1 = new InOutMemoryJack(4);
            var e2 = new CompositeJack(new InOutMemoryJack(4));
            var e3 = new CompositeJack(new CompositeJack(new InOutMemoryJack(4)));
            AssertAreIdentical(e1, e2);
            AssertAreIdentical(e2, e3);
            AssertAreIdentical(e1, e3);
        }
    }
}
