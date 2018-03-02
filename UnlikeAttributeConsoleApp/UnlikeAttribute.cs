using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace UnlikeAttributeConsoleApp
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class UnlikeAttribute : ValidationAttribute
    {
        private string otherPropertyName;
        private string otherPropertyDisplay;
        private const string DefaultErrorMessage = "{0} must be different than {1}";
        public UnlikeAttribute(string otherProperty) : base(DefaultErrorMessage)
        {
            otherPropertyName = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, otherPropertyDisplay);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherProperty = validationContext.ObjectInstance
                .GetType()
                .GetProperty(otherPropertyName);
            
            // in case no property where found 
            if (otherProperty == null)
                throw new IndexOutOfRangeException($"{otherPropertyName} does not exist");
            
            // getting the value of the other property
            var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance);

            // if they are different, then the case is successful
            if (!Equals(value, otherPropertyValue)) return ValidationResult.Success;

            // checks if DisplayAttribute has been used
            if (!IsDefined(otherProperty, typeof(DisplayAttribute)))
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));

            // gets the DisplayAttribute.Name
            var displayAttribute = 
                (DisplayAttribute)otherProperty.GetCustomAttribute(typeof(DisplayAttribute));

            // checks if Resource is bound 
            if (displayAttribute.ResourceType != null)
            {
                var manager = new ResourceManager(displayAttribute.ResourceType);
                otherPropertyDisplay = manager.GetString(otherPropertyName);
                return new ValidationResult(
                    FormatErrorMessage(manager.GetString(validationContext.MemberName)));
            }
            
            return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
        }
    }
}
