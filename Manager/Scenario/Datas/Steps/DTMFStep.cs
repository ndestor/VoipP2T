using System;
using System.Text;
using System.ComponentModel;

using CommonProject.Scenario.Datas.Steps;
using Manager.IHM.Tools;

namespace Manager.Scenario.Datas.Steps 
{
    public class DTMFStep : GenericDTMFStep
    {
        public DTMFStep()  : base ()
        {
        }

        public DTMFStep(DTMFSignalType _DTMFSignalType, DTMF _dtmf)
            : base(_DTMFSignalType, _dtmf)
        {
        }

        [CategoryAttribute("\tParam�tres"), DescriptionAttribute("Type de DTMF � envoy�: \n SIPInfoRFC2833 . Autres types possible...")]
        public override DTMFSignalType DTMFSignalType
        {
            get { return dtmfSignalType; }
            set { dtmfSignalType = value; }
        }

        [CategoryAttribute("\tParam�tres"), DescriptionAttribute("DTMF � envoy�")]
        public override DTMF DTMFVal
        {
            get { return dtmfVal; }
            set { dtmfVal = value; }
        }

        [CategoryAttribute("\tParam�tres"), DescriptionAttribute("Temps d'appuis � simuler sur la touche (en ms)")]
        public override int TapDuration
        {
            get { return tapDuration; }
            set { tapDuration = value; }
        }
        [CategoryAttribute("\tParam�tres"), DescriptionAttribute("Pause entre chaque envois de DTMF (en ms)")]
        public override int PauseBetweenTap
        {
            get { return pauseBetweenTap; }
            set { pauseBetweenTap = value; }
        }

        public override Object ToGeneric()
        {
            GenericDTMFStep temp = new GenericDTMFStep();
            temp.DTMFSignalType = this.DTMFSignalType;
            temp.DTMFVal = this.DTMFVal;            
            temp.PauseBetweenTap = this.PauseBetweenTap;
            temp.TapDuration = this.TapDuration;


            temp.NameId = this.NameId;
            temp.TesterDestination = this.TesterDestination;
            temp.TesterSource = this.TesterSource;
            temp.TimeOut = this.TimeOut;
            temp.NumStep = this.NumStep;

            return temp;
        }

        #region Override GenericStep Functions

        [BrowsableAttribute(false)]
        public override int NameId
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

        [CategoryAttribute("\t\tActeurs"), DescriptionAttribute("Testeur source ex�cutant le step")]
        [DisplayName("\tSource"),PropertyOrder(1)]
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

        [CategoryAttribute("\t\tActeurs"), DescriptionAttribute("Testeur ou entit� de destination du step")]
        [DisplayName("Destination"),PropertyOrder(2)]
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


        [Category("\tParam�tres"), DescriptionAttribute("D�lais critique pour l'�chec du step")]
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
