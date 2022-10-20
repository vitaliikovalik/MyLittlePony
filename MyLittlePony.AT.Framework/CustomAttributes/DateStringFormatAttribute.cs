using System;

namespace MyLittlePony.AT.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DateStringFormatAttribute : Attribute
    {
        public string DateStringFormat { get; set; }

        public DateStringFormatAttribute(string dateStringFormat)
        {
            DateStringFormat = dateStringFormat;
        }
    }
}
