﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using HomeScale.src.util;

namespace HomeScale.src.util
{
    public class CheckUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool isEmpty(object obj)
        {
            if (obj == null || "".Equals(obj.ToString().Trim()) || "null".Equals(obj.ToString().Trim()))
            {
                return true;
            }
            return false;
        }

        public static bool isNotEmpty(object obj)
        {
            return !isEmpty(obj);
        }

        public static bool isEmptyLst(List<string> lst)
        {
            if (null == lst)
            {
            return true;
            }

            if (lst.Count() <= 0) {
                return true;
            }
            return false;
        }

        public static bool isNotEmptyLst(List<string> lst)
        {
            if (null != lst && lst.Count() > 0)
            {
            return true;
            }
            return false;
        }

    }
}
