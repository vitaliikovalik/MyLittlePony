using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using AT.Framework.CustomAttributes;

namespace AT.Framework.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }


        /// <summary>
        /// Get value of Custom Attribute DateStringFormatAttribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value of DateStringFormatAttribute</returns>
        public static string GetDateStringFormat(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            FieldInfo field = value.GetType().GetField(value.ToString());

            DateStringFormatAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(DateStringFormatAttribute))
                    as DateStringFormatAttribute;

            return attribute == null ? value.ToString() : attribute.DateStringFormat;
        }

        /// <summary>
        /// Convert string to enum, based on 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static TEnum GetValueFromDescription<TEnum>(this string description) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new InvalidConstraintException($"Generic method was called with not supportable type: {typeof(TEnum)}. Expected Enum.");

            foreach (var field in typeof(TEnum).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (TEnum)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (TEnum)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }
    }
}
