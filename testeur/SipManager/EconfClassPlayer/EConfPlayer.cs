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
using eConf;
//using CommonProject;


namespace Tester.SipManager.EconfClassPlayer
{
  

	#region delegates
	/// <summary>
	/// Handler gérant l'événement d'émission d'un appel
	/// </summary>
	public delegate void CallingHandler(int nID, object XMLdatas);
	/// <summary>
	/// Handler gérant l'événement de réception d'un appel
	/// </summary>
	public delegate void IncomingCallHandler(int nID, string callerName);
	/// <summary>
	/// Handler gérant l'événement de réception d'un appel
	/// </summary> 
	public delegate void IncomingCallExHandler(int nID, eConf.IRemotePartyInfo XMLdatas);
	/// <summary>
	/// Handler  d'événement gérant l'écher d'un appel
	/// </summary>
	public delegate void CallFailedHandler(int nID, short failureReason);
	/// <summary>
	/// Handler  d'événement gérant l'interception d'un appel
	/// </summary>
	public delegate void CallInterceptedHandler(int nID, short id);
	/// <summary>
	/// Handler générique avec un booléen en argument
	/// </summary>
	public delegate void GenericBoolHandler(bool condition);
	/// <summary>
	/// Handler générique d'appel avec un entier en argument
	/// </summary>
	public delegate void GenericCallHandler(int nCallID);
	/// <summary>
	/// Handler générique avec un entier en argument
	/// </summary>
	public delegate void GenericIntegerHandler(int intParam);
	/// <summary>
	/// Handler générique avec un short en argument
	/// </summary>
	public delegate void GenericShortHandler(short shortParam);
	/// <summary>
	/// Handler générique avec une chaine de caractère en argument
	/// </summary>
	public delegate void GenericMessageHandler(string message);
	/// <summary>
	/// Handler pour l'envoie de DTMF
	/// </summary>
	public delegate void DTMFSentHandler(int callID, string strDTMF, eDTMFKind kind, int duration);
	/// <summary>
	/// Handler pour la réception de DTMF
	/// </summary>
	public delegate void DTMFReceivedHandler(string strDTMF);
	/// <summary>
	/// Handler pour la réception d'un DTMF outband
	/// </summary>
	public delegate void DTMFOutbandReceivedHandler(string strDTMF, int duration);
	/// <summary>
	/// Handler générique sur un événement d'ouverture de fermeture de channel
	/// </summary>
	public delegate void MediaGraphEventHandler(int nChannelID);
	/// <summary>
	/// Handler de démarrage d'un encodeur vidéo
	/// </summary>
	public delegate void VideoExEncoderStartedHandler(int callId,short channelID,int hWnd);
	/// <summary>
	/// Handler de démarrage d'un encodeur vidéo
	/// </summary>
	public delegate void VideoExEncoderStoppedHandler(int callId,short channelID);
	/// <summary>
	/// Handler gérant les captures d'images
	/// </summary>
	public delegate void ImageCaptureHandler(int callID, string filename);
	/// <summary>
	/// Handler gérant la fin d'un transfert de fichier
	/// </summary>
	public delegate void InfoFileTransferHandler(string filename);
	/// <summary>
	/// Handler gérant la progression d'un transfert de fichier
	/// </summary>
	public delegate void FileTransferProgressHandler(int nBytes, int nTotalBytes);
	/// <summary>
	/// Handler gérant la désactivation du son généré
	/// </summary>
	public delegate void InputMutedHandler(bool IsMuted);
	/// <summary>
	/// Handler gérant la désactivation du son reçu d'un correspondant
	/// </summary>
	public delegate void OutputMutedHandler(int nID, bool IsMuted);
	/// <summary>
	/// Handler gérant la fin de streaming d'une vidéo
	/// </summary>
	public delegate void PlayMediaHandler(int callID, string filename);
	/// <summary>
	/// Handler gérant le démarrage de la call stack
	/// </summary>
	public delegate void CallStackStartedHandler(eProtocol protocol);
	/// <summary>
	/// Handler gérant le changement d'annonce du répondeur
	/// </summary>
	public delegate void AnnonceChangedHandler(string annonce, short id);
	/// <summary>
	/// Handler gérant la suppression d'un contact
	/// </summary>
	public delegate void ContactRemovedHandler(string user, int id);
	/// <summary>
	/// Handler gérant la reception de donnée
	/// </summary>
	public delegate void DataReceivedHandler(eConf.IDataInfo data);
	/// <summary>
	/// Handler gérant les erreurs perçu du répondeur
	/// </summary>
	public delegate void ErrorAnsweringHandler(eConf.eErrorRecorder error);
	/// <summary>
	/// Handler gérant les messages recus
	/// </summary>
	public delegate void MessageReceivedInCallHandler(int callId, string contentType,string body);
	/// <summary>
	/// Handler gérant les messages recus
	/// </summary>
	public delegate void MessageReceivedOutCallHandler(string address, string contentType,string body);
	/// <summary>
	/// Handler gérant les info rçu d'un correspondant
	/// </summary>
	public delegate void PeerInfoReceivedHandler(int callId, string info);
	/// <summary>
	/// Handler générique de réception d'info
	/// </summary>
	public delegate void MemberEventHandler(int callId, string user);
	/// <summary>
	/// Habdler gérant le changement de résolution d'une video
	/// </summary>
	public delegate void VideoFormatHandler(int callId, short channelId, int width, int height);
	/// <summary>
	/// Handler gérant la levée d'indication Q931
	/// </summary>
	public delegate void Q931IndicationRaisedHandler(short code,short normalizedCode);
	/// <summary>
	/// Handler gérant la réception de message Q931
	/// </summary>
	public delegate void Q931MessageReceivedHandler(string message,int decoderIndice);
	/// <summary>
	/// Handler gérant la reception de messages SIP
	/// </summary>
	public delegate void SIPRawMessageReceivedHandler(string message,bool IsRequest);
	/// <summary>
	/// Handler gérant la reception des informations sur le distant
	/// </summary>
	public delegate void RemotePartyInfoHandler(int callId, eConf.IRemotePartyInfo partyInfo);
	/// <summary>
	/// Handler générique concernant les abonnements
	/// </summary>
	public delegate void SubscriptionHandler(string str1, string str2);
	/// <summary>
	/// Handler d'enregistrement SIP
	/// </summary>
	public delegate void SIPRegistrationHandler(short statusCode, short status);
	/// <summary>
	/// Handler de changement de qualité d'un flux vidéo
	/// </summary>
	public delegate void VideoQualityChangedHandler(short channelID, short quality);
	#endregion

	#region Structure/class
	internal enum Events
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
		H323_ALERT ,
		H323_INDICATION,
		H323_RAS_INDICATION,
		IM_MESSAGE_IN_CALL,
		IM_MESSAGE_OUT_CALL ,
		INCOMING_EX ,
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

	internal struct InfoCall
	{
		public int CallId;
		public object Info;
	}

	internal struct InfoGeneric
	{
		public int Integer;
		public string Message;
	}
	internal struct InfoDTMF
	{
		public int Duration;
		public eConf.eDTMFKind Kind;
		public string DTMF;
	}
	/// <summary>
	/// Class utilisé pour la réception des événements EConf
	/// </summary>
	internal class EventInfo
	{
		public Events _EventsType;
		public object _Parameter;
		public EventInfo(Events eventsType)
		{
			_EventsType = eventsType;
			_Parameter = null;
		}
		public EventInfo(Events eventsType, object parameter)
		{
			_EventsType = eventsType;
			_Parameter = parameter;
		}
	}


	internal class ConnectionException :Exception
	{
		public ConnectionException(string message ) : base(message)
		{
		}
	}
	#endregion

	/// <summary>
	/// Singleton EConf wrapper. Fait transité toutes les requêtes vers Econf. Répercute les messages venant d'Econf.
	/// </summary>
	public class EConfPlayer
	{
		#region events
		/// <summary>
		/// Connecté à Econf
		/// </summary>
		public event EventHandler Connected;
		/// <summary>
		/// Déconnecté à Econf
		/// </summary>
		public event EventHandler Disconnected;
		/// <summary>
		/// Emis lorsqu'on econf ferme
		/// </summary>
		public event EventHandler OnAppExit;
		/// <summary>
		/// Evénement emis lorsqu'un appel est placé
		/// </summary>
		public event CallingHandler Calling;
		/// <summary>
		/// Evénement émis lorsqu'un appel arrive
		/// </summary>
		public event IncomingCallHandler IncomingCall;
		/// <summary>
		/// Evénement émis lorsqu'un appel entrant
		/// </summary>
		public event IncomingCallExHandler IncomingCallEx;
		/// <summary>
		/// Evénement émis lorsqu'un appel échoue
		/// </summary>
		public event CallFailedHandler CallFailed;
		/// <summary>
		/// Evénement émis lorsqu'un appel est rejeté
		/// </summary>
		public event GenericCallHandler CallRejected;
		/// <summary>
		/// Evénement émis lorsqu'un appel arrive dans l'état connecté
		/// </summary>
		public event GenericCallHandler CallConnected;
		/// <summary>
		/// Evénement émis lorsqu'un appel arrive dans l'état déconnecté
		/// </summary>
		public event GenericCallHandler CallDisconnected;
		/// <summary>
		/// Evénement émis lorsqu'un appel est accepté localement
		/// </summary>
		public event GenericCallHandler LocalAccepted;
		/// <summary>
		/// Evénement émis lorsqu'un appel est rejeté localement
		/// </summary>
		public event GenericCallHandler LocalRejected;
		/// <summary>
		/// Evenement émis lorsqu'un appel est intercepté
		/// </summary>
		public event CallInterceptedHandler CallIntercepted;
		/// <summary>
		/// Evénement émis lors de l'envoie de DTMF
		/// </summary>
		public event DTMFSentHandler DTMFSent;
		/// <summary>
		/// Evénement émis lors de la réception de DTMF
		/// </summary>
		public event DTMFReceivedHandler DTMFReceived;
		/// <summary>
		/// Evénement émis lors de la réception de DTMF outband
		/// </summary>
		public event DTMFOutbandReceivedHandler DTMFOutbandReceived;
		/// <summary>
		/// Evénement émis lors de la réception de DTMF SIP outband
		/// </summary>
		public event DTMFOutbandReceivedHandler SIP_DTMFOutbandReceived;
		/// <summary>
		/// Evénement émis lors du début de transfert d'un fichier
		/// </summary>
		public event InfoFileTransferHandler FileTransferStarted;
		/// <summary>
		/// Evénement émis lors de la fin de transfert d'un fichier
		/// </summary>
		public event InfoFileTransferHandler FileTransferEnded;
		/// <summary>
		/// Evénement émis lors de l'annulation de transfert d'un fichier
		/// </summary>
		public event InfoFileTransferHandler FileTransferCancelled;
		/// <summary>
		/// Evénement émis lors de la progression de transfert d'un fichier
		/// </summary>
		public event FileTransferProgressHandler FileTransferProgress;
		/// <summary>
		/// Evénement émis lors du démarrage du décodeur audio
		/// </summary>
		public event MediaGraphEventHandler AudioDecoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt du décodeur audio
		/// </summary>
		public event MediaGraphEventHandler AudioDecoderStopped;
		/// <summary>
		/// Evénement émis lors du démarrage de l'encodeur audio
		/// </summary>
		public event MediaGraphEventHandler AudioEncoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt de l'encodeur audio
		/// </summary>
		public event MediaGraphEventHandler AudioEncoderStopped;
		/// <summary>
		/// Evénement émis lors de l'arrêt de l'encodeur vidéo
		/// </summary>
		public event MediaGraphEventHandler VideoDecoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt du décodeur vidéo
		/// </summary>
		public event MediaGraphEventHandler VideoDecoderStopped;
		/// <summary>
		/// Evénement émis lors du démarrage de l'encodeur vidéo
		/// </summary>
		public event MediaGraphEventHandler VideoEncoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arret de l'encodeur vidéo
		/// </summary>
		public event MediaGraphEventHandler VideoEncoderStopped;
		/// <summary>
		/// Evénement émis lors de l'arret de l'encodeur text
		/// </summary>
		public event MediaGraphEventHandler TextEncoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt de l'encodeur text
		/// </summary>
		public event MediaGraphEventHandler TextEncoderStopped;
		/// <summary>
		/// Evénement émis lors du démarrage du décodeur text
		/// </summary>
		public event MediaGraphEventHandler TextDecoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt du décodeur text
		/// </summary>
		public event MediaGraphEventHandler TextDecoderStopped;
		/// <summary>
		/// Evénement émis lors du démarrage du décodeur donnée
		/// </summary>
		public event MediaGraphEventHandler DataDecoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt du décodeur donnée
		/// </summary>
		public event MediaGraphEventHandler DataDecoderStopped;
		/// <summary>
		/// Evénement émis lors du démarrage du décodeur donnée
		/// </summary>
		public event MediaGraphEventHandler DataEncoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt du décodeur donnée
		/// </summary>
		public event MediaGraphEventHandler DataEncoderStopped;
		/// <summary>
		/// Evénement émis lors du démarrage de l'encodeur vidéo + fenêtre
		/// </summary>
		public event VideoExEncoderStartedHandler VideoExEncoderStarted;
		/// <summary>
		/// Evénement émis lors de l'arrêt de l'encodeur vidéo + fenêtre
		/// </summary>
		public event VideoExEncoderStoppedHandler VideoExEncoderStopped;
		/// <summary>
		/// Evénement émis lorsque le son du micro est coupé
		/// </summary>
		public event InputMutedHandler InputMuted;
		/// <summary>
		/// Evénement émis lorsque le son du speaker est coupé
		/// </summary>
		public event OutputMutedHandler OutputMuted;
		/// <summary>
		/// Evénement émis lorsque le flux d'un canal est coupé
		/// </summary>
		public event OutputMutedHandler ChannelMuted;
		/// <summary>
		/// Evénement émis lorsque le gain en entrée est modifié
		/// </summary>
		public event GenericShortHandler InputGainChanged;
		/// <summary>
		/// Evénement émis lorsqu'une image est capturé
		/// </summary>
		public event ImageCaptureHandler ImageCaptured;
		/// <summary>
		/// Evénement émis lorsqu'une vidéo a été joué
		/// </summary>
		public event PlayMediaHandler MediaPlayed;
		/// <summary>
		/// Evénement émis lorsqu'un message est ajouté au répondeur
		/// </summary>
		public event GenericIntegerHandler MessageAdded;
		/// <summary>
		/// Evénement émis lorsqu'un message archive est ajouté au répondeur
		/// </summary>
		public event GenericIntegerHandler ArchiveMessageAdded;
		/// <summary>
		/// Evénement émis le niveau audio est changé
		/// </summary>
		public event GenericShortHandler AudioLevelChanged;
		/// <summary>
		/// Evénement émis le niveau audio du grabber est changé
		/// </summary>
		public event GenericShortHandler AudioLevelGrabberChanged;
		/// <summary>
		/// Evénement émis lorsque l'on configure en audio seulement le répondeur
		/// </summary>
		public event GenericShortHandler AudioOnlySet;
		/// <summary>
		/// Evénement émis lorsqu'on rentre un mauvais message de répondeur
		/// </summary>
		public event GenericShortHandler BadMessageAnswering;
		/// <summary>
		/// Evénement émis lorsque le répondeur commence à capturer un message
		/// </summary>
        /// 
		public event System.Windows.Forms.MethodInvoker BeginCaptureMessage;
		/// <summary>
		/// Evénement émis pour signifier que le status du benchmark a changé
		/// </summary>
		public event GenericIntegerHandler BenchStatus;
		/// <summary>
		/// Evénement émis lorsque la pile d'appel a été initialisé pour un appel
		/// </summary>
		public event CallStackStartedHandler CallStackStarted;
		/// <summary>
		/// Evénement émis lorsque l'état d'activation du répondeur a changé
		/// </summary>
		public event GenericShortHandler ChangeActivate;
		/// <summary>
		/// Evénement émis lorsque l'annonce d'accueil a été changé
		/// OnChangeActivate
		/// </summary>
		public event AnnonceChangedHandler AnnonceChanged;
		/// <summary>
		/// Evénement émis lorsque l'espace d'allocation a été changé
		/// </summary>
		public event GenericShortHandler DiskAllocationChanged;
		/// <summary>
		/// Evénement émis lorsque le chemin des messages a changé
		/// </summary>
		public event GenericMessageHandler MessageLocationChanged;
		/// <summary>
		/// Evénement émis lorsque la durée maximun d'un message a changé
		/// </summary>
		public event GenericShortHandler MaxDurationChanged;
		/// <summary>
		/// Evénement émis lorsque le delai de non-réponse est changé
		/// </summary>
		public event GenericShortHandler NoAnswerChanged;
		/// <summary>
		/// Evénement émis lorsque le type de répondeur a changé
		/// </summary>
		public event GenericShortHandler RecorderTypeChanged;
		/// <summary>
		/// Evénement émis lorsque la durée total des messages a changé
		/// </summary>
		public event GenericIntegerHandler TotalDurationMessageUsedChanged;
		/// <summary>
		/// Evénement émis lorsque une message console est généré
		/// </summary>
		public event GenericMessageHandler ConsoleMessage;
		/// <summary>
		/// Evénement émis lorsque un contact est ajouté
		/// </summary>
		public event GenericMessageHandler ContactAdded;
		/// <summary>
		/// Evénement émis lorsque un contact est supprimé
		/// </summary>
		public event ContactRemovedHandler ContactRemoved;
		/// <summary>
		/// Evénement émis lorsque le panneau de configuration eConf est fermé
		/// </summary>
		public event GenericBoolHandler ConfigPanelClosed;
		/// <summary>
		/// Evénement émis lorsque le panneau de configuration eConf est ouvert
		/// </summary>
		public event System.Windows.Forms.MethodInvoker ConfigPanelOpened;
		/// <summary>
		/// Evénement émis lorsque des données sont reçues
		/// </summary>
		public event DataReceivedHandler DataReceived;
		/// <summary>
		/// Evénement émis lorsque des données sont reçues (en utf8)
		/// </summary>
		public event DataReceivedHandler UTF8DataReceived;
		/// <summary>
		/// Evénement émis lorsque tous les messages sont détruits (répondeur)
		/// </summary>
		public event System.Windows.Forms.MethodInvoker AllMessagesDeleted;
		/// <summary>
		/// Evénement émis lorsque un message est détruit( répondeur)
		/// </summary>
		public event GenericShortHandler MessageDeleted;
		/// <summary>
		/// Evénement émis lorsque une erreur dans le répondeur intervient
		/// </summary>
		public event ErrorAnsweringHandler ErrorAnswering;
		/// <summary>
		/// Evénement émis lorsque le nombre de fichier droppé a changé
		/// </summary>
		public event GenericIntegerHandler DropFileInfoCountChanged;
		/// <summary>
		/// Evénement émis lorsque un fichier a été droppé
		/// </summary>
		public event GenericMessageHandler DropFileInfo;
		/// <summary>
		/// Evénement émis lorsque l'enregistrement du message est terminé (répondeur)
		/// </summary>
		public event GenericMessageHandler CaptureMessageFinished;
		/// <summary>
		/// Evénement émis lorsque on se connect à une gatekeeper
		/// </summary>
		public event System.Windows.Forms.MethodInvoker GKConnected;
		/// <summary>
		/// Evénement émis lorsque on se déconnecte à une gatekeeper
		/// </summary>
		public event System.Windows.Forms.MethodInvoker GKDisconnected;
		/// <summary>
		/// Evénement émis lorsqu'une indication H245 est levé
		/// </summary>
		public event GenericShortHandler H245IndicationRaised;
		/// <summary>
		/// Evénement émis lorsqu'une alerte H323 est levé
		/// </summary>
		public event GenericIntegerHandler H323AlertRaised;
		/// <summary>
		/// Evénement émis lorsqu'une indication H323 est levé
		/// </summary>
		public event GenericShortHandler H323IndicationRaised;
		/// <summary>
		/// Evénement émis lorsqu'une indication RAS H323 est levé
		/// </summary>
		public event GenericShortHandler H323RASIndicationRaised;
		/// <summary>
		/// Evénement émis lorsqu'on reçoit un IM
		/// </summary>
		public event MessageReceivedInCallHandler IMMessageReceivedInCall;
		/// <summary>
		/// Evénement émis lorsqu'on envoit un IM
		/// </summary>
		public event MessageReceivedOutCallHandler IMMessageReceivedOutCall;
		/// <summary>
		/// Evénement émis lorsqu'on reçoit la carte d'un correspondant
		/// </summary>
		public event PeerInfoReceivedHandler InfoCardReceived;
		/// <summary>
		/// InfoMessageInCallReceived
		/// </summary>
		public event MessageReceivedInCallHandler InfoMessageInCallReceived;
		/// <summary>
		/// InfoMessageOutCallReceived
		/// </summary>
		public event MessageReceivedOutCallHandler InfoMessageOutCallReceived;
		/// <summary>
		/// Evénement émis lorsque l'état du réseau change
		/// </summary>
		public event GenericShortHandler NetworkStateChanged;
		/// <summary>
		/// Evénement émis lorsqu'un membre est ajouté
		/// </summary>
		public event MemberEventHandler MemberAdded;
		/// <summary>
		/// Evénement émis lorsqu'un nom est reçu
		/// </summary>
		public event MemberEventHandler NameReceived;
		/// <summary>
		/// Evénement émis lorsque le format de la vidéo change
		/// </summary>
		public event VideoFormatHandler VideoFormatChanged;
		/// <summary>
		/// Evénement émis lorsqu'on reçoit l'adresse du correspondant
		/// </summary>
		public event PeerInfoReceivedHandler PeerAddressReceived;
		/// <summary>
		/// Evénement émis lorsqu'une Q931 Indication est levé
		/// </summary>
		public event Q931IndicationRaisedHandler Q931IndicationRaised;
		/// <summary>
		/// Evénement émis lorsqu'un Q931 message est reçu
		/// </summary>
		public event Q931MessageReceivedHandler Q931MessageReceived;
		/// <summary>
		/// Evénement émis lorsqu'un message SIP est reçu
		/// </summary>
		public event SIPRawMessageReceivedHandler SIPRawMessageReceived;
		/// <summary>
		/// Evénement émis lorsqu'on lit un message (répondeur)
		/// </summary>
		public event GenericShortHandler ReadMessageRaised;
		/// <summary>
		/// Evénement émis lorsque l'on reçoit les infos du correspondant
		/// </summary>
		public event RemotePartyInfoHandler RemotePartyInfoRaised;
		/// <summary>
		/// Evénement émis lorsque l'appel est dans l'état ringing distant
		/// </summary>
		public event GenericIntegerHandler RemoteRinging;
		/// <summary>
		/// Evénement émis lorsque le SIP présence status change
		/// </summary>
		public event GenericIntegerHandler SIPPresenceStatusChanged;
		/// <summary>
		/// Evénement émis lorsqu'on s'abonne/désabonne au registrar
		/// </summary>
		public event SIPRegistrationHandler SIPRegistred;
		/// <summary>
		/// Evénement émis lorsque les codecs ont été négocié
		/// </summary>
		public event GenericIntegerHandler CodecsNegociated;
		/// <summary>
		/// StatusChanged
		/// </summary>
		public event GenericIntegerHandler StatusChanged;
		/// <summary>
		/// Evénement émis lorsque l'abonnement a été supprimé
		/// </summary>
		public event SubscriptionHandler SubscriptionRemoved;
		/// <summary>
		/// Evénement émis lorsque l'abonnement a été supprimé
		/// </summary>
		public event SubscriptionHandler SubscriptionRequested;
		/// <summary>
		/// Evénement émis lorsque l'abonnement a été accepté
		/// </summary>
		public event SubscriptionHandler SubscriptionAccepted;
		/// <summary>
		/// Evénement émis lorsque l'abonnement est attente
		/// </summary>
		public event SubscriptionHandler SubscriptionPending;
		/// <summary>
		/// Evénement émis lorsque l'abonnement a été refusé
		/// </summary>
		public event SubscriptionHandler SubscriptionRefused;
		/// <summary>
		/// Evénement émis lorsque le canal T120 est ouvert
		/// </summary>
		public event GenericIntegerHandler T120Connected;
		/// <summary>
		/// Evénement émis lorsque le canal T120 est fermé
		/// </summary>
		public event GenericIntegerHandler T120Disconnected;
		/// <summary>
		/// Evénement émis lorsque la qualité de la vidéo change
		/// </summary>
		public event VideoQualityChangedHandler VideoQualityChanged;
		#endregion

