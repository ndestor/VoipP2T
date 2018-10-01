using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;

namespace Manager.Scenario.ResultDatas
{
    [XmlRoot("ResultScenario")]
    public class ScenarioResult
    {
        [XmlAttribute("Name")]      private String name = null;
        [XmlAttribute("BeginTime")] private DateTime beginTime = DateTime.MinValue;
        [XmlAttribute("HasCrashed")]private Boolean hasCrashed = false;
        [XmlAttribute("LogResult")] private String logResult = null;
        [XmlAttribute("Comments")]  private String comments = String.Empty;

        private Int16 idScenario;
        //Declaration d'une liste contenant les résultat des Steps du scenario
        private List<StepResult> listStepResults = new List<StepResult>(250);

        //Constructeurs
        public ScenarioResult(String _name,Int16 _idScenario)
        {
            name = _name;
            idScenario = _idScenario;
            hasCrashed = false;
        }
        public ScenarioResult()
        {
        }

        public void AddStepResults(StepResult value)
        {
            this.listStepResults.Add(value);
        }

        [XmlElement("stepsReults")]
        public virtual StepResult[] StepsResults
        {
            get
            {
                StepResult[] currentList = new StepResult[listStepResults.Count];
                listStepResults.CopyTo(currentList);
                return currentList;
            }
            set
            {
                if (value == null) return;
                StepResult[] currentList = (StepResult[])value;
                listStepResults.Clear();
                foreach (StepResult step in currentList)
                    listStepResults.Add(step);
            }
        }


        #region Accesseurs
       
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        public Boolean HasCrashed
        {
            get { return hasCrashed; }
            set { hasCrashed = value; }
        }
        public String LogResult
        {
            get { return logResult; }
            set { logResult = value; }
        }

        public Int16 IdScenario
        {
            get { return idScenario; }
            set { idScenario = value; }
        }

        public String Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        #endregion
    }
}
