using System;

namespace CommonProject.Tools
{
    /// <summary>
    /// Niveau des traces
    /// </summary>
    public enum TraceLevel
    {
        /// <summary>
        /// Beaucoup de traces
        /// </summary>
        Verbose,
        /// <summary>
        /// Pas de traces
        /// </summary>
        Normal
    }
    
    /// <summary>
    /// Classe gérant les traces de l'application
    /// </summary>
    public  class Trace
    {

        /// <summary>
        /// Niveau de trace de l'application
        /// </summary>
        public static TraceLevel _Level = TraceLevel.Normal;
        /// <summary>
        /// Fonction statique écrivant une trace si on est en Verbose
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLog(string message)
        {            
            if (_Level == TraceLevel.Verbose)
            {
                WriteLine(message);
            }
        }
        /// <summary>
        /// Fonction statique écrivant une trace
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLine(string message)
        {
            Console.WriteLine(System.DateTime.Now.ToString() + " : " + message);
        }
        /// <summary>
        /// Fonction statique écrivant une trace pour une exception
        /// </summary>
        /// <param name="exception"></param>
        public static void WriteLine(Exception exception)
        {
            string message = "ERREUR : " + exception.ToString();
            WriteLine(message);
        }

        /// <summary>
        /// The <code>WriteInfo</code> logging level designates events that
        ///	are useful in monitoring events that are significant
        ///	in an application life cycle.
        /// </summary>
        public static void WriteInfo(string _message)
        {
            string message = "INFO : " + _message;
            WriteLine(message);
        }
        /// <summary>
        /// The <code>WriteDebug</code> level designates the level used to 
        /// debug the system and to help in resolving issues surrounding
        /// an application's malfunction.
        /// </summary>
        public static void WriteDebug(string _message)
        {
            if (_Level == TraceLevel.Verbose)
            {
                string message = "DEBUG : " + _message;
                WriteLine(message);
            }
        }
        /// <summary>
        /// The <code>WriteError</code> level designates error events that
        /// might still allow the application to continue running.
        /// </summary>
        public static void WriteError(string _message)
        {
            string message = "ERROR : " + _message;
            WriteLine(message);
        }

        /// <summary>
        /// the <code>WriteWarn</code> level designates events that might
        /// be harmful to system stability.
        /// </summary>
        public static void WriteWarn(string _message)
        {
            string message = "WARN : " + _message;
            WriteLine(message);
        }
    }
}
