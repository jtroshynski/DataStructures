using System;
using System.Collections.Generic;

namespace DataStructuresProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node startNode = 
                new Node(5,
                    new Node(3,
                        new Node(1,
                            new Node(0),
                            null),
                        new Node(4)),
                    new Node(10,
                        new Node(6,
                            null,
                            new Node(8,
                                new Node(7),
                                new Node(9))),
                        new Node(11)));

            /*
             *          5
             *        /   \
             *       3     10
             *      / \   /  \
             *     1   4 6    11
             *   /        \  
             *  0          8 
             *            / \
             *           7   9
             */

            var sorter = new Sorter();

            Console.WriteLine(sorter.lowestCommonAncestor(startNode,new Node(6), new Node(7)).value);

            //foreach (Node node in sorter.DFS(startNode))
            //{
            //    Console.WriteLine(node.value);
            //}
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
        
        public Node lowestCommonAncestor(Node root, Node firstNode, Node secondNode)
        {

            if (firstNode.value > root.value && secondNode.value > root.value)
            {
                // If both nodes are greater than the parent
                return lowestCommonAncestor(root.rightChild, firstNode, secondNode);
            }
            else if (firstNode.value < root.value && secondNode.value < root.value)
            {
                // If both nodes are less that the parent
                return lowestCommonAncestor(root.leftChild, firstNode, secondNode);
            }
            else
            {
                // We have found the split point, i.e. the LCA node.
                return root;
            }
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
