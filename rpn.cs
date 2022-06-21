using System;
using System.Collections;

namespace rpn
{
    class Program
    {
        static void Main()
        {
            Stack stos = new Stack();
            string tmp = Console.ReadLine();
            Console.WriteLine("Przekształcenie na ONP:");
            for (int i = 0; i < tmp.Length; i++)
            {
                switch (tmp[i])
                {
                    case ' ':
                        break;

                    case '(':
                        stos.Push('(');
                        break;

                    case ')':
                        while ((char)stos.Peek() != '(')
                        {
                            Console.Write(stos.Pop() + " ");
                        }
                        stos.Pop();
                        break;

                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        while (stos.Count != 0)
                        {
                            if ((Priorytet(tmp[i]) == 3) || (Priorytet(tmp[i]) > Priorytet((char)stos.Peek())))
                            {
                                break;
                            }
                            if ((char)stos.Peek()!='(')
                            {
                                Console.Write(stos.Pop() + " ");
                            }
                        }                
                        stos.Push(tmp[i]);
                        break;
                    default:
                        Console.Write(tmp[i] + " ");
                        break;

                }
            }
            PrintValues(stos);
            Console.ReadLine();
        }
        
        public static void PrintValues(IEnumerable myCollection) // wypisanie
        {
            foreach (Object obj in myCollection)
                if ((char)obj !='(')
                {
                    Console.Write("{0} ", obj);
                }
            Console.WriteLine();
        }
        
        static int Priorytet(char x) // sprawdzenie priorytetu
        {
            switch (x)
            {
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
