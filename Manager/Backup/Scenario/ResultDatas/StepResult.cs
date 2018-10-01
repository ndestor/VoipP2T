using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;

using CommonProject.Scenario.ResultDatas;

namespace Manager.Scenario.ResultDatas
{
    [XmlInclude(typeof(GenericTesterResult))]
    public class StepResult
    {         
        [XmlAttribute("NameId")]private int nameId;         
        [XmlAttribute("NumStep")]private Int32 numStep; 
        [XmlAttribute("Status")]private TestStatus status;
        [XmlAttribute("StartTime")]private DateTime startTime = DateTime.MinValue;
        [XmlAttribute("Msg")]private String msg = null;
        [XmlAttribute("CrashExeption")]private String crashExeption = null;
        
        private List<GenericTesterResult> testersResults = new List<GenericTesterResult>(2);

        /// <summary>
        /// Constructeur
        /// </summary>
        public StepResult(int _nameid, Int32 _numStep,
            TestStatus _status, DateTime _startTime,String _msg)
        {
            NameId = _nameid;
            NumStep = _numStep;
            Status = _status;
            StartTime = _startTime;
            msg = _msg;
        }
        /// <summary>
        /// Constructeur avec exeption
        /// </summary>
        public StepResult(int _nameid, Int32 _numStep,
          TestStatus _status, DateTime _startTime, String _msg, String _crashExeption)
        {
            NameId = _nameid;
            NumStep = _numStep;
            Status = _status;
            StartTime = _startTime;
            msg = _msg;
            CrashExeption = _crashExeption;
        }

        public StepResult()
        {

        }

        #region Accesseurs

        public int NameId
        {
            get { return nameId; }
            set { nameId = value; }
        }

        public Int32 NumStep
        {
            get { return numStep; }
            set { numStep = value; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public String CrashExeption
        {
            get { return crashExeption; }
            set { crashExeption = value; }
        }

        public TestStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        [XmlElement("TestersResults")]
        public virtual GenericTesterResult[] TestersResults
        {
            get
            {
                GenericTesterResult[] list = new GenericTesterResult[2];                
                testersResults.CopyTo(list);               
                return list;
            }
            set
            {
                if (value == null) return;
                GenericTesterResult[] list = (GenericTesterResult[])value;  
                testersResults.Clear();
                foreach (GenericTesterResult result in list)
                    testersResults.Add(result);
            }
        }
        #endregion
    }
}
