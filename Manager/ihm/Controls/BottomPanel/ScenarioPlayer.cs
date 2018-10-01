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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using XPTable;
using XPTable.Editors;
using XPTable.Models;

namespace Manager.IHM.Controls.BottomPanel
{
    public partial class ScenarioPlayer : UserControl
    {
        private Int16 currentRowIndex = -1;
        private Int32 progressBarValue = 0;
        private Int32 indexOfStep = 0;


        //variable utilisé pour le timer
        private delegate void TimerLabelUpdateHandler(TimeSpan waitTime);
        private TimerLabelUpdateHandler TimerLabelUpdate;
        private Thread threadTimer;
        private DateTime lauchTime;

        public ScenarioPlayer()
        {
            InitializeComponent();

            this.table1.BeginUpdate();

            ImageColumn imageColumn = new ImageColumn("", 25);
            TextColumn OrderColumn = new TextColumn("Ordre", 60);
            //OrderColumn.Maximum = 500;
            //OrderColumn.ShowUpDownButtons = true;

            TextColumn nomColumn = new TextColumn("Nom", 130);
            nomColumn.Editable = false;
            ProgressBarColumn progressColumn = new ProgressBarColumn("Progress", 150);

            TextColumn etatColumn = new TextColumn("Etat", 190);
            
            etatColumn.Editable = false;
            progressColumn.DrawPercentageText = true;
            this.table1.ColumnModel = new ColumnModel(new Column[] { imageColumn,
                                                                     OrderColumn,
																	  nomColumn,
																	  progressColumn,			
                                                                      etatColumn														  
																	  });

            this.table1.EndUpdate();

            MainEntry._ScenarioEvents.NewScenarioToPlay += new EventHandler(_ScenarioEvents_NewScenarioToPlay);
            MainEntry._ScenarioEvents.PlayerStatus += new EventHandler(_ScenarioEvents_PlayerStatus);

            MainEntry._ScenarioEvents.ManagerStatus += new EventHandler(_ScenarioEvents_ManagerStatus);

            table1.CellClick += new XPTable.Events.CellMouseEventHandler(table1_CellClick);
            
            dateCheckBox.CheckedChanged+=new EventHandler(dateCheckBox_CheckedChanged);

            TimerLabelUpdate = new TimerLabelUpdateHandler(UpdateTimeLabel);

        }

        private void RefreshListView()
        {

            this.table1.TableModel.Rows.Clear();

            this.dateCheckBox.Checked=false;

            if (MainEntry.scenarioSolution != null)
            {
                //Remplissage de la listview 
                this.table1.BeginUpdate();
                this.table1.TableModel = new TableModel();
                Int16 index = 1;

                foreach (Scenario.Datas.Scenario s in MainEntry.scenarioSolution.ScenariosToPlay)
                {               
                    Cell Order = new Cell(index.ToString());
                    Order.Tag = "Order";
                    Cell[] cells = { new Cell("", global::Manager.Properties.Resources.circleBlue), new Cell(index.ToString()), new Cell(s.Name), new Cell("En Attente"), new Cell(0), new Cell("Arrêter"), new Cell("", false) };
                    Row row = new Row(cells);
                    row.Tag = s;
                    this.table1.TableModel.Rows.Add(row);
                    this.table1.TableModel.RowHeight = 21;
                    index++;
                }

                this.table1.EndUpdate();
            }
        }

        #region Table Events

        private void table1_CellClick(Object sender, XPTable.Events.CellMouseEventArgs e)
        {
            currentRowIndex = (Int16)e.Row;
        }
        

        private void _ScenarioEvents_ManagerStatus(Object sender, EventArgs e)
        {
            Manager.Scenario.ScenarioManager manager = (Manager.Scenario.ScenarioManager)sender;
            if(manager.IsPlaying)
            {
                UpButton.Enabled = false;
                DownButton.Enabled = false;
                deletteButton.Enabled = false;
            }
            else 
            {
                this.UpButton.Enabled = true;
                this.DownButton.Enabled = true;
                this.deletteButton.Enabled = true;
            }

        }

