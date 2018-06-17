using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using HomeScale.src.util;
using HomeScale.src.model.form;

namespace HomeScale.src.util
{
    public class LoadComboUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<ComboYesOrNoForm> loadComboYesOrNo()
        {
            List<ComboYesOrNoForm> lstCombo = new List<ComboYesOrNoForm>();
            ComboYesOrNoForm comboForm0 = new ComboYesOrNoForm();
            ComboYesOrNoForm comboForm1 = new ComboYesOrNoForm();

            comboForm0.yeONId = 0;
            comboForm0.yeONName = "ไม่ใช้";
            
            comboForm1.yeONId = 1;
            comboForm1.yeONName = "ใช้";

            lstCombo.Add(comboForm0);
            lstCombo.Add(comboForm1);

            return lstCombo;
        }
    }
}
