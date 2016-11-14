using System;
using System.Collections.Generic;

namespace Tries
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Trie trie = new Trie();

            for (int commandCount = 0; commandCount < n; commandCount++)
            {
                string[] tokens_op = Console.ReadLine().Split(' ');
                string operation = tokens_op[0];
                string contact = tokens_op[1];
                if (operation.Equals("add")){
                    trie.Add(contact);
                }
                else if (operation.Equals("find"))
                {
                    var count = trie.Count(contact);
                    Console.WriteLine(count);
                }
            }
        }
    }

    class Trie
    {
        int count = 0;
        readonly Dictionary<char, Trie> letters = new Dictionary<char, Trie>();

        public void Add(string contact)
        {
            count++;
            if (!string.IsNullOrEmpty(contact))
            {
                char first = contact[0];
                if (!letters.ContainsKey(first))
                {
                    letters.Add(first, new Trie());
                }
                letters[first].Add(contact.Substring(1));
            }
        }

        public int Count(string contact)
        {
            if (string.IsNullOrEmpty(contact))
                return count;
            char first = contact[0];
            return letters.ContainsKey(first) ? letters[first].Count(contact.Substring(1)) : 0;
        }

    }
}
