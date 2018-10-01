using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Manager.IHM.Tools
{
    class PropertyGridConverterSourceActors : StringConverter
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
            return new StandardValuesCollection((MainEntry.listTesters.TestersName.ToArray()));
        }
    }
}
