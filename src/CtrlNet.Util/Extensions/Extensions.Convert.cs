﻿using System;

namespace CtrlNet.Util.Extensions
{

    /// <summary>
    ///		常规类型转换扩展类
    ///     <see cref="Int32"/>
    ///     <see cref="Double"/>
    ///     <see cref="Decimal"/>
    ///     <see cref="Boolean"/>
    ///     <see cref="DateTime"/>
    ///     <see cref="String"/>
    /// </summary>
    public static partial class Extensions
    {
        #region 数值转换
        /// <summary>
        ///		转为整形
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            var success = int.TryParse(data.ToString(), out int result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        ///		转换为可空整形
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return null;
            bool isValid = int.TryParse(data.ToString(), out int result);
            if (isValid)
                return result;
            return null;
        }
        /// <summary>
        ///		转为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;
            return double.TryParse(data.ToString(), out double result) ? result : 0;
        }
        /// <summary>
        ///     转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位</param>
        /// <returns></returns>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }

        /// <summary>
        ///     转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return null;
            bool isValid = double.TryParse(data.ToString(), out double result);
            if (isValid)
                return result;
            return null;
        }
        /// <summary>
        ///     转换为高精度浮点数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;
            return decimal.TryParse(data.ToString(), out decimal result) ? result : 0;
        }
        /// <summary>
        /// 转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal(this object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }



        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? ToDecimalOrNull(this object data)
        {
            if (data == null)
                return null;
            bool isValid = decimal.TryParse(data.ToString(), out decimal result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }
        #endregion

        #region 日期转换
        /// <summary>
        ///     转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static DateTime ToDate(this object data)
        {
            if (data == null)
                return DateTime.MinValue;
            return DateTime.TryParse(data.ToString(), out DateTime result) ? result : DateTime.MinValue;
        }

        /// <summary>
        ///     转换为可空日期
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return null;
            bool isValid = DateTime.TryParse(data.ToString(), out DateTime result);
            if (isValid)
                return result;
            return null;
        }

        #endregion

        #region 布尔值转换
        /// <summary>
        ///     转换为布尔值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            return bool.TryParse(data.ToString(), out bool result) && result;
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private static bool? GetBool(this object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "否":
                    return false;
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool isValid = bool.TryParse(data.ToString(), out bool result);
            if (isValid)
                return result;
            return null;
        }
        #endregion

        #region 字符串转换
        /// <summary>
        ///     转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string ToString(this object data)
        {
            return data == null ? string.Empty : data.ToString().Trim();
        }
        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="input">输入值</param>
        public static string SafeString(this object input)
        {
            return input?.ToString().Trim() ?? string.Empty;
        }
        #endregion
    }

}

