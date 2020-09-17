using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            // check date format
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "dd MMM yyyy", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out dateTime);

            // check if date is in future
            return (isValid && dateTime > DateTime.Now);
        }
    }
}