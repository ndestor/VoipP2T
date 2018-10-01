using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Manager.IHM.Tools
{
    class PropertyGridConverterDestinationActors : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, but allow free-form

            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<String> units = new List<string>();

            units = MainEntry.listTesters.TestersName;
            //Exemple : On ajoute un autre tableau (liste des CallServers)
            //units.InsertRange(units.Count-1,RemoteUnits.remoteUnits);
            return new StandardValuesCollection(units.ToArray());
        }
    }
}

