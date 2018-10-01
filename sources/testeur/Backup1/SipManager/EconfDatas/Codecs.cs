using System;
using System.Collections.Generic;
using System.Text;

namespace Tester.SipManager.EconfDatas
{
    /// <summary>
    /// Type de configuration de codecs
    /// </summary>
    public enum CodecType
    {
        /// <summary>
        /// Par d�faut
        /// </summary>
        Default,
        /// <summary>
        /// Sp�cifique
        /// </summary>
        Specific,
        /// <summary>
        /// Un pool de codecs
        /// </summary>
        Pool
    }

    /// <summary>
	/// Classe d�terminant les codecs � activer/d�sactiver
	/// </summary>
	public class Codecs
	{
		private bool[] _Codecs;
		private CodecType _Type;
		private eConf.eCodecType _AudioCodec;
		private eConf.eCodecType _VideoCodec;
		/// <summary>
		/// Constructeur par d�faut
		/// </summary>
		public Codecs()
		{
            EconfClassPlayer.EConfPlayer.Instance.GetValidCodecs(out _Codecs);
		}
		/// <summary>
		/// Constructeur avec le tableau de bool�en
		/// </summary>
		/// <param name="codecs"></param>
		public Codecs(bool[] codecs)
		{
			_Codecs = codecs;
			_Type = CodecType.Pool;
		}
		/// <summary>
		/// Constructeur pour des codecs sp�cifiques
		/// </summary>
		/// <param name="audioCodec"></param>
		/// <param name="videoCodec"></param>
		public Codecs(eConf.eCodecType audioCodec , eConf.eCodecType videoCodec)
		{
			_AudioCodec = audioCodec;
			_VideoCodec = videoCodec;
			_Type = CodecType.Specific;
			//Table de booleen � true
            EconfClassPlayer.EConfPlayer.Instance.GetValidCodecs(out _Codecs);
		}
		/// <summary>
		/// Type de codec : pool, sp�cifique
		/// </summary>
	
		public CodecType Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}
	
		public bool[] Pool
		{
			get
			{
				return _Codecs;
			}
			set
			{
				_Codecs = value;
			}
		}
		/// <summary>
		/// Codec sp�cifique audio
		/// </summary>
		public eConf.eCodecType AudioCodec
		{
			get
			{
				return _AudioCodec;
			}
			set
			{
				_AudioCodec = value;
			}
		}
		/// <summary>
		/// Codec sp�cifique vid�o
		/// </summary>
		public eConf.eCodecType VideoCodec
		{
			get
			{
				return _VideoCodec;
			}
			set
			{
				_VideoCodec = value;
			}
		}
		/// <summary>
		/// overwrite le tostring
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _Type.ToString();
		}
	}
}
