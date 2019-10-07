using System;
using System.Collections.Generic;

namespace DataStructuresProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node startNode = 
                new Node(1,
                    new Node(2,
                        new Node(4,null,
                            new Node(7))),
                    new Node(3,
                        new Node(5,null,
                            new Node(8,
                                new Node(9),
                                new Node(10))),
                        new Node(6)));

            /*
             *        1
             *      /   \
             *     2     3
             *    /    /  \
             *   4    5    6
             *    \    \  
             *     7    8 
             *         / \
             *        9   10
             */

            var sorter = new Sorter();

            foreach (Node node in sorter.DFS(startNode))
            {
                Console.WriteLine(node.value);
            }
            //BFS = 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            //DFS = 1, 2, 4, 7, 3, 5, 8, 9, 10, 6
            Console.ReadKey();
        }
    }

    public class Sorter
    {
        List<Node> visitedNodes = new List<Node>();

        /// <summary>
        /// traverses list of nodes and returns them in order, breadth first
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public List<Node> BFS(Node startNode)
        {

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                //Console.WriteLine(currentNode.value);

                visitedNodes.Add(currentNode);

                if (currentNode.leftChild != null)
                {
                    queue.Enqueue(currentNode.leftChild);
                }
                if (currentNode.rightChild != null)
                {
                    queue.Enqueue(currentNode.rightChild);
                }

            }

            return visitedNodes;
        }

        /// <summary>
        /// recursively traverses a binary search tree and returns the nodes in order
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public List<Node> DFS(Node currentNode)
        {
            if (currentNode != null)
            {
                visitedNodes.Add(currentNode);

                DFS(currentNode.leftChild);
 
                DFS(currentNode.rightChild);
                
            }

            return visitedNodes;
        }
    }

    public class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;

        public Node() { }
        public Node(int value, Node leftChild = null, Node rightChild = null)
        {
            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
    }
}
