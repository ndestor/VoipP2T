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
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections;

using CommonProject.Scenario.Datas;
using CommonProject.Tools;
using CommonProject.Communication;


namespace Manager
{    
     class MainEntry
     {
        #region Globals Datas

        //Declaration de la solution des scenarios
        public static Manager.Scenario.ScenarioSolution scenarioSolution=null ;

        //Declaration du contrôleur d'événements pour les scenarios
        public static Scenario.ScenarioEvents _ScenarioEvents = new Manager.Scenario.ScenarioEvents();
                  
        //Declaration de la liste des terminaux
        public static Manager.Communication.TestersList listTesters = new Manager.Communication.TestersList();

        //Declaration du contrôleur d'événements pour les communication Manager-Testeurs
        public static Communication.TcpEvents _TcpEvents = new Manager.Communication.TcpEvents();

        //Declaration du scenarioManager pour la lecture des scenarios
        public static Scenario.ScenarioManager scenarioManager = new Manager.Scenario.ScenarioManager();
         
        //Declaration de la variable d'accés à l'IHM
        public static IHM.Forms.MainForm ihm;

        #endregion

        #region Pour affichage de la console
        //Console
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        #endregion

        #region Main function
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Trace._Level = TraceLevel.Verbose;
           if (AllocConsole())
            {
                CommonProject.Tools.Trace.WriteInfo("The console is open.");
            }        
            InitProgram();          
            
            if (true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ihm = new Manager.IHM.Forms.MainForm();
                Application.Run(ihm);
            }
        }
        #endregion

        #region Private functions

        private static void InitProgram(){
            
            try
            {
                //Instatiation de la liste des testeurs - Fait dans la fonction ReadManagerConfigurationFile()
                listTesters=Manager.Tools.ConfigurationFile.ReadManagerConfigurationFile();                
            }
            catch(Exception e){
                Console.WriteLine("InitProgram: Erreur lors de l'appel à ReadManagerConfigurationFile() => Vérifier votre de fichier de configuration");                  
            }           
           
            try
            {
                //Essai de Connection aux testeur
                foreach (Communication.Tester current in listTesters.Tester)
                {
                   // current.ConnectToTester();                    
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("InitProgram: Erreur Lors de l'essai de connection aux testeurs");           
            }

            _TcpEvents = new Manager.Communication.TcpEvents();

            try
            {
               // scenario.Init();
            }
            catch(Exception e)
            {
            }
            //return true;
        }

        #endregion
    }
}