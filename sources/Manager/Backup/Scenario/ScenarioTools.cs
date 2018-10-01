using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas;
using Manager.Scenario.Datas.Steps;
using CommonProject.Scenario.Datas.Steps;

namespace Manager.Scenario
{
    /// <summary>
    /// Classe définissant le résutat d'une vérification de scénario
    /// </summary>
    public class VerifyResult
    {
        private Boolean isCorrect = true;
        private String[] LogErrors;

        public Boolean IsCorrect
        {
            get { return isCorrect; }
        }
    }

    static class ScenarioTools
    {
        /// <summary>
        /// Vérifie le contenue d'un scénario avant sa lecture
        /// </summary>
        public static VerifyResult VerifyScenario(Datas.Scenario scenario)
        {
            //Parcours de tous les steps pour le traitement
            foreach (GenericStep currentStep in scenario.Steps)
            {
                //On détermine le type de Step (Transformation à partir d'un String en Enum "StepsName"

                switch ((StepsName)currentStep.NameId)
                {
                    case StepsName.Appel:
                        {
                            CallStep _step = (CallStep)currentStep;
                            String newAlias = MainEntry.listTesters.Tester[MainEntry.listTesters.GetIdFromName(currentStep.TesterDestination)].Alias;

                            if (_step.CallMode == CallMode.OIR)
                            {
                                newAlias = "*31*" + newAlias;
                            }
                            if (_step.Protocol == CallProtocol.Sip)
                            {
                                newAlias = "sip:" + newAlias;
                            }

                            _step.Alias = newAlias;
                            Console.WriteLine(_step.Alias);
                            break;
                        }

                    case StepsName.Attente:
                        {
                            break;
                        }

                    case StepsName.DTMF:
                        {
                            break;
                        }
                    case StepsName.Raccrochage:
                        {
                            break;
                        }
                }

            }


            VerifyResult result = new VerifyResult();
            return result;
        }

        /// <summary>
        /// Récupère la liste des testeurs acteurs du scénario
        /// </summary>rioPlayer
        public static List<short> GetActorsOfScenario(Datas.Scenario _scenario)
        {
            Boolean newActor = true;
            List<short> finalList = new List<short>();

            List<short> tempList = new List<short>();
            
            //On regroupe tout les IDs des testeurs destinations et sources dans un tableau
            foreach (CommonProject.Scenario.Datas.GenericStep step in _scenario.Steps)
            {
                tempList.Add(MainEntry.listTesters.GetIdFromName(step.TesterSource));
                tempList.Add(MainEntry.listTesters.GetIdFromName(step.TesterDestination));
            }
            //Filtrage des IDs distinct 
            foreach (short t_id in tempList)
            {
                newActor = true;
                foreach (short id in finalList)
                {
                    if (id == t_id) { newActor = false; }
                }
                if (newActor) finalList.Add(t_id);
            }
            return finalList;
        }

    }
}
