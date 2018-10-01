using System;
using System.Text;
using System.ComponentModel;

using CommonProject.Scenario.Datas.Steps;
using Manager.IHM.Tools;

namespace Manager.Scenario.Datas.Steps
{
    public class HangupStep : GenericHangupStep
    {
        public HangupStep()
            : base()
        {
        }

        public override Object ToGeneric()
        {
            GenericHangupStep temp = new GenericHangupStep();
            
            temp.NameId = this.NameId;
            temp.TesterDestination = this.TesterDestination;
            temp.TesterSource = this.TesterSource;
            temp.TimeOut = this.TimeOut;
            temp.NumStep = this.NumStep;

            return temp;
        }

        #region Override GenericStep Functions

        [BrowsableAttribute(false)]
        public override int  NameId
        {
            get
            {
                return base.NameId;
            }
            set
            {
                base.NameId = value;
            }
        }
        [BrowsableAttribute(false)]
        public override short NumStep
        {
            get
            {
                return base.NumStep;
            }
            set
            {
                base.NumStep = value;
            }
        }

        [CategoryAttribute("\t\tActeurs"), DescriptionAttribute("Testeur source exécutant le step")]
        [DisplayName("\tSource"), PropertyOrder(1)]
        [TypeConverter(typeof(PropertyGridConverterSourceActors))]
        public override string TesterSource
        {
            get
            {
                return base.TesterSource;
            }
            set
            {
                base.TesterSource = value;
            }
        }

        [CategoryAttribute("\t\tActeurs"), DescriptionAttribute("Testeur ou entité de destination du step")]
        [DisplayName("Destination"), PropertyOrder(2)]
        [TypeConverter(typeof(PropertyGridConverterDestinationActors))]
        public override string TesterDestination
        {
            get
            {
                return base.TesterDestination;
            }
            set
            {
                base.TesterDestination = value;
            }
        }


        [Category("\tParamètres"), DescriptionAttribute("Délais critique pour l'échec du step")]
        [DisplayName("TimeOut")]
        public override long TimeOut
        {
            get
            {
                return base.TimeOut;
            }
            set
            {
                base.TimeOut = value;
            }
        }

        #endregion
    }
}
