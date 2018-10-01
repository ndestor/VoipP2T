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
using System.Collections;

namespace Manager.Communication
{

    /// <summary>
    //Classe comprenant une liste de testeurs disponibles par le manager
    /// <summary>  
    class TestersList 
    { 
        private List<Tester> listTesters= new List<Tester>(20);

        public Tester[] Tester
        {
            get
            {
                Tester[] tester = new Tester[listTesters.Count];
                listTesters.CopyTo(tester);
                return tester;
            }            
        }

        public void AddTester(Tester t)
        {
            t.Id = (short)listTesters.Count;           
            listTesters.Add(t);
        }

        public List<String> TestersName
        {
            get
            {
                List<String> testersName = new List<String>(listTesters.Count);
                foreach (Tester tester in listTesters)
                {
                    testersName.Add(tester.Name);
                }
                return testersName;
            }
        }


        public Int16 GetIdFromName(String name)
        {
            foreach (Tester t in listTesters)
            {
                if (t.Name == name)
                {
                    return t.Id;
                }
            }
            return 0;
        }

        public Tester GetTesterFromName(String name)
        {
            Tester tempTester = new Tester();
            foreach (Tester t in listTesters)
            {
                if (t.Name == name)
                {
                    tempTester = t;
                   
                }
            }
            return tempTester;
        }

        public String GetNameFromId(Int16 id)
        {
            foreach (Tester t in listTesters)
            {
                if (t.Id == id)
                {
                    return t.Name;
                }
            }
            return null;
        }


    }
}
