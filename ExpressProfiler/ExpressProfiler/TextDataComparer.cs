using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ExpressProfiler.EventComparers
{
	public class TextDataComparer : IComparer<ListViewItem>
	{
		public int CheckedColumn { get; set; }
		public SortOrder SortOrder { get; set; }

		public TextDataComparer(int checkedColumn, SortOrder sortOrder)
		{
			CheckedColumn = checkedColumn;
			SortOrder = sortOrder;
		}

		public int Compare(ListViewItem x, ListViewItem y)
		{
			if (SortOrder == SortOrder.Descending)
			{
				return CompareDescending(x, y);
			}
			return CompareAscending(x, y);
		}

		private int CompareAscending(ListViewItem x, ListViewItem y)
		{
			if (x.SubItems[CheckedColumn] == null && y.SubItems[CheckedColumn] == null) return 0;
			else if (x.SubItems[CheckedColumn] == null) return -1;
			else if (y.SubItems[CheckedColumn] == null) return 1;
			else
			{
				int xAsInt;
				bool xIsInt = Int32.TryParse(x.SubItems[CheckedColumn].Text.Replace(",",""), out xAsInt);

				int yAsInt;
				bool yIsInt = Int32.TryParse(y.SubItems[CheckedColumn].Text.Replace(",",""), out yAsInt);

				if (xIsInt && yIsInt)
				{
					if (xAsInt < yAsInt)
						return -1;
					else if (xAsInt > yAsInt)
						return 1;
					return 0; //Equals.
				}
				return String.Compare(x.SubItems[CheckedColumn].Text, y.SubItems[CheckedColumn].Text, false);
			}
		}

		private int CompareDescending(ListViewItem x, ListViewItem y)
		{
			if (x.SubItems[CheckedColumn] == null && y.SubItems[CheckedColumn] == null) return 0;
			else if (x.SubItems[CheckedColumn] == null) return 1;
			else if (y.SubItems[CheckedColumn] == null) return -1;
			else
			{
				int xAsInt;
				bool xIsInt = Int32.TryParse(x.SubItems[CheckedColumn].Text.Replace(",",""), out xAsInt);

				int yAsInt;
				bool yIsInt = Int32.TryParse(y.SubItems[CheckedColumn].Text.Replace(",",""), out yAsInt);

				if (xIsInt && yIsInt)
				{
					if (xAsInt > yAsInt)
						return -1;
					else if (xAsInt < yAsInt)
						return 1;
					return 0; //Equals.
				}
				return String.Compare(y.SubItems[CheckedColumn].Text, x.SubItems[CheckedColumn].Text, false);
			}
		}
	}
}
