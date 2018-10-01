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
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CommonProject.Scenario.Datas.Steps
{

    /// <summary>
    /// Objet Callstep générique
    /// Définit l'objet CallStep commun entre le testeur et le manager.
    /// <summary>
    public class GenericCallStep : GenericStep
    {
        [XmlAttribute("CallType")] protected CallType callType;
        [XmlAttribute("Protocol")] protected CallProtocol protocol;
        [XmlAttribute("Alias")] protected String alias;
        [XmlAttribute("CallMode")] protected CallMode callMode;

        //Paramètres définissant les condition de réussite de l'appel
        [XmlAttribute("CallerIdentitie")] protected Boolean callerIdentitie=true;

        public GenericCallStep()
            : base((int)StepsName.Appel)
        {
            TimeOut = 20000;
        }
        
        public virtual CallType CallType
        {
            get { return callType; }
            set { callType = value; }
        }        
        public virtual String Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }
        public virtual CallProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        public virtual CallMode CallMode
        {
            get { return callMode; }
            set { callMode = value; }
        }      
        public virtual Boolean CallerIdentitie
        {
            get { return callerIdentitie; }
            set { callerIdentitie = value; }
        }
    }

#region Definition de type de données

    public  enum CallType { SipUri };
    public enum CallProtocol { Sip };
    public enum CallMode {Normal,OIR }
    public enum CallerIdentitie { Standart, Secret }    
    
#endregion
}
