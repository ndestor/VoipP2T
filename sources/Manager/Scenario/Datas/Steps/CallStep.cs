using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas.Steps;
using Manager.IHM.Tools;

using System.ComponentModel;

namespace Manager.Scenario.Datas.Steps
{
    public class CallStep : GenericCallStep
    {
        [BrowsableAttribute(false)]
        public override CallType CallType
        {
            get
            {
                return base.CallType;
            }
            set
            {
                base.CallType = value;
            }
        }

        [BrowsableAttribute(false)]
        public override String Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }

        [Category("\tParamètres"), DescriptionAttribute("Protocol utilisé pour l'appel : SIP.")]
        [DisplayName("Protocole")]
        public override CallProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        [Category("\tParamètres"), DescriptionAttribute("Mode d'appel : Normal (présentation du numéro) ou OIR (Secret)")]
        [DisplayName("Mode d'appel")]
        public override CallMode CallMode
        {
            get { return callMode; }
            set { callMode = value; }
        }

        [CategoryAttribute("Conditions de réussite"), DescriptionAttribute("Présentation du numéro sur l'appelant")]
        [DisplayName("Présentation du numéro")]
        public override Boolean CallerIdentitie
        {
            get { return callerIdentitie; }
            set { callerIdentitie = value; }
        }

        public override Object ToGeneric()
        {
            GenericCallStep temp = new GenericCallStep();
            temp.Alias = this.Alias;
            temp.CallerIdentitie = this.CallerIdentitie;            
            temp.CallMode = this.CallMode;
            temp.CallType = this.CallType;
            temp.Protocol = this.Protocol;

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
