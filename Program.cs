using System;
using System.Collections.Generic;
using System.Linq;

namespace matchPairs
{
    class Program
    {
      static Dictionary<char, char> pairs = new Dictionary<char, char>()
        {{'(', ')'}, {'[', ']'}, {'{', '}'}};

      static Stack<char> stack = new Stack<char>();
      static bool correctness(string st) 
      {
        for (int i = 0; i < st.Length; i++)
        {
          if (pairs.Keys.Any(p => p == st[i]))
          {
            // push the closing pair so there won't be a need for opposite dictionary
            stack.Push(pairs[st[i]]);
          }
          else if (pairs.Values.Any(p => p == st[i]))
          {
            var ch = stack.Pop();
            if (ch != st[i])
            {
              return false;
            }
          }
        }
        return true;
      }
      static void Main(string[] args)
      {
          Console.WriteLine(correctness("(()())")); // True
          Console.WriteLine(correctness("([]())")); // True
          Console.WriteLine(correctness("([()({})])")); //True
          Console.WriteLine(correctness("([)]")); //False
      }
    }
}
