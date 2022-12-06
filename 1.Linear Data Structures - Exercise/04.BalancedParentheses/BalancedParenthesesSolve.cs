namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if(parentheses.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<char>();
            foreach(char currCh in parentheses)
            {
                char expectedChar = default;
                switch (currCh)
                {
                    case ')':
                        expectedChar = '(';
                        break;
                    case ']':
                        expectedChar = '[';
                        break;
                    case '}':
                        expectedChar = '{';
                        break;
                    default:
                        stack.Push(currCh);
                    break;

                }
                if(expectedChar == default)
                {
                    continue;
                }
                if(stack.Pop() != expectedChar)
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
