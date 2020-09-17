using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            // check date format
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "HH:mm", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out dateTime);

            // check if date is in future
            return (isValid);
        }
    }
}