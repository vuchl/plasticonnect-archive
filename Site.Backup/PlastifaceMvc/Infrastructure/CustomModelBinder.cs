using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace PlastifaceMvc
{
	/// <summary>
	/// Override for DefaultModelBinder in order to implement fixes to its behavior.
	/// </summary>
	public class CustomModelBinder : DefaultModelBinder
	{
		/// <summary>
		/// Fix for the default model binder's failure to decode enum types when binding to JSON.
		/// </summary>
		protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext,
			PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
		{
			throw new Exception("test");
			var propertyType = propertyDescriptor.PropertyType;
			if (propertyType.IsEnum)
			{
				var providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
				if (null != providerValue)
				{
					var value = providerValue.RawValue;
					if (null != value)
					{
						var valueType = value.GetType();
						if (!valueType.IsEnum)
						{
							return Enum.ToObject(propertyType, value);
						}
					}
				}
			}
			return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
		}

	}
	public class EnumModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			throw new Exception("test");
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState { Value = valueResult };
			object actualValue = null;

			try
			{
				return Enum.ToObject(Type.GetType(bindingContext.ModelType.AssemblyQualifiedName), Convert.ToInt32(valueResult.AttemptedValue));
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}

			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}
	}

	public class EnumConverterModelBinder : DefaultModelBinder
	{
		protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
		{
//			throw new Exception("test");
			var propertyType = propertyDescriptor.PropertyType;
			if (propertyType.IsEnum)
			{
				var providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
				if (null != providerValue)
				{
					var value = providerValue.RawValue;
					if (null != value)
					{
						var valueType = value.GetType();
						if (!valueType.IsEnum)
						{
							return Enum.ToObject(propertyType, value);
						}
					}
				}
			}
			return null; // base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
		}
	}


}