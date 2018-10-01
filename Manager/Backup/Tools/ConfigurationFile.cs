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
                //Creation de l'élément racine du fichier
                configuration.WriteStartElement("Manager");

                //Paramètre générals
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
                //ArrayList list = new ArrayList(); => Permet d'avoir un nombre de testeurs indéfinis


                Manager.Communication.TestersList list = new Manager.Communication.TestersList();


                XmlDocument testerConf = new XmlDocument();
                testerConf.Load("ConfigManager.xml");
                XmlNodeList xnl_testerConf = testerConf.GetElementsByTagName("Tester");
                foreach (XmlNode nodeTester in xnl_testerConf)
                {
                    Manager.Communication.Tester current = new Manager.Communication.Tester();
                    //Récupération des données
                    XmlAttribute name = nodeTester.Attributes[0];
                    XmlNode nodeNetwork = nodeTester.FirstChild;
                    XmlAttribute IpAdress = nodeNetwork.Attributes[0];
                    XmlAttribute Port = nodeNetwork.Attributes[1];
                    XmlAttribute SipNumber = nodeNetwork.Attributes[2];

                    //Affectation des données récupérées                  
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

