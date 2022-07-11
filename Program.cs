﻿using System;

namespace Derevo
{
    public class Tree
    {
        internal class PNode                                 //внутренний класс - узел
        {
            private int value;                                //значение в вершине
            private PNode left;                              //левый потомок
            private PNode right;                             //правый потомок

            internal PNode()                                 //конструктор
            {
                value = 0;
                left = null;
                right = null;
            }

            internal int Value { get { return value; } set { this.value = value; } }                  //свойства
            internal PNode Left { get { return left; } set { left = value; } }
            internal PNode Right { get { return right; } set { right = value; } }
        }

        private PNode head;                                   //вершина дерева
        private int chet = 0;                                    // для вывода

        public Tree(int N)                                //конструктор
        {
            Head = CreateTree(N);
            SetValue(Head);
            PrintTree(50, Head);
        }

        internal PNode Head { get { return head; } set { head = value; } }                     //свойство

        internal PNode CreateTree(int N)                      //метод создания дерева
        {
            PNode p;
            if (N == 0) { p = null; }
            else
            {
                p = new PNode();
                p.Left = CreateTree(N / 2);
                p.Right = CreateTree(N - 1 - N / 2);
            }

            return p;
        }
        internal void SetValue(PNode p)
        {
            if (p.Left != null)
            {
                p.Left.Value = p.Value + 1;
                SetValue(p.Left);
            }
            if (p.Right != null)
            {
                p.Right.Value = p.Value + 1;
                SetValue(p.Right);
            }

        }
        internal void PrintTree(int count, PNode p)           //метод вывода дерева на консоль
        {
            Console.SetCursorPosition(0, chet + 1);
            Console.Write("{0}:", chet);
            Console.SetCursorPosition(count, chet + 1);
            Console.Write("{0}", p.Value);
            if (p.Left != null)
            {
                Console.SetCursorPosition(count, chet + 1);
                chet++;
                int pos = count - 100 / (int)Math.Pow(2, chet + 1);
                Console.SetCursorPosition(pos, chet);
                for (int i = pos + 1; i < count; i++) { Console.Write("-"); }
                PrintTree(pos, p.Left);
            }
            if (p.Right != null)
            {
                Console.SetCursorPosition(count + 1, chet + 1);
                chet++;
                int pos = count + 100 / (int)Math.Pow(2, chet + 1);
                Console.SetCursorPosition(count + 2, chet);
                for (int i = count + 2; i < pos; i++) { Console.Write("-"); }
                PrintTree(pos, p.Right);
            }
            chet--;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число N > 0");
            int n = int.Parse(Console.ReadLine());
            Tree tree = new Tree(n);
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Корень дерева: {0}", tree.Head);
        }
    }
}

