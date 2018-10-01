using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using CommonProject.Tools;

namespace Manager.Scenario
{

    public delegate void _CloseScenarioResult(int _IndexTabPage, EventArgs e);

    /// <summary>
    /// Classe surveillant les process exécuté sur le Manager (création de scénario, lecture, etc...).
    /// </summary>

    public class ScenarioEvents
    {
        #region Manager EventHandler
        /// <summary>
        /// Handler gérant l'événement de création d'un scénario
        /// </summary>
        public event EventHandler NewScenario;
        /// <summary>
        /// Handler gérant l'événement de création d'un nouveau step
        /// </summary>
        public event EventHandler NewStep;
        /// <summary>
        /// Handler gérant l'événement de changement de status du scénario en cours de lecture 
        /// </summary>
        public event EventHandler PlayerStatus;
        /// <summary>
        /// Handler gérant l'événement d'état du manager (lecture d'un scénario ou au repos)
        /// </summary>
        public event EventHandler ManagerStatus;
        /// <summary>
        /// Handler gérant l'événement de création d'un résultat d'un scénario
        /// </summary>
        public event EventHandler NewScenarioResult;
        /// <summary>
        /// Handler gérant l'événement de sélection d'un scénario par l'utilisateur (clic dans le treeview de gauche uniquement)
        /// </summary>
        public event EventHandler SelectScenarioEvent;
        /// <summary>
        /// Handler gérant l'événement de création d'une solution de scénario
        /// </summary>
        public event EventHandler NewScenarioSolution;
        /// <summary>
        /// Handler gérant l'événement de l'ajout d'un scénario à jouer
        /// </summary>
        public event EventHandler NewScenarioToPlay;
        /// <summary>
        /// Handler gérant l'événement d'arrivée ou de création de nouvelles données à enregistrer
        /// </summary>
        public event EventHandler NewRecordableDatas;
        /// <summary>
        /// Handler gérant l'événement de l'arrivé d'une fiche résultat d'un scénario à afficher
        /// </summary>
        public event EventHandler NewScenarioResultToView;
        /// <summary>
        /// Handler gérant l'événement de la fermeture d'une fiche résultat
        /// </summary>
        public event _CloseScenarioResult CloseScenarioResult;

        #endregion 

        /* Pour tous les événements ci dessous, l'objet sender est instancié avec l'objet 
         * à l'origine de l'événement.
         * Exemple : Pour l'événement "NewScenario", le sender correspond à l'objet scenario 
         * venant d'être créé.
         */

        public virtual void OnNewRecordableDatas(object sender, EventArgs e)
        {
            if (NewRecordableDatas != null)
            {
                NewRecordableDatas(sender, e);
            }
        }

        public virtual void OnNewScenarioToPlay(object sender, EventArgs e)
        {
            if (NewScenarioToPlay != null)
            {
                NewScenarioToPlay(sender, e);
            }
        }

        public virtual void OnNewScenario(object sender, EventArgs e)
        {
            if (NewScenario != null)
            {
                NewScenario(sender, e);
            }
        }

        public virtual void OnNewStep(object sender, EventArgs e)
        {
            if (NewStep != null)
            {
                NewStep(sender, e);
            }
        }

        public virtual void OnNewScenarioSolution(object sender, EventArgs e)
        {
            if (NewScenarioSolution != null)
            {
                NewScenarioSolution(sender, e);
            }
        }

        public void OnSelectScenarioEvent(object sender, EventArgs e)
        {
            if (SelectScenarioEvent != null)
            {
                SelectScenarioEvent(sender, e);
            }
        }

        public void OnPlayerStatusChange(object sender, EventArgs e)
        {
            if (PlayerStatus != null)
            {
                PlayerStatus(sender, e);
            }
        }

        public void OnNewScenarioResult(object sender, EventArgs e)
        {
            if (NewScenarioResult != null)
            {
                NewScenarioResult(sender, e);
            }
        }             

        public virtual void OnManagerStatusChange(object sender, EventArgs e)
        {
            if (ManagerStatus != null)
            {
                ManagerStatus(sender, e);
            }
        }

        public virtual void OnNewScenarioResultToView(object sender, EventArgs e)
        {
            if (NewScenarioResultToView != null)
            {
                NewScenarioResultToView(sender, e);
            }
        }

        public virtual void OnCloseScenarioResult(int _IndexTabPage, EventArgs e)
        {
            if (CloseScenarioResult != null)
            {
                CloseScenarioResult(_IndexTabPage, e);
            }
        }
    }
}
