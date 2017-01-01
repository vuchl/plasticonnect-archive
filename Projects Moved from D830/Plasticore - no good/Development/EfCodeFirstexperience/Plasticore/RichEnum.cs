using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Plasticore
{
	/// <summary>
	/// Gives the appropriate functionality to work with special Regency enums. These enums act as a mapping to the old database as well
	/// as the regular enums. 
	/// </summary>
	public static class RichEnum
	{
		/// <summary>
		/// gets the description assigned to the enum item. 
		/// </summary>
		/// <param name="value">enum item</param>
		/// <returns>the assigned description to the item. returns item.ToString() if there is no description assigned</returns>
		public static string GetDescription(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());
			var attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
					typeof(DescriptionAttribute), false);
			return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
		}

		/// <summary>
		/// gets all available choices for a specific enum.
		/// </summary>
		/// <remarks>This is helpful when you want to have a list like a drop down, to display all the available choices</remarks>
		/// <typeparam name="T">enum type</typeparam>
		/// <returns>List of all available options</returns>
		public static List<T> GetAllOptions<T>()
		{
			Array values = Enum.GetValues(typeof(T));
			var options = new List<T>(values.Length);
			for (var i = 0; i < values.Length; i++)
			{
				var value = (T)values.GetValue(i);
				options.Add(value);
			}
			return options;
		}

		/// <summary>
		/// gets an item with a specific enum ID
		/// </summary>
		/// <typeparam name="T">enum item</typeparam>
		/// <param name="id">provided id</param>
		/// <returns>found item</returns>
		public static T GetById<T>(int id)
		{
			return (T)Enum.ToObject(typeof(T), id);
		}
	}
}
