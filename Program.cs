using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var xmls = new List<XmlElement>
            {
                new XmlElement
                {
                    Name = "leaf 1"
                },
                new XmlElement
                {
                    Name = "branch 1",
                    ChildElements = new List<XmlElement>
                    {
                        new XmlElement
                        {
                            Name = "leaf 2"
                        }
                    }
                }
            };

            var root = new XmlElement(xmls)
            {
                Name = "root"
            };

            var x = root.DepthSearch();

            Console.WriteLine(x);
        }
    }

    public class XmlElement
    {
        public string Name { get; set; }
        public List<XmlElement> ChildElements { get; set; }

        public XmlElement(List<XmlElement> children)
        {
            ChildElements = children;
        }

        public XmlElement()
        {
            ChildElements = new List<XmlElement>();
        }

        public bool IsInvalid()
        {
            Console.WriteLine(Name);
            return false;
        }

        public bool DepthSearch()
        {
            return IsInvalid() || (ChildElements.Any() && ChildElements.Any(x => x.DepthSearch()));
        }
    }
}
