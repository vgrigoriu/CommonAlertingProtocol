using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    [DebuggerDisplay("{DisplayName} - {Value}")]
    public class Enumeration<TEnumeration> : Enumeration<TEnumeration, int>
        where TEnumeration : Enumeration<TEnumeration>
    {
        protected Enumeration(int value, string displayName)
            : base(value, displayName)
        {
        }

        public static TEnumeration FromInt32(int value)
        {
            return FromValue(value);
        }

        public static bool TryFromInt32(int listItemValue, out TEnumeration result)
        {
            return TryParse(listItemValue, out result);
        }
    }

    [DebuggerDisplay("{DisplayName} - {Value}")]
#pragma warning disable SA1402 // File may only contain a single class
    public class Enumeration<TEnumeration, TValue> : IComparable<TEnumeration>, IEquatable<TEnumeration>
#pragma warning restore SA1402 // File may only contain a single class
        where TEnumeration : Enumeration<TEnumeration, TValue>
        where TValue : IComparable
    {
#pragma warning disable RECS0108 // Warns about static fields in generic types
        private static Lazy<TEnumeration[]> enumerations = new Lazy<TEnumeration[]>(GetEnumerations);
#pragma warning restore RECS0108 // Warns about static fields in generic types

        private readonly string displayName;
        private readonly TValue value;

        protected Enumeration(TValue value, string displayName)
        {
            this.value = value;
            this.displayName = displayName;
        }

        public TValue Value
        {
            get { return value; }
        }

        public string DisplayName
        {
            get { return displayName; }
        }

        public static bool operator ==(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
        {
            return !Equals(left, right);
        }

        public static TEnumeration[] GetAll()
        {
            return enumerations.Value;
        }

        public static TEnumeration FromValue(TValue value)
        {
            return Parse(value, "value", item => item.Value.Equals(value));
        }

        public static TEnumeration Parse(string displayName)
        {
            return Parse(displayName, "display name", item => item.DisplayName == displayName);
        }

        public static bool TryParse(TValue value, out TEnumeration result)
        {
            return TryParse(e => e.Value.Equals(value), out result);
        }

        public static bool TryParse(string displayName, out TEnumeration result)
        {
            return TryParse(e => e.DisplayName == displayName, out result);
        }

        public int CompareTo(TEnumeration other)
        {
            return Value.CompareTo(other.Value);
        }

        public override sealed string ToString()
        {
            return DisplayName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TEnumeration);
        }

        public bool Equals(TEnumeration other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        private static TEnumeration[] GetEnumerations()
        {
            var enumerationType = typeof(TEnumeration).GetTypeInfo();
            return enumerationType
                .DeclaredFields
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType.GetTypeInfo()))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToArray();
        }

        private static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration result)
        {
            result = GetAll().FirstOrDefault(predicate);
            return result != null;
        }

        private static TEnumeration Parse(object value, string description, Func<TEnumeration, bool> predicate)
        {
            TEnumeration result;

            if (!TryParse(predicate, out result))
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(TEnumeration));
                throw new ArgumentException(message, nameof(value));
            }

            return result;
        }
    }
}
