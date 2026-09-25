using UnityEngine;

namespace Midterm
{
    public class TreeSample : MonoBehaviour
    {
        TreeNode root = null;

        private void Start()
        {
            CreateTree();

            //Find the TreeNode with the highest value
        }

        private void CreateTree()
        {
            root = new TreeNode(7);

            TreeNode nodeA = new TreeNode(4);
            TreeNode nodeB = new TreeNode(6);
            TreeNode nodeC = new TreeNode(2);
            TreeNode nodeD = new TreeNode(10);

            //Leaf nodes further down
            nodeA.AddChild(nodeC);
            nodeB.AddChild(nodeD);

            //Children of the root
            root.AddChild(nodeA);
            root.AddChild(nodeB);

        }
    }
}
