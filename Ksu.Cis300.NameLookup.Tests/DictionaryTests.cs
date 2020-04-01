/* DictionaryTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ksu.Cis300.NameLookup.Tests
{
    /// <summary>
    /// Unit tests for the Dictionary class.
    /// </summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>
        /// Checks that the height of null is -1.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAHeightOfNull()
        {
            Assert.That(BinaryTreeNode<int>.Height(null), Is.EqualTo(-1));
        }

        /// <summary>
        /// Checks that the height of a one-node tree is 0.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBHeightOfOneNode()
        {
            Assert.That(BinaryTreeNode<string>.Height(BinaryTreeNode<string>.GetAvlTree("one", null, null)), Is.EqualTo(0));
        }

        /// <summary>
        /// Checks that the height of a two-node tree is 1.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCHeightOfTwoNodes()
        {
            BinaryTreeNode<int> t = BinaryTreeNode<int>.GetAvlTree(1, BinaryTreeNode<int>.GetAvlTree(2, null, null), null);
            Assert.That(BinaryTreeNode<int>.Height(t), Is.EqualTo(1));
        }

        /// <summary>
        /// Checks that the height of a two-node tree is 1.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCHeightOfTwoOtherNodes()
        {
            BinaryTreeNode<int> t = BinaryTreeNode<int>.GetAvlTree(1, null, BinaryTreeNode<int>.GetAvlTree(2, null, null));
            Assert.That(BinaryTreeNode<int>.Height(t), Is.EqualTo(1));
        }

        /// <summary>
        /// Tests a single rotate left.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDSingleRotateLeft()
        {
            BinaryTreeNode<char> a = BinaryTreeNode<char>.GetAvlTree('a', null, null);
            BinaryTreeNode<char> c = BinaryTreeNode<char>.GetAvlTree('c', null, null);
            BinaryTreeNode<char> e = BinaryTreeNode<char>.GetAvlTree('e', null, BinaryTreeNode<char>.GetAvlTree('f', null, null));
            BinaryTreeNode<char> d = BinaryTreeNode<char>.GetAvlTree('d', c, e);
            BinaryTreeNode<char> result = BinaryTreeNode<char>.GetAvlTree('b', a, d);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data, Is.EqualTo('d'));
                Assert.That(result.LeftChild.Data, Is.EqualTo('b'));
                Assert.That(result.LeftChild.LeftChild, Is.EqualTo(a));
                Assert.That(result.LeftChild.RightChild, Is.EqualTo(c));
                Assert.That(result.RightChild, Is.EqualTo(e));
            });
        }

        /// <summary>
        /// Tests a double rotate right.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDDoubleRotateRight()
        {
            BinaryTreeNode<char> a = BinaryTreeNode<char>.GetAvlTree('a', null, null);
            BinaryTreeNode<char> c = BinaryTreeNode<char>.GetAvlTree('c', null, null);
            BinaryTreeNode<char> e = BinaryTreeNode<char>.GetAvlTree('e', null, null);
            BinaryTreeNode<char> g = BinaryTreeNode<char>.GetAvlTree('g', null, null);
            BinaryTreeNode<char> d = BinaryTreeNode<char>.GetAvlTree('d', c, e);
            BinaryTreeNode<char> b = BinaryTreeNode<char>.GetAvlTree('b', a, d);
            BinaryTreeNode<char> result = BinaryTreeNode<char>.GetAvlTree('f', b, g);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data, Is.EqualTo('d'));
                Assert.That(result.LeftChild.Data, Is.EqualTo('b'));
                Assert.That(result.LeftChild.LeftChild, Is.EqualTo(a));
                Assert.That(result.LeftChild.RightChild, Is.EqualTo(c));
                Assert.That(result.RightChild.Data, Is.EqualTo('f'));
                Assert.That(result.RightChild.LeftChild, Is.EqualTo(e));
                Assert.That(result.RightChild.RightChild, Is.EqualTo(g));
            });
        }

        /// <summary>
        /// Tests a double rotate left.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDDoubleRotateLeft()
        {
            BinaryTreeNode<char> a = BinaryTreeNode<char>.GetAvlTree('a', null, null);
            BinaryTreeNode<char> c = BinaryTreeNode<char>.GetAvlTree('c', null, null);
            BinaryTreeNode<char> e = BinaryTreeNode<char>.GetAvlTree('e', null, null);
            BinaryTreeNode<char> g = BinaryTreeNode<char>.GetAvlTree('g', null, null);
            BinaryTreeNode<char> d = BinaryTreeNode<char>.GetAvlTree('d', c, e);
            BinaryTreeNode<char> f = BinaryTreeNode<char>.GetAvlTree('f', d, g);
            BinaryTreeNode<char> result = BinaryTreeNode<char>.GetAvlTree('b', a, f);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data, Is.EqualTo('d'));
                Assert.That(result.LeftChild.Data, Is.EqualTo('b'));
                Assert.That(result.LeftChild.LeftChild, Is.EqualTo(a));
                Assert.That(result.LeftChild.RightChild, Is.EqualTo(c));
                Assert.That(result.RightChild.Data, Is.EqualTo('f'));
                Assert.That(result.RightChild.LeftChild, Is.EqualTo(e));
                Assert.That(result.RightChild.RightChild, Is.EqualTo(g));
            });
        }
    }
}