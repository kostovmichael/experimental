using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
namespace PatternsAndConcepts.Algs
{
   /// <summary>
   /// 
   /// </summary>
   /// <typeparam name="TValue"></typeparam>
   public class TernarySearchTrie<TValue>
   {
      private int n;              // size
      private Node<TValue> root;   // root of TST

      class Node<TValue>
      {
         public char KeyChar;                        // character
         public Node<TValue> left, mid, right;  // left, middle, and right subtries
         public TValue val;                     // value associated with string
      }

      public TernarySearchTrie() { }

      public int Size()
      {
         return n;
      }

      public Boolean Contains(ReadOnlySpan<char> key)
      {
         if (key == null)
         {
            throw new ArgumentNullException("argument to contains() is null");
         }
         return Get(key) != null;
      }

      public TValue Get(ReadOnlySpan<char> key)
      {
         if (key == null)
         {
            throw new ArgumentNullException("calls get() with null argument");
         }
         //if (key.length() == 0) throw new IllegalArgumentException("key must have length >= 1");
         Node<TValue> x = get(root, ref key, 0);
         if (x == null)
         {
            return default(TValue);
         }
         return x.val;
      }

      /// <summary>
      /// Indexer wrapping <c>Get</c> and <c>Put</c> for convenient syntax
      /// </summary>
      /// <param name="key">key the key </param>
      /// <returns>value associated with the key</returns>
      /// <exception cref="NullReferenceException">null reference being used for value type</exception>
      public TValue this[ReadOnlySpan<char> key]
      {
         get
         {
            TValue value = Get(key);
            if (value == null)
            {
               if (default(TValue) == null) return (TValue)value;
               else throw new NullReferenceException("null reference being used for value type");
            }
            return value;
         }
         set
         {
            Put(key, value);
         }
      }
      private Node<TValue> get(Node<TValue> node, ref ReadOnlySpan<char> key, int d)
      {
         if (node == null)
         {
            return null;
         }
         if (key.Length == 0)
         {
            throw new ArgumentException("key must have length >= 1");
         }

         char searchCharAtPositionD = key[d];
         if (searchCharAtPositionD < node.KeyChar)
         {
            return get(node.left, ref key, d);
         }
         else if (searchCharAtPositionD > node.KeyChar)
         {
            return get(node.right, ref key, d);
         }
         else if (d < key.Length - 1)
         {
            return get(node.mid, ref key, d + 1);
         }
         else
         {
            return node;
         }
      }


      public void Put(ReadOnlySpan<char> key, TValue val)
      {
         if (key == null)
         {
            throw new ArgumentException("calls put() with null key");
         }
         //var theKey = key.AsSpan();
         if (!Contains(key))
         {
            n++;
         }

         root = put(root, ref key, val, 0);
      }
      private Node<TValue> put(Node<TValue> node, ref ReadOnlySpan<char> key, TValue val, int position)
      {
         char searchChar = key[position];
         if (node == null)
         {
            node = new Node<TValue>();
            node.KeyChar = searchChar;
         }
         if (searchChar < node.KeyChar)
         {
            node.left = put(node.left, ref key, val, position);
         }
         else if (searchChar > node.KeyChar)
         {
            node.right = put(node.right, ref key, val, position);
         }
         else if (position < key.Length - 1)
         {
            node.mid = put(node.mid, ref key, val, position + 1);
         }
         else
         {
            node.val = val;
         }
         return node;
      }

      /// <summary>
      /// Returns the string in the symbol table that is the longest prefix of query or  null,
      /// if no such string. Throws IllegalArgumentException if query is  null
      /// </summary>
      /// <param name="query"></param>
      /// <returns>Returns the string in the symbol table that is the longest prefix of query or  null,
      /// if no such string.</returns>
      public unsafe String LongestPrefixOf(ReadOnlySpan<char> query)
      {
         if (query == null)
         {
            throw new ArgumentException("calls LongestPrefixOf() with null argument");
         }
         if (query.Length == 0) return null;

         int length = 0;
         Node<TValue> x = root;
         int i = 0;
         fixed (char* f = &MemoryMarshal.GetReference(query))
         {
            char* pointer = f;
            while (x != null && i < query.Length)
            {
               //char c = query[i];
               //char* c = pointer;
               if (*pointer < x.KeyChar)
               {
                  x = x.left;
               }
               else if (*pointer > x.KeyChar)
               {
                  x = x.right;
               }
               else
               {
                  i++;
                  pointer++;
                  if (x.val != null)
                  {
                     length = i;
                  }
                  x = x.mid;
               }
            }
         }


         return query.Slice(0, length).ToString();
      }




      /// <summary>
      /// Returns all keys in the symbol table
      /// </summary>
      /// <returns>
      ///  <see cref="System.Collections.Generic.IEnumerable"/>.
      /// </returns>
      public IEnumerable<String> Keys()
      {
         Queue<String> queue = new Queue<String>();
         collect(root, new StringBuilder(), queue);
         return queue;
      }

      /**
       * Returns all of the keys in the set that start with {@code prefix}.
       * @param prefix the prefix
       * @return all of the keys in the set that start with {@code prefix},
       *     as an iterable
       * @throws IllegalArgumentException if {@code prefix} is {@code null}
       */
      public IEnumerable<String> KeysWithPrefix(String prefix)
      {
         if (prefix == null)
         {
            throw new ArgumentException("calls keysWithPrefix() with null argument");
         }
         Queue<String> queue = new Queue<String>();
         var thePrefix = prefix.AsSpan();
         Node<TValue> x = get(root, ref thePrefix, 0);
         if (x == null) return queue;
         if (x.val != null) queue.Enqueue(prefix);
         collect(x.mid, new StringBuilder(prefix), queue);
         return queue;
      }

      // all keys in subtrie rooted at x with given prefix
      private void collect(Node<TValue> x, StringBuilder prefix, Queue<String> queue)
      {
         if (x == null) return;
         collect(x.left, prefix, queue);
         if (x.val != null) queue.Enqueue(prefix.ToString() + x.KeyChar);
         collect(x.mid, prefix.Append(x.KeyChar), queue);
         prefix.Remove(prefix.Length - 1, 1);
         collect(x.right, prefix, queue);
      }


      /**
       * Returns all of the keys in the symbol table that match {@code pattern},
       * where . symbol is treated as a wildcard character.
       * @param pattern the pattern
       * @return all of the keys in the symbol table that match {@code pattern},
       *     as an iterable, where . is treated as a wildcard character.
       */

      public IEnumerable<String> KeysThatMatch(String pattern)
      {
         Queue<String> queue = new Queue<String>();
         collect(root, new StringBuilder(), 0, pattern, queue);
         return queue;
      }

      private void collect(Node<TValue> x, StringBuilder prefix, int i, String pattern, Queue<String> queue)
      {
         if (x == null) return;
         char c = pattern[i];
         if (c == '.' || c < x.KeyChar) collect(x.left, prefix, i, pattern, queue);
         if (c == '.' || c == x.KeyChar)
         {
            if (i == pattern.Length - 1 && x.val != null) queue.Enqueue(prefix.ToString() + x.KeyChar);
            if (i < pattern.Length - 1)
            {
               collect(x.mid, prefix.Append(x.KeyChar), i + 1, pattern, queue);
               prefix.Remove(prefix.Length - 1, 1);
            }
         }
         if (c == '.' || c > x.KeyChar) collect(x.right, prefix, i, pattern, queue);
      }


   }
}
