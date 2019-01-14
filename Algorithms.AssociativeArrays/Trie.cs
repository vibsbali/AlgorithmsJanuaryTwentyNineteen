using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.AssociativeArrays
{
   public class Trie
   {
      internal class Node
      {
         public Node(int suffixSize)
         {
            Next = new Node[suffixSize];
         }

         internal Node[] Next { get; set; }
         internal string Value { get; set; }
      }

      public Trie(int suffixSize)
      {
         SuffixSize = suffixSize;
         Root = new Node(suffixSize);
      }

      private Node Root { get; set; }

      public int SuffixSize { get; set; }

      public int Count { get; private set; }

      public void Add(string word)
      {
         var current = Root;
         foreach (var character in word.ToLower())
         {
            if (current.Next[character] == null)
            {
               current.Next[character] = new Node(SuffixSize);
            }

            current = current.Next[character];
         }

         current.Value = word.ToLower();
         ++Count;
      }

      public List<string> GetWords(string prefix)
      {
         var current = Root;
         foreach (var character in prefix)
         {
            if (current?.Next[character] == null)
            {
               return null;
            }

            current = current.Next[character];
         }

         var queueOfNodes = new Queue<Node>();
         var listOfWords = new List<string>();
         queueOfNodes.Enqueue(current);
         while (queueOfNodes.Count > 0)
         {
            current = queueOfNodes.Dequeue();
            foreach (var nonNullNode in current.Next.Where(n => n != null))
            {
               queueOfNodes.Enqueue(nonNullNode);
               if (!string.IsNullOrWhiteSpace(nonNullNode.Value))
               {
                  listOfWords.Add(nonNullNode.Value);
               }
            }
         }

         return listOfWords;
      }
   }
}
