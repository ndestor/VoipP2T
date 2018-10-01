/*
 * Copyright � 2007, Nicolas Destor
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
using System.Collections;
using System.Windows.Forms;
using System;

namespace Manager.Tools
{
    /* Inutilis� pour le moment dans le projet */
    
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Sp�cifie la colonne � trier
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Sp�cifie l'ordre de tri (en d'autres termes 'Croissant').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Objet de comparaison ne respectant pas les majuscules et minuscules
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Constructeur de classe.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialise la colonne sur '0'
            ColumnToSort = 0;
            
            // Initialise l'ordre de tri sur 'aucun'
            OrderOfSort = SortOrder.None;

            // Initialise l'objet CaseInsensitiveComparer
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// Cette m�thode est h�rit�e de l'interface IComparer.  Il compare les deux objets pass�s en effectuant une comparaison 
        ///qui ne tient pas compte des majuscules et des minuscules.
        /// </summary>
        /// <param name="x">Premier objet � comparer</param>
        /// <param name="x">Deuxi�me objet � comparer</param>
        /// <returns>Le r�sultat de la comparaison. "0" si �quivalent, n�gatif si 'x' est inf�rieur � 'y' 
        ///et positif si 'x' est sup�rieur � 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Envoit les objets � comparer aux objets ListViewItem
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare les deux �l�ments
            compareResult = ObjectCompare.Compare(Convert.ToInt32(listviewX.SubItems[ColumnToSort].Text), Convert.ToInt32(listviewY.SubItems[ColumnToSort].Text));

            // Calcule la valeur correcte d'apr�s la comparaison d'objets
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Le tri croissant est s�lectionn�, renvoie des r�sultats normaux de comparaison
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Le tri d�croissant est s�lectionn�, renvoie des r�sultats n�gatifs de comparaison
                return (-compareResult);
            }
            else
            {
                // Renvoie '0' pour indiquer qu'ils sont �gaux
                return 0;
            }
        }

        /// <summary>
        /// Obtient ou d�finit le num�ro de la colonne � laquelle appliquer l'op�ration de tri (par d�faut sur '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Obtient ou d�finit l'ordre de tri � appliquer (par exemple, 'croissant' ou 'd�croissant').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }

   
}
