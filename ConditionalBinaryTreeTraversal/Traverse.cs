using System;
using System.Collections.Generic;
using System.Linq;

namespace ConditionalBinaryTreeTraversal
{
    public class Traverse
    {
        Array values = Enum.GetValues(typeof(NodeSwitch));
        Random random = new Random(DateTime.Now.TimeOfDay.Seconds);
        List<Node> TreeNodes = new List<Node>(31);
        List<int> ProcessedNodeIds = new List<int>();
        private int inputDepth;
        private int numberOfNodes;
        private int numberOfBalls;

        public Traverse(int inputDepth)
        {
            this.inputDepth = inputDepth;
            numberOfNodes = (int)Math.Pow(2, (inputDepth+1)) - 1;  // Number of the nodes in complete binary tree : [ 2 raise to the power (depth+1) ] - 1;
            numberOfBalls = (int)Math.Pow(2, inputDepth) - 1; // Number of the leaf nodes in complete binary tree : 2 raise to the power depth.
        }

        public void Start_Traversing()
        {
            List<int> data = new List<int>();
            for (int i = 0; i < numberOfNodes; i++)
            {
                data.Add(i);
            }

            Node rootNode = BuildTree(data, 0);
            Queue<Node> queue = new Queue<Node>();

            for (int i = 0; i < numberOfBalls; i++)
            {
                queue.Enqueue(rootNode);
                while (queue.Count > 0)
                {
                    Node current = queue.Dequeue();
                    if (current == null) continue;
                    if (current.Left == null && current.Right == null)
                    {
                        //We have reached leaf node, put the ball in it.
                        ProcessNode(current);
                        continue;
                    }

                    switch (current.Switch)
                    {
                        case NodeSwitch.Left:
                            {
                                queue.Enqueue(current.Left);
                                current.Switch = NodeSwitch.Right;
                                break;
                            }
                        case NodeSwitch.Right:
                            {
                                queue.Enqueue(current.Right);
                                current.Switch = NodeSwitch.Left;
                                break;
                            }
                    }
                }
            }

            Node emptyNode = TreeNodes.Where(node => !ProcessedNodeIds.Any(a => a == node.Id) && node.Left == null && node.Right == null).FirstOrDefault();

            if (emptyNode != null)
            {
                Console.WriteLine("Node which did not get any ball: " + emptyNode.Data);
            }
        }

        private void ProcessNode(Node current)
        {
            ProcessedNodeIds.Add(current.Id);
            Console.WriteLine("Ball went into the node: " + current.Data);
        }

        private Node BuildTree(List<int> data, int i)
        {
            if (i >= data.Count) return null;
            Node node = new Node();
            node.Id = i;
            node.Data = "Node :" + data.ElementAt(i);
            node.Left = BuildTree(data, 2 * i + 1);
            node.Right = BuildTree(data, 2 * i + 2);
            node.Switch = (NodeSwitch)values.GetValue(random.Next(values.Length));
            TreeNodes.Add(node);
            return node;
        }
    }
}
