using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwdGenerate
{
    public class Tool
    {
        /// <summary>
        /// 数字元数据
        /// </summary>
        private static char[] _number = null;
        /// <summary>
        /// 字母元数据
        /// </summary>
        private static char[] _letter = null;

        private const int _letterCount = 26;

        static Tool()
        {
            string number = "0123456789";
            _number = new char[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                _number[i] = number[i];
            }
        }

        /// <summary>
        /// 字母大小写方式
        /// </summary>
        public enum EType
        {
            /// <summary>
            /// 大写
            /// </summary>
            Upper = 1,
            /// <summary>
            /// 小写
            /// </summary>
            Lower = 2,
            /// <summary>
            /// 大小写
            /// </summary>
            UpperLower = 3
        }

        /// <summary>
        /// 初始化字母元数据
        /// </summary>
        /// <param name="type"></param>
        private static void InitLetter(EType type)
        {
            int index = 0;
            if (type == EType.UpperLower)
            {
                _letter = new char[_letterCount + _letterCount];
            }
            else
            {
                _letter = new char[_letterCount];
            }
            if (type == EType.Upper || type == EType.UpperLower)
            {
                for (int i = 65; i < 91; i++)
                {
                    _letter[index] = (char)i;
                    index++;
                }
            }
            if (type == EType.Lower || type == EType.UpperLower)
            {
                for (int i = 97; i < 123; i++)
                {
                    _letter[index] = (char)i;
                    index++;
                }
            }
        }

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <param name="other">特殊字符</param>
        /// <param name="type">字母大小写方式</param>
        /// <param name="number">是否包含数字</param>
        /// <param name="min">最小数</param>
        /// <param name="max">最大数</param>
        /// <returns>生成的密码</returns>
        public static string Generate(char[] other, EType type = EType.UpperLower, bool number = true, int min = 6, int max = 15)
        {
            List<char> list = new List<char>();
            InitLetter(type);
            Random ran = new Random();
            int len = ran.Next(min, max);
            int lenNumber = ran.Next(1, len - 2);
            int lenLetter = ran.Next(1, len - lenNumber - 1);
            int lenOther = len - lenNumber - lenLetter;
            for (int i = 0; i < lenNumber; i++)
            {
                list.Add(_number[ran.Next(0, _number.Length - 1)]);
            }
            for (int i = 0; i < lenLetter; i++)
            {
                list.Add(_letter[ran.Next(0, _letter.Length - 1)]);
            }
            for (int i = 0; i < lenOther; i++)
            {
                list.Add(other[ran.Next(0, other.Length - 1)]);
            }
            return new string(list.ToArray());
        }

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <param name="type">字母大小写方式</param>
        /// <param name="number">是否包含数字</param>
        /// <param name="len">密码数</param>
        /// <returns>生成的密码</returns>
        public static string Generate(EType type = EType.UpperLower, bool number = true, int len = 10)
        {
            return Generate(new char[] { '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' }, type, number, len, len);
        }

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <param name="len">密码数</param>
        /// <returns>生成的密码</returns>
        public static string Generate(int len = 10)
        {
            return Generate(EType.UpperLower, true, len);
        }
    }
}
