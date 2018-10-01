using System;
using System.Collections.Generic;
using System.Text;

namespace Tester.SipManager.EconfDatas
{
    public enum MediaStreamType
    {
        /// <summary>
        /// Locale
        /// </summary>
        Local,
        /// <summary>
        /// Distant
        /// </summary>
        Remote
    }


    public enum RecordType
    {
        /// <summary>
        /// Les deux flux
        /// </summary>
        MS_CONF_ALL_MEDIA = 0,
        /// <summary>
        /// Distant
        /// </summary>
        MS_CALL_ONLY = 1,
        /// <summary>
        /// Local
        /// </summary>
        MS_LOCAL_ONLY = 2
    }

}
