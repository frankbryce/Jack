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
        [TestMethod]
        public void CommutativeProperty()
        {
            Assert.AreNotEqual(
                    Hash.With(5).AndWith(55),
                    Hash.With(55).AndWith(5)
                );

            Assert.AreNotEqual(
                    Hash.With(55).AndWith(555).AndWith(5).AndWith(5555),
                    Hash.With(555).AndWith(5).AndWith(5555).AndWith(55)
                );

            var ints1 = new[] { 888888888, 8, 88888 };
            var ints2 = new[] { 8, 88888, 888888888 };

            Assert.AreNotEqual(
                    Hash.With(ints1),
                    Hash.With(ints2)
                );

            Assert.AreNotEqual(
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

        [TestMethod]
        public void ArraysAndVariableParamsAreTheSame()
        {
            var hash1 = Hash.With(new[] { 1234, 5678 });
            var hash2 = Hash.With(1234, 5678);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void VariableAndFluentCallsAreTheSame()
        {
            var hash1 = Hash.With(1234, 5678);
            var hash2 = Hash.With(1234).AndWith(5678);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void ArrayAndFluentCallsAreTheSame()
        {
            var hash1 = Hash.With(new[] { 1234, 5678 });
            var hash2 = Hash.With(1234).AndWith(5678);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashWithIdentityAndWithObjectEqualsIdentityWithObject()
        {
            Hash hash = Hash.Identity;
            var hash1 = hash.AndWith(5678);
            var hash2 = Hash.With(hash).AndWith(5678);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashWithObjectAndWithIdentityEqualsIdentityWithObject()
        {
            var hash1 = Hash.Identity.AndWith(5678);
            var hash2 = Hash.With(5678).AndWith(Hash.Identity);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashWithObjectAndWithIdentityEqualsObjectWithIdentity()
        {
            var hash1 = Hash.FromInt(5678).AndWith(Hash.Identity);
            var hash2 = Hash.With(5678).AndWith(Hash.Identity);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void ComplexIdentityHashingTest()
        {
            Assert.AreEqual(Hash.Identity.AndWith(5678).AndWith(Hash.Identity).AndWith(1234).AndWith(Hash.Identity),
                            Hash.With(5678).AndWith(1234));
        }

        [TestMethod]
        public void HashIdentityWithIdentityEqualsIdentity()
        {
            var hash1 = Hash.With(Hash.Identity);
            var hash2 = Hash.Identity.AndWith(Hash.Identity);

            Assert.AreEqual(hash1, Hash.Identity);
            Assert.AreEqual(hash2, Hash.Identity);
        }

        [TestMethod]
        public void ValueOfIdentityIsNotEqualToIdentity()
        {
            Assert.AreNotEqual(Hash.FromInt(Hash.Identity), Hash.Identity);
        }

        [TestMethod]
        public void IdentityEqualsIdentity()
        {
            Assert.AreEqual(Hash.Identity, Hash.Identity);
        }
    }
}
