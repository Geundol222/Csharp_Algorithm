using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return;
            }

            Node current = root;
            while (current != null)
            {
                // 비교해서 더 작은 경우 왼쪽으로 감
                if (item.CompareTo(current.item) < 0)
                {
                    // 비교 노드가 왼쪽 자식이 있는 경우
                    if (current.left != null)
                    {
                        // 왼쪽 자식과 또 비교하기 위해 current를 왼쪽 자식으로 설정
                        current = current.left;
                    }
                    // 비교 노드가 왼쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리가 추가될 자리이다.
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 비교해서 더 큰 경우 오른쪽으로 감
                else if (item.CompareTo(current.item) > 0)
                {
                    // 비교 노드가 오른쪽 자식이 있는 경우
                    if (current.right != null)
                    {
                        // 오른쪽 자식과 또 비교하기 위해 current를 오른쪽 자식으로 설정
                        current = current.right;
                    }
                    // 비교 노드가 오른쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리가 추가될 자리이다.
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                {
                    return;
                }
            }
        }

        public class Node
        {
            internal T item;
            internal Node parent;
            internal Node left;
            internal Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }
        }
    }
}
