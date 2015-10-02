using System.Windows.Forms;

namespace ExpressProfiler
{
    class ListViewNF : ListView
    {

		public SortOrder SortOrder { get; set; }

        public ListViewNF()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

			SortOrder = SortOrder.Ascending;
        }

	    public void ToggleSortOrder()
	    {
		    if (SortOrder == SortOrder.Ascending)
		    {
			    SortOrder = SortOrder.Descending;
				return;
		    }
			SortOrder = SortOrder.Ascending;
	    }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}