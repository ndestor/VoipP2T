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
