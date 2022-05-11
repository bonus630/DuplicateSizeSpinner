using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using corel = Corel.Interop.VGCore;

namespace DuplicateSizeSpinner
{
    public partial class ControlUI : UserControl
    {
        public static corel.Application corelApp;
        private corel.DataSourceProxy duplicateSpinnerDSP;
        private corel.DataSourceProxy originalSpinnerDSP;
        private XmlUnitParser xmlUnitParser;
        private UnitPairs unitPairs;
        public ControlUI(object app)
        {

            try
            {
                corelApp = app as corel.Application;
                var dsf = new DataSource.DataSourceFactory();
                dsf.AddDataSource("DuplicateSizeSpinnerDS", typeof(DataSource.DuplicateSizeSpinnerDataSource));
                dsf.Register();

                xmlUnitParser = new XmlUnitParser();
                unitPairs = new UnitPairs();
                xmlUnitParser.Pairs = unitPairs;

                xmlUnitParser.LoadFile(Path.Combine(corelApp.AddonPath,"DuplicateSizeSpinner\\UnitPairs.xml"));

                duplicateSpinnerDSP = corelApp.FrameWork.Application.DataContext.GetDataSource("DuplicateSizeSpinnerDS");
                originalSpinnerDSP = corelApp.FrameWork.Application.DataContext.GetDataSource("DocumentPrefsDS");

                corelApp.OnApplicationEvent += CorelApp_OnApplicationEvent;
            }
            catch
            {
                global::System.Windows.MessageBox.Show("VGCore Erro");
            }

        }

        private void CorelApp_OnApplicationEvent(string EventName, ref object[] Parameters)
        {
            if (EventName.Equals("DocUnitChange"))
            {
                string bottom = originalSpinnerDSP.GetProperty("YRulerUnit").ToString();
                string top = originalSpinnerDSP.GetProperty("XRulerUnit").ToString();

                UnitPair topPair = unitPairs.FindFirstOrDefaultPair(top);
                UnitPair bottomPair = unitPairs.FindFirstOrDefaultPair(bottom);

                if(bottomPair!=null)
                    duplicateSpinnerDSP.SetProperty("BottomDisplayUnit",bottomPair.ReverseUnit(bottom));
                if(topPair!=null)
                    duplicateSpinnerDSP.SetProperty("TopDisplayUnit", topPair.ReverseUnit(top));
            }
        }
     


    }
}
