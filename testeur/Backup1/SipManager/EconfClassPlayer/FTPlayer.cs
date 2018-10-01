using System;
using System.Diagnostics;

namespace Tester.SipManager.EconfClassPlayer
{
	/// <summary>
	/// Class surveillant le process ftplayer.
	/// </summary>
	public class FTPlayer
	{
		//Process
		private const string _EconfProcessName = "ftplayer";
		private Process _EConfProcess = null;
		private static FTPlayer _Instance = null;
		//Log
		private static bool _IsLogActivated;
		/// <summary>
		/// Taille des derniers messages lus des logs. Si -1 enregistre tous les logs.
		/// </summary>
		public static int _LastReadMsg;
		/// <summary>
		/// Chemin par défaut du fichier de sortie
		/// </summary>
		public const string LogPath = @"C:\output.txt";
		private long _InitFileSize;
		
		private FTPlayer()
		{
			CheckProcess();
		}
		/// <summary>
		/// Récupère le singleton
		/// </summary>
		public static FTPlayer Instance
		{
			get
			{
				if(_Instance==null)
				{
					_Instance = new FTPlayer();
				}
				return _Instance;
			}
		}
		/// <summary>
		/// Récupère si le process existe
		/// </summary>
		public static bool IsExist
		{
			get
			{
				Process [] processes = Process.GetProcessesByName(_EconfProcessName);
				if(processes.Length<=0)
				{
					return false;
				}
				return true;
			}

		}
		#region Process info
		private bool CheckProcess()
		{
			if(_EConfProcess!=null)
			{
				if(!_EConfProcess.HasExited)
				{
					return true;
				}
			}
			//On doit recréer le process
			Process [] processes = Process.GetProcessesByName(_EconfProcessName);
			if(processes.Length<=0)
			{
				return false;
			}
			_EConfProcess  = processes[0];
			return true;
		}
		/// <summary>
		/// Récupère la mémoire virtuel utilisée
		/// </summary>
		/// <param name="MemorySize"></param>
		/// <returns></returns>
		public bool GetMemory(out int MemorySize)
		{
			_EConfProcess.Refresh();
			MemorySize = 0;
			if(!CheckProcess())
			{
				return false;
			}
			MemorySize = _EConfProcess.PrivateMemorySize;
			return true;
		}
		/// <summary>
		/// Récupère la mémoire utilisée
		/// </summary>
		/// <param name="WorkingSet"></param>
		/// <returns></returns>
		public bool GetWorkingSet(out int WorkingSet)
		{
			WorkingSet = 0;
			if(!CheckProcess())
			{
				return false;
			}
			_EConfProcess.Refresh();
			WorkingSet = _EConfProcess.WorkingSet;
			return true;
		}
		/// <summary>
		/// Récupère le pic de mémoire utilisée
		/// </summary>
		/// <param name="PeakWorkingSet"></param>
		/// <returns></returns>
		public bool GetPeakWorkingSet(out int PeakWorkingSet)
		{
			PeakWorkingSet = 0;
			if(!CheckProcess())
			{
				return false;
			}
			_EConfProcess.Refresh();
			PeakWorkingSet = _EConfProcess.PeakWorkingSet;
			return true;
		}
		/// <summary>
		/// Récupère le nombre de handles
		/// </summary>
		/// <param name="Handles"></param>
		/// <returns></returns>
		public bool GetHandles(out int Handles)
		{
			_EConfProcess.Refresh();
			Handles = 0;
			if(!CheckProcess())
			{
				return false;
			}
			_EConfProcess.Refresh();
			Handles = _EConfProcess.HandleCount;
			return true;
		}
		/// <summary>
		/// Récupère le nombre de handles
		/// </summary>
		/// <param name="Threads"></param>
		/// <returns></returns>
		public bool GetThreads(out int Threads)
		{
			Threads = 0;
			if(!CheckProcess())
			{
				return false;
			}
			Threads = _EConfProcess.Threads.Count;
			return true;
		}
		/// <summary>
		/// Interroge le process
		/// </summary>
		/// <param name="IsResponding"></param>
		/// <returns></returns>
		public bool IsResponding(out bool IsResponding)
		{
			IsResponding = false;
			if(!CheckProcess())
			{
				return false;
			}
			_EConfProcess.Refresh();
			IsResponding = _EConfProcess.Responding;
			return true;
		}
		#endregion
		#region Log info
		/// <summary>
		/// Change le fichier logger.ini pour activer les traces
		/// </summary>
		/// <returns></returns>
        /// 
        /*
		public static bool ActivateLog()
		{
			bool success = false;
			try
			{
				string root = EConf.EConfPlayer.Instance.GetEconfRoot();
				if(root==null || root==string.Empty)
				{
					return false;
				}
				root = root.Trim();
				if(root!=null && root!=string.Empty)
				{
					if(!root.EndsWith(@"\"))
					{
						root = root+@"\";
					}
					System.IO.Stream strLogg =  System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ModuleTest."+ConfigManager.DirectoryResources+"."+ConfigManager.ActiveLoggerIni);
					if(strLogg!=null)
					{
						Tools.File.CopyFromStream(strLogg,root+ConfigManager.LoggerIni);
					}
				}
				success = true;
				_IsLogActivated = true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine("Impossible de mettre à jour le fichier logger :"+exception.ToString());
				success = false;
			}
			return success;
		}
         *
		/// <summary>
		/// Change le fichier logger.ini pour désactiver les traces
		/// </summary>
		/// <returns></returns>
		public static bool DesactivateLog()
		{
			bool success = false;
			try
			{
				string root = EConf.EConfPlayer.Instance.GetEconfRoot();
				root = root.Trim();
				if(root!=null && root!=string.Empty)
				{
					if(!root.EndsWith(@"\"))
					{
						root = root+@"\";
					}
					System.IO.Stream strLogg = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ModuleTest."+ConfigManager.DirectoryResources+"."+ConfigManager.InactiveLoggerIni);
					if(strLogg!=null)
					{
						Tools.File.CopyFromStream(strLogg,root+ConfigManager.LoggerIni);
					}
				}
				success = true;
				_IsLogActivated = false;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine("Impossible de mettre à jour le fichier logger :"+exception.ToString());
				success = false;
			}
			return success;
		} */
        /// <summary>
		/// Démarre l'enregistrement des logs. Prends la taille du fichier de log
		/// </summary>
		/// <returns></returns>
		public static bool StartSessionLog()
		{
			bool success = false;
			if(!_IsLogActivated)
			{
				return false;
			}
			if(_Instance==null)
			{
				_Instance=new FTPlayer();
			}
			if(!System.IO.File.Exists(LogPath))
			{
				return false;
			}
			try
			{
				System.IO.FileInfo fileInfo =new System.IO.FileInfo(LogPath);
				_Instance._InitFileSize = fileInfo.Length;
				success = true;
			}
			catch(Exception exception)
			{
			    Tools.Trace.WriteLine(exception);
			}
			return success;
		}
		/// <summary>
		/// Termine la session de logs
		/// </summary>
		/// <param name="errorCountDurungSession"></param>
		/// <param name="lineLog"></param>
		/// <returns></returns>
		public static bool EndSessionLog(out int errorCountDurungSession, out string lineLog)
		{
			System.IO.FileStream stream = null ;
			double result =0;
			bool success = false;
			errorCountDurungSession =0;
			lineLog=string.Empty;
			if(!_IsLogActivated)
			{
				return false;
			}
			if(_Instance==null)
			{
				_Instance=new FTPlayer();
			}
			if(!System.IO.File.Exists(LogPath))
			{
				return false;
                
			}
			try
			{
                EconfTools.QueryPerfCounter.Instance.Start();
				System.IO.File.Copy(LogPath,@"c:\temp.txt",true);
                EconfTools.QueryPerfCounter.Instance.Stop();
                result = EconfTools.QueryPerfCounter.Instance.Duration();
				Tools.Trace.WriteLog("EndSessionLog copy fichier :"+result+" nanos");

                EconfTools.QueryPerfCounter.Instance.Start();
				stream = System.IO.File.Open(@"c:\temp.txt",System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.Read);
				if(stream==null)
				{
					return false;
				}
				stream.Seek(_Instance._InitFileSize,System.IO.SeekOrigin.Begin);
				_Instance.GetErrorSession(stream,out errorCountDurungSession, out lineLog);
                EconfTools.QueryPerfCounter.Instance.Stop();
                result = EconfTools.QueryPerfCounter.Instance.Duration();
				Tools.Trace.WriteLog("EndSessionLog GetErrorSession :"+result+" nanos");
				success = true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception);
			}
			return success;
		}

		private bool GetErrorSession(System.IO.Stream stream, out int count, out string lastError)
		{
			bool success = false;
			count = 0;
			lastError = string.Empty;
			if(stream==null)
			{
				return false;
			}
			if(!_IsLogActivated)
			{
				return false;
			}
			if(!System.IO.File.Exists(LogPath))
			{
				return false;
			}
			try
			{
				string tmpStr;
				int line=0;
				long TriggerPosition =-1;
				if(_LastReadMsg>0)
				{
					TriggerPosition= stream.Length - _LastReadMsg;
				}
				using (System.IO.StreamReader reader = new System.IO.StreamReader(stream)) 
				{
					while (reader.Peek() >= 0) 
					{
						tmpStr = reader.ReadLine();

						line++;
						if((line = tmpStr.IndexOf(" ERRO "))>0)
						{
							count++;
						}
						if(stream.Position>TriggerPosition)
						{
							lastError+=tmpStr+"\n";
						}
					}
				}
				
				success = true;
			}
			catch(Exception exception)
			{
				Tools.Trace.WriteLine(exception);
			}
			return success;
		}
		
		#endregion
	}
}
