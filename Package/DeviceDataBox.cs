using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PavilionMonitor.Package
{
    public class DeviceDataBox : Box
    {
        public const string classNameString = "DeviceDataBox_Base";
        public DeviceDataBox()
        { }

        public override string className()
        {
            return classNameString;
        }

        public void load(string _systemId, string _cabId, string _devId, State _state,
            string _value, string _unit, string _paraLow, string _paraHigh, string _correctFactor)
        {
            systemId_ = _systemId;
            cabId_ = _cabId; //cab id
            devId_ = _devId; //device id
            state_ = _state; //device state
            value_ = _value; //real-time value of device
            unit_ = _unit; //unit of value
            parahigh = _paraHigh;//高阈值
            correctFactor = _correctFactor;//修正因子
            paralow = _paraLow;//低阈值
        }

        public override XmlElement toXmlElement(XmlDocument doc)
        {
            XmlElement element = doc.CreateElement(className());
            element.SetAttribute("systemId", systemId_);
            element.SetAttribute("cabId", cabId_);
            element.SetAttribute("devId", devId_);
            element.SetAttribute("state", state_.ToString());
            element.SetAttribute("value", value_);
            element.SetAttribute("unit", unit_);
            element.SetAttribute("highThreshold", parahigh);
            element.SetAttribute("lowThreshold", paralow);
            element.SetAttribute("factor", correctFactor);
            return element;
        }
        public string systemId
        {
            get { return systemId_; }
            set { systemId_ = value; }
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
        public State state
        {
            get { return state_; }
            set { state_ = value; }
        }
        public string value
        {
            get { return value_; }
            set { this.value_ = value; }
        }
        public string unit
        {
            get { return unit_; }
            set { unit_ = value; }
        }

        private string systemId_;
        private string cabId_;
        private string devId_;
        private State state_;
        private string value_;


        private string unit_;
        private string paralow;

        public string Paralow
        {
            get { return paralow; }
            set { paralow = value; }
        }
        private string parahigh;

        public string Parahigh
        {
            get { return parahigh; }
            set { parahigh = value; }
        }
        private String correctFactor;

        public String CorrectFactor
        {
            get { return correctFactor; }
            set { correctFactor = value; }
        }
  
    }
}
