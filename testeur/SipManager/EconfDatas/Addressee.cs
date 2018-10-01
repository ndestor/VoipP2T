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
using System.ComponentModel;


namespace Tester.SipManager.EconfDatas
{ 
	// This is a special type converter which will be associated with the Employee class.
	// It converts an Employee object to string representation for use in a property grid.
	internal class AddresseeConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
			if( destType == typeof(string) && value is Addressee )
			{
				// Cast the value to an Employee type
				Addressee addr = (Addressee)value;

				// Return department and department role separated by comma.
				return addr.Address;
			}
			return base.ConvertTo(context,culture,value,destType);
		}
	}

	/// <summary>
	/// Classe stockant les informations sur le destinataire
	/// </summary>
	[TypeConverter(typeof(AddresseeConverter))]
	public class Addressee
	{
		private string _Address;
		private eConf.eProtocol _Protocol;
		private eConf.eCallType _CallType;
		/// <summary>
		/// Constructeur
		/// </summary>
		/// <param name="address"></param>
		/// <param name="protocol"></param>
		/// <param name="callType"></param>
		public Addressee(string address, eConf.eProtocol protocol, eConf.eCallType callType)
		{
			_Address = address;
			_Protocol = protocol;
			_CallType = callType;
		}
		/// <summary>
		/// Adresse du destinataire
		/// </summary>
		public string Address
		{
			get
			{
				return _Address;
			}
			set
			{
				_Address = value;
			}
		}
		/// <summary>
		/// Protocole utilisé
		/// </summary>
		public eConf.eProtocol Protocol
		{
			get
			{
				return _Protocol;
			}
			set
			{
				_Protocol = value;
			}
		}
		/// <summary>
		/// Type d'adresse
		/// </summary>
		public eConf.eCallType CallType
		{
			get
			{
				return _CallType;
			}
			set
			{
				_CallType = value;
			}
		}
	}
}
