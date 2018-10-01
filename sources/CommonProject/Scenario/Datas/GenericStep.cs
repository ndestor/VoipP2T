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

namespace CommonProject.Scenario.Datas
{
    /// <summary>
    //Enumération des noms des steps
    /// <summary>
    public enum  StepsName
    {
        Appel = 0,
        DTMF = 1,
        Raccrochage = 2,
        Attente = 3
    }

    [XmlInclude(typeof(Steps.GenericCallStep)), XmlInclude(typeof(Steps.GenericHangupStep)),
     XmlInclude(typeof(Steps.GenericWaitStep)), XmlInclude(typeof(Steps.GenericDTMFStep))]

    /// <summary>
    /// Objet step généric
    /// Définit l'objet step commun entre le testeur et le manager.
    /// <summary>
    public class GenericStep
    {
        [XmlAttribute("Name")] protected int nameId;
        [XmlAttribute("numStep")] protected Int16 numStep;
        [XmlAttribute("testerSource")] protected String testerSource;
        [XmlAttribute("testerDestination")] protected String testerDestination;        
        [XmlAttribute("timeOut")] protected Int64 timeOut;
        
        public GenericStep()
        {
        }
        public GenericStep(int _nameId)
        {
            nameId = _nameId;
        }

        public virtual String TesterSource
        {
            get { return this.testerSource; }
            set { this.testerSource = value; }
        }
        public virtual String TesterDestination
        {
            get { return this.testerDestination; }
            set { this.testerDestination = value; }
        }
        public virtual Int64 TimeOut
        {
            get { return this.timeOut; }
            set { this.timeOut = value; }
        }
        public virtual int NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        public virtual Int16 NumStep
        {
            get { return numStep; }
            set { numStep = value; }
        }

        public virtual Object ToGeneric()
        {
            return null;
        }

    }
}