		/// <summary>
		/// Nombre de codecs
		/// </summary>
		public const int CodecSize = 35;
		/// <summary>
		/// Nombre possibles de configuration réseaux
		/// </summary>
		public const int NetworkSize = 24;
		/// <summary>
		/// Nombre possibles de configuration réseaux
		/// </summary>
		public const int SpecialNetworkIndex = 23;
		/// <summary>
		/// Periode de rafraichissement des événements recu d'Econf. Cadence à laquelle les événements sont dispatchés
		/// </summary>
		public const int _PeriodRefresh = 750;
		/// <summary>
		/// Instance singleton du wrapper Econf
		/// </summary>
		private static EConfPlayer _Instance ;
		/// <summary>
		/// Chemin d'econf. Initialisé à l'instanciation.
		/// </summary>
		private static string _EConfRoot;
		/// <summary>
		/// Si on est connecté à Econf
		/// </summary>
		private bool _IsConnected = false;
		/// <summary>
		/// Thread de désenregistrement
		/// </summary>
		private System.Threading.Thread _UnsubscribeThread;
		private System.Threading.ManualResetEvent _UnsubscribeWaitHandle;
		private int _Timeout = 2000;

		//Interface d'Econf
		public Terminal _Terminal;
		private eConfPlayer.eConfPlayerClass _EConfPlayer = null;
		private eConf.TerminalAVOptions _TerminalAVOptions;
		private eConf.TerminalAVControl _TerminalAVControl;
		private eConf.SipTerminal _SipTerminal;

		//Entier des derniers channel Ids
		private short _LastRtpIdAudioOut=-1;
		private short _LastRtpIdAudioIn=-1;
		private short _LastRtpIdVideoOut=-1;
		private short _LastRtpIdVideoIn=-1;
        
		/// <summary>
		/// Collection des événements non-traités
		/// </summary>
		private System.Collections.ArrayList _Events;
		/// <summary>
		/// Timer gérant le dispatching des événenments
		/// </summary>
		private System.Threading.Timer _Timer;
		
		private EConfPlayer() 
		{
			CheckInstance();
			_Events = new System.Collections.ArrayList();
		}
		/// <summary>
		/// Destructeur
		/// </summary>
		~EConfPlayer()
		{
			if(_Terminal!=null)
			{

				Tools.Trace.WriteLog("Econfplayer : destruction d'une instance");
				int refCount = 0;
				refCount = System.Runtime.InteropServices.Marshal.ReleaseComObject(_Terminal);
				_Terminal = null;
			}
		}
		
