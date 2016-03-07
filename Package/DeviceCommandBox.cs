using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PavilionMonitor.Package
{
    public class DeviceCommandBox : Box
    {
        public const string classNameString = "DeviceCommandBox";
        public DeviceCommandBox()
        { }

        public override string className()
        {
            return classNameString;
        }

        public void load(string _devId, string _cabId, string _command,
            string _value)
        {
            devId_ = _devId;
            cabId_ = _cabId;
            command_ = _command;
            value_ = _value;
        }

        public void fromXmlElement(XmlElement element)
        {
            devId_ = element.GetAttribute("devId");
            cabId_ = element.GetAttribute("cabId");
            command_ = element.GetAttribute("command");
            value_ = element.GetAttribute("value");
        }

        public override XmlElement toXmlElement(XmlDocument doc)
        {
            XmlElement element = doc.CreateElement(className());
            element.SetAttribute("devId", devId_);
            element.SetAttribute("cabId", cabId_);
            element.SetAttribute("command", command_);
            element.SetAttribute("value", value_);
            return element;
        }

        public string devId
        {
            get { return devId_; }
            set { devId_ = value; }
        }
        public string cabId
        {
            get { return cabId_; }
            set { cabId_ = value; }
        }
        public string command
        {
            get { return command_; }
            set { command_ = value; }
        }
        public string value
        {
            get { return value_; }
            set { this.value_ = value; }
        }

        private string devId_;
        private string cabId_;
        private string command_;
        private string value_;
    }
}
