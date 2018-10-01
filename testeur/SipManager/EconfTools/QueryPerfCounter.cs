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
using System.Runtime.InteropServices;

namespace Tester.SipManager.EconfTools
{
    public class QueryPerfCounter
    {
        /// <summary>
        /// Classe calculant le temps d'exécution d'une requête
        /// </summary>
        private static QueryPerfCounter _Instance;
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);
        private long start;
        private long stop;
        private long frequency;
        Decimal multiplier = new Decimal(1.0e9);
        private QueryPerfCounter()
        {
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new System.ComponentModel.Win32Exception();
            }
        }
        /// <summary>
        /// Classe récupérant le singleton
        /// </summary>
        public static QueryPerfCounter Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QueryPerfCounter();
                }
                return _Instance;
            }
        }
        /// <summary>
        /// Démarre le calcul du temps d'exécution
        /// </summary>
        public void Start()
        {
            QueryPerformanceCounter(out start);
        }
        /// <summary>
        /// Arrête le calcul du temps d'exécution
        /// </summary>
        public void Stop()
        {
            QueryPerformanceCounter(out stop);
        }
        /// <summary>
        /// Récupère la durée calculée
        /// </summary>
        /// <returns></returns>
        public double Duration()
        {
            return (((double)(stop - start) * (double)multiplier) / (double)
                frequency);
        }
    }
}

