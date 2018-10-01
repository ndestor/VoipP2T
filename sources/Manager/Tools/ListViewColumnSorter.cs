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
using System.Collections;
using System.Windows.Forms;
using System;

namespace Manager.Tools
{
    /* Inutilisé pour le moment dans le projet */
    
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Spécifie la colonne à trier
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Spécifie l'ordre de tri (en d'autres termes 'Croissant').
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
        /// Cette méthode est héritée de l'interface IComparer.  Il compare les deux objets passés en effectuant une comparaison 
        ///qui ne tient pas compte des majuscules et des minuscules.
        /// </summary>
        /// <param name="x">Premier objet à comparer</param>
        /// <param name="x">Deuxième objet à comparer</param>
        /// <returns>Le résultat de la comparaison. "0" si équivalent, négatif si 'x' est inférieur à 'y' 
        ///et positif si 'x' est supérieur à 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Envoit les objets à comparer aux objets ListViewItem
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare les deux éléments
            compareResult = ObjectCompare.Compare(Convert.ToInt32(listviewX.SubItems[ColumnToSort].Text), Convert.ToInt32(listviewY.SubItems[ColumnToSort].Text));

            // Calcule la valeur correcte d'après la comparaison d'objets
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Le tri croissant est sélectionné, renvoie des résultats normaux de comparaison
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Le tri décroissant est sélectionné, renvoie des résultats négatifs de comparaison
                return (-compareResult);
            }
            else
            {
                // Renvoie '0' pour indiquer qu'ils sont égaux
                return 0;
            }
        }

        /// <summary>
        /// Obtient ou définit le numéro de la colonne à laquelle appliquer l'opération de tri (par défaut sur '0').
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
        /// Obtient ou définit l'ordre de tri à appliquer (par exemple, 'croissant' ou 'décroissant').
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
