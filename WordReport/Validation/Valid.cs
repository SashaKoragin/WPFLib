using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WordReport.Validation
{
    class Valid : ValidationRule
    {

        public string Names { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            switch (Names)
            {
                case "TextBox":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext1);
                    else
                        return ValidationResult.ValidResult;
                default:
                    throw new InvalidCastException();
            }
        }
    }
}
