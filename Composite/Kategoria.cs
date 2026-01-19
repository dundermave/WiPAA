using System;
using System.Collections.Generic;

namespace Composite
{
    public interface IMenuNode
    {
        void Print(int indent);
    }

    // LIŚĆ
    public sealed class MenuItem : IMenuNode
    {
        private readonly string _title;

        public MenuItem(string title)
        {
            _title = title;
        }

        public void Print(int indent)
        {
            Console.WriteLine(new string(' ', indent) + "- " + _title);
        }
    }

    // KOMPOZYT
    public sealed class MenuSection : IMenuNode
    {
        private readonly string _title;
        private readonly List<IMenuNode> _children = new List<IMenuNode>();

        public MenuSection(string title)
        {
            _title = title;
        }

        public void Print(int indent)
        {
            Console.WriteLine(new string(' ', indent) + "[+] " + _title);

            foreach (var node in _children)
            {
                node.Print(indent + 2);
            }
        }

        public void Add(IMenuNode node)
        {
            _children.Add(node);
        }

        public void Remove(IMenuNode node)
        {
            _children.Remove(node);
        }
    }
}
