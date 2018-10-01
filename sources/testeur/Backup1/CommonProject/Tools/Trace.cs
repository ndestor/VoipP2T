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