		/// <summary>
		/// Propriété renvoyant le Singleton
		/// </summary>
		public static EConfPlayer Instance
		{
			get
			{
				if(_Instance==null)
				{
					_Instance = new EConfPlayer();
				}
				return _Instance;
			}
		}
		/// <summary>
		/// Obtient l'état de connexion à econf
		/// </summary>
		public bool IsConnected
		{
			get
			{
				return _IsConnected;
			}
		}
		/// <summary>
		/// obtient le dernier canal utilisé pour l'audio sortant
		/// </summary>
		public short LastRtpIdAudioOut
		{
			get
			{
				if(_Instance==null)
				{
					return -1;
				}
				return _Instance._LastRtpIdAudioOut;
			}
		}
		/// <summary>
		/// Obtient le dernier canal utilisé pour l'audio entrant
		/// </summary>
		public short LastRtpIdAudioIn
		{
			get
			{
				if(_Instance==null)
				{
					return -1;
				}
				return _Instance._LastRtpIdAudioIn;
			}
		}
		/// <summary>
		/// Obtient le dernier canal utilisé pour la vidéo sortante
		/// </summary>
		public short LastRtpIdVideoOut
		{
			get
			{
				if(_Instance==null)
				{
					return -1;
				}
				return _Instance._LastRtpIdVideoOut;
			}
		}
		/// <summary>
		/// Obtient le dernier canal utilisé pour la vidéo entrante
		/// </summary>
		public short LastRtpIdVideoIn
		{
			get
			{
				if(_Instance==null)
				{
					return -1;
				}
				return _Instance._LastRtpIdVideoIn;
			}
		}
		/// <summary>
		/// Arrête l'instance Econf
		/// </summary>
		/// <returns></returns>
		public bool Exit()
		{
			bool success = false;
			try
			{
				//				_Instance.Unsubscribe();
                Tools.Trace.WriteLog("Econfplayer : arrêt econf.");
				_Instance._EConfPlayer.AppExit();
				success = true;
			}
			catch(Exception exception)
			{
                Tools.Trace.WriteLine(exception);
				success = false;
			}
			return success;
		}
		/// <summary>
		/// Redémarre l'instance Econf. Synchrone.
		/// </summary>
		/// <returns></returns>
		public bool Restart()
		{
			bool success  = false;
			try
			{
               
				Tools.Trace.WriteLog("Econfplayer : redémarrage econf.");
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo = new System.Diagnostics.ProcessStartInfo(_EConfRoot+"restarter.exe");
				proc.Start();
				success  = proc.WaitForExit(10000);
				if(success)
				{
					CheckInstance();
				}
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception);
				success = false;
			}			
			return success;
		}
		/// <summary>
		/// Réinitialise les canaux enregistrés
		/// </summary>
		public void ResetChannelsID()
		{
			if(_Instance==null)
			{
				return ;
			}
			_Instance._LastRtpIdVideoIn = -1;
			_Instance._LastRtpIdVideoOut = -1;
			_Instance._LastRtpIdAudioIn = -1;
			_Instance._LastRtpIdAudioOut = -1;
		}
		/// <summary>
		/// Récupérer le chemin d'exécution d'Econf
		/// </summary>
		/// <returns></returns>
		public string GetEconfRoot()
		{
			try
			{
				if(_EConfRoot==null)
				{
					eConf.IVersionInfo IEConfInfo = (eConf.IVersionInfo)_Instance._Terminal.VersionInfo;
					_EConfRoot = IEConfInfo.RootPath;
				}
			}
			catch(System.Exception exception)
			{
				Tools.Trace.WriteLine(exception.ToString());
			}
			return _EConfRoot;
		}
		/// <summary>
		/// Récupère la version d'Econf
		/// </summary>
		/// <returns></returns>
		public string GetEConfVersion()
		{
			System.Text.StringBuilder version = new System.Text.StringBuilder();
			try
			{
				
				eConf.IVersionInfo IEConfInfo = (eConf.IVersionInfo)_Instance._Terminal.VersionInfo;
				version.Append(IEConfInfo.Major);
				version.Append('.');
				version.Append(IEConfInfo.Minor);
				version.Append('.');
				version.Append(IEConfInfo.Revision);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return HandleConnectionLoss(null) as string;
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return HandleConnectionLoss(null) as string;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception);
			}
			return version.ToString();
		}

		#region EConf Call methods
		
		#region ITerminalConfig
		#region Network config
		/// <summary>
		/// Récupère les codecs audio valides
		/// </summary>
		/// <param name="audioCodecs"></param>
		/// <returns></returns>
		public bool GetValidAudioCodecs(out bool[]audioCodecs)
		{
			bool success = false;
			int audioCodecSize;
			audioCodecs= null;
			try
			{
				audioCodecSize = (int)eConf.eCodecType.eCODEC_VIDEOUNDEFINED-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED;
				audioCodecs = new bool[audioCodecSize];
				for(int i = 0 ; i<audioCodecSize ; i++)
				{
					audioCodecs[i] =false;
				}
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOG711-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG711);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOG711MU-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG711MU);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOG722-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG722);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOG7231-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG7231);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOTDACHIERAR-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDACHIERAR);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOTDAC24-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDAC24);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOTDAC32-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDAC32);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOTDAC64-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDAC64);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOAMR-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOAMR);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOWBAMR-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOWBAMR);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIORFC2833-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIORFC2833);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOGSM610-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOGSM610);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOG729-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG729);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOSCA729-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOSCA729);
				audioCodecs[(int)eConf.eCodecType.eCODEC_AUDIOCODECX-(int)eConf.eCodecType.eCODEC_AUDIOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOCODECX);
				success = true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception.ToString());
				success = false;
			}
			return success;
		}

		/// <summary>
		/// Récupères les codecs vidéos valides
		/// </summary>
		/// <param name="videoCodecs"></param>
		/// <returns></returns>
		public bool GetValidVideoCodecs(out bool[]videoCodecs)
		{
			int videoCodecSize;
			videoCodecs = null;
			try
			{
				videoCodecSize = (int)eConf.eCodecType.eCODEC_DATAUNDEFINED-(int)eConf.eCodecType.eCODEC_VIDEOUNDEFINED;
				videoCodecs = new bool[videoCodecSize];
				for(int i = 0 ; i<videoCodecSize ; i++)
				{
					videoCodecs[i] =false;
				}
				videoCodecs[(int)eConf.eCodecType.eCODEC_VIDEOH261-(int)eConf.eCodecType.eCODEC_VIDEOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOH261);
				videoCodecs[(int)eConf.eCodecType.eCODEC_VIDEOH263-(int)eConf.eCodecType.eCODEC_VIDEOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOH263);
				videoCodecs[(int)eConf.eCodecType.eCODEC_VIDEOH263P-(int)eConf.eCodecType.eCODEC_VIDEOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOH263P);
				videoCodecs[(int)eConf.eCodecType.eCODEC_VIDEOMPEG4-(int)eConf.eCodecType.eCODEC_VIDEOUNDEFINED]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOMPEG4);
				return true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception.ToString());
				return false;
			}
		}

		/// <summary>
		/// Récupère tous les codecs valides
		/// </summary>
		/// <param name="codecs"></param>
		/// <returns></returns>
		public bool GetValidCodecs(out bool[]codecs)
		{
			codecs = null;
			try
			{
				codecs = new bool[CodecSize];
				for(int i = 0 ; i<CodecSize ; i++)
				{
					codecs[i] =false;
				}
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOG711]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG711);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOG711MU]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG711MU);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOG722]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG722);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOG7231]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG7231);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOTDACHIERAR]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDACHIERAR);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOTDAC24]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDAC24);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOTDAC32]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDAC32);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOTDAC64]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOTDAC64);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOAMR]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOAMR);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOWBAMR]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOWBAMR);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIORFC2833]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIORFC2833);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOGSM610]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOGSM610);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOG729]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOG729);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOSCA729]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOSCA729);
				codecs[(int)eConf.eCodecType.eCODEC_AUDIOCODECX]=IsCodecAvailable(eConf.eCodecType.eCODEC_AUDIOCODECX);
				codecs[(int)eConf.eCodecType.eCODEC_VIDEOH261]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOH261);
				codecs[(int)eConf.eCodecType.eCODEC_VIDEOH263]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOH263);
				codecs[(int)eConf.eCodecType.eCODEC_VIDEOH263P]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOH263P);
				codecs[(int)eConf.eCodecType.eCODEC_VIDEOMPEG4]=IsCodecAvailable(eConf.eCodecType.eCODEC_VIDEOMPEG4);
				codecs[(int)eConf.eCodecType.eCODEC_DATAATOR]=IsCodecAvailable(eConf.eCodecType.eCODEC_DATAATOR);
				codecs[(int)eConf.eCodecType.eCODEC_DATAT120]=IsCodecAvailable(eConf.eCodecType.eCODEC_DATAT120);
				codecs[(int)eConf.eCodecType.eCODEC_DATAT140]=IsCodecAvailable(eConf.eCodecType.eCODEC_DATAT140);
				return true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception.ToString());
				return false;
			}
		}
		/// <summary>
		/// configuration du reseau
		/// </summary>
		/// <param name="idNetwork"></param>
		/// <param name="d"></param>
		/// <param name="u"></param>
		public void SetConfigReseau(int idNetwork, int d, int u)
		{
			int down ,up;
			switch(idNetwork)
			{
	
				case 0:
				{
					down=up=28;
				}
					break;
				case 1:
				{
					down=up=64;	
				}
					break;
				case 2:
				{
					down=up=128;	
				}
					break;
				case 3:
				{
					down=up=256;
				}
					break;
				case 4:
				{
					down=up=384;
				}
					break;
				case 5:
				{
					down=up=512;
				}
					break;
				case 6:
				{
					down=up=768;
				}
					break;
				case 7:
				{
					down=up=1024;
				}
					break;
				case 8:
				{
					down=up=1280;
				}
					break;
				case 9:
				{
					down=up=1536;
				}
					break;
				case 10:
				{
					down=up=1792;
				}
					break;
				case 11:
				{
					down=up=2048;
				}
					break;
				case 12:
				{
					down=64;
					up=64;	
				}
					break;
				case 13:
				{
					up=64;
					down=128;
				}
					break;
				case 14:
				{
					up=128;
					down=128;
				}
					break;
				case 15:
				{
					up=128;
					down=512;
				}
					break;
				case 16:
				{
					up=256;
					down=256;
				}
					break;
				case 17:
				{
					up=256;
					down=512;
				}
					break;
				case 18:
				{
					up=256;
					down=1024;
				}
					break;
				case 19:
				{
					up=512;
					down=512;
				}
					break;
				case 20:
				{
					up=512;
					down=1024;
				}
					break;
				case 21:
				{
					up=2048;
					down=2048;
				}
					break;
				default:
				{
					down=d;
					up=u;
				}
					break;
		
			}
			//configuration
			SetGlobalBandWidth(idNetwork, down, up);
		}
		/// <summary>
		/// Déactive tous les codecs
		/// </summary>
		/// <returns></returns>
		public bool ResetAllCodecs()
		{
			bool res = false;
			try
			{
				for(int i =0; i<CodecSize; i++)
				{
					DesactivateCodec((eConf.eCodecType)i);
				}
				res = true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception.ToString());
				res = false;
			}
			return res;
		}
		/// <summary>
		/// Active le codec spécifié
		/// </summary>
		/// <param name="codecType"></param>
		public void ActivateCodec(eConf.eCodecType codecType)
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).ActivateCodec(codecType);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(codecType);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(codecType);
			}
		}
		/// <summary>
		/// Désactive le codec spécifié
		/// </summary>
		/// <param name="codecType"></param>
		public void DesactivateCodec(eConf.eCodecType codecType)
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).DesactivateCodec(codecType);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(codecType);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(codecType);
			}
		}
		/// <summary>
		/// Détermine si le codec spécifié est activé
		/// </summary>
		/// <param name="codecType"></param>
		/// <returns></returns>
		public bool IsCodecActivated(eConf.eCodecType codecType)
		{
			try
			{
				return (((ITerminalConfig)_Instance._Terminal.Config).IsCodecActivated(codecType)==1);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(codecType);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(codecType);
			}
		}
		/// <summary>
		/// Détermine si le codec spécifié est disponible
		/// </summary>
		/// <param name="codecType"></param>
		/// <returns></returns>
		public bool IsCodecAvailable(eConf.eCodecType codecType)
		{
			try
			{
				return (((ITerminalConfig)_Instance._Terminal.Config).IsCodecAvailable(codecType)==1);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(codecType);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(codecType);
			}
		}
		/// <summary>
		/// Active ou désactive les codecs à partir du tableau de booléen donné
		/// </summary>
		/// <param name="codecs"></param>
		/// <returns></returns>
		public bool ConfigCodecs(bool[] codecs)
		{
			bool res = false;
			if(codecs==null)
			{
				return res;
			}
			try
			{
				if(codecs.Length!=CodecSize)
				{
					return res;
				}
				Tools.Trace.WriteLog("Econfplayer : Configuration des codecs.");
				for(int i =0; i<CodecSize; i++)
				{
					if((eConf.eCodecType)i == eConf.eCodecType.eCODEC_UNDEFINED_TYPE ||
						(eConf.eCodecType)i == eConf.eCodecType.eCODEC_AUDIOUNDEFINED ||
						(eConf.eCodecType)i == eConf.eCodecType.eCODEC_DATAUNDEFINED ||
						(eConf.eCodecType)i == eConf.eCodecType.eCODEC_VIDEOUNDEFINED)
					{
						continue;
					}
					if(codecs[i])
					{
						ActivateCodec((eConf.eCodecType)i);
					}
					else
					{
						DesactivateCodec((eConf.eCodecType)i);
					}
				}
				res = true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception.ToString());
				res = false;
			}
			return res;
		}
		/// <summary>
		/// configuration du reseau
		/// </summary>
		/// <param name="idNetwork"></param>
		/// <param name="down"></param>
		/// <param name="up"></param>
		public void GetNetworkConfigDetails(int idNetwork, out int down,out int up)
		{
			down =-1;
			up=-1;
			switch(idNetwork)
			{
	
				case 0:
				{
					down=up=28;
				}
					break;
				case 1:
				{
					down=up=64;	
				}
					break;
				case 2:
				{
					down=up=128;	
				}
					break;
				case 3:
				{
					down=up=192;
				}
					break;
				case 4:
				{
					down=up=256;
				}
					break;
				case 5:
				{
					down=up=384;
				}
					break;
				case 6:
				{
					down=up=512;
				}
					break;
				case 7:
				{
					down=up=768;
				}
					break;
				case 8:
				{
					down=up=1024;
				}
					break;
				case 9:
				{
					down=up=1280;
				}
					break;
				case 10:
				{
					down=up=1536;
				}
					break;
				case 11:
				{
					down=up=1792;
				}
					break;
				case 12:
				{
					down=up=2048;
				}
					break;
				case 13:
				{
					down=64;
					up=64;	
				}
					break;
				case 14:
				{
					up=64;
					down=128;
				}
					break;
				case 15:
				{
					up=128;
					down=128;
				}
					break;
				case 16:
				{
					up=128;
					down=512;
				}
					break;
				case 17:
				{
					up=256;
					down=256;
				}
					break;
				case 18:
				{
					up=256;
					down=512;
				}
					break;
				case 19:
				{
					up=256;
					down=1024;
				}
					break;
				case 20:
				{
					up=512;
					down=512;
				}
					break;
				case 21:
				{
					up=512;
					down=1024;
				}
					break;
				case 22:
				{
					up=2048;
					down=2048;
				}
					break;
				default:
				{
					down=-1;
					up=-1;
				}
				break;
			}
		}
		/// <summary>
		/// Fixe le débit réseau  partir de l'idnetwork
		/// </summary>
		/// <param name="idNetwork"></param>
		/// <param name="down"></param>
		/// <param name="up"></param>
		public void SetGlobalBandWidth(int idNetwork, int down, int up)
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).SetGlobalBandwidth(idNetwork, down, up);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(idNetwork, down, up);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(idNetwork, down, up);
			}
		}
		/// <summary>
		/// Récupère le débit réseau configuré dans econf
		/// </summary>
		/// <param name="idNetwork"></param>
		/// <param name="down"></param>
		/// <param name="up"></param>
		public void GetGlobalBandWidth(out int idNetwork,out int down,out int up)
		{
			idNetwork = -1;
			down = -1;
			up = -1;
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).GetGlobalBandwidth(out idNetwork, out down, out up);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				object [] objects = new object[3];
				object obj1,obj2, obj3;
				obj1 = idNetwork;
				obj2 = down;
				obj3 = up;
				objects.SetValue(obj1,0);
				objects.SetValue(obj2,1);
				objects.SetValue(obj3,2);
				//				objects[0] = idNetwork;
				//				objects[1] = down;
				//				objects[2] = up;
				HandleConnectionLoss(objects);
				idNetwork = (int)obj1;
				down = (int)obj2;
				up = (int)obj3;
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				object [] objects = new object[3];
				object obj1,obj2, obj3;
				obj1 = idNetwork;
				obj2 = down;
				obj3 = up;
				objects.SetValue(obj1,0);
				objects.SetValue(obj2,1);
				objects.SetValue(obj3,2);
				//				objects[0] = idNetwork;
				//				objects[1] = down;
				//				objects[2] = up;
				HandleConnectionLoss(objects);
				idNetwork = (int)obj1;
				down = (int)obj2;
				up = (int)obj3;
			}
		}
		#endregion
		#region GK/H323
		/// <summary>
		/// Récupère le gatekeeper selectionné
		/// </summary>
		/// <returns></returns>
		public int GetSelectedGatekeeper()
		{
			try
			{
				return ((TerminalConfig)_Instance._Terminal.Config).GetSelectedGatekeeper();
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (int)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (int)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Récupère le nom du gatekeeper sélectionné
		/// </summary>
		/// <param name="gkId"></param>
		/// <returns></returns>
		public string GetGatekeeperAddress(int gkId)
		{
			try
			{
				return ((TerminalConfig)_Instance._Terminal.Config).get_Gatekeeper(gkId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe les informations sur le gatekeeper
		/// </summary>
		/// <param name="gkId"></param>
		/// <param name="IpAddress"></param>
		public void SetGatekeeperAddress(int gkId, string IpAddress)
		{
			try
			{
				((TerminalConfig)_Instance._Terminal.Config).set_Gatekeeper(gkId, IpAddress);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(gkId, IpAddress);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(gkId, IpAddress);
			}
		}
		/// <summary>
		/// Récupère l'id Alias H323
		/// </summary>
		/// <param name="gkId"></param>
		/// <returns></returns>
		public string GetH323IDAlias(uint gkId)
		{
			try
			{
				return ((ITerminalConfig)_Instance._Terminal.Config).get_H323IDAlias(gkId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(gkId);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(gkId);
			}
		}
		/// <summary>
		/// Fixe l'id alias
		/// </summary>
		/// <param name="gkId"></param>
		/// <param name="alias"></param>
		public void SetH323IDAlias(uint gkId, string alias)
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).set_H323IDAlias(gkId, alias);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(gkId, alias);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(gkId, alias);
			}
		}
		/// <summary>
		/// récupère le téléphone alias
		/// </summary>
		/// <param name="gkId"></param>
		/// <returns></returns>
		public string GetPhoneAlias(uint gkId)
		{
			try
			{
				return ((ITerminalConfig)_Instance._Terminal.Config).get_PhoneAlias(gkId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(gkId);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(gkId);
			}
		}
		/// <summary>
		/// Fixe le téléphone alias
		/// </summary>
		/// <param name="gkId"></param>
		/// <param name="tel"></param>
		public void SetPhoneAlias(uint gkId, string tel)
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).set_PhoneAlias(gkId, tel);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(gkId, tel);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(gkId, tel);
			}
		}
		/// <summary>
		/// Récupère l'information sur l'utilisation du fast start
		/// </summary>
		/// <returns></returns>
		public bool GetUseFastStart()
		{
			try
			{
				return ((ITerminalConfig)_Instance._Terminal.Config).UseFastStart == 1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe les informations sur le fast start
		/// </summary>
		/// <param name="val"></param>
		public void SetUseFastStart(bool val)
		{
			try
			{
				if(val)
				{
					((ITerminalConfig)_Instance._Terminal.Config).UseFastStart = 1;
				}
				else
				{
					((ITerminalConfig)_Instance._Terminal.Config).UseFastStart = 0;
				}
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(val);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(val);
			}
		}
		/// <summary>
		/// Sauvegarde la configuration du terminal.
		/// </summary>
		public void SaveConfig()
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).Save();
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss();
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss();
			}
		}
		/// <summary>
		/// A partir de la configuration, opère les changements nécessaires.
		/// </summary>
		public void Reload()
		{
			try
			{
				((TerminalConfig)_Instance._Terminal.Config).ReloadConfig();
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Sélectionne le gatekeeper donné
		/// </summary>
		/// <param name="gkId"></param>
		public void SelectGatekeeper(int gkId)
		{
			try
			{
				((ITerminalConfig)_Instance._Terminal.Config).SelectGatekeeper(gkId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(gkId);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(gkId);
			}
		}
		/// <summary>
		/// Récupère l'information si on utilise le gatekeeper par défaut
		/// </summary>
		/// <returns></returns>
		public bool GetUseDefaultGateKeeper()
		{

			try
			{
				return ((ITerminalConfig)_Instance._Terminal.Config).UseDefaultGateKeeper==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe si on utilise le gatekeeper par défaut
		/// </summary>
		/// <param name="val"></param>
		public void SetUseDefaultGateKeeper(bool val)
		{
			try
			{
				if(val)
				{
					((ITerminalConfig)_Instance._Terminal.Config).UseDefaultGateKeeper =1;
				}
				else
				{
					((ITerminalConfig)_Instance._Terminal.Config).UseDefaultGateKeeper =0;
				}
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(val);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(val);
			}
		}
		/// <summary>
		/// Récupère si econf est enregistré sur une gatekeeper
		/// </summary>
		/// <returns></returns>
		public bool IsGKActive()
		{
			try
			{
				return ((ITerminal)_Instance._Terminal).IsGKActive == 1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss();
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss();
			}
		}
		
		#endregion
		#region SIP Config
		/// <summary>
		/// Récupère l'adresse du registrar
		/// </summary>
		/// <returns></returns>
		public string GetRegistrarAddress()
		{
			try
			{
				return ((SipConfig)_Instance._Terminal.SipConfig).RegistrarAddress;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe l'adresse du registrar
		/// </summary>
		/// <param name="address"></param>
		public void SetRegistrarAddress(string address)
		{
			try
			{
                string tmp = address;
                if (tmp == null)
                {
                    tmp = "";
                }
                ((SipConfig)_Instance._Terminal.SipConfig).RegistrarAddress = tmp;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(address);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(address);
			}
		}
		/// <summary>
		/// Récupère le login
		/// </summary>
		/// <returns></returns>
		public string GetLogin()
		{
			try
			{
				return ((SipConfig)_Instance._Terminal.SipConfig).LoginName;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe le login SIP
		/// </summary>
		/// <param name="login"></param>
		public void SetLogin(string login)
		{
			try
			{
                string tmp = login;
                if (tmp == null)
                {
                    tmp = "";
                }
                ((SipConfig)_Instance._Terminal.SipConfig).LoginName = tmp;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(login);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(login);
			}
		}
		/// <summary>
		/// Récupère le mot de passe
		/// </summary>
		/// <returns></returns>
		public string GetPassword()
		{
			try
			{
				return ((SipConfig)_Instance._Terminal.SipConfig).UserPassword;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe le mot de passe
		/// </summary>
		/// <param name="pswd"></param>
		public void SetPassword(string pswd)
		{
			try
			{
                string tmp = pswd;
                if (tmp == null)
                {
                    tmp = "";
                }
                ((SipConfig)_Instance._Terminal.SipConfig).UserPassword = tmp;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(pswd);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(pswd);
			}
		}
		/// <summary>
		/// Récupère le username définit
		/// </summary>
		/// <returns></returns>
		public string GetUserName()
		{
			try
			{
				return ((SipConfig)_Instance._Terminal.SipConfig).UserName;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe le username spécifié
		/// </summary>
		/// <param name="name"></param>
		public void SetUserName(string name)
		{
			try
			{
                string tmp = name;
                if (tmp == null)
                {
                    tmp = "";
                }
                ((SipConfig)_Instance._Terminal.SipConfig).UserName = tmp;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(name);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(name);
			}
		}
		/// <summary>
		/// Récupère le display name
		/// </summary>
		/// <returns></returns>
		public string GetDisplayName()
		{
			try
			{
				return ((SipConfig)_Instance._Terminal.SipConfig).DisplayName;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (string)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (string)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe le display name
		/// </summary>
		/// <param name="name"></param>
		public void SetDisplayName(string name)
		{
			try
			{
                string tmp = name;
                if (tmp == null)
                {
                    tmp = "";
                }
				((SipConfig)_Instance._Terminal.SipConfig).DisplayName = name;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(name);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(name);
			}
		}
		/// <summary>
		/// Récupère si on s'abonne au registrar par défaut
		/// </summary>
		/// <returns></returns>
		public bool GetUseRegistrarInfo()
		{
			try
			{
				return ((SipConfig)_Instance._Terminal.SipConfig).UseRegistrarInfo==1;

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe si on utilise le registrar par défaut
		/// </summary>
		/// <param name="newVal"></param>
		public void SetUseRegistrarInfo(bool newVal)
		{
			try
			{
				if(newVal)
				{
					((SipConfig)_Instance._Terminal.SipConfig).UseRegistrarInfo=1;
				}
				else
				{
					((SipConfig)_Instance._Terminal.SipConfig).UseRegistrarInfo=0;
				}

			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(newVal);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(newVal);
			}
		}
		/// <summary>
		/// Sauvegarde la configuration SIP
		/// </summary>
		public void SaveSIPConfig()
		{
			try
			{
				((SipConfig)_Instance._Terminal.SipConfig).Save();
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(null);
			}
		}
		#endregion
		/// <summary>
		/// S'enregistre auprès du registrar
		/// </summary>
		public void PerformRegister()
		{
			try
			{
				((ISipTerminal)_Instance._Terminal.SIPTerm).PerformRegister();
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Se désabonne du registrar
		/// </summary>
		public void PerformUnregister()
		{
			try
			{
				((ISipTerminal)_Instance._Terminal.SIPTerm).PerformUnregister();
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(null);
			}
		}
		#endregion

		#region call
		/// <summary>
		/// Récupère l'état de l'appel
		/// </summary>
		/// <param name="CallId"></param>
		/// <returns></returns>
		public int GetCallInfoState(int CallId)
		{
			try
			{
				return _Terminal.get_CallInfoState(CallId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return Convert.ToInt32(HandleConnectionLoss(CallId));
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return Convert.ToInt32(HandleConnectionLoss(CallId));
			}
		}

		/// <summary>
		/// Récupère l'état de l'appel
		/// </summary>
		/// <param name="CallId"></param>
		/// <returns></returns>
		public int GetCallInfoCaps(int CallId)
		{
			try
			{
				return _Terminal.get_CallInfoCaps(CallId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return Convert.ToInt32(HandleConnectionLoss(CallId));
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return Convert.ToInt32(HandleConnectionLoss(CallId));
			}
		}
		/// <summary>
		/// Récupère l'état de l'appel
		/// </summary>
		/// <param name="CallId"></param>
		/// <returns></returns>
		public int GetCallState(int CallId)
		{
			try
			{
				return _Terminal.get_CallInfoState(CallId);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return Convert.ToInt32(HandleConnectionLoss(CallId));
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return Convert.ToInt32(HandleConnectionLoss(CallId));
			}
		}
		/// <summary>
		/// Récupère le nombre d'appel actif
		/// </summary>
		/// <returns></returns>
		public int GetNumberOfActiveCalls()
		{
			try
			{
				return _Terminal.NumberOfActiveCalls;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return Convert.ToInt32(HandleConnectionLoss(null));
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return Convert.ToInt32(HandleConnectionLoss(null));
			}
		}
		/// <summary>
		/// Place l'appel
		/// </summary>
		/// <param name="Protocol"></param>
		/// <param name="Address"></param>
		/// <param name="CallType"></param>
		public void PerformCall(eConf.eProtocol Protocol,string Address, eConf.eCallType CallType)
		{
			try
			{
				_Terminal.Call(Protocol, Address, (short)CallType);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(Protocol, Address, CallType);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(Protocol, Address, CallType);
			}
		}
		/// <summary>
		/// Transfert l'appel
		/// </summary>
		/// <param name="Address"></param>
		/// <param name="CallType"></param>
		/// <param name="CallID"></param>
		public void TransferCall(string Address, eConf.eCallType CallType, int CallID)
		{
			try
			{
				_Terminal.CallTransfer(Address,CallType,CallID);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(Address,CallType,CallID);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(Address,CallType,CallID);
			}
		}
		/// <summary>
		/// Raccroche l'appel
		/// </summary>
		/// <param name="CallID"></param>
		public void Hangup(int CallID)
		{
			try
			{
				_Terminal.Hangup(CallID);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID);
			}
		}
		/// <summary>
		/// Accepte l'appel
		/// </summary>
		/// <param name="CallID"></param>
		public void AcceptCall(int CallID)
		{
			try
			{
				_Terminal.AcceptCall(CallID);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID);
			}
		}
		/// <summary>
		/// Rejète l'appel
		/// </summary>
		/// <param name="CallID"></param>
		public void RejectCall(int CallID)
		{
			try
			{
				_Terminal.RejectCall(CallID);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID);
			}
		}
		#endregion

		#region DTFM
		/// <summary>
		/// Envoi un DTMF
		/// </summary>
		/// <param name="CallID"></param>
		/// <param name="DTMF"></param>
		public void SendDTMF(int CallID, string DTMF)
		{
			try
			{
				_Terminal.SendDTMF(0,DTMF);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID, DTMF);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID, DTMF);
			}
            
		}
		
		/// <summary>
		/// Envoi un dtmf dans la bande
		/// </summary>
		/// <param name="CallID"></param>
		/// <param name="DTMF"></param>
		/// <param name="duration"></param>
		public void SendDTMFInBand(int CallID, string DTMF, int duration)
		{
			try
			{                
				_Terminal.SendDTMFInBand(CallID,DTMF,duration);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID, DTMF,duration);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID, DTMF, duration);
			}
		}
		/// <summary>
		/// Envoie le dtmf en RFC2833 info
		/// </summary>
		/// <param name="CallID"></param>
		/// <param name="DTMF"></param>
        public void SendDTMFRFC2833Info(short CallID, string DTMF, int duration)
		{
			try
			{
                ((ISipTerminal)_Instance._Terminal.SIPTerm).SendDTMFRFC2833Info(CallID, DTMF, duration);
				//_Terminal.SendDTMF(CallID,DTMF);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID, DTMF);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID,DTMF);
			}
		}
		/// <summary>
		/// Envoie un DTMF
		/// </summary>
		/// <param name="CallID"></param>
		/// <param name="DTMF"></param>
		/// <param name="duration"></param>
		public void SendDTMFRelay(short CallID, string DTMF, int duration)
		{
			try
			{
				((ISipTerminal)_Instance._Terminal.SIPTerm).SendDTMFRelay(CallID,DTMF,duration);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallID, DTMF,duration);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallID,DTMF,duration);
			}
		}
		#endregion

		#region AV options
		/// <summary>
		/// Récupère si le cannel audio est muté
		/// </summary>
		/// <param name="nId"></param>
		/// <returns></returns>
		public bool GetOutputMute(short nId)
		{
			try
			{
				return ((eConf.TerminalAVOptions)_Terminal.AVOptions).get_OutputMute(nId)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(nId);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(nId);
			}
		}
		/// <summary>
		/// Fixe le cannal audio spécifié a mute
		/// </summary>
		/// <param name="nId"></param>
		/// <param name="newVal"></param>
		public void SetOutputMute(short nId, bool newVal)
		{
			try
			{
				_TerminalAVOptions.set_OutputMute(nId,Convert.ToInt32(newVal));
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(nId, newVal);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(nId, newVal);
			}
		}
		/// <summary>
		/// Récupère on n'envoie aucun son
		/// </summary>
		/// <returns></returns>
		public bool GetInputMute()
		{
			try
			{
				return ((eConf.TerminalAVOptions)_Terminal.AVOptions).InputMute==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(null);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(null);
			}
		}
		/// <summary>
		/// Fixe si on n'envoie aucun son
		/// </summary>
		/// <param name="bMute"></param>
		public void SetInputMute(bool bMute)
		{
			try
			{
				((eConf.TerminalAVOptions)_Terminal.AVOptions).InputMute=Convert.ToInt32(bMute);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(bMute);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(bMute);
			}
		}
		/// <summary>
		/// Récupère si on n'envoie aucun flux vidéo au correspondant spécifié
		/// </summary>
		/// <param name="ChannelID"></param>
		/// <returns></returns>
		public bool GetVideoMute(short ChannelID)
		{
			try
			{
				return ((eConf.TerminalAVOptions)_Terminal.AVOptions).GetVideoMute(ChannelID)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(ChannelID);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(ChannelID);
			}
		}
		/// <summary>
		/// Fixe si on n'envoie la vidéo au coresspondant spécifié
		/// </summary>
		/// <param name="ChannelID"></param>
		/// <param name="newVal"></param>
		public void SetVideoMute(short ChannelID, bool newVal)
		{
			try
			{
				((eConf.TerminalAVOptions)_Terminal.AVOptions).SetVideoMute(ChannelID,Convert.ToInt16(newVal));
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(ChannelID, newVal);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(ChannelID, newVal);
			}
		}
		#endregion

		#region AV Control
		/// <summary>
		/// Récupère les informations spécifés
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="InfoType"></param>
		/// <param name="ChannelID"></param>
		/// <returns></returns>
		public int GetRTPInfo(int CallId, short InfoType,short ChannelID)
		{
			try
			{
				return ((ITerminalAVControl)_Terminal.AVControl).get_RTPInfo(CallId,InfoType, ChannelID);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return Convert.ToInt32(HandleConnectionLoss(CallId, InfoType, ChannelID));
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return Convert.ToInt32(HandleConnectionLoss(CallId, InfoType, ChannelID));
			}
		}
		#endregion

		#region Divers
		/// <summary>
		/// Démarre la décoration du flux vidéo spécifié
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="ChannelId"></param>
		/// <param name="ImagePath"></param>
		/// <returns></returns>
		public bool StartDecorateVideo(int CallId,int ChannelId, string ImagePath)
		{
			try
			{
				return ((IDecorateVideoService)_Terminal.DVService).StartDecorateVideo(CallId, ChannelId, ImagePath)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(CallId, ChannelId, ImagePath);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(CallId, ChannelId, ImagePath);
			}
		}
		/// <summary>
		/// Arrête la décoration vidéo du flux vidéo spécifié
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="ChannelId"></param>
		/// <returns></returns>
		public bool StopDecorateVideo(int CallId,int ChannelId)
		{
			try
			{
				return ((IDecorateVideoService)_Terminal.DVService).StopDecorateVideo(CallId, ChannelId)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(CallId, ChannelId);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(CallId, ChannelId);
			}
		}
		/// <summary>
		/// Capture l'image du flux vidéo
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="FileName"></param>
		/// <param name="mediaType"></param>
		/// <returns></returns>
		public bool RecordingPicture(int CallId, string FileName, EconfDatas.MediaStreamType mediaType)
		{
			try
			{
				return ((eConf.IRecordMediaService)_Terminal.RMService).RecordingPicture(CallId, FileName, (short)mediaType)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(CallId, FileName, mediaType);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(CallId, FileName, mediaType);
			}
		}
		/// <summary>
		/// Démarre l'enregistrement d'une vidéo
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="FileName"></param>
		/// <param name="TypeCallRecord"></param>
		/// <param name="AudioOnly"></param>
		/// <returns></returns>
		public bool StartRecordingMedia(int CallId, string FileName, EconfDatas.RecordType TypeCallRecord, int AudioOnly)
		{
			try
			{
				return ((eConf.IRecordMediaService)_Terminal.RMService).StartRecordingMedia(CallId, FileName, (int)TypeCallRecord,AudioOnly)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(FileName, TypeCallRecord, AudioOnly);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(FileName, TypeCallRecord, AudioOnly);
			}
		}
		/// <summary>
		/// Arrête l'enregistrement d'une vidéo
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="FileDuration"></param>
		/// <param name="FileSize"></param>
		/// <param name="StreamType"></param>
		/// <returns></returns>
		public bool StopRecordingMedia(int CallId, out int FileDuration, out int FileSize, out EconfDatas.RecordType StreamType)
		{
			int intStreamType;
			FileDuration = -1;
			FileSize= -1;
			StreamType= EconfDatas.RecordType.MS_CONF_ALL_MEDIA;
            
			bool Ret = false;
			try
			{
				Ret = ((eConf.IRecordMediaService)_Terminal.RMService).StopRecordingMedia(CallId, out FileDuration, out FileSize,out intStreamType)==1;
                StreamType = (EconfDatas.RecordType)intStreamType;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				object [] objs = new object[4];
				objs[0] = CallId;
				objs[1] = FileDuration;
				objs[2] = FileSize;
				objs[3] = StreamType;
				Ret = (bool)HandleConnectionLoss(objs);
				FileDuration =	(int)objs[1];
				FileSize =		(int)objs[2];
                StreamType = (EconfDatas.RecordType)objs[3];
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				object [] objs = new object[4];
				objs[0] = CallId;
				objs[1] = FileDuration;
				objs[2] = FileSize;
				objs[3] = StreamType;
				Ret = (bool)HandleConnectionLoss(objs);
				FileDuration =	(int)objs[1];
				FileSize =		(int)objs[2];
                StreamType = (EconfDatas.RecordType)objs[3];
			}
			return Ret;
		}
		/// <summary>
		/// Envoi le fichier spécifié
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="FilePath"></param>
		public void SendFile(int CallId, string FilePath)
		{
			try
			{
				_Instance._Terminal.SendFile(CallId,FilePath);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallId, FilePath);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallId, FilePath);
			}
		}
		/// <summary>
		/// Envoie le texte spécifié
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="TextToFile"></param>
		public void SendText(int CallId, string TextToFile)
		{
			try
			{
				_Instance._Terminal.SendText(CallId,TextToFile);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				HandleConnectionLoss(CallId, TextToFile);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				HandleConnectionLoss(CallId, TextToFile);
			}
		}
		#endregion

		#region Media functions
		/// <summary>
		/// Commence le streaming vidéo du fichier spécifié
		/// </summary>
		/// <param name="callId"></param>
		/// <param name="mediafFile"></param>
		/// <param name="iteration">Nombre d'itération : 0, boucle infini</param>
		/// <returns></returns>
		public bool PlayMediaFile(int callId,string mediafFile, int iteration)
		{
			try
			{
				return (((IPlayMediaService)_Instance._Terminal.PMService).PlayMediaFile(callId,mediafFile, iteration)==1);
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(callId, mediafFile, iteration);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(callId, mediafFile, iteration);
			}
		}
		/// <summary>
		/// Pause sur le fichier média
		/// </summary>
		/// <param name="callId"></param>
		/// <param name="statePlay"></param>
		/// <returns></returns>
		public bool PauseMediaFile(int callId, int statePlay)
		{
			try
			{
				return ((IPlayMediaService)_Instance._Terminal.PMService).PauseMediaFile(callId, statePlay)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(callId, statePlay);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(callId, statePlay);
			}
		}
		/// <summary>
		/// Fixe le mode de diffusion
		/// </summary>
		/// <param name="CallId"></param>
		/// <param name="VideoSource"></param>
		/// <param name="Volume"></param>
		/// <returns></returns>
		public bool SetMediaMode(int CallId, int VideoSource, int Volume)
		{
			try
			{
				return ((IPlayMediaService)_Instance._Terminal.PMService).SetMediaMode(CallId, VideoSource, Volume)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(CallId, VideoSource, Volume);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(CallId, VideoSource, Volume);
			}
		}
		/// <summary>
		/// Arrête la diffusion de média
		/// </summary>
		/// <param name="CallId"></param>
		/// <returns></returns>
		public bool StopMediaFile(int CallId)
		{
			try
			{
				return ((IPlayMediaService)_Instance._Terminal.PMService).StopMediaFile(CallId)==1;
			}
			catch(System.InvalidCastException castException)
			{
				Tools.Trace.WriteLine(castException);
				return (bool)HandleConnectionLoss(CallId);
			}
			catch(System.Runtime.InteropServices.COMException COMexception)
			{
				Tools.Trace.WriteLine(COMexception);
				return (bool)HandleConnectionLoss(CallId);
			}
		}
		#endregion
		#endregion

		#region private methods
		/// <summary>
		/// Vérifie l'instanciation de la classe. Si non instancié, elle crée une instance et s'abonne aux événements
		/// </summary>
		private void CheckInstance()
		{
			try
			{
				if(_IsConnected)
				{
					return;
				}
				else
				{
					Tools.Trace.WriteLog("Econfplayer : Création d'une instance");
					_EConfPlayer = new eConfPlayer.eConfPlayerClass();
					_EConfPlayer.OnAppExit+=new eConfPlayer._IeConfPlayerEvents_OnAppExitEventHandler(_EConfPlayer_OnAppExit);
					_Terminal = (Terminal)_EConfPlayer.Conf;
					_TerminalAVControl = (eConf.TerminalAVControl) _Terminal.AVControl;
					_TerminalAVOptions = (eConf.TerminalAVOptions) _Terminal.AVOptions;
					_SipTerminal = (eConf.SipTerminal)_Terminal.SIPTerm;
					if(_Terminal!=null)
					{
						//On s'abonne à tous les événements de l'interface terminal events
						//Elle a presque tous les événéments sauf qqs
						_Terminal.OnAddMsg+=new _ITerminalEvents_OnAddMsgEventHandler(_Terminal_OnAddMsg);
						_Terminal.OnArchiveMsg+=new _ITerminalEvents_OnArchiveMsgEventHandler(_Terminal_OnArchiveMsg);
						_Terminal.OnAudioLevel+=new _ITerminalEvents_OnAudioLevelEventHandler(_Terminal_OnAudioLevel);
						_Terminal.OnAudioLevelGrabber+=new _ITerminalEvents_OnAudioLevelGrabberEventHandler(_Terminal_OnAudioLevelGrabber);
						_Terminal.OnAudioOnly+=new _ITerminalEvents_OnAudioOnlyEventHandler(_Terminal_OnAudioOnly);
						_Terminal.OnBadMsgAnswering+=new _ITerminalEvents_OnBadMsgAnsweringEventHandler(_Terminal_OnBadMsgAnswering);
						_Terminal.OnBeginCaptureMsg+=new _ITerminalEvents_OnBeginCaptureMsgEventHandler(_Terminal_OnBeginCaptureMsg);
						_Terminal.OnBenchStatus+=new _ITerminalEvents_OnBenchStatusEventHandler(_Terminal_OnBenchStatus);
						_Terminal.OnCalling+=new _ITerminalEvents_OnCallingEventHandler(_Terminal_OnCalling);
						_Terminal.OnCallFailed+=new _ITerminalEvents_OnCallFailedEventHandler(_Terminal_OnCallFailed);
						_Terminal.OnCallLocalAccepted+=new _ITerminalEvents_OnCallLocalAcceptedEventHandler(_Terminal_OnCallLocalAccepted);
						_Terminal.OnCallLocalRejected+=new _ITerminalEvents_OnCallLocalRejectedEventHandler(_Terminal_OnCallLocalRejected);
						_Terminal.OnCallRejected+=new _ITerminalEvents_OnCallRejectedEventHandler(_Terminal_OnCallRejected);
						_Terminal.OnCallStackStarted+=new _ITerminalEvents_OnCallStackStartedEventHandler(_Terminal_OnCallStackStarted);
						_Terminal.OnChangeActivate+=new _ITerminalEvents_OnChangeActivateEventHandler(_Terminal_OnChangeActivate);
						_Terminal.OnChangeAnnonce+=new _ITerminalEvents_OnChangeAnnonceEventHandler(_Terminal_OnChangeAnnonce);
						_Terminal.OnChangeDiskAllocation+=new _ITerminalEvents_OnChangeDiskAllocationEventHandler(_Terminal_OnChangeDiskAllocation);
						_Terminal.OnChangeLocMsg+=new _ITerminalEvents_OnChangeLocMsgEventHandler(_Terminal_OnChangeLocMsg);
						_Terminal.OnChangeMaxDuration+=new _ITerminalEvents_OnChangeMaxDurationEventHandler(_Terminal_OnChangeMaxDuration);
						_Terminal.OnChangeNoAnswer+=new _ITerminalEvents_OnChangeNoAnswerEventHandler(_Terminal_OnChangeNoAnswer);
						_Terminal.OnChangeRecorderType+=new _ITerminalEvents_OnChangeRecorderTypeEventHandler(_Terminal_OnChangeRecorderType);
						_Terminal.OnChangeTotalDurationMsgUsed+=new _ITerminalEvents_OnChangeTotalDurationMsgUsedEventHandler(_Terminal_OnChangeTotalDurationMsgUsed);
						_Terminal.OnChannelMuted+=new _ITerminalEvents_OnChannelMutedEventHandler(_Terminal_OnChannelMuted);
						_Terminal.OnConnect+=new _ITerminalEvents_OnConnectEventHandler(_Terminal_OnConnect);
						_Terminal.OnConsoleMessage+=new _ITerminalEvents_OnConsoleMessageEventHandler(_Terminal_OnConsoleMessage);
						_Terminal.OnContactAdded+=new _ITerminalEvents_OnContactAddedEventHandler(_Terminal_OnContactAdded);
						_Terminal.OnContactRemoved+=new _ITerminalEvents_OnContactRemovedEventHandler(_Terminal_OnContactRemoved);
						_Terminal.OnCPLExit+=new _ITerminalEvents_OnCPLExitEventHandler(_Terminal_OnCPLExit);
						_Terminal.OnCPLOpen+=new _ITerminalEvents_OnCPLOpenEventHandler(_Terminal_OnCPLOpen);
						_Terminal.OnDataReceived+=new _ITerminalEvents_OnDataReceivedEventHandler(_Terminal_OnDataReceived);
						_Terminal.OnDataUTF8Received+=new _ITerminalEvents_OnDataUTF8ReceivedEventHandler(_Terminal_OnDataUTF8Received);
						_Terminal.OnDelAllMsg+=new _ITerminalEvents_OnDelAllMsgEventHandler(_Terminal_OnDelAllMsg);
						_Terminal.OnDelMsg+=new _ITerminalEvents_OnDelMsgEventHandler(_Terminal_OnDelMsg);
						_Terminal.OnDisconnect+=new _ITerminalEvents_OnDisconnectEventHandler(_Terminal_OnDisconnect);
						_Terminal.OnDropFileInfoCount+=new _ITerminalEvents_OnDropFileInfoCountEventHandler(_Terminal_OnDropFileInfoCount);
						_Terminal.OnDropFileInfoElem+=new _ITerminalEvents_OnDropFileInfoElemEventHandler(_Terminal_OnDropFileInfoElem);
						_Terminal.OnDTMFReceived+=new _ITerminalEvents_OnDTMFReceivedEventHandler(_Terminal_OnDTMFReceived);
						_Terminal.OnDTMFSent+=new _ITerminalEvents_OnDTMFSentEventHandler(_Terminal_OnDTMFSent);
						_Terminal.OnErrorAnswering+=new _ITerminalEvents_OnErrorAnsweringEventHandler(_Terminal_OnErrorAnswering);
						_Terminal.OnFileTransferStarted+=new eConf._ITerminalEvents_OnFileTransferStartedEventHandler(_Terminal_OnFileTransferStarted);
						_Terminal.OnFileTransferProgress+=new eConf._ITerminalEvents_OnFileTransferProgressEventHandler(_Terminal_OnFileTransferProgress);
						_Terminal.OnFileTransferCanceled+=new eConf._ITerminalEvents_OnFileTransferCanceledEventHandler(_Terminal_OnFileTransferCanceled);
						_Terminal.OnFileTransferCompleted+=new eConf._ITerminalEvents_OnFileTransferCompletedEventHandler(_Terminal_OnFileTransferCompleted);
						_Terminal.OnFinishCaptureMsg+=new _ITerminalEvents_OnFinishCaptureMsgEventHandler(_Terminal_OnFinishCaptureMsg);
						_Terminal.OnGKConnect+=new _ITerminalEvents_OnGKConnectEventHandler(_Terminal_OnGKConnect);
						_Terminal.OnGKDisconnect+=new _ITerminalEvents_OnGKDisconnectEventHandler(_Terminal_OnGKDisconnect);
						_Terminal.OnH245Indication+=new _ITerminalEvents_OnH245IndicationEventHandler(_Terminal_OnH245Indication);
						_Terminal.OnH323Alert+=new _ITerminalEvents_OnH323AlertEventHandler(_Terminal_OnH323Alert);
						_Terminal.OnH323Indication+=new _ITerminalEvents_OnH323IndicationEventHandler(_Terminal_OnH323Indication);
						_Terminal.OnH323RASIndication+=new _ITerminalEvents_OnH323RASIndicationEventHandler(_Terminal_OnH323RASIndication);
						_Terminal.OnIMMessageInCall+=new _ITerminalEvents_OnIMMessageInCallEventHandler(_Terminal_OnIMMessageInCall);
						_Terminal.OnIMMessageOutOfCall+=new _ITerminalEvents_OnIMMessageOutOfCallEventHandler(_Terminal_OnIMMessageOutOfCall);
						_Terminal.OnIncomingCall+=new _ITerminalEvents_OnIncomingCallEventHandler(_Terminal_OnIncomingCall);
						_Terminal.OnIncomingCallEx+=new _ITerminalEvents_OnIncomingCallExEventHandler(_Terminal_OnIncomingCallEx);
						_Terminal.OnInfoCard+=new _ITerminalEvents_OnInfoCardEventHandler(_Terminal_OnInfoCard);
						_Terminal.OnINFOMessageInCallReceived+=new _ITerminalEvents_OnINFOMessageInCallReceivedEventHandler(_Terminal_OnINFOMessageInCallReceived);
						_Terminal.OnINFOMessageOutOfCallReceived+=new _ITerminalEvents_OnINFOMessageOutOfCallReceivedEventHandler(_Terminal_OnINFOMessageOutOfCallReceived);
						_Terminal.OnInputGain+=new _ITerminalEvents_OnInputGainEventHandler(_Terminal_OnInputGain);
						_Terminal.OnInputMute+=new _ITerminalEvents_OnInputMuteEventHandler(_Terminal_OnInputMute);
						_Terminal.OnInterceptCall+=new _ITerminalEvents_OnInterceptCallEventHandler(_Terminal_OnInterceptCall);
						_Terminal.OnNetworkStateChanged+=new _ITerminalEvents_OnNetworkStateChangedEventHandler(_Terminal_OnNetworkStateChanged);
						_Terminal.OnNewMember+=new _ITerminalEvents_OnNewMemberEventHandler(_Terminal_OnNewMember);
						_Terminal.OnNewName+=new _ITerminalEvents_OnNewNameEventHandler(_Terminal_OnNewName);
						_Terminal.OnNewVideoFormat+=new _ITerminalEvents_OnNewVideoFormatEventHandler(_Terminal_OnNewVideoFormat);
						_Terminal.OnOutbandDTMF+=new _ITerminalEvents_OnOutbandDTMFEventHandler(_Terminal_OnOutbandDTMF);
						_Terminal.OnPeerAddress+=new _ITerminalEvents_OnPeerAddressEventHandler(_Terminal_OnPeerAddress);
						_Terminal.OnPictureTaking+=new _ITerminalEvents_OnPictureTakingEventHandler(_Terminal_OnPictureTaking);
						_Terminal.OnPlayMediaFile+=new _ITerminalEvents_OnPlayMediaFileEventHandler(_Terminal_OnPlayMediaFile);
						_Terminal.OnQ931Indication+=new _ITerminalEvents_OnQ931IndicationEventHandler(_Terminal_OnQ931Indication);
						_Terminal.OnQ931MessageReceived+=new _ITerminalEvents_OnQ931MessageReceivedEventHandler(_Terminal_OnQ931MessageReceived);
						_Terminal.OnRawSIPMessageReceived+=new _ITerminalEvents_OnRawSIPMessageReceivedEventHandler(_Terminal_OnRawSIPMessageReceived);
						_Terminal.OnReadMsg+=new _ITerminalEvents_OnReadMsgEventHandler(_Terminal_OnReadMsg);
						_Terminal.OnRemotePartyInfo+=new _ITerminalEvents_OnRemotePartyInfoEventHandler(_Terminal_OnRemotePartyInfo);
						_Terminal.OnRemotePartyRinging+=new _ITerminalEvents_OnRemotePartyRingingEventHandler(_Terminal_OnRemotePartyRinging);
						_Terminal.OnRemoveSubscription+=new _ITerminalEvents_OnRemoveSubscriptionEventHandler(_Terminal_OnRemoveSubscription);
						_Terminal.OnSipPresenceStatus+=new _ITerminalEvents_OnSipPresenceStatusEventHandler(_Terminal_OnSipPresenceStatus);
						_Terminal.OnSipRegistrationResult+=new _ITerminalEvents_OnSipRegistrationResultEventHandler(_Terminal_OnSipRegistrationResult);
						_Terminal.OnStandardCodecsNegotiated+=new _ITerminalEvents_OnStandardCodecsNegotiatedEventHandler(_Terminal_OnStandardCodecsNegotiated);
						_Terminal.OnStartAudioDecoder+=new _ITerminalEvents_OnStartAudioDecoderEventHandler(_Terminal_OnStartAudioDecoder);
						_Terminal.OnStartAudioEncoder+=new _ITerminalEvents_OnStartAudioEncoderEventHandler(_Terminal_OnStartAudioEncoder);
						_Terminal.OnStartDataDecoder+=new _ITerminalEvents_OnStartDataDecoderEventHandler(_Terminal_OnStartDataDecoder);
						_Terminal.OnStartDataEncoder+=new _ITerminalEvents_OnStartDataEncoderEventHandler(_Terminal_OnStartDataEncoder);
						_Terminal.OnStartTextT140Decoder+=new _ITerminalEvents_OnStartTextT140DecoderEventHandler(_Terminal_OnStartTextT140Decoder);
						_Terminal.OnStartTextT140Encoder+=new _ITerminalEvents_OnStartTextT140EncoderEventHandler(_Terminal_OnStartTextT140Encoder);
						_Terminal.OnStatusChanged+=new _ITerminalEvents_OnStatusChangedEventHandler(_Terminal_OnStatusChanged);
						_Terminal.OnStopAudioDecoder+=new _ITerminalEvents_OnStopAudioDecoderEventHandler(_Terminal_OnStopAudioDecoder);
						_Terminal.OnStopAudioEncoder+=new _ITerminalEvents_OnStopAudioEncoderEventHandler(_Terminal_OnStopAudioEncoder);
						_Terminal.OnStopDataDecoder+=new _ITerminalEvents_OnStopDataDecoderEventHandler(_Terminal_OnStopDataDecoder);
						_Terminal.OnStopDataEncoder+=new _ITerminalEvents_OnStopDataEncoderEventHandler(_Terminal_OnStopDataEncoder);
						_Terminal.OnStopTextT140DataDecoder+=new _ITerminalEvents_OnStopTextT140DataDecoderEventHandler(_Terminal_OnStopTextT140DataDecoder);
						_Terminal.OnStopTextT140DataEncoder+=new _ITerminalEvents_OnStopTextT140DataEncoderEventHandler(_Terminal_OnStopTextT140DataEncoder);
						_Terminal.OnSubscription+=new _ITerminalEvents_OnSubscriptionEventHandler(_Terminal_OnSubscription);
						_Terminal.OnSubscriptionAccepted+=new _ITerminalEvents_OnSubscriptionAcceptedEventHandler(_Terminal_OnSubscriptionAccepted);
						_Terminal.OnSubscriptionPending+=new _ITerminalEvents_OnSubscriptionPendingEventHandler(_Terminal_OnSubscriptionPending);
						_Terminal.OnSubscriptionRefused+=new _ITerminalEvents_OnSubscriptionRefusedEventHandler(_Terminal_OnSubscriptionRefused);
						_Terminal.OnT120Connect+=new _ITerminalEvents_OnT120ConnectEventHandler(_Terminal_OnT120Connect);
						_Terminal.OnT120Disconnect+=new _ITerminalEvents_OnT120DisconnectEventHandler(_Terminal_OnT120Disconnect);
						_Terminal.OnVideoQuality+=new _ITerminalEvents_OnVideoQualityEventHandler(_Terminal_OnVideoQuality);
					}

					if(_SipTerminal!=null)
					{
						//On s'abonne au terminal SIP
						_SipTerminal.OnOutbandDTMF+=new eConf._ISipTerminalEvents_OnOutbandDTMFEventHandler(_SipTerminal_OnOutbandDTMF);
					}
					if(_TerminalAVOptions!=null)
					{
						_TerminalAVOptions.OnOutputMute+=new _ITerminalAVOptionsEvents_OnOutputMuteEventHandler(_TerminalAVOptions_OnOutputMute);
					}
					if(_TerminalAVControl!=null)
					{
						_TerminalAVControl.OnStartVideoDecoder+=new _ITerminalAVControlEvents_OnStartVideoDecoderEventHandler(_TerminalAVControl_OnStartVideoDecoder);
						_TerminalAVControl.OnStartVideoDecoderEx+=new _ITerminalAVControlEvents_OnStartVideoDecoderExEventHandler(_TerminalAVControl_OnStartVideoDecoderEx);
						_TerminalAVControl.OnStartVideoEncoder+=new _ITerminalAVControlEvents_OnStartVideoEncoderEventHandler(_TerminalAVControl_OnStartVideoEncoder);
						_TerminalAVControl.OnStopVideoDecoder+=new _ITerminalAVControlEvents_OnStopVideoDecoderEventHandler(_TerminalAVControl_OnStopVideoDecoder);
						_TerminalAVControl.OnStopVideoDecoderEx+=new _ITerminalAVControlEvents_OnStopVideoDecoderExEventHandler(_TerminalAVControl_OnStopVideoDecoderEx);
						_TerminalAVControl.OnStopVideoEncoder+=new _ITerminalAVControlEvents_OnStopVideoEncoderEventHandler(_TerminalAVControl_OnStopVideoEncoder);
					}
					try
					{
						//On retrouve le chemin du répertoire d'Econf
						eConf.IVersionInfo IEConfInfo = (eConf.IVersionInfo)_Terminal.VersionInfo;
						_EConfRoot = IEConfInfo.RootPath;
					}
					catch(Exception exception)
					{
						Tools.Trace.WriteLine(exception);
					}
					if(_Timer!=null)
					{
						_Timer.Dispose();
					}
					_Timer = new System.Threading.Timer(new System.Threading.TimerCallback(TickHandleEvents),null,500,_PeriodRefresh);
					
					_IsConnected = true;
					if(Connected!=null)
					{
						Connected(this, new System.EventArgs());
					}
				}
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception);
			}
		}
		private void UnsubscribeTimeoutHandler(object obj, bool timeout)
		{
			if(_UnsubscribeWaitHandle!=null)
			{
				_UnsubscribeWaitHandle.Set();
				_UnsubscribeThread.Abort();
			}
		}
		
		private void ASyncUnsubscribe()
		{
			try
			{
				Tools.Trace.WriteLog("Econfplayer : Désenregistrement au événement de l'instance.");
				if(_Instance._EConfPlayer!=null)
				{
					_Instance._EConfPlayer.OnAppExit-=new eConfPlayer._IeConfPlayerEvents_OnAppExitEventHandler(_EConfPlayer_OnAppExit);
				}
				if(_Instance._Terminal!=null)
				{
					_Instance._Terminal.OnAddMsg-=new _ITerminalEvents_OnAddMsgEventHandler(_Terminal_OnAddMsg);
					_Instance._Terminal.OnArchiveMsg-=new _ITerminalEvents_OnArchiveMsgEventHandler(_Terminal_OnArchiveMsg);
					_Instance._Terminal.OnAudioLevel-=new _ITerminalEvents_OnAudioLevelEventHandler(_Terminal_OnAudioLevel);
					_Instance._Terminal.OnAudioLevelGrabber-=new _ITerminalEvents_OnAudioLevelGrabberEventHandler(_Terminal_OnAudioLevelGrabber);
					_Instance._Terminal.OnAudioOnly-=new _ITerminalEvents_OnAudioOnlyEventHandler(_Terminal_OnAudioOnly);
					_Instance._Terminal.OnBadMsgAnswering-=new _ITerminalEvents_OnBadMsgAnsweringEventHandler(_Terminal_OnBadMsgAnswering);
					_Instance._Terminal.OnBeginCaptureMsg-=new _ITerminalEvents_OnBeginCaptureMsgEventHandler(_Terminal_OnBeginCaptureMsg);
					_Instance._Terminal.OnBenchStatus-=new _ITerminalEvents_OnBenchStatusEventHandler(_Terminal_OnBenchStatus);
					_Instance._Terminal.OnCalling-=new _ITerminalEvents_OnCallingEventHandler(_Terminal_OnCalling);
					_Instance._Terminal.OnCallFailed-=new _ITerminalEvents_OnCallFailedEventHandler(_Terminal_OnCallFailed);
					_Instance._Terminal.OnCallLocalAccepted-=new _ITerminalEvents_OnCallLocalAcceptedEventHandler(_Terminal_OnCallLocalAccepted);
					_Instance._Terminal.OnCallLocalRejected-=new _ITerminalEvents_OnCallLocalRejectedEventHandler(_Terminal_OnCallLocalRejected);
					_Instance._Terminal.OnCallRejected-=new _ITerminalEvents_OnCallRejectedEventHandler(_Terminal_OnCallRejected);
					_Instance._Terminal.OnCallStackStarted-=new _ITerminalEvents_OnCallStackStartedEventHandler(_Terminal_OnCallStackStarted);
					_Instance._Terminal.OnChangeActivate-=new _ITerminalEvents_OnChangeActivateEventHandler(_Terminal_OnChangeActivate);
					_Instance._Terminal.OnChangeAnnonce-=new _ITerminalEvents_OnChangeAnnonceEventHandler(_Terminal_OnChangeAnnonce);
					_Instance._Terminal.OnChangeDiskAllocation-=new _ITerminalEvents_OnChangeDiskAllocationEventHandler(_Terminal_OnChangeDiskAllocation);
					_Instance._Terminal.OnChangeLocMsg-=new _ITerminalEvents_OnChangeLocMsgEventHandler(_Terminal_OnChangeLocMsg);
					_Instance._Terminal.OnChangeMaxDuration-=new _ITerminalEvents_OnChangeMaxDurationEventHandler(_Terminal_OnChangeMaxDuration);
					_Instance._Terminal.OnChangeNoAnswer-=new _ITerminalEvents_OnChangeNoAnswerEventHandler(_Terminal_OnChangeNoAnswer);
					_Instance._Terminal.OnChangeRecorderType-=new _ITerminalEvents_OnChangeRecorderTypeEventHandler(_Terminal_OnChangeRecorderType);
					_Instance._Terminal.OnChangeTotalDurationMsgUsed-=new _ITerminalEvents_OnChangeTotalDurationMsgUsedEventHandler(_Terminal_OnChangeTotalDurationMsgUsed);
					_Instance._Terminal.OnChannelMuted-=new _ITerminalEvents_OnChannelMutedEventHandler(_Terminal_OnChannelMuted);
					_Instance._Terminal.OnConnect-=new _ITerminalEvents_OnConnectEventHandler(_Terminal_OnConnect);
					_Instance._Terminal.OnConsoleMessage-=new _ITerminalEvents_OnConsoleMessageEventHandler(_Terminal_OnConsoleMessage);
					_Instance._Terminal.OnContactAdded-=new _ITerminalEvents_OnContactAddedEventHandler(_Terminal_OnContactAdded);
					_Instance._Terminal.OnContactRemoved-=new _ITerminalEvents_OnContactRemovedEventHandler(_Terminal_OnContactRemoved);
					_Instance._Terminal.OnCPLExit-=new _ITerminalEvents_OnCPLExitEventHandler(_Terminal_OnCPLExit);
					_Instance._Terminal.OnCPLOpen-=new _ITerminalEvents_OnCPLOpenEventHandler(_Terminal_OnCPLOpen);
					_Instance._Terminal.OnDataReceived-=new _ITerminalEvents_OnDataReceivedEventHandler(_Terminal_OnDataReceived);
					_Instance._Terminal.OnDataUTF8Received-=new _ITerminalEvents_OnDataUTF8ReceivedEventHandler(_Terminal_OnDataUTF8Received);
					_Instance._Terminal.OnDelAllMsg-=new _ITerminalEvents_OnDelAllMsgEventHandler(_Terminal_OnDelAllMsg);
					_Instance._Terminal.OnDelMsg-=new _ITerminalEvents_OnDelMsgEventHandler(_Terminal_OnDelMsg);
					_Instance._Terminal.OnDisconnect-=new _ITerminalEvents_OnDisconnectEventHandler(_Terminal_OnDisconnect);
					_Instance._Terminal.OnDropFileInfoCount-=new _ITerminalEvents_OnDropFileInfoCountEventHandler(_Terminal_OnDropFileInfoCount);
					_Instance._Terminal.OnDropFileInfoElem-=new _ITerminalEvents_OnDropFileInfoElemEventHandler(_Terminal_OnDropFileInfoElem);
					_Instance._Terminal.OnDTMFReceived-=new _ITerminalEvents_OnDTMFReceivedEventHandler(_Terminal_OnDTMFReceived);
					_Instance._Terminal.OnDTMFSent-=new _ITerminalEvents_OnDTMFSentEventHandler(_Terminal_OnDTMFSent);
					_Instance._Terminal.OnErrorAnswering-=new _ITerminalEvents_OnErrorAnsweringEventHandler(_Terminal_OnErrorAnswering);
					_Instance._Terminal.OnFileTransferStarted-=new eConf._ITerminalEvents_OnFileTransferStartedEventHandler(_Terminal_OnFileTransferStarted);
					_Instance._Terminal.OnFileTransferProgress-=new eConf._ITerminalEvents_OnFileTransferProgressEventHandler(_Terminal_OnFileTransferProgress);
					_Instance._Terminal.OnFileTransferCanceled-=new eConf._ITerminalEvents_OnFileTransferCanceledEventHandler(_Terminal_OnFileTransferCanceled);
					_Instance._Terminal.OnFileTransferCompleted-=new eConf._ITerminalEvents_OnFileTransferCompletedEventHandler(_Terminal_OnFileTransferCompleted);
					_Instance._Terminal.OnFinishCaptureMsg-=new _ITerminalEvents_OnFinishCaptureMsgEventHandler(_Terminal_OnFinishCaptureMsg);
					_Instance._Terminal.OnGKConnect-=new _ITerminalEvents_OnGKConnectEventHandler(_Terminal_OnGKConnect);
					_Instance._Terminal.OnGKDisconnect-=new _ITerminalEvents_OnGKDisconnectEventHandler(_Terminal_OnGKDisconnect);
					_Instance._Terminal.OnH245Indication-=new _ITerminalEvents_OnH245IndicationEventHandler(_Terminal_OnH245Indication);
					_Instance._Terminal.OnH323Alert-=new _ITerminalEvents_OnH323AlertEventHandler(_Terminal_OnH323Alert);
					_Instance._Terminal.OnH323Indication-=new _ITerminalEvents_OnH323IndicationEventHandler(_Terminal_OnH323Indication);
					_Instance._Terminal.OnH323RASIndication-=new _ITerminalEvents_OnH323RASIndicationEventHandler(_Terminal_OnH323RASIndication);
					_Instance._Terminal.OnIMMessageInCall-=new _ITerminalEvents_OnIMMessageInCallEventHandler(_Terminal_OnIMMessageInCall);
					_Instance._Terminal.OnIMMessageOutOfCall-=new _ITerminalEvents_OnIMMessageOutOfCallEventHandler(_Terminal_OnIMMessageOutOfCall);
					_Instance._Terminal.OnIncomingCall-=new _ITerminalEvents_OnIncomingCallEventHandler(_Terminal_OnIncomingCall);
					_Instance._Terminal.OnIncomingCallEx-=new _ITerminalEvents_OnIncomingCallExEventHandler(_Terminal_OnIncomingCallEx);
					_Instance._Terminal.OnInfoCard-=new _ITerminalEvents_OnInfoCardEventHandler(_Terminal_OnInfoCard);
					_Instance._Terminal.OnINFOMessageInCallReceived-=new _ITerminalEvents_OnINFOMessageInCallReceivedEventHandler(_Terminal_OnINFOMessageInCallReceived);
					_Instance._Terminal.OnINFOMessageOutOfCallReceived-=new _ITerminalEvents_OnINFOMessageOutOfCallReceivedEventHandler(_Terminal_OnINFOMessageOutOfCallReceived);
					_Instance._Terminal.OnInputGain-=new _ITerminalEvents_OnInputGainEventHandler(_Terminal_OnInputGain);
					_Instance._Terminal.OnInputMute-=new _ITerminalEvents_OnInputMuteEventHandler(_Terminal_OnInputMute);
					_Instance._Terminal.OnInterceptCall-=new _ITerminalEvents_OnInterceptCallEventHandler(_Terminal_OnInterceptCall);
					_Instance._Terminal.OnNetworkStateChanged-=new _ITerminalEvents_OnNetworkStateChangedEventHandler(_Terminal_OnNetworkStateChanged);
					_Instance._Terminal.OnNewMember-=new _ITerminalEvents_OnNewMemberEventHandler(_Terminal_OnNewMember);
					_Instance._Terminal.OnNewName-=new _ITerminalEvents_OnNewNameEventHandler(_Terminal_OnNewName);
					_Instance._Terminal.OnNewVideoFormat-=new _ITerminalEvents_OnNewVideoFormatEventHandler(_Terminal_OnNewVideoFormat);
					_Instance._Terminal.OnOutbandDTMF-=new _ITerminalEvents_OnOutbandDTMFEventHandler(_Terminal_OnOutbandDTMF);
					_Instance._Terminal.OnPeerAddress-=new _ITerminalEvents_OnPeerAddressEventHandler(_Terminal_OnPeerAddress);
					_Instance._Terminal.OnPlayMediaFile-=new _ITerminalEvents_OnPlayMediaFileEventHandler(_Terminal_OnPlayMediaFile);
					_Instance._Terminal.OnPictureTaking-=new _ITerminalEvents_OnPictureTakingEventHandler(_Terminal_OnPictureTaking);
					_Instance._Terminal.OnQ931Indication-=new _ITerminalEvents_OnQ931IndicationEventHandler(_Terminal_OnQ931Indication);
					_Instance._Terminal.OnQ931MessageReceived-=new _ITerminalEvents_OnQ931MessageReceivedEventHandler(_Terminal_OnQ931MessageReceived);
					_Instance._Terminal.OnRawSIPMessageReceived-=new _ITerminalEvents_OnRawSIPMessageReceivedEventHandler(_Terminal_OnRawSIPMessageReceived);
					_Instance._Terminal.OnReadMsg-=new _ITerminalEvents_OnReadMsgEventHandler(_Terminal_OnReadMsg);
					_Instance._Terminal.OnRemotePartyInfo-=new _ITerminalEvents_OnRemotePartyInfoEventHandler(_Terminal_OnRemotePartyInfo);
					_Instance._Terminal.OnRemotePartyRinging-=new _ITerminalEvents_OnRemotePartyRingingEventHandler(_Terminal_OnRemotePartyRinging);
					_Instance._Terminal.OnRemoveSubscription-=new _ITerminalEvents_OnRemoveSubscriptionEventHandler(_Terminal_OnRemoveSubscription);
					_Instance._Terminal.OnSipPresenceStatus-=new _ITerminalEvents_OnSipPresenceStatusEventHandler(_Terminal_OnSipPresenceStatus);
					_Instance._Terminal.OnSipRegistrationResult-=new _ITerminalEvents_OnSipRegistrationResultEventHandler(_Terminal_OnSipRegistrationResult);
					_Instance._Terminal.OnStandardCodecsNegotiated-=new _ITerminalEvents_OnStandardCodecsNegotiatedEventHandler(_Terminal_OnStandardCodecsNegotiated);
					_Instance._Terminal.OnStartAudioDecoder-=new _ITerminalEvents_OnStartAudioDecoderEventHandler(_Terminal_OnStartAudioDecoder);
					_Instance._Terminal.OnStartAudioEncoder-=new _ITerminalEvents_OnStartAudioEncoderEventHandler(_Terminal_OnStartAudioEncoder);
					_Instance._Terminal.OnStartDataDecoder-=new _ITerminalEvents_OnStartDataDecoderEventHandler(_Terminal_OnStartDataDecoder);
					_Instance._Terminal.OnStartDataEncoder-=new _ITerminalEvents_OnStartDataEncoderEventHandler(_Terminal_OnStartDataEncoder);
					_Instance._Terminal.OnStartTextT140Decoder-=new _ITerminalEvents_OnStartTextT140DecoderEventHandler(_Terminal_OnStartTextT140Decoder);
					_Instance._Terminal.OnStartTextT140Encoder-=new _ITerminalEvents_OnStartTextT140EncoderEventHandler(_Terminal_OnStartTextT140Encoder);
					//					_Instance._Terminal.OnStartVideoDecoder-=new _ITerminalEvents_OnStartVideoDecoderEventHandler(_Terminal_OnStartVideoDecoder);
					//					_Instance._Terminal.OnStartVideoDecoderEx-=new _ITerminalEvents_OnStartVideoDecoderExEventHandler(_Terminal_OnStartVideoDecoderEx);
					//					_Instance._Terminal.OnStartVideoEncoder-=new _ITerminalEvents_OnStartVideoEncoderEventHandler(_Terminal_OnStartVideoEncoder);
					_Instance._Terminal.OnStatusChanged-=new _ITerminalEvents_OnStatusChangedEventHandler(_Terminal_OnStatusChanged);
					_Instance._Terminal.OnStopAudioDecoder-=new _ITerminalEvents_OnStopAudioDecoderEventHandler(_Terminal_OnStopAudioDecoder);
					_Instance._Terminal.OnStopAudioEncoder-=new _ITerminalEvents_OnStopAudioEncoderEventHandler(_Terminal_OnStopAudioEncoder);
					_Instance._Terminal.OnStopDataDecoder-=new _ITerminalEvents_OnStopDataDecoderEventHandler(_Terminal_OnStopDataDecoder);
					_Instance._Terminal.OnStopDataEncoder-=new _ITerminalEvents_OnStopDataEncoderEventHandler(_Terminal_OnStopDataEncoder);
					_Instance._Terminal.OnStopTextT140DataDecoder-=new _ITerminalEvents_OnStopTextT140DataDecoderEventHandler(_Terminal_OnStopTextT140DataDecoder);
					_Instance._Terminal.OnStopTextT140DataEncoder-=new _ITerminalEvents_OnStopTextT140DataEncoderEventHandler(_Terminal_OnStopTextT140DataEncoder);
					//					_Instance._Terminal.OnStopVideoDecoder-=new _ITerminalEvents_OnStopVideoDecoderEventHandler(_Terminal_OnStopVideoDecoder);
					//					_Instance._Terminal.OnStopVideoDecoderEx-=new _ITerminalEvents_OnStopVideoDecoderExEventHandler(_Terminal_OnStopVideoDecoderEx);
					//					_Instance._Terminal.OnStopVideoEncoder-=new _ITerminalEvents_OnStopVideoEncoderEventHandler(_Terminal_OnStopVideoEncoder);
					_Instance._Terminal.OnSubscription-=new _ITerminalEvents_OnSubscriptionEventHandler(_Terminal_OnSubscription);
					_Instance._Terminal.OnSubscriptionAccepted-=new _ITerminalEvents_OnSubscriptionAcceptedEventHandler(_Terminal_OnSubscriptionAccepted);
					_Instance._Terminal.OnSubscriptionPending-=new _ITerminalEvents_OnSubscriptionPendingEventHandler(_Terminal_OnSubscriptionPending);
					_Instance._Terminal.OnSubscriptionRefused-=new _ITerminalEvents_OnSubscriptionRefusedEventHandler(_Terminal_OnSubscriptionRefused);
					_Instance._Terminal.OnT120Connect-=new _ITerminalEvents_OnT120ConnectEventHandler(_Terminal_OnT120Connect);
					_Instance._Terminal.OnT120Disconnect-=new _ITerminalEvents_OnT120DisconnectEventHandler(_Terminal_OnT120Disconnect);
					_Instance._Terminal.OnVideoQuality-=new _ITerminalEvents_OnVideoQualityEventHandler(_Terminal_OnVideoQuality);
					_Instance._Terminal=null;                   
				}
				if(_Instance._SipTerminal!=null)
				{
					_Instance._SipTerminal.OnOutbandDTMF-=new _ISipTerminalEvents_OnOutbandDTMFEventHandler(_SipTerminal_OnOutbandDTMF);
					
                    _Instance._SipTerminal = null;
				}
				if(_Instance._TerminalAVOptions!=null)
				{
					_Instance._TerminalAVOptions.OnOutputMute-=new _ITerminalAVOptionsEvents_OnOutputMuteEventHandler(_TerminalAVOptions_OnOutputMute);
					_Instance._TerminalAVOptions = null;
				}
				if(_TerminalAVControl!=null)
				{
					_TerminalAVControl.OnStartVideoDecoder-=new _ITerminalAVControlEvents_OnStartVideoDecoderEventHandler(_TerminalAVControl_OnStartVideoDecoder);
					_TerminalAVControl.OnStartVideoDecoderEx-=new _ITerminalAVControlEvents_OnStartVideoDecoderExEventHandler(_TerminalAVControl_OnStartVideoDecoderEx);
					_TerminalAVControl.OnStartVideoEncoder-=new _ITerminalAVControlEvents_OnStartVideoEncoderEventHandler(_TerminalAVControl_OnStartVideoEncoder);
					_TerminalAVControl.OnStopVideoDecoder-=new _ITerminalAVControlEvents_OnStopVideoDecoderEventHandler(_TerminalAVControl_OnStopVideoDecoder);
					_TerminalAVControl.OnStopVideoDecoderEx-=new _ITerminalAVControlEvents_OnStopVideoDecoderExEventHandler(_TerminalAVControl_OnStopVideoDecoderEx);
					_TerminalAVControl.OnStopVideoEncoder-=new _ITerminalAVControlEvents_OnStopVideoEncoderEventHandler(_TerminalAVControl_OnStopVideoEncoder);
					_TerminalAVControl=null;
				}
				if(_UnsubscribeWaitHandle!=null)
				{
					_UnsubscribeWaitHandle.Set();
				}
			}
			catch(Exception exception)
			{
				//Tools.Trace.WriteLine(exception);
			}
			
		}
		private void Unsubscribe()
		{
			try
			{
				System.Threading.AutoResetEvent autoWaitHandle = new System.Threading.AutoResetEvent(false);
				_UnsubscribeWaitHandle = new System.Threading.ManualResetEvent(false);
				System.Threading.RegisteredWaitHandle registeredWaitHandle = System.Threading.ThreadPool.RegisterWaitForSingleObject(autoWaitHandle,new System.Threading.WaitOrTimerCallback(UnsubscribeTimeoutHandler),null,_Timeout,true);
				System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(ASyncUnsubscribe);
				_UnsubscribeThread = new System.Threading.Thread(threadStart);
				_UnsubscribeThread.Start();
				_UnsubscribeWaitHandle.WaitOne();
				if(_Timer!=null)
				{
					_Timer.Dispose();
					_Timer = null;
				}
				if(registeredWaitHandle!=null)
				{
					registeredWaitHandle.Unregister(null);
				}
				if(_UnsubscribeWaitHandle!=null)
				{
					_UnsubscribeWaitHandle.Close();
					_UnsubscribeWaitHandle = null;
				}
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception);			
			}
				
		}
		private object HandleConnectionLoss(params object[]parameters)
		{
			Tools.Trace.WriteLog("Econfplayer : Connexion econf perdu.");
			_IsConnected = false;
			if(Disconnected!=null)
			{
				Disconnected(this, new System.EventArgs());
			}
			Restart();
			System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
			System.Diagnostics.StackFrame stackFrame = null;
			bool IsHandleAlreadyLaunched = false;
			for(int i = 1;i< stackTrace.FrameCount; i++)
			{
				stackFrame = stackTrace.GetFrame(i);
				if(stackFrame.GetMethod().Name=="HandleConnectionLoss")
				{
					IsHandleAlreadyLaunched = true;
				}
			}
			if(!IsHandleAlreadyLaunched)
			{
				try
				{
					stackFrame = stackTrace.GetFrame(1);
					System.Reflection.MethodInfo methodInfo = stackFrame.GetMethod() as System.Reflection.MethodInfo ;
					Tools.Trace.WriteLog("Econfplayer : Relance après perte de connexion econf de "+methodInfo.Name);
					return methodInfo.Invoke(this,parameters);
				}
				catch(Exception exception)
				{
					Tools.Trace.WriteLine(exception);
					throw new ConnectionException("Impossible de relancer la fonction");
				}

			}
			else
			{
				_IsConnected = false;
				if(Disconnected!=null)
				{
					Disconnected(this, new System.EventArgs());
				}
				//				Restart();
				string message = "Impossible de se connecter à EConf";
				Tools.Trace.WriteLog("Econfplayer : Impossible de redémarrer la fonction.");
				throw new ConnectionException(message);
			}
		}
		private void TickHandleEvents(object state)
		{
			EventInfo [] tabs = null;
			int count=0;
			lock(_Events)
			{
				count = _Events.Count;
				if(count==0)
				{
					return;
				}
				tabs = new EventInfo[count];
				_Events.CopyTo(tabs);
				_Events.Clear();
			}
			for(int i =0; i<count;i++)
			{
				Tools.Trace.WriteLog("Econfplayer : Evénement "+tabs[i]._EventsType+" recu.");
				HandlesEvent(tabs[i]);
			}
		}
		private void HandlesEvent(object state)
		{
			EventInfo info = (EventInfo)state;
			InfoCall callInfo;
			InfoGeneric details;
			int callId;
			short sId;
			switch(info._EventsType)
			{
				case Events.APPEXIT :
					_IsConnected = false;
					Unsubscribe();
					if(Disconnected!=null)
					{
						Disconnected(this,new System.EventArgs());
					}
					if(OnAppExit!=null)
					{
						OnAppExit(this, new System.EventArgs());
					}
					break;
				case Events.CALLING :
					if(Calling!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						eConf.IRemotePartyInfo XMLdatas = (eConf.IRemotePartyInfo)callInfo.Info;
						Calling(callInfo.CallId,XMLdatas);
					}
					break;
				case Events.CONNECT :
					if(CallConnected!=null)
					{
						callId = Convert.ToInt32(info._Parameter);
						CallConnected(callId);
					}
					break;
				case Events.DISCONNECT :
					if(CallDisconnected!=null)
					{
						callId = Convert.ToInt32(info._Parameter);
						CallDisconnected(callId);
					}
					break;
				case Events.FAILED :
					if(CallFailed!=null)
					{
						int[] tabF = (int[])info._Parameter;
						CallFailed(tabF[0], (short)tabF[1]);
					}
					break;
				case Events.INCOMING :
					if(IncomingCall!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						IncomingCall(callInfo.CallId, (string)callInfo.Info);
					}
					break;
				case Events.LOCAL_ACCEPTED :
					if(LocalAccepted!=null)
					{
						callId = Convert.ToInt32(info._Parameter);
						LocalAccepted(callId);
					}
					break;
				case Events.LOCAL_REJECTED :
					if(LocalRejected!=null)
					{
						callId = Convert.ToInt32(info._Parameter);
						LocalRejected(callId);
					}
					break;
				case Events.REJECTED :
					if(CallRejected!=null)
					{
						callId = Convert.ToInt32(info._Parameter);
						CallRejected(callId);
					}
					break;
				case Events.DTMF :
					if(DTMFReceived!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						string dtmf = (string)callInfo.Info;
						DTMFReceived(dtmf);
					}
					break;
				case Events.DTMF_OUTBAND :
					if(DTMFOutbandReceived!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						string tmp = (string)callInfo.Info;
						string dtmf = tmp[tmp.Length-1].ToString();
						tmp = tmp.Remove(tmp.Length-1,1);
						int duration =Convert.ToInt32(tmp);
						DTMFOutbandReceived(dtmf,duration);
					}
					break;
				case Events.SIP_DTMF_OUTBAND :
					if(SIP_DTMFOutbandReceived!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						string tmp = (string)callInfo.Info;
						string dtmf = tmp[tmp.Length-1].ToString();
						tmp = tmp.Remove(tmp.Length-1,1);
						int duration =Convert.ToInt32(tmp);
						SIP_DTMFOutbandReceived(dtmf,duration);
					}
					break;
				case Events.FILETRANSFER_STARTED :
					if(FileTransferStarted!=null)
					{
						FileTransferStarted((string)info._Parameter);
					}
					break;
				case Events.FILETRANSFER_CANCELLED :
					if(FileTransferCancelled!=null)
					{
						FileTransferCancelled((string)info._Parameter);
					}
					break;
				case Events.FILETRANSFER_PROGRESS :
					if(FileTransferProgress!=null)
					{
						int[] bytes = (int[])info._Parameter;
						if(bytes.Length!=2)
						{
							throw new Exception("internal error");
						}
						FileTransferProgress(bytes[0],bytes[1]);
					}
					break;
				case Events.FILETRANSFER_ENDED :
					if(FileTransferEnded!=null)
					{
						FileTransferEnded((string)info._Parameter);
					}
					break;
				case Events.INPUT_MUTE :
					if(InputMuted!=null)
					{
						bool IsMuted = false;
						int intIsMuted = (int)info._Parameter;
						try
						{
							IsMuted = Convert.ToBoolean(intIsMuted);
						}
						catch(Exception exception)
						{
							Tools.Trace.WriteLine(exception);
						}
						
						InputMuted(IsMuted);
					}
					break;
				case Events.OUTPUT_MUTE :
					if(OutputMuted!=null)
					{
						int[] tabs = (int[])info._Parameter;
						bool IsMuted = false;
						if(tabs.Length!=2)
						{
							throw new Exception("internal error");
						}
						try
						{
							IsMuted = Convert.ToBoolean(tabs[1]);
						}
						catch(Exception exception)
						{
							Tools.Trace.WriteLine(exception);
						}
						OutputMuted(tabs[0],IsMuted);
					}
					break;
				case Events.CHANNEL_MUTE :
					if(ChannelMuted!=null)
					{
						int[] tabs = (int[])info._Parameter;
						bool IsMuted = false;
						if(tabs.Length!=2)
						{
							throw new Exception("internal error");
						}
						try
						{
							IsMuted = Convert.ToBoolean(tabs[1]);
						}
						catch(Exception exception)
						{
							Tools.Trace.WriteLine(exception);
						}
						ChannelMuted(tabs[0],IsMuted);
					}
					break;
				case Events.PICTURE_CAPTURED :
					if(ImageCaptured!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						ImageCaptured(callInfo.CallId, (string)callInfo.Info);
					}
					break;
				case Events.MEDIA_PLAYED :
					if(MediaPlayed!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						MediaPlayed(callInfo.CallId, (string)callInfo.Info);
					}
					break;
				case Events.ADD_MSG :
					if(MessageAdded!=null)
					{
						sId = (short)info._Parameter;
						MessageAdded( sId);
					}
					break;
				case Events.ARCHIVE_MSG :
					if(ArchiveMessageAdded!=null)
					{
						sId = (short)info._Parameter;
						ArchiveMessageAdded( sId);
					}
					break;
				case Events.AUDIO_LEVEL :
					if(AudioLevelChanged!=null)
					{
						AudioLevelChanged((short)info._Parameter);
					}
					break;
				case Events.AUDIO_LEVEL_GRABER :
					if(AudioLevelGrabberChanged!=null)
					{
						AudioLevelGrabberChanged((short)info._Parameter);
					}
					break;
				case Events.AUDIO_ONLY :
					if(AudioOnlySet!=null)
					{
						AudioOnlySet((short)info._Parameter);
					}
					break;
				case Events.BAD_MSG_ANSWERING :
					if(BadMessageAnswering!=null)
					{
						BadMessageAnswering((short)info._Parameter);
					}
					break;
				case Events.BEGIN_CAPTURE_MSG :
					if(BeginCaptureMessage!=null)
					{
						BeginCaptureMessage();
					}
					break;
				case Events.BENCH_STATUS :
					if(BenchStatus!=null)
					{
						BenchStatus((int)info._Parameter);
					}
					break;
				case Events.CALL_STACK_STARTED :
					if(CallStackStarted!=null)
					{
						eProtocol protocol = (eProtocol) info._Parameter;
						CallStackStarted(protocol);
					}
					break;
				case Events.CHANGE_ACTIVATE :
					if(ChangeActivate!=null)
					{
						ChangeActivate((short)info._Parameter);
					}
					break;
				case Events.CHANGE_ANNONCE :
					if(AnnonceChanged!=null)
					{
						details = (InfoGeneric)info._Parameter;
						AnnonceChanged(details.Message,(short)details.Integer);
					}
					break;
				case Events.CHANGE_DISK_ALLOCATION :
					if(DiskAllocationChanged!=null)
					{
						DiskAllocationChanged((short)info._Parameter);
					}
					break;
				case Events.CHANGE_LOC_MSG :
					if(MessageLocationChanged!=null)
					{
						string path = (string)info._Parameter;
						MessageLocationChanged(path);
					}
					break;
				case Events.CHANGE_MAX_DURATION :
					if(MaxDurationChanged!=null)
					{
						MaxDurationChanged((short)info._Parameter);
					}
					break;
				case Events.CHANGE_NO_ANSWER :
					if(NoAnswerChanged!=null)
					{
						NoAnswerChanged((short)info._Parameter);
					}
					break;
				case Events.CHANGE_RECORDER_TYPE :
					if(RecorderTypeChanged!=null)
					{
						RecorderTypeChanged((short)info._Parameter);
					}
					break;
				case Events.CHANGE_TOTAL_DURATION_MSG_USED :
					if(TotalDurationMessageUsedChanged!=null)
					{
						TotalDurationMessageUsedChanged((int)info._Parameter);
					}
					break;
				case Events.CONSOLE_MESSAGE :
					if(ConsoleMessage!=null)
					{
						ConsoleMessage((string)info._Parameter);
					}
					break;
				case Events.CONTACT_ADDED :
					if(ContactAdded!=null)
					{
						ContactAdded((string)info._Parameter);
					}
					break;
				case Events.CONTACT_REMOVED :
					if(ContactRemoved!=null)
					{
						details = (InfoGeneric)info._Parameter;
						ContactRemoved(details.Message,details.Integer);
					}
					break;
				case Events.CPL_EXIT :
					if(ConfigPanelClosed!=null)
					{
						bool IsOk = Convert.ToBoolean((short)info._Parameter);
						ConfigPanelClosed(IsOk);
					}
					break;
				case Events.CPL_OPEN :
					if(ConfigPanelOpened!=null)
					{
						ConfigPanelOpened();
					}
					break;
				case Events.DATA_RECEIVED :
					if(DataReceived!=null)
					{
						eConf.IDataInfo data = (eConf.IDataInfo)info._Parameter;
						DataReceived(data);
					}
					break;
				case Events.DATA_RECEIVED_UTF8 :
					if(UTF8DataReceived!=null)
					{
						eConf.IDataInfo data = (eConf.IDataInfo)info._Parameter;
						UTF8DataReceived(data);
					}
					break;
				case Events.DELETE_ALL_MSG :
					if(AllMessagesDeleted!=null)
					{
						AllMessagesDeleted();
					}
					break;
				case Events.DELETE_MSG :
					if(MessageDeleted!=null)
					{
						MessageDeleted((short)info._Parameter);
					}
					break;
				case Events.DTMF_SENT:
					callInfo = (InfoCall)info._Parameter;
					InfoDTMF infoDTMF = (InfoDTMF) callInfo.Info;
					if(DTMFSent!=null)
					{
						DTMFSent(callInfo.CallId, infoDTMF.DTMF, infoDTMF.Kind, infoDTMF.Duration);
					}
					break;
				case Events.ERROR_ANSWERING :
					if(ErrorAnswering!=null)
					{
						ErrorAnswering((eConf.eErrorRecorder)info._Parameter);
					}
					break;
				case Events.FILE_DROPPED_COUNT :
					if(DropFileInfoCountChanged!=null)
					{
						DropFileInfoCountChanged((int)info._Parameter);
					}
					break;
					
				case Events.FILE_DROPPED :
					if(DropFileInfo!=null)
					{
						DropFileInfo((string)info._Parameter);
					}
					break;
				case Events.FINISH_CAPTURE_MSG :
					if(CaptureMessageFinished!=null)
					{
						CaptureMessageFinished((string)info._Parameter);
					}
					break;
				case Events.GK_CONNECT :
					if(GKConnected!=null)
					{
						GKConnected();
					}
					break;
				case Events.GK_DISCONNECT :
					if(GKDisconnected!=null)
					{
						GKDisconnected();
					}
					break;
				case Events.H245_INDICATION :
					if(H245IndicationRaised!=null)
					{
						H245IndicationRaised((short)info._Parameter);
					}
					break;
				case Events.H323_ALERT :
					if(H323AlertRaised!=null)
					{
						H323AlertRaised((int)info._Parameter);
					}
					break;
				case Events.H323_INDICATION :
					if(H323IndicationRaised!=null)
					{
						H323IndicationRaised((short)info._Parameter);
					}
					break;
				case Events.H323_RAS_INDICATION :
					if(H323RASIndicationRaised!=null)
					{
						H323RASIndicationRaised((short)info._Parameter);
					}
					break;
				case Events.IM_MESSAGE_IN_CALL :
					if(IMMessageReceivedInCall!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						string[]Fields = (string[])callInfo.Info;
						IMMessageReceivedInCall(callInfo.CallId,Fields[0],Fields[1]);
					}
					break;
				case Events.IM_MESSAGE_OUT_CALL :
					if(IMMessageReceivedOutCall!=null)
					{
						string[]Fields = (string[])info._Parameter;
						IMMessageReceivedOutCall(Fields[0],Fields[1],Fields[2]);
					}
					break;
				case Events.INCOMING_EX :
					if(IncomingCallEx!=null)
					{
						callInfo  = (InfoCall )info._Parameter;
						IncomingCallEx(callInfo.CallId,(eConf.IRemotePartyInfo)callInfo.Info);
					}
					break;
				case Events.INFO_CARD :
					if(InfoCardReceived!=null)
					{
						callInfo  = (InfoCall )info._Parameter;
						InfoCardReceived(callInfo.CallId,(string)callInfo.Info);
					}
					break;
				case Events.INFO_MESSAGE_IN_CALL_RECEIVED :
					if(InfoMessageInCallReceived!=null)
					{
						callInfo = (InfoCall)info._Parameter;
						string[] fields = (string[])callInfo.Info;
						InfoMessageInCallReceived(callInfo.CallId, fields[0], fields[1]);
					}
					break;
				case Events.INFO_MESSAGE_OUT_CALL_RECEIVED :
					if(InfoMessageOutCallReceived!=null)
					{
						string[] fields  = (string[])info._Parameter;
						InfoMessageOutCallReceived(fields[0], fields[1], fields[2]);
					}
					break;
				case Events.INPUT_GAIN :
					if(InputGainChanged!=null)
					{
						InputGainChanged((short)info._Parameter);
					}
					break;
				case Events.INTERCEPT_CALL :
					if(CallIntercepted!=null)
					{
						callInfo = (InfoCall) info._Parameter;
						CallIntercepted(callInfo.CallId, (short)callInfo.Info);
					}
					break;
				case Events.NETWORK_STATE_CHANGED :
					if(NetworkStateChanged!=null)
					{
						NetworkStateChanged((short)info._Parameter);
					}
					break;
				case Events.NEW_MEMBER :
					if(MemberAdded!=null)
					{
						callInfo = (InfoCall) info._Parameter;
						MemberAdded(callInfo.CallId, (string)callInfo.Info);
					}
					break;
				case Events.NEW_NAME :
					if(NameReceived!=null)
					{
						callInfo = (InfoCall) info._Parameter;
						NameReceived(callInfo.CallId, (string)callInfo.Info);
					}
					break;
				case Events.NEW_VIDEO_FORMAT :
					if(VideoFormatChanged!=null)
					{
						int[] tabs = (int[]) info._Parameter;
						VideoFormatChanged(tabs[0],(short)tabs[1],tabs[2],tabs[3]);
					}
					break;
				case Events.PEER_ADDRESS :
					if(PeerAddressReceived!=null)
					{
						callInfo = (InfoCall) info._Parameter;
						PeerAddressReceived(callInfo.CallId,(string)callInfo.Info);
					}
					break;
				case Events.Q931_INDICATION :
					if(Q931IndicationRaised!=null)
					{
						short[] tabs = (short[]) info._Parameter;
						Q931IndicationRaised(tabs[0], tabs[1]);
					}
					break;
				case Events.Q931_MESSAGE_RECEIVED :
					if(Q931MessageReceived!=null)
					{
						details = (InfoGeneric ) info._Parameter;
						Q931MessageReceived(details.Message, details.Integer);
					}
					break;
				case Events.SIP_RAWMESSAGE_RECEIVED :
					if(SIPRawMessageReceived!=null)
					{
						details = (InfoGeneric ) info._Parameter;
						SIPRawMessageReceived(details.Message, Convert.ToBoolean((short)details.Integer));
					}
					break;
				case Events.READ_MSG :
					if(ReadMessageRaised!=null)
					{
						ReadMessageRaised((short)info._Parameter);
					}
					break;
				case Events.REMOTE_PARTY_INFO :
					if(RemotePartyInfoRaised!=null)
					{
						callInfo = (InfoCall) info._Parameter;
						RemotePartyInfoRaised(callInfo.CallId, (eConf.IRemotePartyInfo)callInfo.Info);
					}
					break;
				case Events.REMOTE_PARTY_RINGING :
					if(RemoteRinging!=null)
					{
						RemoteRinging((int)info._Parameter);
					}
					break;
				case Events.REMOVE_SUBSCRIPTION  :
					if(SubscriptionRemoved!=null)
					{
						string[] fields = (string[])info._Parameter;
						SubscriptionRemoved(fields[0],fields[1]);
					}
					break;
				case Events.SIP_PRESENCE_STATUS  :
					if(SIPPresenceStatusChanged!=null)
					{
						SIPPresenceStatusChanged((int)info._Parameter);
					}
					break;
				case Events.SIP_REGISTRATION_RESULT  :
					if(SIPRegistred!=null)
					{
						short[] status = (short[])info._Parameter;
						SIPRegistred(status[0],status[1]);
					}
					break;
				case Events.STANDARD_CODECS_NEGOTIATED  :
					if(CodecsNegociated!=null)
					{
						CodecsNegociated((int)info._Parameter);
					}
					break;
				case Events.STATUS_CHANGED:
					if(StatusChanged!=null)
					{
						StatusChanged((int)info._Parameter);
					}
					break;
				case Events.AUDIO_DECODER_STARTED:
					_LastRtpIdAudioIn = (short)info._Parameter;
					if(AudioDecoderStarted!=null)
					{
						AudioDecoderStarted(_LastRtpIdAudioIn);
					}
					break;
				case Events.AUDIO_DECODER_STOPPED:
					if(AudioDecoderStopped!=null)
					{
						AudioDecoderStopped((short)info._Parameter);
					}
					break;
				case Events.AUDIO_ENCODER_STARTED:
					_LastRtpIdAudioOut = (short)info._Parameter;
					if(AudioEncoderStarted!=null)
					{
						AudioEncoderStarted(_LastRtpIdAudioOut);
					}
					break;
				case Events.AUDIO_ENCODER_STOPPED:
					if(AudioEncoderStopped!=null)
					{
						AudioEncoderStopped((short)info._Parameter);
					}
					break;
				case Events.DATA_DECODER_STARTED  :
					if(DataDecoderStarted!=null)
					{
						DataDecoderStarted((int)info._Parameter);
					}
					break;
				case Events.DATA_DECODER_STOPPED  :
					if(DataDecoderStopped!=null)
					{
						DataDecoderStopped((short)info._Parameter);
					}
					break;
				case Events.DATA_ENCODER_STARTED  :
					if(DataEncoderStarted!=null)
					{
						DataEncoderStarted((int)info._Parameter);
					}
					break;
				case Events.DATA_ENCODER_STOPPED :
					if(DataEncoderStopped!=null)
					{
						DataEncoderStopped((short)info._Parameter);
					}
					break;
				case Events.TEXT_DECODER_STARTED :
					if(TextDecoderStarted!=null)
					{
						TextDecoderStarted((short)info._Parameter);
					}
					break;
				case Events.TEXT_DECODER_STOPPED :
					if(TextDecoderStopped!=null)
					{
						TextDecoderStopped((short)info._Parameter);
					}
					break;
				case Events.TEXT_ENCODER_STARTED :
					if(TextEncoderStarted!=null)
					{
						TextEncoderStarted((short)info._Parameter);
					}
					break;
				case Events.TEXT_ENCODER_STOPPED :
					if(TextEncoderStopped!=null)
					{
						TextEncoderStopped((short)info._Parameter);
					}
					break;
				case Events.VIDEO_DECODER_STARTED :
					_LastRtpIdVideoIn = (short)info._Parameter;
					if(VideoDecoderStarted!=null)
					{
						VideoDecoderStarted(_LastRtpIdVideoIn);
					}
					break;
				case Events.VIDEO_DECODER_STOPPED:
					if(VideoDecoderStopped!=null)
					{
						VideoDecoderStopped((short)info._Parameter);
					}
					break;
				case Events.VIDEO_ENCODER_STARTED:
					_LastRtpIdVideoOut = (short)info._Parameter;
					if(VideoEncoderStarted!=null)
					{
						VideoEncoderStarted(_LastRtpIdVideoOut);
					}
					break;
				case Events.VIDEO_ENCODER_STOPPED:
					if(VideoEncoderStopped!=null)
					{
						VideoEncoderStopped((short)info._Parameter);
					}
					break;
				case Events.VIDEO_DECODER_EX_STARTED:
					int[]tabsInt = (int[])info._Parameter;
					if(VideoExEncoderStarted!=null)
					{
						VideoExEncoderStarted(tabsInt[0], (short)tabsInt[1], tabsInt[2]);
					}
					break;
				case Events.VIDEO_DECODER_EX_STOPPED:
					callInfo  = (InfoCall )info._Parameter;
					if(VideoExEncoderStopped!=null)
					{
						VideoExEncoderStopped(callInfo.CallId,(short)callInfo.Info);
					}
					break;
				case Events.SUBSCRIPTION:
					if(SubscriptionRequested!=null)
					{
						string[] userInfos = (string[])info._Parameter;
						SubscriptionRequested(userInfos[0],userInfos[1]);
					}
					break;
				case Events.SUBSCRIPTION_ACCEPTED:
					if(SubscriptionAccepted!=null)
					{
						string[] userInfos = (string[])info._Parameter;
						SubscriptionAccepted(userInfos[0],userInfos[1]);
					}
					break;
				case Events.SUBSCRIPTION_PENDING:
					if(SubscriptionPending!=null)
					{
						string[] userInfos = (string[])info._Parameter;
						SubscriptionPending(userInfos[0],userInfos[1]);
					}
					break;
				case Events.SUBSCRIPTION_REFUSED:
					if(SubscriptionRefused!=null)
					{
						string[] userInfos = (string[])info._Parameter;
						SubscriptionRefused(userInfos[0],userInfos[1]);
					}
					break;
				case Events.T120_CONNECTED:
					if(T120Connected!=null)
					{
						T120Connected((int)info._Parameter);
					}
					break;
				case Events.T120_DISCONNECTED:
					if(T120Disconnected!=null)
					{
						T120Disconnected((int)info._Parameter);
					}
					break;
				case Events.VIDEO_QUALITY_CHANGED:
					if(VideoQualityChanged!=null)
					{
						short[] videoInfos = (short[])info._Parameter;
						VideoQualityChanged(videoInfos[0],videoInfos[1]);
					}
					break;
				default:
					Tools.Trace.WriteLine("Error EConfPlayer : Event not handled.");
					break;
			}
		}
		#endregion

		#region econf events
		#region Terminal events
		private void _EConfPlayer_OnAppExit()
		{
			_IsConnected= false;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.APPEXIT,null));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.APPEXIT,null));
		}
		private void _Terminal_OnCalling(int nCallId, object pRemotePartyInfo)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCalling");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			eConf.IRemotePartyInfo XMLdatas = (eConf.IRemotePartyInfo)pRemotePartyInfo;
			callInfo.Info = XMLdatas;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CALLING,callInfo));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CALLING,callInfo));
		}
		private void _Terminal_OnCallFailed(int nCallId, short nFailureReason)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCallFailed");
			int[]tab = new int[2];
			tab[0] = nCallId;
			tab[1] = (int)nFailureReason;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FAILED,tab));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FAILED,tab));
		}
		private void _Terminal_OnCallRejected(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCallRejected");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.REJECTED,nCallId));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.REJECTED,nCallId));
		}
		private void _Terminal_OnConnect(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnConnect");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CONNECT,nCallId));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CONNECT,nCallId));
		}
		private void _Terminal_OnDisconnect(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDisconnect");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DISCONNECT,nCallId));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DISCONNECT,nCallId));
		}
		
		private void _Terminal_OnCallLocalAccepted(short nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCallLocalAccepted");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.LOCAL_ACCEPTED,nCallId));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.LOCAL_ACCEPTED,nCallId));
		}
		private void _Terminal_OnCallLocalRejected(short nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCallLocalRejected");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.LOCAL_REJECTED,nCallId));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.LOCAL_REJECTED,nCallId));
		}
		private void _Terminal_OnDTMFReceived(int nCallId, string szDTMF)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDTMFReceived");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = szDTMF;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DTMF,callInfo));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DTMF,callInfo));
		}
		private void _Terminal_OnOutbandDTMF(short nCallId, string szDTMF, int nDuration)
		{
			//Tools.Trace.WriteLine("_Terminal_OnOutbandDTMF");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			if(szDTMF=="" || szDTMF==string.Empty)
			{
				szDTMF=" ";
			}
			callInfo.Info = nDuration.ToString()+szDTMF;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DTMF_OUTBAND,callInfo));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DTMF_OUTBAND,callInfo));
		}
		private void _Terminal_OnFileTransferCanceled(string strFileName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnFileTransferCanceled");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FILETRANSFER_CANCELLED,strFileName));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FILETRANSFER_CANCELLED,strFileName));
		}
		
		private void _Terminal_OnFileTransferStarted(string strFileName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnFileTransferStarted");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FILETRANSFER_STARTED,strFileName));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FILETRANSFER_STARTED,strFileName));
		}

		private void _Terminal_OnFileTransferCompleted(string strFileName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnFileTransferCompleted");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FILETRANSFER_ENDED,strFileName));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FILETRANSFER_ENDED,strFileName));
		}

		private void _Terminal_OnFileTransferProgress(int nBytesTransferred, int nBytesTotal)
		{
			//Tools.Trace.WriteLine("_Terminal_OnFileTransferProgress");
			int[] tabInts=new int[2];
			tabInts[0] = nBytesTransferred;
			tabInts[1] = nBytesTotal;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FILETRANSFER_PROGRESS,tabInts));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FILETRANSFER_PROGRESS,tabInts));
		}
		private void _Terminal_OnAddMsg(short nMsgID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnAddMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.ADD_MSG,nMsgID));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.ADD_MSG,nMsgID));
		}

		private void _Terminal_OnArchiveMsg(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnArchiveMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.ARCHIVE_MSG,nID));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.ARCHIVE_MSG,nID));
		}
		private void _Terminal_OnAudioLevel(short nLevel)
		{
			//Tools.Trace.WriteLine("_Terminal_OnAudioLevel");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_LEVEL,nLevel));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_LEVEL,nLevel));
		}

		private void _Terminal_OnAudioLevelGrabber(short nLevel)
		{
			//Tools.Trace.WriteLine("_Terminal_OnAudioLevelGrabber");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_LEVEL_GRABER,nLevel));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_LEVEL_GRABER,nLevel));
		}

		private void _Terminal_OnAudioOnly(short nVal)
		{
			//Tools.Trace.WriteLine("_Terminal_OnAudioOnly");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_ONLY,nVal));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_ONLY,nVal));
		}

		private void _Terminal_OnBadMsgAnswering(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnBadMsgAnswering");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.BAD_MSG_ANSWERING,nID));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.BAD_MSG_ANSWERING,nID));
		}

		private void _Terminal_OnBeginCaptureMsg()
		{
			//Tools.Trace.WriteLine("_Terminal_OnBeginCaptureMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.BEGIN_CAPTURE_MSG,null));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.BEGIN_CAPTURE_MSG,null));
		}

		private void _Terminal_OnBenchStatus(int nState)
		{
			//Tools.Trace.WriteLine("_Terminal_OnBenchStatus");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.BEGIN_CAPTURE_MSG,null));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.BEGIN_CAPTURE_MSG,null));
		}

		private void _Terminal_OnCallStackStarted(eProtocol protocol, string szLocalIpAddressUsed, int lMajorPortNumber)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCallStackStarted");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CALL_STACK_STARTED,protocol));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CALL_STACK_STARTED,protocol));
		}

		private void _Terminal_OnChangeActivate(short nMode)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeActivate");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_ACTIVATE,nMode));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_ACTIVATE,nMode));
		}

		private void _Terminal_OnChangeAnnonce(string bszFileAnnonce, short nType)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeAnnonce");
			InfoGeneric annonce = new InfoGeneric();
			annonce.Message = bszFileAnnonce;
			annonce.Integer = (int)nType;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_ANNONCE,annonce));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_ANNONCE,annonce));
		}

		private void _Terminal_OnChangeDiskAllocation(short nDuration)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeDiskAllocation");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_DISK_ALLOCATION,nDuration));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_DISK_ALLOCATION,nDuration));
		}

		private void _Terminal_OnChangeLocMsg(string bszPathMsg)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeLocMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_LOC_MSG,bszPathMsg));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_LOC_MSG,bszPathMsg));
		}

		private void _Terminal_OnChangeMaxDuration(short nNewVal)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeMaxDuration");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_MAX_DURATION,nNewVal));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_MAX_DURATION,nNewVal));
		}

		private void _Terminal_OnChangeNoAnswer(short nNewVal)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeNoAnswer");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_NO_ANSWER,nNewVal));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_NO_ANSWER,nNewVal));
		}

		private void _Terminal_OnChangeRecorderType(short nMode)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeRecorderType");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_RECORDER_TYPE,nMode));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_RECORDER_TYPE,nMode));
		}

		private void _Terminal_OnChangeTotalDurationMsgUsed(int iDuration)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChangeTotalDurationMsgUsed");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANGE_TOTAL_DURATION_MSG_USED,iDuration));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANGE_TOTAL_DURATION_MSG_USED,iDuration));
		}

		private void _Terminal_OnChannelMuted(int nChannelId, short bMuted)
		{
			//Tools.Trace.WriteLine("_Terminal_OnChannelMuted");
			int[] tabs = new int[2];
			tabs[0] =nChannelId;
			tabs[1] =bMuted;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CHANNEL_MUTE,tabs));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CHANNEL_MUTE,tabs));
		
		}
		private void _Terminal_OnConsoleMessage(string strMessage)
		{
			//Tools.Trace.WriteLine("_Terminal_OnConsoleMessage");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CONSOLE_MESSAGE,strMessage));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CONSOLE_MESSAGE,strMessage));
		}

		private void _Terminal_OnContactAdded(string szContactIdentifier)
		{
			//Tools.Trace.WriteLine("_Terminal_OnContactAdded");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CONTACT_ADDED,szContactIdentifier));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CONTACT_ADDED,szContactIdentifier));
		}

		private void _Terminal_OnContactRemoved(string szContactIdentifier, int nReason)
		{
			//Tools.Trace.WriteLine("_Terminal_OnContactRemoved");
			InfoGeneric info = new InfoGeneric();
			info.Message = szContactIdentifier;
			info.Integer = nReason;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CONTACT_REMOVED,info));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CONTACT_REMOVED,info));
		}

		private void _Terminal_OnCPLExit(short exitByOk)
		{
			//Tools.Trace.WriteLine("_Terminal_OnCPLExit");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CPL_EXIT,exitByOk));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CPL_EXIT,exitByOk));
		}

		private void _Terminal_OnCPLOpen()
		{
			//Tools.Trace.WriteLine("_Terminal_OnCPLOpen");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.CPL_OPEN,null));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.CPL_OPEN,null));
		}

		private void _Terminal_OnDataReceived(object pDataInfo)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDataReceived");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DATA_RECEIVED, pDataInfo));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DATA_RECEIVED, pDataInfo));
		}

		private void _Terminal_OnDataUTF8Received(object pDataInfo)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDataUTF8Received");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DATA_RECEIVED_UTF8, pDataInfo));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DATA_RECEIVED_UTF8, pDataInfo));
		}

		private void _Terminal_OnDelAllMsg()
		{
			//Tools.Trace.WriteLine("_Terminal_OnDelAllMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DELETE_ALL_MSG, null));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DELETE_ALL_MSG, null));
		}

		private void _Terminal_OnDelMsg(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDelMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DELETE_MSG, nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DELETE_MSG, nID));
		}

		private void _Terminal_OnDropFileInfoCount(int nElem)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDropFileInfoCount");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FILE_DROPPED_COUNT , nElem));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FILE_DROPPED_COUNT , nElem));
		}

		private void _Terminal_OnDropFileInfoElem(string strFilePath)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDropFileInfoElem");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FILE_DROPPED , strFilePath));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FILE_DROPPED , strFilePath));
		}

		private void _Terminal_OnDTMFSent(int nCallId, int chDMTF, eDTMFKind nKind, int nDuration)
		{
			//Tools.Trace.WriteLine("_Terminal_OnDTMFSent");
			InfoDTMF infoDTMF = new InfoDTMF();
			infoDTMF.DTMF = ((char)chDMTF).ToString();
			infoDTMF.Duration = nDuration;
			infoDTMF.Kind = nKind;

			InfoCall infoCall = new InfoCall();
			infoCall.Info = infoDTMF;
			infoCall.CallId = nCallId;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DTMF_SENT , infoCall));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DTMF_SENT , infoCall));
		}

		private void _Terminal_OnErrorAnswering(eErrorRecorder nError)
		{
			//Tools.Trace.WriteLine("_Terminal_OnErrorAnswering");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.ERROR_ANSWERING , nError));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.ERROR_ANSWERING , nError));
		}

		private void _Terminal_OnFinishCaptureMsg(string bszFileName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnFinishCaptureMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.FINISH_CAPTURE_MSG , bszFileName));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.FINISH_CAPTURE_MSG , bszFileName));
		}

		private void _Terminal_OnGKConnect()
		{
			//Tools.Trace.WriteLine("_Terminal_OnGKConnect");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.GK_CONNECT , null));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.GK_CONNECT , null));
		}

		private void _Terminal_OnGKDisconnect()
		{
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.GK_DISCONNECT , null));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.GK_DISCONNECT , null));
		}

		private void _Terminal_OnH245Indication(short nCode, short nNormalizedCode)
		{
			//Tools.Trace.WriteLine("_Terminal_OnH245Indication");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.H245_INDICATION , nCode));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.H245_INDICATION , nCode));
		}

		private void _Terminal_OnH323Alert(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnH323Alert");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.H323_ALERT , nCallId));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.H323_ALERT , nCallId));
		}

		private void _Terminal_OnH323Indication(short nCode, short nNormalizedCode)
		{
			//Tools.Trace.WriteLine("_Terminal_OnH323Indication");
			short[]tabs = new short[2];
			tabs[0] = nCode;
			tabs[1] = nNormalizedCode;
			//Tools.Trace.WriteLine("_Terminal_OnH323Alert");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.H323_INDICATION , tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.H323_INDICATION , tabs));
		}

		private void _Terminal_OnH323RASIndication(short nCode, short nNormalizedCode)
		{
			//Tools.Trace.WriteLine("_Terminal_OnH323RASIndication");
			short[]tabs = new short[2];
			tabs[0] = nCode;
			tabs[1] = nNormalizedCode;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.H323_RAS_INDICATION , tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.H323_RAS_INDICATION , tabs));
		}

		private void _Terminal_OnIMMessageInCall(short nCallId, string bstrContentType, string bstrBody)
		{
			//Tools.Trace.WriteLine("_Terminal_OnH323RASIndication");
			InfoCall infoCall = new InfoCall();
			infoCall.Info = new string[]{bstrContentType,bstrBody};
			infoCall.CallId = nCallId;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.IM_MESSAGE_IN_CALL , infoCall));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.IM_MESSAGE_IN_CALL , infoCall));
		}

		private void _Terminal_OnIMMessageOutOfCall(string szContact, string bstrContentType, string bstrMessage)
		{
			//Tools.Trace.WriteLine("_Terminal_OnIMMessageOutOfCall");
			string[] tabs = new string[]{szContact,bstrContentType,bstrMessage};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.IM_MESSAGE_OUT_CALL , tabs ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.IM_MESSAGE_OUT_CALL , tabs ));
		
		}
		private void _Terminal_OnIncomingCall(int nCallId, string szCallerName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnIncomingCall");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = szCallerName;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INCOMING,callInfo));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INCOMING,callInfo));
		}

		private void _Terminal_OnIncomingCallEx(int nCallId, object pRemotePartyInfo)
		{

           
			//Tools.Trace.WriteLine("_Terminal_OnIncomingCallEx");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			eConf.IRemotePartyInfo XMLdatas = (eConf.IRemotePartyInfo)pRemotePartyInfo;
			callInfo.Info = XMLdatas;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INCOMING_EX , callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INCOMING_EX , callInfo ));
		}

		private void _Terminal_OnInfoCard(int nCallId, string szInfoCardURL)
		{
			//Tools.Trace.WriteLine("_Terminal_OnInfoCard");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = szInfoCardURL;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INFO_CARD , callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INFO_CARD , callInfo ));
		}

		private void _Terminal_OnINFOMessageInCallReceived(short nCallId, string bstrContentType, string bstrBody)
		{
			//Tools.Trace.WriteLine("_Terminal_OnINFOMessageInCallReceived");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = new string[]{bstrContentType,bstrBody};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INFO_MESSAGE_IN_CALL_RECEIVED , callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INFO_MESSAGE_IN_CALL_RECEIVED , callInfo ));
		}

		private void _Terminal_OnINFOMessageOutOfCallReceived(string bstrFromURI, string bstrContentType, string bstrBody)
		{
			//Tools.Trace.WriteLine("_Terminal_OnINFOMessageOutOfCallReceived");
			string [] tabs = new string[]{bstrFromURI,bstrContentType,bstrBody};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INFO_MESSAGE_OUT_CALL_RECEIVED , tabs ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INFO_MESSAGE_OUT_CALL_RECEIVED , tabs ));
		}
		private void _Terminal_OnInputGain(short nGain)
		{
			//Tools.Trace.WriteLine("_Terminal_OnInputGain");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INPUT_GAIN , nGain ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INPUT_GAIN , nGain ));
		}

		private void _Terminal_OnInputMute(int bMute)
		{
			//Tools.Trace.WriteLine("_Terminal_OnInputMute");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INPUT_MUTE,bMute));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INPUT_MUTE,bMute));
		}

		private void _Terminal_OnInterceptCall(int nIdCall, short nVal)
		{
			//Tools.Trace.WriteLine("_Terminal_OnInterceptCall");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nIdCall;
			callInfo.Info = nVal;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.INTERCEPT_CALL, callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.INTERCEPT_CALL, callInfo ));
		}

		private void _Terminal_OnNetworkStateChanged(short nState)
		{
			//Tools.Trace.WriteLine("_Terminal_OnNetworkStateChanged");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.NETWORK_STATE_CHANGED, nState ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.NETWORK_STATE_CHANGED, nState ));
		}

		private void _Terminal_OnNewMember(int nCallId, string szName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnNewMember");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = szName;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.NEW_MEMBER, callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.NEW_MEMBER, callInfo ));
		}

		private void _Terminal_OnNewName(int nCallId, string szName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnNewName");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = szName;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.NEW_NAME, callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.NEW_NAME, callInfo ));
		}

		private void _Terminal_OnNewVideoFormat(int nCallId, short nChannelId, int width, int height)
		{
			//Tools.Trace.WriteLine("_Terminal_OnNewVideoFormat");
			int[] tabs=new int[4];
			tabs[0] = nCallId;
			tabs[1] = (int)nChannelId;
			tabs[2] = width;
			tabs[3] = height;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.NEW_VIDEO_FORMAT, tabs ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.NEW_VIDEO_FORMAT, tabs ));
		}

		private void _Terminal_OnPeerAddress(int nCallId, string szDottedAddr)
		{
			//Tools.Trace.WriteLine("_Terminal_OnPeerAddress");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = szDottedAddr;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.PEER_ADDRESS, callInfo ));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.PEER_ADDRESS, callInfo ));
		}
		private void _Terminal_OnPictureTaking(int nCallId, string bszFileName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnPictureTaking");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = bszFileName;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.PICTURE_CAPTURED,callInfo));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.PICTURE_CAPTURED,callInfo));
		}

		private void _Terminal_OnPlayMediaFile(int nCallId, string bszFileName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnPlayMediaFile");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = bszFileName;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.MEDIA_PLAYED,callInfo));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.MEDIA_PLAYED,callInfo));
		}

		private void _Terminal_OnQ931Indication(short nCode, short nNormalizedCode)
		{
			//Tools.Trace.WriteLine("_Terminal_OnQ931Indication");
			short[] tabs = new short[2];
			tabs[0] = nCode;
			tabs[1] = nNormalizedCode;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.Q931_INDICATION,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.Q931_INDICATION,tabs));
		}

		private void _Terminal_OnQ931MessageReceived(string bstrMessage, int nDecodeurIndice)
		{
			//Tools.Trace.WriteLine("_Terminal_OnQ931MessageReceived");
			InfoGeneric message = new InfoGeneric();
			message.Message = bstrMessage;
			message.Integer = nDecodeurIndice;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.Q931_MESSAGE_RECEIVED,message));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.Q931_MESSAGE_RECEIVED,message));
		}

		private void _Terminal_OnRawSIPMessageReceived(string bstrMessage, short bIsRequest)
		{
			//Tools.Trace.WriteLine("_Terminal_OnRawSIPMessageReceived");
			InfoGeneric message = new InfoGeneric();
			message.Message = bstrMessage;
			message.Integer = (int)bIsRequest;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SIP_RAWMESSAGE_RECEIVED,message));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SIP_RAWMESSAGE_RECEIVED,message));
		}

		private void _Terminal_OnReadMsg(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnReadMsg");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.READ_MSG,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.READ_MSG,nID));
		}

		private void _Terminal_OnRemotePartyInfo(int nCallId, object pRemotePartyInfo)
		{
			//Tools.Trace.WriteLine("_Terminal_OnRemotePartyInfo");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			eConf.IRemotePartyInfo XMLdatas = (eConf.IRemotePartyInfo)pRemotePartyInfo;
			callInfo.Info = XMLdatas;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.REMOTE_PARTY_INFO,callInfo));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.REMOTE_PARTY_INFO,callInfo));
		}

		private void _Terminal_OnRemotePartyRinging(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnRemotePartyRinging");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.REMOTE_PARTY_RINGING,nCallId));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.REMOTE_PARTY_RINGING,nCallId));
		}

		private void _Terminal_OnRemoveSubscription(string szContactIdentifier, string szEventPackageName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnRemoveSubscription");
			string[] tabs = new string[2];
			tabs[0] = szContactIdentifier;
			tabs[1] = szEventPackageName;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.REMOVE_SUBSCRIPTION,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.REMOVE_SUBSCRIPTION,tabs));
		}

		private void _Terminal_OnSipPresenceStatus(int nStatus)
		{
			//Tools.Trace.WriteLine("_Terminal_OnSipPresenceStatus");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SIP_PRESENCE_STATUS,nStatus));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SIP_PRESENCE_STATUS,nStatus));
		}

		private void _Terminal_OnSipRegistrationResult(short nStatusCode, short nStatus)
		{
			//Tools.Trace.WriteLine("_Terminal_OnSipRegistrationResult");
			short[] tabs = new short[2] ;
			tabs[0] = nStatusCode ;
			tabs[1] = nStatus ;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SIP_REGISTRATION_RESULT,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SIP_REGISTRATION_RESULT,tabs));
		}

		private void _Terminal_OnStandardCodecsNegotiated(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStandardCodecsNegotiated");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.STANDARD_CODECS_NEGOTIATED,nCallId));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.STANDARD_CODECS_NEGOTIATED,nCallId));
		}

		private void _Terminal_OnStartAudioDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartAudioDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_DECODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_DECODER_STARTED,nID));
			//			_LastRtpIdAudioIn = nID;
			//			if(StartAudioDecoder!=null)
			//			{
			//				StartAudioDecoder(nID);
			//			}
		}

		private void _Terminal_OnStartAudioEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartAudioEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_ENCODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_ENCODER_STARTED,nID));
			//			_LastRtpIdAudioOut = nID;
			//			if(StartAudioEncoder!=null)
			//			{
			//				StartAudioEncoder(nID);
			//			}
		}

		private void _Terminal_OnStartDataDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartDataDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DATA_DECODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DATA_DECODER_STARTED,nID));
		}

		private void _Terminal_OnStartDataEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartDataEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DATA_ENCODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DATA_ENCODER_STARTED,nID));
		}

		private void _Terminal_OnStartTextT140Decoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartTextT140Decoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.TEXT_DECODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.TEXT_DECODER_STARTED,nID));
		}

		private void _Terminal_OnStartTextT140Encoder(short nID)
		{
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.TEXT_ENCODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.TEXT_ENCODER_STARTED,nID));
		}

		//		private void _Terminal_OnStartVideoDecoder(short nID)
		//		{
		//			//Tools.Trace.WriteLine("_Terminal_OnStartVideoDecoder");
		//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_STARTED,nID));
		////			_LastRtpIdVideoIn = nID;
		////			if(StartVideoDecoder!=null)
		////			{
		////				StartVideoDecoder(nID);
		////			}
		//		}
		//
		//		private void _Terminal_OnStartVideoDecoderEx(int nCallId, short nID, int hWnd)
		//		{
		//			//Tools.Trace.WriteLine("_Terminal_OnStartVideoDecoderEx");
		//			int[] tabs = new int[3];
		//			tabs[0] = nCallId;
		//			tabs[1] = (int) nID;
		//			tabs[2] = hWnd;
		//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_EX_STARTED,tabs));
		////			_LastRtpIdVideoIn = nID;
		////			if(StartVideoDecoder!=null)
		////			{
		////				StartVideoDecoder(nID);
		////			}
		//		}
		//
		//		private void _Terminal_OnStartVideoEncoder(short nID)
		//		{
		//			//Tools.Trace.WriteLine("_Terminal_OnStartVideoEncoder");
		//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_ENCODER_STARTED,nID));
		////			_LastRtpIdVideoOut = nID;
		////			if(StartVideoEncoder!=null)
		////			{
		////				StartVideoEncoder(nID);
		////			}
		//		}

		private void _Terminal_OnStatusChanged(string Contact, string szPackageName, string szContentType, string szNewStatusDescription)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStatusChanged");
			string[] statusTabs = new string[]{Contact,szPackageName,szContentType,szNewStatusDescription};
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.STATUS_CHANGED,statusTabs));
		}

		private void _Terminal_OnStopAudioDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopAudioDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_DECODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_DECODER_STOPPED,nID));
		}

		private void _Terminal_OnStopAudioEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopAudioEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.AUDIO_ENCODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.AUDIO_ENCODER_STOPPED,nID));
		}

		private void _Terminal_OnStopDataDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopDataDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DATA_DECODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DATA_DECODER_STOPPED,nID));
		}

		private void _Terminal_OnStopDataEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopDataEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.DATA_ENCODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.DATA_ENCODER_STOPPED,nID));
		}

		private void _Terminal_OnStopTextT140DataDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopTextT140DataDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.TEXT_DECODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.TEXT_DECODER_STOPPED,nID));
		}

		private void _Terminal_OnStopTextT140DataEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopTextT140DataEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.TEXT_ENCODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.TEXT_ENCODER_STOPPED,nID));
		}

		//		private void _Terminal_OnStopVideoDecoder(short nID)
		//		{
		//			//Tools.Trace.WriteLine("_Terminal_OnStopVideoDecoder");
		//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_STOPPED,nID));
		//		}
		//
		//		private void _Terminal_OnStopVideoDecoderEx(int nCallId, short nID)
		//		{
		//			//Tools.Trace.WriteLine("_Terminal_OnStopVideoDecoderEx");
		//			InfoCall callInfo = new InfoCall();
		//			callInfo.CallId = nCallId;
		//			callInfo.Info = nID;
		//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_EX_STOPPED,callInfo));
		//		}
		//
		//		private void _Terminal_OnStopVideoEncoder(short nID)
		//		{
		//			//Tools.Trace.WriteLine("_Terminal_OnStopVideoEncoder");
		//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_ENCODER_STOPPED,nID));
		//		}

		private void _Terminal_OnSubscription(string szContactIdentifier, string szEventPackageName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnSubscription");
			string[]tabs = new string[]{szContactIdentifier,szEventPackageName};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SUBSCRIPTION,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SUBSCRIPTION,tabs));
		}

		private void _Terminal_OnSubscriptionAccepted(string szContactIdentifier, string szEventPackageName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnSubscriptionAccepted");
			string[]tabs = new string[]{szContactIdentifier,szEventPackageName};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SUBSCRIPTION_ACCEPTED,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SUBSCRIPTION_ACCEPTED,tabs));
		}

		private void _Terminal_OnSubscriptionPending(string bstrMessage, string bstrEventPackage)
		{
			//Tools.Trace.WriteLine("_Terminal_OnSubscriptionPending");
			string[]tabs = new string[]{bstrMessage, bstrEventPackage};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SUBSCRIPTION_PENDING,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SUBSCRIPTION_PENDING,tabs));
		}

		private void _Terminal_OnSubscriptionRefused(string szContactIdentifier, string szEventPackageName)
		{
			//Tools.Trace.WriteLine("_Terminal_OnSubscriptionRefused");
			string[]tabs = new string[]{szContactIdentifier, szEventPackageName};
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SUBSCRIPTION_REFUSED,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SUBSCRIPTION_REFUSED,tabs));
		}

		private void _Terminal_OnT120Connect(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnT120Connect");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.T120_CONNECTED,nCallId));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.T120_CONNECTED,nCallId));
		}

		private void _Terminal_OnT120Disconnect(int nCallId)
		{
			//Tools.Trace.WriteLine("_Terminal_OnT120Disconnect");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.T120_DISCONNECTED,nCallId));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.T120_DISCONNECTED,nCallId));
		}

		private void _Terminal_OnVideoQuality(short nID, short nQuality)
		{
			//Tools.Trace.WriteLine("_Terminal_OnVideoQuality");
			short [] tabs = new short [2];
			tabs[0] = nID;
			tabs[1] = nQuality;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_QUALITY_CHANGED,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_QUALITY_CHANGED,tabs));
		}
		#endregion
		#region AVControl events
		private void _TerminalAVControl_OnStartVideoDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartVideoDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_DECODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_STARTED,nID));
	
		}

		private void _TerminalAVControl_OnStartVideoDecoderEx(int nCallId, short nID, int hWnd)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartVideoDecoderEx");
			int[] tabs = new int[3];
			tabs[0] = nCallId;
			tabs[1] = (int) nID;
			tabs[2] = hWnd;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_DECODER_EX_STARTED,tabs));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_EX_STARTED,tabs));
	
		}

		private void _TerminalAVControl_OnStartVideoEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStartVideoEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_ENCODER_STARTED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_ENCODER_STARTED,nID));

		}

		private void _TerminalAVControl_OnStopVideoDecoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopVideoDecoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_DECODER_STOPPED,nID));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_STOPPED,nID));		
		}

		private void _TerminalAVControl_OnStopVideoDecoderEx(int nCallId, short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopVideoDecoderEx");
			InfoCall callInfo = new InfoCall();
			callInfo.CallId = nCallId;
			callInfo.Info = nID;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_DECODER_EX_STOPPED,callInfo));
			}
			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_DECODER_EX_STOPPED,callInfo));
		}

		private void _TerminalAVControl_OnStopVideoEncoder(short nID)
		{
			//Tools.Trace.WriteLine("_Terminal_OnStopVideoEncoder");
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.VIDEO_ENCODER_STOPPED,nID));
			}
			////System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.VIDEO_ENCODER_STOPPED,nID));
		}
		#endregion
		private void _SipTerminal_OnOutbandDTMF(short nCallId, string szDTMF, int nDuration)
		{
			//Tools.Trace.WriteLine("_SipTerminal_OnOutbandDTMF");
			InfoCall callInfo = new InfoCall();
			if(szDTMF=="" || szDTMF==string.Empty)
			{
				szDTMF=" ";
			}
			callInfo.CallId = nCallId;
			callInfo.Info = nDuration.ToString()+ szDTMF;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.SIP_DTMF_OUTBAND,callInfo));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),new EventInfo(Events.SIP_DTMF_OUTBAND,callInfo));
		}
		private void _TerminalAVOptions_OnOutputMute(short nID, int bMute)
		{
			//Tools.Trace.WriteLine("_TerminalAVOptions_OnOutputMute");
			int[] tabs = new int[2];
			tabs[0] =nID;
			tabs[1] =bMute;
			lock(_Events)
			{
				_Events.Add(new EventInfo(Events.OUTPUT_MUTE,tabs));
			}
//			//System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(HandlesEvent),);
		}
		#endregion
	}
}
