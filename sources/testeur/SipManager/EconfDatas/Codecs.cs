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

namespace Tester.SipManager.EconfDatas
{
    /// <summary>
    /// Type de configuration de codecs
    /// </summary>
    public enum CodecType
    {
        /// <summary>
        /// Par défaut
        /// </summary>
        Default,
        /// <summary>
        /// Spécifique
        /// </summary>
        Specific,
        /// <summary>
        /// Un pool de codecs
        /// </summary>
        Pool
    }

    /// <summary>
	/// Classe déterminant les codecs à activer/désactiver
	/// </summary>
	public class Codecs
	{
		private bool[] _Codecs;
		private CodecType _Type;
		private eConf.eCodecType _AudioCodec;
		private eConf.eCodecType _VideoCodec;
		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		public Codecs()
		{
            EconfClassPlayer.EConfPlayer.Instance.GetValidCodecs(out _Codecs);
		}
		/// <summary>
		/// Constructeur avec le tableau de booléen
		/// </summary>
		/// <param name="codecs"></param>
		public Codecs(bool[] codecs)
		{
			_Codecs = codecs;
			_Type = CodecType.Pool;
		}
		/// <summary>
		/// Constructeur pour des codecs spécifiques
		/// </summary>
		/// <param name="audioCodec"></param>
		/// <param name="videoCodec"></param>
		public Codecs(eConf.eCodecType audioCodec , eConf.eCodecType videoCodec)
		{
			_AudioCodec = audioCodec;
			_VideoCodec = videoCodec;
			_Type = CodecType.Specific;
			//Table de booleen à true
            EconfClassPlayer.EConfPlayer.Instance.GetValidCodecs(out _Codecs);
		}
		/// <summary>
		/// Type de codec : pool, spécifique
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
		/// Codec spécifique audio
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
		/// Codec spécifique vidéo
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
