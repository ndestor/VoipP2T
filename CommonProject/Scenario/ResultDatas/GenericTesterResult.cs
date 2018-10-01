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

using System.Xml.Serialization;

using CommonProject.Scenario.ResultDatas.Steps;

namespace CommonProject.Scenario.ResultDatas
{
    [XmlInclude(typeof(GenericCallResult)), XmlInclude(typeof(GenericDTMFResult)),
    XmlInclude(typeof(GenericHangupResult))]

    /// <summary>
    /// Objet CallResult générique
    /// Définit l'objet TesterResult commun entre le testeur et le manager.
    /// Cet objet contient la réponse d'un testeur après la lecture d'un step
    /// <summary>
    public class GenericTesterResult
    {
        [XmlAttribute("Status")]private TestStatus status;
        [XmlAttribute("Msg")]private List<String> listMsg =  new List<string>(20);        
        [XmlAttribute("Datas")]private Object datas=null;

        public GenericTesterResult()
        {
            status= TestStatus.Unknown;   
            datas=null;
        }

        public GenericTesterResult(TestStatus _status, List<String> _listMsg)
        {
            status = _status;
            listMsg = _listMsg;
        }             

        public GenericTesterResult(TestStatus _status, List<String> _listMsg, Object _datas)
        {
            status = _status;
            listMsg = _listMsg;          
            datas = _datas;
        }

        public TestStatus Status
        {
            get { return status; }
            set { status = value; }
        }                
       
      
        public List<String> Msg
        {
            get { return listMsg; }
            set { listMsg = value; }
        }

        public void AddMsg(String _msg)
        {
            listMsg.Add(_msg);
        }

        /// <summary>
        /// L'objet Data contient le résultat d'un step (CallResult,DTMFResult,HangupResult, etc...)
        /// <summary>
        public Object Datas
        {
            get { return datas; }
            set { datas = value; }
        }
    }
}
