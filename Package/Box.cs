using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PavilionMonitor.Package
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Box
    {
        public abstract XmlElement toXmlElement(XmlDocument doc);
        public abstract string className();
    }
}
