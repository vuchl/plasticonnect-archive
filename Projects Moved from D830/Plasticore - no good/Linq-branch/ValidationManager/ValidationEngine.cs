using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationManager
{
	/// <summary>
	/// The derived of this class follow this rule:
	///		When Validation() is called, all related validation rules has to be invoked
	/// </summary>
	public abstract class ValidatorEngine
	{
		/// <summary>
		/// Validates the provided objects by running all the validation rule methods
		/// </summary>
		/// <param name="toBeValidate">the object instance that to be validate</param>
		/// <param name="statistics">if not null, returns the statistics of the validation process in the list</param>
		/// <returns>true only if all the validations get passed</returns>
		public static bool Validate(object toBeValidate, List<ValidationResult> statistics = null)
		{
			return Validate(toBeValidate, null, statistics);
		}

		/// <summary>
		/// Validates the provided objects by running all the validation rule methods
		/// </summary>
		/// <param name="toBeValidate">the object instance that to be validate</param>
		/// <param name="groupToBeValidate">certain group to be validated. Only validation rules that tagged as this group will be run</param>
		/// <param name="statistics">if not null, returns the statistics of the validation process in the list</param>
		/// <returns>true only if all the validations get passed</returns>
		public static bool Validate(object toBeValidate, string groupToBeValidate, List<ValidationResult> statistics = null)
		{

			var ret = true;

			var type = toBeValidate.GetType();

			foreach (var methodInfo in type.GetMethods())
			{
				var validatorMethod = IsValidator(methodInfo);
				if (validatorMethod != null)
				{
					if(methodInfo.ReturnType != typeof(bool))
						throw new ArgumentException(string.Format("The return value of a Validator method should be bool.\n Method: {1}::{0}( )", methodInfo.Name, type.Name));

					if(methodInfo.GetParameters().Length!=0)
						throw new ArgumentException(string.Format("A Validator method cannot have parameters.\n Method: {1}::{0}(...)", methodInfo.Name, type.Name));

					if (groupToBeValidate==null || validatorMethod.GroupList.Contains(groupToBeValidate))
					{
						var isValid = (bool) methodInfo.Invoke(toBeValidate, null);

						if (statistics != null)
							statistics.Add(new ValidationResult
							          	{
											Status = isValid,
							          		Severity = validatorMethod.Severity,
							          		Message = validatorMethod.Message,
							          		Technical = string.Format("method: {1}::{0}( )", methodInfo.Name, type.Name)
							          	});

						ret &= isValid;
					}
				}
			}

			return ret;
		}

		private static ValidationRuleAttribute IsValidator(MethodInfo methodInfo)
		{
			return
				(ValidationRuleAttribute) Attribute.GetCustomAttributes(methodInfo).FirstOrDefault(
					attribute => attribute.GetType() == typeof (ValidationRuleAttribute));
		}
	}
}
