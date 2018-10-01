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

