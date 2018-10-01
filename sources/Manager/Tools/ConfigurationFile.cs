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
using System.Collections;
using System.Text;
using System.Xml;

namespace Manager.Tools
{
    class ConfigurationFile
    {
        public static void CreateManagerConfigurationFile()
        {
            try
            {
                //Creation du fichier XML - Declaration XML
                XmlTextWriter configuration = new XmlTextWriter("ConfigManager.xml", System.Text.Encoding.UTF8);
                //mise en Forme pour l'indentation
                configuration.Formatting = System.Xml.Formatting.Indented;
                configuration.Indentation = 2;
             
               
                //Debut du fichier xml
                configuration.WriteStartDocument();
                //Commentaire
                configuration.WriteComment("Fichier de configuration du Manager - Automate de Tests V1.0");
                //Creation de l'�l�ment racine du fichier
                configuration.WriteStartElement("Manager");

                //Param�tre g�n�rals
                configuration.WriteStartElement("GeneralParameters");
                configuration.WriteStartElement("GeneralParameters");
                configuration.WriteAttributeString("Name", "Manager");
                configuration.WriteEndElement();


                configuration.WriteEndElement();

                configuration.WriteStartElement("TesterParameters");

                //Testeur1
                configuration.WriteStartElement("Tester");
                configuration.WriteAttributeString("Name", "Tester1");
                configuration.WriteStartElement("NetworkInformations");
                configuration.WriteAttributeString("IPAdress", "172.20.14.75");
                configuration.WriteAttributeString("Port", "20000");
                configuration.WriteEndElement();
                configuration.WriteEndElement();

                //Testeur2
                configuration.WriteStartElement("Tester");
                configuration.WriteAttributeString("Name", "Tester2");
                configuration.WriteStartElement("NetworkInformations");
                configuration.WriteAttributeString("IPAdress", "172.20.14.76");
                configuration.WriteAttributeString("Port", "20000");
                configuration.WriteEndElement();
                configuration.WriteEndElement();

                //Testeur3
                configuration.WriteStartElement("Tester");
                configuration.WriteAttributeString("Name", "Tester3");
                configuration.WriteStartElement("NetworkInformations");
                configuration.WriteAttributeString("IPAdress", "172.20.14.77");
                configuration.WriteAttributeString("Port", "20000");
                configuration.WriteEndElement();
                configuration.WriteEndElement();


                //fermeture Fichier
                configuration.WriteEndElement();
                configuration.Flush();
                configuration.Close();

            }
            catch (Exception e)
            {
                CommonProject.Tools.Trace.WriteError(e.Message);

            }
        }

        public static void ReadManagerGeneralsParameters()
        {
            XmlDocument informations = new XmlDocument();
            informations.Load("ConfigManager.xml");
            XmlNodeList xnl_informations = informations.GetElementsByTagName("GeneralParameters");

        }

        public static Manager.Communication.TestersList ReadManagerConfigurationFile()
        {
            try
            {
                //ArrayList list = new ArrayList(); => Permet d'avoir un nombre de testeurs ind�finis


                Manager.Communication.TestersList list = new Manager.Communication.TestersList();


                XmlDocument testerConf = new XmlDocument();
                testerConf.Load("ConfigManager.xml");
                XmlNodeList xnl_testerConf = testerConf.GetElementsByTagName("Tester");
                foreach (XmlNode nodeTester in xnl_testerConf)
                {
                    Manager.Communication.Tester current = new Manager.Communication.Tester();
                    //R�cup�ration des donn�es
                    XmlAttribute name = nodeTester.Attributes[0];
                    XmlNode nodeNetwork = nodeTester.FirstChild;
                    XmlAttribute IpAdress = nodeNetwork.Attributes[0];
                    XmlAttribute Port = nodeNetwork.Attributes[1];
                    XmlAttribute SipNumber = nodeNetwork.Attributes[2];

                    //Affectation des donn�es r�cup�r�es                  
                    current.Name = name.Value.ToString();
                    current.IpAddress = IpAdress.Value.ToString();
                    current.Port = Convert.ToInt32(Port.Value);
                    current.Alias = SipNumber.Value.ToString();
                    list.AddTester(current);

                }
                return list;
            }
            catch (Exception e)
            {
                CommonProject.Tools.Trace.WriteError("Erreur Lors du chargement du fichier de configuration");
                CommonProject.Tools.Trace.WriteError(e.Message);
                return null;
            }
        }

    }
}

