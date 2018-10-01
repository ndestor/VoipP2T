using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using CommonProject.Tools;

namespace Manager.Scenario
{
    /// <summary>
    /// Classe g�rant la lecture d'un ensemble de sc�nario
    /// </summary>
    class ScenarioManager
    {       
        private scenarioPlayer player;
        private Thread threadScenarioPlayer=null;
        private Boolean isPlaying = false;

        #region M�thodes publiques

        /// <summary>
        /// M�thode activant le thread de lecture d'une liste de sc�nario (m�thode PlayScenarioList() )
        /// </summary>
        public void Start()
        {
            if (!isPlaying)
            {
                //On lance le thread PlayScenarioList          
                isPlaying = true;               
                threadScenarioPlayer = new Thread(new ThreadStart(PlayScenarioList));                
                threadScenarioPlayer.Start();
                MainEntry._ScenarioEvents.OnManagerStatusChange(this, null);
            }
            else
            {
                Trace.WriteInfo("Un scenario est en cours de lecture");
            }
        }

        /// <summary>
        /// M�thode stoppant le thread de lecture d'une liste de sc�nario (m�thode PlayScenarioList() )
        /// </summary>
        public void stop()
        {
            isPlaying = false;
            if (threadScenarioPlayer!=null)
            {
                player.StopScenario();
                threadScenarioPlayer.Abort();
                threadScenarioPlayer = null;
            }
            MainEntry._ScenarioEvents.OnManagerStatusChange(this, null);
        }

        

        /// <summary>
        /// Accesseurs vers l'�tat du thread PlayScenarioList (en cours de lecture ou arr�t�)
        /// </summary>
        public Boolean IsPlaying
        {
            get { return isPlaying; }
        }

        #endregion

        #region Methodes priv�es

        /// <summary>
        /// M�thode asynchrone de lancement de la lecture d'une liste de sc�nario
        /// </summary>
        private void PlayScenarioList()
        {
            Int16 index = 0;
            foreach (Datas.Scenario scenario in MainEntry.scenarioSolution.ScenariosToPlay)
            {
                //On lance la lecture du scenario
                player = new scenarioPlayer(index, scenario);
                player.PlayScenario();
                index++;
            }
            isPlaying = false;
            MainEntry._ScenarioEvents.OnManagerStatusChange(this, null);
        }

        #endregion      
    }
}
