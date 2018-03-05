using System;
using System.Globalization;
using System.Windows.Controls;

namespace SeathZip.SeathZipF.Validate
{
    public class Valid : ValidationRule

    {
        public string Names { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            switch (Names)
            {
                case "comboBox":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext);
                    else
                        return ValidationResult.ValidResult;
                case "comboBox1":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext);
                    else
                        return ValidationResult.ValidResult;
                case "textBox":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext1);
                    else
                        return ValidationResult.ValidResult;
                case "textBoxFull":
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
