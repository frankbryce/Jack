using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jack.Utility;
using Moq;
using System.Linq;

namespace Jack.Model.Test
{
    [TestClass]
    public class HashTest
    {
        public interface IObject
        {
        }

        [TestMethod]
        public void CommutativeProperty()
        {
            Assert.AreEqual(
                    Hash.With(5).AndWith(55),
                    Hash.With(55).AndWith(5)
                );

            Assert.AreEqual(
                    Hash.With(55).AndWith(555).AndWith(5).AndWith(5555),
                    Hash.With(555).AndWith(5).AndWith(5555).AndWith(55)
                );

            var ints1 = new[] { 888888888, 8, 88888 };
            var ints2 = new[] { 8, 88888, 888888888 };

            Assert.AreEqual(
                    Hash.With(ints1),
                    Hash.With(ints2)
                );

            Assert.AreEqual(
                    Hash.With(ints1).AndWith(ints2),
                    Hash.With(ints2).AndWith(ints1)
                );
        }

        [TestMethod]
        public void HashAndDoesNotMutateHashValue()
        {
            Hash hash1 = 5;
            var hash2 = hash1.AndWith(1234);
            var hash3 = hash1.AndWith(1234);

            Assert.AreEqual(hash2, hash3);

            hash2 = hash1.AndWith(hash1);
            hash3 = hash1.AndWith(hash1);

            Assert.AreEqual(hash2, hash3);
        }
    }
}
