using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PaknampoScale.src.util;
using PaknampoScale.src.model.form.combo;

namespace PaknampoScale.src.util
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

        public static List<ComboStatementOrNotStatementForm> loadComboStatement()
        {
            List<ComboStatementOrNotStatementForm> lstCombo = new List<ComboStatementOrNotStatementForm>();

            lstCombo.Add(new ComboStatementOrNotStatementForm() { statementId = 0, statementValue = "ไม่มีบัญชี" });
            lstCombo.Add(new ComboStatementOrNotStatementForm() { statementId = 1, statementValue = "มีบัญชี" });

            return lstCombo;
        }

        public static List<ComboBaudRateForm> loadComboBaudRate()
        {
            List<ComboBaudRateForm> lstCombo = new List<ComboBaudRateForm>();

            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 0, baudRateValue = 300 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 1, baudRateValue = 600 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 2, baudRateValue = 1200 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 3, baudRateValue = 2400 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 4, baudRateValue = 9600 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 5, baudRateValue = 14400 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 6, baudRateValue = 19200 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 7, baudRateValue = 38400 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 8, baudRateValue = 57600 });
            lstCombo.Add(new ComboBaudRateForm() { baudRateId = 9, baudRateValue = 115200 });

            return lstCombo;
        }

        public static List<ComboDataBitsForm> loadComboDataBits()
        {
            List<ComboDataBitsForm> lstCombo = new List<ComboDataBitsForm>();

            lstCombo.Add(new ComboDataBitsForm() { dataBitsId = 0, dataBitsValue = 7 });
            lstCombo.Add(new ComboDataBitsForm() { dataBitsId = 1, dataBitsValue = 8 });

            return lstCombo;
        }

        public static List<ComboStopBitsForm> loadComboStopBits()
        {
            List<ComboStopBitsForm> lstCombo = new List<ComboStopBitsForm>();

            lstCombo.Add(new ComboStopBitsForm() { stopBitsId = 0, stopBitsValue = "One" });
            lstCombo.Add(new ComboStopBitsForm() { stopBitsId = 1, stopBitsValue = "OnePointFive" });
            lstCombo.Add(new ComboStopBitsForm() { stopBitsId = 2, stopBitsValue = "Two" });

            return lstCombo;
        }

        public static List<ComboParityForm> loadComboParity()
        {
            List<ComboParityForm> lstCombo = new List<ComboParityForm>();

            lstCombo.Add(new ComboParityForm() { parityId = 0, parityValue = "None" });
            lstCombo.Add(new ComboParityForm() { parityId = 1, parityValue = "Even" });
            lstCombo.Add(new ComboParityForm() { parityId = 2, parityValue = "Mark" });
            lstCombo.Add(new ComboParityForm() { parityId = 3, parityValue = "Odd" });
            lstCombo.Add(new ComboParityForm() { parityId = 4, parityValue = "Space" });

            return lstCombo;
        }

        public static List<ComboHandShakingForm> loadComboHandShaking()
        {
            List<ComboHandShakingForm> lstCombo = new List<ComboHandShakingForm>();

            lstCombo.Add(new ComboHandShakingForm() { handShakingId = 0, handShakingValue = "None" });
            lstCombo.Add(new ComboHandShakingForm() { handShakingId = 1, handShakingValue = "XOnXOff" });
            lstCombo.Add(new ComboHandShakingForm() { handShakingId = 2, handShakingValue = "RequestToSend" });
            lstCombo.Add(new ComboHandShakingForm() { handShakingId = 3, handShakingValue = "RequestToSendXOnXOff" });

            return lstCombo;
        }
    }
}
