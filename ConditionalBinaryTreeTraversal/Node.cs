namespace ConditionalBinaryTreeTraversal
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public NodeSwitch Switch { get; set; }
        public string Data { get; set; }
        public int Id { get; set; }
    }

    public enum NodeSwitch
    {
        Left,
        Right
    }
}
