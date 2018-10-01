using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Communication;
using CommonProject.Tools;

namespace Tester.Scenario
{
    public class ScenarioManager
    {
        private static ScenarioPlayer player;
        public int callId;

        #region Constructor

        public ScenarioManager()
        {
            player = null;
            //On s'enregistre aux événements
            Register();
        }

        #endregion

        #region Events

        private void OnStartScenarioOrder(Object sender)
        {
            if (player == null)
            {
                Trace.WriteDebug("Starting Scenario");
                player = new ScenarioPlayer();
            }
            else
            {
                Trace.WriteInfo("Une scenario est en cours de lecture");
            }
        }

        private void OnStopScenarioOrder(Object sender)
        {
            if (player != null)
            {
                Trace.WriteDebug("Libération du thread ScenarioPlayer");
                player.Dispose();
                player = null;
            }
        }

        #endregion

        #region Private functions

        private void Register()
        {
            MainEntry._serverEvent.StartScenarioEvent += new StartScenarioHandler(OnStartScenarioOrder);
            MainEntry._serverEvent.StopScenarioEvent += new StopScenarioHandler(OnStopScenarioOrder);
        }

        private void Unregister()
        {
            MainEntry._serverEvent.StartScenarioEvent -= new StartScenarioHandler(OnStartScenarioOrder);
            MainEntry._serverEvent.StopScenarioEvent -= new StopScenarioHandler(OnStopScenarioOrder);
        }

        #endregion

    }
}
