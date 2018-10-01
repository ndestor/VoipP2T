using System;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CommonProject.Scenario.Datas.Steps
{
    /// <summary>
    /// Objet DTMFStep générique
    /// Définit l'objet DTMFStep commun entre le testeur et le manager.
    /// <summary>
    public class GenericDTMFStep : GenericStep
    {
        [XmlAttribute("DTMFSignalType")]protected DTMFSignalType dtmfSignalType;
        [XmlAttribute("DTMFVal")]protected DTMF dtmfVal;       
        [XmlAttribute("TapDuration")]protected int tapDuration; 
        [XmlAttribute("PauseBetweenTap")]protected int pauseBetweenTap; 

        //Constructeurs
        public GenericDTMFStep()
            : base((int)StepsName.DTMF)
        {
            tapDuration = 200;
            pauseBetweenTap = 200;
            TimeOut = 20000;
            
        }

        public GenericDTMFStep(DTMFSignalType _dtmfSignalType, DTMF _dtmfVal)
            : base((int)StepsName.DTMF)
        {            
            dtmfSignalType = _dtmfSignalType;
            dtmfVal = _dtmfVal;            
            tapDuration = 200;
            pauseBetweenTap = 200;
        }

        public virtual DTMFSignalType DTMFSignalType
        {
            get { return dtmfSignalType; }
            set { dtmfSignalType = value; }
        }

        public virtual DTMF DTMFVal
        {
            get { return dtmfVal; }
            set { dtmfVal = value; }
        }

        public virtual int TapDuration
        {
            get { return tapDuration; }
            set { tapDuration = value; }
        }

        public virtual int PauseBetweenTap
        {
            get { return pauseBetweenTap; }
            set { pauseBetweenTap = value; }
        }
      
    }
    
}

#region Definition de type de données

    public enum DTMFSignalType
    {
        Audio,
        Numeric,
        SipInfoRFC2833,
        SIPInfoRelay
    }

    /// <summary>
    /// Valeur possible pour un DTMF
    /// </summary>
    public enum DTMF
    {
        /// <summary>
        /// 1
        /// </summary>
        DTMF_1,
        /// <summary>
        /// 2
        /// </summary>
        DTMF_2,
        /// <summary>
        /// 3
        /// </summary>
        DTMF_3,
        /// <summary>
        /// 4
        /// </summary>
        DTMF_4,
        /// <summary>
        /// 5
        /// </summary>
        DTMF_5,
        /// <summary>
        /// 6
        /// </summary>
        DTMF_6,
        /// <summary>
        /// 7
        /// </summary>
        DTMF_7,
        /// <summary>
        /// 8
        /// </summary>
        DTMF_8,
        /// <summary>
        /// 9
        /// </summary>
        DTMF_9,
        /// <summary>
        /// 0
        /// </summary>
        DTMF_0,
        /// <summary>
        /// *
        /// </summary>
        DTMF_Asterix,
        /// <summary>
        /// 2
        /// </summary>
        DTMF_Sharp,
        /// <summary>
        /// A
        /// </summary>
        DTMF_A,
        /// <summary>
        /// B
        /// </summary>
        DTMF_B,
        /// <summary>
        /// C
        /// </summary>
        DTMF_C,
        /// <summary>
        /// D
        /// </summary>
        DTMF_D
    }
#endregion