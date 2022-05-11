using Corel.Interop.VGCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace DuplicateSizeSpinner.DataSource
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DuplicateSizeSpinnerDataSource : BaseDataSource
    {

      
        public DuplicateSizeSpinnerDataSource(DataSourceProxy proxy) : base(proxy)
        {
            
            
        }
     
      
        public int bottomDisplayUnit = 1;
        public int topDisplayUnit = 1;

        public int BottomDisplayUnit { get { return bottomDisplayUnit; } set { bottomDisplayUnit = value; NotifyPropertyChanged(); } }
        public int TopDisplayUnit { get { return topDisplayUnit; } set { topDisplayUnit = value; NotifyPropertyChanged(); } }
     
    }

}
