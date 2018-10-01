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
