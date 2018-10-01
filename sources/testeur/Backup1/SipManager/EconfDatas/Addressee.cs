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
