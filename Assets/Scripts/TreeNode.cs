using UnityEngine;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;

namespace Midterm
{
    public class TreeNode
    {
        public int data;
        public List<TreeNode> children = new List<TreeNode>();
    
        public TreeNode(int _data)
        {
            data = _data;
        }

        public void AddChild(TreeNode newChild)
        {
            children.Add(newChild);
        }

        public void FindMaximum()
        {
            
        }
    }
}
