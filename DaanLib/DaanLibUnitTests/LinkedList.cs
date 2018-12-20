using DaanLib.Datastructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DaanLibUnitTests {
    [TestClass]
    public class LinkedList {
        [TestMethod]
        public void LinkedListNode_EqualsTest_Equal() {
            LinkedListNode<int> node1 = new LinkedListNode<int>(1);
            LinkedListNode<int> node2 = new LinkedListNode<int>(2);
            LinkedListNode<int> node3 = new LinkedListNode<int>(3);

            int hash = node1.GetHashCode();

            node1.next = node2;
            node1.previous = node3;
            node2.next = node3;
            node2.previous = node1;
            node3.next = node1;
            node3.previous = node2;

            LinkedListNode<int> temp = node1;

            Assert.AreEqual(node1, temp);
        }

        [TestMethod]
        public void LinkedListNode_EqualsTest_EqualSign() {
            LinkedListNode<int> node1 = new LinkedListNode<int>(1);
            LinkedListNode<int> node2 = new LinkedListNode<int>(2);
            LinkedListNode<int> node3 = new LinkedListNode<int>(3);

            node1.next = node2;
            node1.previous = node3;
            node2.next = node3;
            node2.previous = node1;
            node3.next = node1;
            node3.previous = node2;

            LinkedListNode<int> temp = node1;

            Assert.IsTrue(node1 == temp);
        }

        [TestMethod]
        public void LinkedList_IndexTest_GetCorrect() {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
                list.AddFirst(i);

            Assert.AreEqual(9, list[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LinkedList_IndexTest_GetToLowd() {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
                list.AddFirst(i);

            int l = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LinkedList_IndexTest_GetToHigh() {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
                list.AddFirst(i);

            int l = list[10];
        }
    }
}
