using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct30
{
    public class MyString
    {
        private char[] value;
        private int length;

        public MyString()
        {
            value = new char[0];
            length = 0;
        }

        public MyString(char[] value)
        {
            this.value = value;
            length = value.Length;
        }

        public MyString(MyString original)
        {
            value = original.value;
            length = original.length;
        }

        public int Length()
        {
            return length;
        }

        public char CharAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeStringException();
            }
            return value[index];
        }

        public MyString Substring(int beginIndex, int endIndex)
        {
            if (beginIndex > endIndex || beginIndex < 0 || endIndex >= length)
            {
                throw new IndexOutOfRangeStringException();
            }
            int newLength = endIndex - beginIndex + 1;
            char[] newValue = new char[newLength];
            for (int i = beginIndex; i <= endIndex; ++i)
            {
                newValue[i] = value[i];
            }
            return new MyString(newValue);
        }

        public void Concat(MyString str)
        {
            int newLength = length + str.length;
            char[] newValue = new char[length + str.length];
            for (int i = 0; i < length; ++i)
            {
                newValue[i] = value[i];
            }
            for (int i = 0; i < str.length; ++i)
            {
                newValue[length + i] = str.value[i];
            }
            length = newLength;
            value = newValue;
        }

        public bool Equals(MyString str)
        {
            if (length == str.length)
            {
                for (int i = 0; i < length; ++i)
                {
                    if (value[i] != str.value[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool EqualsIgnoreCase(MyString str)
        {
            if (length == str.length)
            {
                for (int i = 0; i < length; ++i)
                {
                    if (char.ToLower(value[i]) != char.ToLower(str.value[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void ToLowerCase()
        {
            for (int i = 0; i < length; ++i)
            {
                value[i] = char.ToLower(value[i]);
            }
        }

        public void ToUpperCase()
        {
            for (int i = 0; i < length; ++i)
            {
                value[i] = char.ToUpper(value[i]);
            }
        }

        public void Trim()
        {
            while (length != 0)
            {
                if (value[0] == ' ')
                {
                    char[] newValue = new char[length - 1];
                    for (int i = 1; i < length; ++i)
                    {
                        newValue[i - 1] = value[i];
                    }
                    --length;
                    value = newValue;
                    continue;
                }
                if (value[length - 1] == ' ')
                {
                    char[] newValue = new char[length - 1];
                    for (int i = 0; i < length - 1; ++i)
                    {
                        newValue[i] = value[i];
                    }
                    --length;
                    value = newValue;
                    continue;
                }
                break;
            }
        }

        public void Replace(char oldChar, char newChar)
        {
            for (int i = 0; i < length; ++i)
            {
                if (value[i] == oldChar)
                {
                    value[i] = newChar;
                }
            }
        }

        private int[] ZFunction(MyString str)
        {
            int[] zf = new int[str.length];
            for (int i = 1; i < str.length; ++i)
            {
                while (i + zf[i] < str.length && str.value[zf[i]] == str.value[i + zf[i]])
                {
                    ++zf[i];
                }
            }
            return zf;
        }

        public bool Contains(MyString substr)
        {
            char[] str = new char[substr.length + 1 + length];
            for (int i = 0; i < substr.length; ++i)
            {
                str[i] = substr.value[i];
            }
            str[substr.length] = '#';
            for (int i = 0; i < length; ++i)
            {
                str[substr.length + 1 + i] = value[i];
            }
            int[] zf = ZFunction(new MyString(str));
            for (int i = 0; i < length; ++i)
            {
                if (zf[substr.length + 1 + i] == substr.length)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(MyString substr)
        {
            char[] str = new char[substr.length + 1 + length];
            for (int i = 0; i < substr.length; ++i)
            {
                str[i] = substr.value[i];
            }
            str[substr.length] = '#';
            for (int i = 0; i < length; ++i)
            {
                str[substr.length + 1 + i] = value[i];
            }
            int[] zf = ZFunction(new MyString(str));
            for (int i = 0; i < length; ++i)
            {
                if (zf[substr.length + 1 + i] == substr.length)
                {
                    return i;
                }
            }
            return -1;
        }

        public MyString[] Split(char delimiter)
        {
            int splitLength = 1;
            for (int i = 0; i < length; ++i)
            {
                if (value[i] == delimiter)
                {
                    ++splitLength;
                }
            }
            char[][] splitStrs = new char[splitLength][];
            int[] splitMarks = new int[splitLength - 1];
            for (int i = 0, j = 0; i < length; ++i)
            {
                if (value[i] == delimiter)
                {
                    splitMarks[j] = i;
                    ++j;
                }
            }
            int currMark = -1;
            char[] str;
            for (int i = 0; i < splitLength - 1; ++i)
            {
                str = new char[splitMarks[i] - currMark - 1];
                for (int j = 0; j < splitMarks[i] - currMark - 1; ++j)
                {
                    str[j] = value[currMark + 1 + j];
                }
                currMark = splitMarks[i];
                splitStrs[i] = str;
            }
            str = new char[length - currMark - 1];
            for (int j = 0; j < length - currMark - 1; ++j)
            {
                str[j] = value[currMark + 1 + j];
            }
            splitStrs[splitLength - 1] = str;
            MyString[] split = new MyString[splitLength];
            for (int i = 0; i < splitLength; ++i)
            {
                split[i] = new MyString(splitStrs[i]);
            }
            return split;
        }

        public bool StartsWith(MyString prefix)
        {
            if (prefix.length <= length)
            {
                for (int i = 0; i < prefix.length; ++i)
                {
                    if (prefix.value[i] != value[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool EndsWith(MyString suffix)
        {
            if (suffix.length <= length)
            {
                for (int i = 0; i < suffix.length; ++i)
                {
                    if (suffix.value[suffix.length - i - 1] != value[length - i - 1])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public MyString Reverse()
        {
            char[] newValue = new char[length];
            for (int i = 0; i < length; ++i)
            {
                newValue[i] = value[length - i - 1];
            }
            return new MyString(newValue);
        }

        public MyString ValueOf(int i)
        {
            int tmp = i, dig = 1, flag = 1;
            while (tmp > 9 || tmp < -9)
            {
                ++dig;
                tmp /= 10;
            }
            char[] newValue = new char[dig];
            tmp = i;
            if (tmp < 0)
            {
                newValue = new char[dig + 1];
                newValue[0] = '-';
                tmp *= -1;
                flag = 0;
            }
            for (int j = 0; j < dig; ++j)
            {
                newValue[dig - j - flag] = (char)(tmp % 10 + '0');
                tmp /= 10;
            }
            return new MyString(newValue);
        }

        public MyString ValueOf(double d)
        {
            int intPart = (int)d;
            double floatPart = Math.Abs(d - Math.Truncate(d));
            int tmpInt = intPart, digInt = 1, flagInt = 1;
            while (tmpInt > 9 || tmpInt < -9)
            {
                ++digInt;
                tmpInt /= 10;
            }
            char[] intValue = new char[digInt];
            tmpInt = intPart;
            if (tmpInt < 0)
            {
                intValue = new char[digInt + 1];
                intValue[0] = '-';
                tmpInt *= -1;
                flagInt = 0;
            }
            for (int j = 0; j < digInt; ++j)
            {
                intValue[digInt - j - flagInt] = (char)(tmpInt % 10 + '0');
                tmpInt /= 10;
            }
            if (floatPart == 0)
            {
                return new MyString(intValue);
            }
            int digPoint = 1;
            while (floatPart < 0.1)
            {
                ++digPoint;
                floatPart *= 10;
            }
            char[] pointValue = new char[digPoint];
            pointValue[0] = '.';
            if (digPoint > 1)
            {
                for (int i = 1; i < digPoint; ++i)
                {
                    pointValue[i] = '0';
                }
            }
            double tmpDouble = floatPart; int digDouble = 0, flagDouble = 1, mult = 1;
            while (tmpDouble * mult != (int)(tmpDouble * mult))
            {
                ++digDouble;
                mult *= 10;
            }
            tmpDouble *= mult;
            char[] doubleValue = new char[digDouble];
            tmpInt = (int)tmpDouble;
            if (tmpInt < 0)
            {
                doubleValue = new char[digDouble + 1];
                doubleValue[0] = '-';
                tmpInt *= -1;
                flagDouble = 0;
            }
            for (int j = 0; j < digDouble; ++j)
            {
                doubleValue[digDouble - j - flagDouble] = (char)(tmpInt % 10 + '0');
                tmpInt /= 10;
            }
            char[] newValue = new char[intValue.Length + digPoint + digDouble];
            for (int i = 0; i < intValue.Length; ++i)
            {
                newValue[i] = intValue[i];
            }
            for (int i = 0; i < digPoint; ++i)
            {
                newValue[intValue.Length + i] = pointValue[i];
            }
            for (int i = 0; i < digDouble; ++i)
            {
                newValue[intValue.Length + digPoint + i] = doubleValue[i];
            }
            return new MyString(newValue);
        }

        public MyString ValueOf(bool b)
        {
            if (b)
            {
                return new MyString(new char[] {'t', 'r', 'u', 'e'});
            }
            return new MyString(new char[] { 'f', 'a', 'l', 's', 'e' });
        }
    }
}
