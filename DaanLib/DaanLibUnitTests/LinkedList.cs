using System;
using DaanLib.Datastructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaanLibUnitTests {
    [TestClass]
    public class LinkedList {
        [TestMethod]
        public void LinkedList_IndexTest_Get() {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
                list.AddFirst(i);

            Assert.AreEqual(9, list[0]);
        }
    }
}
