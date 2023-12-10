using System.ComponentModel;

namespace PlayerControl.Application.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString()) ?? throw new ArgumentException("value cannot be null");
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;

            return value.ToString();
        }
    }
}
