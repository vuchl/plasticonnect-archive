using System;

namespace ValidationManager
{
	/// <summary>
	/// Applies to a validation rule method. The method should have the signature of bool MethodName();
	/// </summary>
	public class ValidationRuleAttribute : Attribute
	{
		/// <summary>
		/// Set the method as a validation rule
		/// </summary>
		/// <param name="groupList">comma separated list of group</param>
		/// <param name="message">validation message</param>
		/// <param name="severity">severity of the rule</param>
		public ValidationRuleAttribute(string groupList, string message, Severity severity = Severity.Critical)
		{
			GroupList = groupList.Split(',');
			Message = message;
			Severity = severity;
		}

		internal string[] GroupList { get; private set; }
		internal string Message { get; private set; }
		internal Severity Severity { get; private set; }
	}
}