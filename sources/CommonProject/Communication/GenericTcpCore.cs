/*
 * Copyright � 2007, Nicolas Destor
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
using System.Net;
using System.Net.Sockets;
using System.IO;



using CommonProject.Tools;

namespace CommonProject.Communication
{
    /// <summary>
    /// Handler g�rant l'�v�nement d'arriv� de donn�es
    /// </summary>
    public delegate void _TcpReceiveDataEvent(Object sender, String XMLdatas);

    /// <summary>
    /// Handler g�rant l'�v�nement d'arriv� de donn�es particuli�res (sc�nario)
    /// </summary>
    public delegate void _TcpReceiveSpecialDataEvent(Object sender, String XMLdatas);
    
    public class GenericTcpCore
    {
        private const int MAX_PACKET_SIZE = 500;
        private const String TERMINATION_STRING = "Chr(1)";

        //Nom donn� pour le testeur ou manager instanciant cette classe
        private String name = null;

        //Port TCP d'�coute ou de reception
        protected Int32 port;

        //Adresse IP du client ou serveur
        protected String ipAddress;

        //Variable utilis�e pour le stockage temporaire d'une donn�e en cours d'envois
        private String tempData = null;

        protected NetworkStream NS;
        //Proc�dure de finalisation d'une lecture
        private AsyncCallback procLecture;
        //proc�dure de finalisation d'une Ecriture
        private AsyncCallback procEcriture;
        //Zone m�moire tampon utilis�e pour la lecture et l'�criture
        private byte[] buffer;

        //Variable d'acc�s au fichier
        private Boolean isReceivingSpecialDatas = false;
        private String specialDatas = String.Empty;

        //Variables d'�tats de l'entit� (testeur ou manager) TCP
        private Boolean isConnected = false;
        protected String msg = null;

        //D�finition des �v�nements 
        public event _TcpReceiveDataEvent ReceiveDataEvent;
        public event _TcpReceiveSpecialDataEvent ReceiveSpecialDataEvent;
        public event _TcpNetworkStatusHandler TcpNetworkStatusEvent;

        public GenericTcpCore()
        {
            procEcriture = new AsyncCallback(this.EndWrite);
            procLecture = new AsyncCallback(this.EndRead);
            buffer = new byte[MAX_PACKET_SIZE];
        }

        /// <summary>
        /// M�thode permettant de r�-initialiser la connection server TCP 
        /// </summary>
        protected virtual void Reset()
        {
           isReceivingSpecialDatas = false;
           specialDatas = String.Empty;

           tempData = String.Empty;

           NS.Flush();
           NS.Close();
        }

        /// <summary>
        /// M�thode asynchrone attendant la r�ception de donn�es
        /// <summary>
        protected void WaitForData()
        {
            buffer = new byte[MAX_PACKET_SIZE];
            NS.BeginRead(buffer, 0, buffer.Length, procLecture, null);
        }
        
        #region Private Functions

        /// <summary>
        /// M�thode ex�cuter lors de la r�ception de donn�es (d�clenchement asynchrone)
        /// <summary>
        private void EndRead(IAsyncResult AR)
        {
            try
            {
                Trace.WriteDebug("Reception de donn�es en cours...");
                //Reception des donn�es
                int Noctets = NS.EndRead(AR);
                if (Noctets != 0)
                {
                    String datasArrival = Encoding.Unicode.GetString(buffer, 0, Noctets);

                    //Analyse des donn�es re�ues
                    ArrivalDatasParser(datasArrival);

                    //On reboucle 
                    WaitForData();
                }
                else
                {
                    IsConnected = false;
                    Trace.WriteInfo("Liaison TCP/IP interrompue");
                    msg = "Liaison TCP/IP interrompue";
                    OnTcpNetworkStatusChange(this, null);
                }
            }
            catch (Exception e)
            {
                IsConnected = false;
                msg = e.Message;
                OnTcpNetworkStatusChange(this, null);
            }
        }
        /// <summary>
        /// Analyse des donn�es et d�clenchement d'�v�nements
        /// <summary>
        private void ArrivalDatasParser(String data)
        {
            //si mode r�ception de de fichier
            if (isReceivingSpecialDatas)
            {
                Trace.WriteDebug("Reception d'un scenario");

                //Si dans le mot "endScenario" est pr�sent dans les donn��s re�ues
                if (data.Contains("Chr(1)"))
                {
                    //r�cup�ration de la fin du fichier
                    int index = data.IndexOf("Chr(1)");
                    tempData = data.Substring(0, index);

                    //Enregistrement dans la variable specialData                    
                    specialDatas += tempData;

                    //D�clenchement de l'�v�nement SpecialData Re�us
                    OnReceiveSpecialDataEvent(null, specialDatas);

                    //Mise � jours des variable de travail
                    isReceivingSpecialDatas = false;
                    specialDatas = null;
                    tempData = null;

                    //Si il reste des donn�es apr�s le s�parateur
                    if (index + "Chr(1)".Length < data.Length)
                    {
                        //R�cup�ration des donn�es restantes 
                        String newData = data.Substring(index + "Chr(1)".Length);

                        //Analyse des donn�es restantes
                        ArrivalDatasParser(newData);
                    }
                }

                else
                {
                    //Enregistrement dans la variable specialData
                    specialDatas += data;
                }
            }

            //Si les donn�es contenus un s�parateur
            else if (data.Contains("Chr(1)"))
            {
                //R�cup�ration les datas avant le s�parateur
                int index = data.IndexOf("Chr(1)");
                tempData += data.Substring(0, index);

                //
                switch (tempData)
                {
                    //case "beginFile": OnBeginFile(tempData.Substring(tempData.LastIndexOf("||")));  break;
                    case "beginScenario": isReceivingSpecialDatas = true; break;
                    case "endScenario": break;
                    default:
                        {
                            // On d�clenche l'�v�nement ReceiveDataEvents      
                            Trace.WriteDebug("Analyse des donn�es " + tempData);
                            OnReceiveDataEvent(null, tempData);
                            break;
                        }
                }

                tempData = null;

                //Si il reste des donn�es apr�s le s�parateur
                if (index + "Chr(1)".Length < data.Length)
                {
                    //R�cup�ration des donn�es restantes
                    String newData = data.Substring(index + "Chr(1)".Length);

                    //Analyse des donn�es restantes
                    ArrivalDatasParser(newData);
                }
            }
            else
            {
                //On m�morise le bout de donn�es restant
                tempData += data;
            }
        }

        /// <summary>
        /// M�thode ex�cuter � la fin d'�mission de donn�es (d�clenchement asynchrone)
        /// <summary>
        private void EndWrite(IAsyncResult AR)
        {
            NS.EndWrite(AR);
        }

        /// <summary>
        /// M�thode ex�cuter � la fin d'�mission d'un fichier (d�clenchement asynchrone)
        /// <summary>
        private void EndWriteFile(IAsyncResult AR)
        {
            NS.EndWrite(AR);
            procEcriture = new AsyncCallback(this.EndWrite);
        }

        #endregion

        #region Public Functions
        /// <summary>
        /// M�thode r�alisant l'envoi de donn�es
        /// <summary>
        public void SendString(String data)
        {
            try
            {
                System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();

                Byte[] values = new Byte[Byte.MaxValue];
                values = encoding.GetBytes(data + "Chr(1)");
                int nextBuf, totalSent = 0;

                if (NS.CanWrite)
                {
                    for (int indx = 0; indx < (values.GetLength(0)); indx += MAX_PACKET_SIZE)
                    {
                        try
                        {
                            //Ecriture des donn�es.
                            NS.Write(values, indx, nextBuf = indx + MAX_PACKET_SIZE < values.GetLength(0) ? MAX_PACKET_SIZE : values.GetLength(0) - indx);
                            totalSent += nextBuf;
                        }
                        catch (Exception e)
                        {
                            // Console.WriteLine("Impossible d'�crire");
                            throw e;
                        }
                    }
                }
                else
                {
                    Trace.WriteDebug(" L'�criture dans le buffer TCP d'un des testers � �chou�");
                }

                values = null;
            }
            catch (Exception e)
            {
                Trace.WriteError("Erreur lors de l'envois de donn�es");
                throw e;
            }
        }

        /// <summary>
        /// M�thode r�alisant l'envoi d'un sc�nario complet
        /// <summary>
        public void SendScenarioDatas(string _datas)
        {        
            SendString("beginScenario");
            SendString(_datas);
        }

        /// <summary>
        /// Retourne true si entit� connect�, false si non-connect�
        /// <summary>
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        /// <summary>
        /// Retourne un message (�tat de la communication)
        /// <summary>
        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        /// <summary>
        /// Retourne le nom du manageur ou testeur instanciant cette classe
        /// <summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Retourne le port d'�coute
        /// <summary>
        public Int32 Port
        {
            get { return port; }
            set { port = value; }
        }
        /// <summary>
        /// Retourne l'adresse IP source
        /// <summary>
        public String IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        #endregion

        #region Events Function

        protected virtual void OnReceiveSpecialDataEvent(Object sender, String XMLdatas)
        {
            if (ReceiveSpecialDataEvent != null)
            {
                ReceiveSpecialDataEvent(sender, XMLdatas);
            }
        }

        protected virtual void OnReceiveDataEvent(Object sender, String XMLdatas)
        {
            if (ReceiveDataEvent != null)
            {
                ReceiveDataEvent(sender, XMLdatas);
            }
        }

        protected virtual void OnTcpNetworkStatusChange(Object sender, EventArgs e)
        {
            if (TcpNetworkStatusEvent != null)
            {
                TcpNetworkStatusEvent(sender, e);
            }
        }

        #endregion

    }
}