        private void _ScenarioEvents_NewScenarioToPlay(Object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void _ScenarioEvents_PlayerStatus(Object sender, EventArgs e)
        {
            Manager.Scenario.scenarioPlayer player = (Manager.Scenario.scenarioPlayer)sender;           
            indexOfStep++;
            Row currentRow = table1.TableModel.Rows[player.PlayIndex];           
            switch (player.Status)
            {
                case Manager.Scenario.ScenarioPlayerSatus.VerifyScenario:
                    {
                        progressBarValue = 100 / (player.TotalSteps);                        
                        break;            
                    }

                case Manager.Scenario.ScenarioPlayerSatus.error:
                    {
                        currentRow.Cells[4].Text = "Erreur : " + player.CrashMsg;
                        currentRow.Cells[0].Image = global::Manager.Properties.Resources.circleRed;
                        break;
                    }
                case Manager.Scenario.ScenarioPlayerSatus.played:
                    {
                        table1.TableModel.Rows[player.PlayIndex].Cells[4].Text = "Scenario Joué";
                        progressBarValue = 0;
                        indexOfStep = 0;
                        currentRow.Cells[0].Image = global::Manager.Properties.Resources.circleGreen;
                        break;
                    }
                case Manager.Scenario.ScenarioPlayerSatus.initTesters:
                    {
                        break;
                    }
                default:
                    {
                        table1.TableModel.Rows[player.PlayIndex].Cells[4].Text = "En cours de lecture";
                        currentRow.Cells[0].Image = global::Manager.Properties.Resources.circleYellow;
                        break;
                    }
            }
            //Mise à jour de la progressBar
            currentRow.Cells[3].Data = progressBarValue;
            progressBarValue = progressBarValue * indexOfStep;
        }
                
        private void UpButton_Click(object sender, EventArgs e)
        {
            if (currentRowIndex != 0 && currentRowIndex != -1)
            {
                MainEntry.scenarioSolution.InvertIndexToPlay(currentRowIndex, (Int16)(currentRowIndex-1));
                RefreshListView();
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (currentRowIndex != (Int16)(table1.RowCount - 1) && currentRowIndex!=-1)
            {
                MainEntry.scenarioSolution.InvertIndexToPlay(currentRowIndex, (Int16)(currentRowIndex + 1));
                RefreshListView();
            }
        }

        private void deletteButton_Click(object sender, EventArgs e)
        {
            if (currentRowIndex != -1)
            {
                MainEntry.scenarioSolution.RemoveScenarioToPlayer(currentRowIndex);
                RefreshListView();
            }
        }

        private void PlayScenario_Click(object sender, EventArgs e)
        {            
            if (MainEntry.scenarioSolution!=null && !MainEntry.scenarioManager.IsPlaying)
            {             
                if (dateCheckBox.Checked)
                {
                    lauchTime = new DateTime(datePicker2.Value.Year, datePicker2.Value.Month,
                    datePicker2.Value.Day, timePicker1.Value.Hour, timePicker1.Value.Minute, timePicker1.Value.Second);
                  threadTimer = new Thread(new ThreadStart(UpdateTimer));
                  threadTimer.Start();

                  //Update des forms
                  datePicker2.Enabled = false;
                  timePicker1.Enabled = false;
                }
                else
                {
                        // RefreshListView();
                    MainEntry.scenarioManager.Start();                    
                }
                
            }            
        }

        private void StopPlayer_Click(object sender, EventArgs e)
        {   
            MainEntry.scenarioManager.stop();
            this.RefreshListView();

            if (threadTimer != null)
            {
                threadTimer.Abort();
                threadTimer = null;
            }
            this.timeToWaitLabel.Text = "";
        }

        #endregion

        private void UpdateTimer()
        {
            Boolean isFinish=false;
            while (!isFinish)
            {
                TimeSpan newTime = lauchTime-DateTime.Now;
                if (newTime.TotalSeconds <=0)
                {
                    isFinish = true;
                    MainEntry.scenarioManager.Start();
                    this.TimerLabelUpdate.Invoke(TimeSpan.MinValue);
                }
                else
                {
                    this.TimerLabelUpdate.Invoke(newTime);
                    Thread.Sleep(6000);
                }
            }
       }

        private void dateCheckBox_CheckedChanged(Object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                datePicker2.Enabled = true;
                timePicker1.Enabled = true;
            }
            else
            {
                datePicker2.Enabled = false;
                timePicker1.Enabled = false;
            }
        }
        
        private void UpdateTimeLabel(TimeSpan _time)
        {
            String str;
            if (_time == TimeSpan.MinValue)
            {
                str = "";
            }
            else if (_time.Days <= 0 && _time.Hours <= 0)
            {
                str = _time.Minutes + "min avant lancement";              
            }
            else if(_time.Days <= 0)
            {
                str = _time.Hours + "h et " + _time.Minutes + "min avant lancement";
            }
            else
            {
                str = _time.Days + "j " + _time.Hours + "h et " + _time.Minutes + "min avant lancement";
            }
            this.timeToWaitLabel.Text = str;
        }
    }
}
