using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using HomeScale.src.util;

namespace HomeScale.src.util
{
    public class CommonUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string DUPLICATE_DATA = "ไม่สามารถบันทึก กรุณาตรวจสอบข้อมูลซ้ำ";
        public static string REQUIRE_MESSAGE = "กรุณากรอกข้อมูลที่มีให้ครบถ้วน";
        public static string SAVE_DATA_SUCCESS = "บันทึกข้อมูลเรียบร้อย";
        public static string DELETE_DATA_SUCCESS = "ลบข้อมูลเรียบร้อย";
        public static string SELECT_DATA_DELETE = "กรุณาเลือกข้อมูลที่ต้องการลบ!";
        public static string CONFIRM_DELETE_DATA = "คุณแน่ใจว่าต้องการลบข้อมูล!";
        public static string TITLE_DELETE = "ลบข้อมูล";
        public static string DATA_NOTFOUND_AGAIN_LOGIN = "ไม่พบข้อมูลกรุณาล็อกอินอีกครั้ง";
        public static string REQUIRE_MESSAGE_USER_LOGIN = "กรุณากรอกบัญชีผู้ใช้";
        public static string REQUIRE_MESSAGE_PASSWORD_LOGIN = "กรุณากรอกรหัสผ่าน";
    }
}
