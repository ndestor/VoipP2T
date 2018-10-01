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
using System.Collections.Generic;
using System.Text;

namespace Tester.Scenario.DTMFManager
{
    public abstract class DTMFConverter
    {
        /// <summary>
        /// ConvertDTMFToString
        /// </summary>
        /// <param name="dtmf"></param>
        /// <returns></returns>
        public static string ConvertDTMFToString(DTMF dtmf)
        {
            string strDTMF = string.Empty;
            switch (dtmf)
            {
                case DTMF.DTMF_1:
                    strDTMF = "1";
                    break;
                case DTMF.DTMF_2:
                    strDTMF = "2";
                    break;
                case DTMF.DTMF_3:
                    strDTMF = "3";
                    break;
                case DTMF.DTMF_4:
                    strDTMF = "4";
                    break;
                case DTMF.DTMF_5:
                    strDTMF = "5";
                    break;
                case DTMF.DTMF_6:
                    strDTMF = "6";
                    break;
                case DTMF.DTMF_7:
                    strDTMF = "7";
                    break;
                case DTMF.DTMF_8:
                    strDTMF = "8";
                    break;
                case DTMF.DTMF_9:
                    strDTMF = "9";
                    break;
                case DTMF.DTMF_0:
                    strDTMF = "0";
                    break;
                case DTMF.DTMF_Asterix:
                    strDTMF = "*";
                    break;
                case DTMF.DTMF_Sharp:
                    strDTMF = "#";
                    break;
                case DTMF.DTMF_A:
                    strDTMF = "A";
                    break;
                case DTMF.DTMF_B:
                    strDTMF = "B";
                    break;
                case DTMF.DTMF_C:
                    strDTMF = "C";
                    break;
                case DTMF.DTMF_D:
                    strDTMF = "D";
                    break;
            }
            return strDTMF;
        }
        /// <summary>
        /// ConvertStringToDTMF
        /// </summary>
        /// <param name="strDTMF"></param>
        /// <returns></returns>
        public static DTMF ConvertStringToDTMF(string strDTMF)
        {
            DTMF dtmf = DTMF.DTMF_0;
            switch (strDTMF)
            {
                case "1":
                    dtmf = DTMF.DTMF_1;
                    break;
                case "2":
                    dtmf = DTMF.DTMF_2;
                    break;
                case "3":
                    dtmf = DTMF.DTMF_3;
                    break;
                case "4":
                    dtmf = DTMF.DTMF_4;
                    break;
                case "5":
                    dtmf = DTMF.DTMF_5;
                    break;
                case "6":
                    dtmf = DTMF.DTMF_6;
                    break;
                case "7":
                    dtmf = DTMF.DTMF_7;
                    break;
                case "8":
                    dtmf = DTMF.DTMF_8;
                    break;
                case "9":
                    dtmf = DTMF.DTMF_9;
                    break;
                case "0":
                    dtmf = DTMF.DTMF_0;
                    break;
                case "*":
                    dtmf = DTMF.DTMF_Asterix;
                    break;
                case "#":
                    dtmf = DTMF.DTMF_Sharp;
                    break;
                case "A":
                    dtmf = DTMF.DTMF_A;
                    break;
                case "B":
                    dtmf = DTMF.DTMF_B;
                    break;
                case "C":
                    dtmf = DTMF.DTMF_C;
                    break;
                case "D":
                    dtmf = DTMF.DTMF_D;
                    break;
            }
            return dtmf;
        }
    }
}
