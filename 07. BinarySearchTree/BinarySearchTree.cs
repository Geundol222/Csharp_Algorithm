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

        public bool Remove(T item)
        {
            Node findNode = FindNode(item);

            if (findNode == null)
                return false;
            else
            {
                EraseNode(findNode);
                return true;
            }
        }

        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);

            if (findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }

        private Node FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }

            Node current = root;
            while (current != null)
            {
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                {
                    // 왼쪽 자식부터 다시 찾기 시작
                    current = current.left;
                }
                // 현재 노드의 값이 찾고자 하는 값보다 큰 경우
                else if (item.CompareTo(current.item) > 0)
                {
                    // 오른쪽 자식부터 다시 찾기 시작
                    current = current.right;
                }
                // 현재 노드의 값이 찾고자 하는 값이랑 같은 경우
                else
                {
                    return current;
                }
            }
            return null;
        }

        private void EraseNode(Node node)
        {
            // 1. 자식 노드가 없는 노드일 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else // if (node.isRootNode)
                    root = null;
            }
            // 2. 자식 노드가 하나인 노드일 경우
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;

                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else // if (node.IsRootNode)
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 3. 자식 노드가 둘다 있는 노드일 경우
            // 왼쪽 자식 중 가장 큰값과 데이터 교환 후, 그 노드를 삭제하는 방식으로 대체한다.
            else // if (node.HasBothChild)
            {
                // 한번 왼쪽으로 간뒤 오른쪽으로 계속 이동하면서 왼쪽 자식 중 제일 큰값을 찾는다.
                Node replaceNode = node.left;
                while (replaceNode.right != null)
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);

                /* C#에서 쓰는 방법, 위의 결과와 동일하지만 방식의 차이만 있다.
                Node replaceNode = node.right;
                while (replaceNode.left != null)
                {
                    replaceNode = replaceNode.left;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);
                 */
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

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }
    }
}
