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
using System.Windows.Forms;

namespace Manager.IHM.Tools
{
    public class FileFunctions
    {
        /// <summary>
        //Fonction chargement de fichier
        /// <summary>  
        public static void LoadFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
           
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "Fichier scenario (*.ats)|*.ats|Fichier solution (*.atp)|*.atp";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                String extension = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
                if (extension == ".atp")
                {
                    if (MainEntry.scenarioSolution != null)
                    {
                        if (MessageBox.Show(" La solution actuelle va être fermée. Voulez-vous enregistrer les modifications apportées à la solution actuelle ?",
                            "Enregistrer la solution",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            MainEntry.scenarioSolution.SaveSolution();
                        }
                    }

                    MainEntry.scenarioSolution = new Manager.Scenario.ScenarioSolution(openFileDialog1.FileName);
                    MainEntry._ScenarioEvents.OnNewScenarioSolution(MainEntry.scenarioSolution, null);
                }

                if (extension == ".ats")
                {
                    if (MainEntry.scenarioSolution == null)
                    {
                        MessageBox.Show("Ouverture impossible! Veuillez auparavant ouvrir une solution.",
                            "Ouverture de scenario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MainEntry.scenarioSolution.AddScenario(new Manager.Scenario.Datas.Scenario(openFileDialog1.FileName));
                    }
                }
            }
        }
    }
}
