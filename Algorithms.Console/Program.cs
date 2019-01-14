using System;
using System.Linq;
using Algorithms.AssociativeArrays;

namespace Algorithms.Console
{
   class Program
   {
      static void Main(string[] args)
      {
         var trie = new Trie(256);
         Assert.IsTrue(trie.Count == 0, $"Should be 0 but was {trie.Count}");

         trie.Add("a");
         Assert.IsTrue(trie.Count == 1, $"Should be 1 but was {trie.Count}");

         trie.Add("alpha");
         trie.Add("beta");
         trie.Add("gamma");
         trie.Add("Amber");
         trie.Add("Amazing");
         trie.Add("between");
         trie.Add("benzer");

         var listOfWords = trie.GetWords("bet");
         foreach (var listOfWord in listOfWords)
         {
            System.Console.WriteLine(listOfWord);
         }
      }
   }

   static class Assert
   {
      public static void IsTrue(bool b, string s)
      {
         if (!b)
         {
            throw new ApplicationException(s);
         }
      }
   }
}
