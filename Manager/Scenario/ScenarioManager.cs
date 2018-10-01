/*
 * Copyright © 2007, Nicolas Destor
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, 
 * are permitted provided that the following conditions are met:
 *
 *    - Redistributions of source code must retain the above copyright notice, 
 *      this list of conditions and the following disclaimer.
 * 
 *    - Redistributions in binary form must reproduce the above copyright notice, 
 *      this list of conditions and the following disclaimer in the documentation 
 *      and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
 * OF SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using CommonProject.Tools;

namespace Manager.Scenario
{
    /// <summary>
    /// Classe gérant la lecture d'un ensemble de scénario
    /// </summary>
    class ScenarioManager
    {       
        private scenarioPlayer player;
        private Thread threadScenarioPlayer=null;
        private Boolean isPlaying = false;

        #region Méthodes publiques

        /// <summary>
        /// Méthode activant le thread de lecture d'une liste de scénario (méthode PlayScenarioList() )
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
        /// Méthode stoppant le thread de lecture d'une liste de scénario (méthode PlayScenarioList() )
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
        /// Accesseurs vers l'état du thread PlayScenarioList (en cours de lecture ou arrêté)
        /// </summary>
        public Boolean IsPlaying
        {
            get { return isPlaying; }
        }

        #endregion

        #region Methodes privées

        /// <summary>
        /// Méthode asynchrone de lancement de la lecture d'une liste de scénario
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
