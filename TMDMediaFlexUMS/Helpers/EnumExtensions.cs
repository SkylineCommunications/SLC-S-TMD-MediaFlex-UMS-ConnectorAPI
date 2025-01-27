namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Helpers
{
	using System;
	using System.ComponentModel;
	using System.Linq;

    /// <summary>
    /// An extension class for Enum.
    /// </summary>
	public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description attribute value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute is null
                ? value.ToString()
                : attribute.Description;
        }

        /// <summary>
        /// Gets the enum value by looking at Descripion attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T GetValueFromDescription<T>(string description, Ignore ignore = Ignore.None) where T : Enum
        {
            string cleanDescription = description.Clean(ignore);
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    string cleanAttributeDescription = attribute.Description.Clean(ignore);
                    if (String.Equals(cleanDescription, cleanAttributeDescription))
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (String.Equals(field.Name.Clean(ignore), cleanDescription))
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }

        /// <summary>
        /// Tries to get the enum value by looking at the description attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <param name="value"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        public static bool TryGetEnumValueFromDescription<T>(string description, out T value, Ignore ignore = Ignore.None) where T : Enum
        {
            try
            {
                value = GetValueFromDescription<T>(description, ignore);
                return true;
            }
            catch (Exception)
            {
                value = default;
                return false;
            }
        }

        private static string Clean(this string input, Ignore ignore)
        {
            string output = input;
            if (ignore.HasFlag(Ignore.Underscores))
            {
                output = output.Replace("_", String.Empty);
            }

            if (ignore.HasFlag(Ignore.WhiteSpaces))
            {
                output = output.Replace(" ", String.Empty);
            }

            if (ignore.HasFlag(Ignore.Casing))
            {
                output = output.ToUpper();
            }

            return output;
        }
	}

	/// <summary>
	/// Ignore flags enum.
	/// </summary>
	[Flags]
	public enum Ignore
	{
		/// <summary>
		/// None
		/// </summary>
		None = 0,

		/// <summary>
		/// Underscores
		/// </summary>
		Underscores = 1,

		/// <summary>
		/// Whitespaces
		/// </summary>
		WhiteSpaces = 2,

		/// <summary>
		/// Casing
		/// </summary>
		Casing = 4
	}
}
