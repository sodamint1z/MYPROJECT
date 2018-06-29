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

        public static List<ComboUseOrNotUseForm> loadComboUseOrNotUse()
        {
            List<ComboUseOrNotUseForm> lstCombo = new List<ComboUseOrNotUseForm>();

            lstCombo.Add(new ComboUseOrNotUseForm() { useOrNotUseId = 0, useOrNotUseValue = "ไม่ใช้" });
            lstCombo.Add(new ComboUseOrNotUseForm() { useOrNotUseId = 1, useOrNotUseValue = "ใช้" });

            return lstCombo;
        }
    }
}
