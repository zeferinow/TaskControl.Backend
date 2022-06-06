using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Models
{
    public class DateOnly : IConvertible
    {
        public static implicit operator DateTime?(DateOnly value)
        {
            return value?.value;
        }

        public static implicit operator DateTime(DateOnly value)
        {
            return value?.value ?? DateTime.MinValue;
        }

        private DateTime value;

        public DateTime Value
        {
            get => value.Date;
            set => this.value = value;
        }

        public TypeCode GetTypeCode() => TypeCode.DateTime;
        public DateTime ToDateTime(IFormatProvider provider) => Value;
        public string ToString(IFormatProvider provider) => Value.ToString(provider);

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(DateTime) ||
                conversionType == typeof(DateTime?))
            {
                return Value;
            }

            throw new NotSupportedException();
        }

        public bool ToBoolean(IFormatProvider provider) => throw new NotSupportedException();
        public byte ToByte(IFormatProvider provider) => throw new NotSupportedException();
        public char ToChar(IFormatProvider provider) => throw new NotSupportedException();
        public decimal ToDecimal(IFormatProvider provider) => throw new NotSupportedException();
        public double ToDouble(IFormatProvider provider) => throw new NotSupportedException();
        public short ToInt16(IFormatProvider provider) => throw new NotSupportedException();
        public int ToInt32(IFormatProvider provider) => throw new NotSupportedException();
        public long ToInt64(IFormatProvider provider) => throw new NotSupportedException();
        public sbyte ToSByte(IFormatProvider provider) => throw new NotSupportedException();
        public float ToSingle(IFormatProvider provider) => throw new NotSupportedException();
        public ushort ToUInt16(IFormatProvider provider) => throw new NotSupportedException();
        public uint ToUInt32(IFormatProvider provider) => throw new NotSupportedException();
        public ulong ToUInt64(IFormatProvider provider) => throw new NotSupportedException();
    }
}

