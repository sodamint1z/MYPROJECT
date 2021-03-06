﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PaknampoScale.src.util;

namespace PaknampoScale.src.util
{
    public class CommonUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string DUPLICATE_DATA = "ไม่สามารถบันทึก กรุณาตรวจสอบข้อมูลซ้ำ";
        public static string REQUIRE_MESSAGE = "กรุณากรอกข้อมูลที่มี * ให้ครบถ้วน";
        public static string SAVE_DATA_SUCCESS = "บันทึกข้อมูลเรียบร้อย";
        public static string DELETE_DATA_SUCCESS = "ลบข้อมูลเรียบร้อย";
        public static string SELECT_DATA_DELETE = "กรุณาเลือกข้อมูลที่ต้องการลบ!";
        public static string CONFIRM_DELETE_DATA = "คุณแน่ใจว่าต้องการลบข้อมูล!";
        public static string TITLE_DELETE = "ลบข้อมูล";
        public static string DATA_NOTFOUND_AGAIN_LOGIN = "ไม่พบข้อมูลกรุณาล็อกอินอีกครั้ง";
        public static string REQUIRE_MESSAGE_USER_LOGIN = "กรุณากรอกบัญชีผู้ใช้";
        public static string REQUIRE_MESSAGE_PASSWORD_LOGIN = "กรุณากรอกรหัสผ่าน";
        public static string REQUIRE_MESSAGE_REGISTER = "กรุณากรอกรหัสลงทะเบียน";
        public static string MESSAGE_REGISTER_SUCCESS = "รหัสถูกต้อง ลงทะเบียนสำเร็จ";
        public static string MESSAGE_REGISTER_FAILED = "รหัสไม่ถูกต้อง! กรุณากรอกใหม่อีกครั้ง";
        public static string REQUIRE_MESSAGE_CHAR_DIGIT = "กรุณากรอกรหัส 60 ตัวอักษรเท่านั้น";
    }
}
