/* Dictionary.cs
 * Author: Nick Ruffini
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A generic dictionary using Hash Tables
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    public class Dictionary<TKey, TValue>
    {
        /// <summary>
        /// The keys and values in the dictionary stored in an array of linked lists!
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>[] _elements = new LinkedListCell<KeyValuePair<TKey, TValue>>[23];

        /// <summary>
        /// Gets the hash code of a key and returns it's array index!
        /// </summary>
        /// <param name="k"> Key that we are finding the index of in the array! </param>
        /// <returns> int value representing the index where the key is located (or to be) </returns>
        private int GetLocation(TKey k)
        {
            int code = k.GetHashCode();
            int stripped = code & 0x7fffffff;
            int result = stripped % _elements.Length;
            return result;
        }

        /// <summary>
        /// Checks to see if the given key is null, and if so, throws an
        /// ArgumentNullException.
        /// </summary>
        /// <param name="key">The key to check.</param>
        private static void CheckKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Steps through a linked list, trying to find the designated key. If not found, returns null
        /// </summary>
        /// <param name="k"> Key we are looking for in list </param>
        /// <param name="list"> Linked List we are iterating through </param>
        /// <returns></returns>
        private LinkedListCell<KeyValuePair<TKey, TValue>> GetCell(TKey k, LinkedListCell<KeyValuePair<TKey, TValue>> list)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> temp = list;
            while (temp != null)
            {
                if (k.Equals(temp.Data.Key))
                {
                    return temp;
                }
                else
                {
                    temp = temp.Next;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the given cell into the front of the linked list at the designated array location!
        /// </summary>
        /// <param name="cell"> Cell that is being added to the linked list </param>
        /// <param name="loc"> Location in the array we are adding this cell to </param>
        private void Insert(LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _elements[loc];
            _elements[loc] = cell;
        }

        /// <summary>
        /// Creates a new cell and adds it to the array
        /// </summary>
        /// <param name="k"> Key value for the new cell </param>
        /// <param name="v"> Value parameter for the cell </param>
        /// <param name="loc"> Index in the array we are adding this cell </param>
        private void Insert(TKey k, TValue v, int loc)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> newCell = new LinkedListCell<KeyValuePair<TKey, TValue>>();
            newCell.Data = new KeyValuePair<TKey, TValue>(k, v);
            Insert(newCell, loc);

        }

        /// <summary>
        /// Tries to get the value associated with the given key.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <param name="v">The value associated with k, or the default value if
        /// k is not in the dictionary.</param>
        /// <returns>Whether k was found as a key in the dictionary.</returns>
        public bool TryGetValue(TKey k, out TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> newCell = GetCell(k, _elements[loc]);
            if (newCell == null)
            {
                v = default(TValue);
                return false;
            }
            else
            {
                v = newCell.Data.Value;
                return true;
            }
        }

        /// <summary>
        /// Adds the given key with the given associated value.
        /// If the given key is already in the dictionary, throws an
        /// InvalidOperationException.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <param name="v">The value.</param>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> newCell = GetCell(k, _elements[loc]);
            if (newCell != null)
            {
                throw new ArgumentException();
            }
            else
            {
                Insert(k, v, loc);
            }
        }
    }
}
