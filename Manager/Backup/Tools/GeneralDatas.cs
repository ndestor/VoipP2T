using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Tools
{
    /* Inutilisé pour le moment dans le projet */

    public class GeneralDatas
    {
        private const string version = "1.0";
        private Int16 nbTesters;
        private string lastScenarioPlayed;

        public String Version
        {
            get { return version; }
        }

        public Int16 NbTesters
        {
            get { return nbTesters; }
            set { nbTesters = value; }
        }

        public String LastScenarioPlayed
        {
            get { return lastScenarioPlayed; }
            set { lastScenarioPlayed = value; }
        }

    }
}
