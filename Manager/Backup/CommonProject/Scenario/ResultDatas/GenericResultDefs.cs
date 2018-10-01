using System;
using System.Collections.Generic;
using System.Text;



namespace CommonProject.Scenario.ResultDatas
{
    /// <summary>
    /// Enumération des raisons d'un échec
    /// </summary>
    public class EventFailedReason
    {
        /// <summary>
        /// Type de l'événements
        /// </summary>
        public Events eventType;
        /// <summary>
        /// Raison
        /// </summary>
        public FailureReason reason;
        /// <summary>
        /// Raison définit par le programmeur
        /// </summary>
        public String programmerReason;
    }

    /// <summary>
    /// FailureReason :  the value is one of the following table:
    /// 2 No_Bandwidth (bande passante insuffusante) 
    /// 3 No_GK_Resources (pas de resources GateKeeper) 
    /// 4 Dest_Unreachable (destinataire non joignable) 
    /// 5 Dest_Reject (Destinataire rejette l'appel) 
    /// 6 Disconnect_Invalid 
    /// 7 No_permission (permission insuffisante) 
    /// 8 GK_Unreachable (GateKeeper non joignable) 
    /// 9 GW_Ressources (pas de resource Gateway) 
    /// 10 Bad_Address_Format (mauvais format d'adresse) 
    /// 11 Adaptative_busy 
    /// 12 Party Busy 
    /// 13 Disconnect_Undefined (raison inconnue) 
    /// 14 Facility_call_Deflection 
    /// 15 Host_Incorrect (Nom de machine incorrect) 
    /// 115 No GateKeeper has been found to place the call 
    /// </summary>
    public enum FailureReason
    {
        None,
        No_Bandwidth = 2,
        No_GK_Resources = 3,
        Dest_Unreachable = 4,
        Dest_Reject = 5,
        Disconnect_Invalid = 6,
        No_permission = 7,
        GK_Unreachable = 8,
        GW_Ressources = 9,
        Bad_Address_Format = 10,
        Adaptative_busy = 11,
        Party_Busy = 12,
        Disconnect_Undefined = 13,
        Facility_call_Deflection = 14,
        Host_Incorrect = 15,
        No_GateKeeper = 115
    }




    public enum Events
    {
        APPEXIT,
        INCOMING,
        CALLING,
        FAILED,
        LOCAL_ACCEPTED,
        LOCAL_REJECTED,
        REJECTED,
        CONNECT,
        DISCONNECT,
        FILETRANSFER_STARTED,
        FILETRANSFER_ENDED,
        FILETRANSFER_CANCELLED,
        FILETRANSFER_PROGRESS,
        INPUT_MUTE,
        OUTPUT_MUTE,
        CHANNEL_MUTE,
        DTMF,
        DTMF_OUTBAND,
        SIP_DTMF_OUTBAND,
        PICTURE_CAPTURED,
        MEDIA_PLAYED,
        ADD_MSG,
        ARCHIVE_MSG,
        AUDIO_LEVEL,
        AUDIO_LEVEL_GRABER,
        AUDIO_ONLY,
        BAD_MSG_ANSWERING,
        BEGIN_CAPTURE_MSG,
        BENCH_STATUS,
        CALL_STACK_STARTED,
        CHANGE_ACTIVATE,
        CHANGE_ANNONCE,
        CHANGE_DISK_ALLOCATION,
        CHANGE_LOC_MSG,
        CHANGE_MAX_DURATION,
        CHANGE_NO_ANSWER,
        CHANGE_RECORDER_TYPE,
        CHANGE_TOTAL_DURATION_MSG_USED,
        CONSOLE_MESSAGE,
        CONTACT_ADDED,
        CONTACT_REMOVED,
        CPL_EXIT,
        CPL_OPEN,
        DATA_RECEIVED,
        DATA_RECEIVED_UTF8,
        DELETE_ALL_MSG,
        DELETE_MSG,
        FILE_DROPPED_COUNT,
        FILE_DROPPED,
        DTMF_SENT,
        ERROR_ANSWERING,
        FINISH_CAPTURE_MSG,
        GK_CONNECT,
        GK_DISCONNECT,
        H245_INDICATION,
        H323_ALERT,
        H323_INDICATION,
        H323_RAS_INDICATION,
        IM_MESSAGE_IN_CALL,
        IM_MESSAGE_OUT_CALL,
        INCOMING_EX,
        INFO_CARD,
        INFO_MESSAGE_IN_CALL_RECEIVED,
        INFO_MESSAGE_OUT_CALL_RECEIVED,
        INPUT_GAIN,
        INTERCEPT_CALL,
        NETWORK_STATE_CHANGED,
        NEW_MEMBER,
        NEW_NAME,
        NEW_VIDEO_FORMAT,
        PEER_ADDRESS,
        Q931_INDICATION,
        Q931_MESSAGE_RECEIVED,
        SIP_RAWMESSAGE_RECEIVED,
        READ_MSG,
        REMOTE_PARTY_INFO,
        REMOTE_PARTY_RINGING,
        REMOVE_SUBSCRIPTION,
        SIP_PRESENCE_STATUS,
        SIP_REGISTRATION_RESULT,
        STANDARD_CODECS_NEGOTIATED,
        AUDIO_DECODER_STARTED,
        AUDIO_ENCODER_STARTED,
        DATA_DECODER_STARTED,
        DATA_ENCODER_STARTED,
        TEXT_DECODER_STARTED,
        TEXT_ENCODER_STARTED,
        VIDEO_DECODER_STARTED,
        VIDEO_DECODER_EX_STARTED,
        VIDEO_ENCODER_STARTED,
        STATUS_CHANGED,
        AUDIO_DECODER_STOPPED,
        AUDIO_ENCODER_STOPPED,
        DATA_DECODER_STOPPED,
        DATA_ENCODER_STOPPED,
        TEXT_DECODER_STOPPED,
        TEXT_ENCODER_STOPPED,
        VIDEO_DECODER_STOPPED,
        VIDEO_DECODER_EX_STOPPED,
        VIDEO_ENCODER_STOPPED,
        SUBSCRIPTION,
        SUBSCRIPTION_ACCEPTED,
        SUBSCRIPTION_PENDING,
        SUBSCRIPTION_REFUSED,
        T120_CONNECTED,
        T120_DISCONNECTED,
        VIDEO_QUALITY_CHANGED,
        ALL
    }

    public enum TestStatus
    {
        /// <summary>
        /// Réussi
        /// </summary>
        Success = 0, 
        /// <summary>
        /// Echec
        /// </summary>
        Failed = 1,             
        /// <summary>
        // TimeOut
        /// </summary>
        TimeOut = 2,
        /// <summary>
        /// Inconnu
        /// </summary>
        Unknown = 3
        
    }
}
