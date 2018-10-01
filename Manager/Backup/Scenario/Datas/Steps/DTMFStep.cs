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

        [CategoryAttribute("\tParamètres"), DescriptionAttribute("Type de DTMF à envoyé: \n SIPInfoRFC2833 . Autres types possible...")]
        public override DTMFSignalType DTMFSignalType
        {
            get { return dtmfSignalType; }
            set { dtmfSignalType = value; }
        }

        [CategoryAttribute("\tParamètres"), DescriptionAttribute("DTMF à envoyé")]
        public override DTMF DTMFVal
        {
            get { return dtmfVal; }
            set { dtmfVal = value; }
        }

        [CategoryAttribute("\tParamètres"), DescriptionAttribute("Temps d'appuis à simuler sur la touche (en ms)")]
        public override int TapDuration
        {
            get { return tapDuration; }
            set { tapDuration = value; }
        }
        [CategoryAttribute("\tParamètres"), DescriptionAttribute("Pause entre chaque envois de DTMF (en ms)")]
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

        [CategoryAttribute("\t\tActeurs"), DescriptionAttribute("Testeur source exécutant le step")]
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

        [CategoryAttribute("\t\tActeurs"), DescriptionAttribute("Testeur ou entité de destination du step")]
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
