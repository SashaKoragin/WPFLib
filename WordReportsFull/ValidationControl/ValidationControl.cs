using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace WordReportsFull.ValidationControl
{

   public class IsValidControl
    {
        internal delegate object MyDelegate();

        public static bool IsSeathZn(Control control)
        {
            object resul = null;
            resul = control.Dispatcher.Invoke(DispatcherPriority.Background, (MyDelegate)delegate
            {
                var bindingExpression = control.GetBindingExpression(TextBox.TextProperty);  //Чтобы рботало должны совпадать свойства с ValidateRule на что установленно в xamle ВАЖНО!!!!
                bindingExpression?.UpdateSource();
                return resul = !Validation.GetHasError(control);
            });
            return (bool)resul;
        }

        public static bool IsSelectcom1(Control control)
        {
            object resul = null;
            resul = control.Dispatcher.Invoke(DispatcherPriority.Background, (MyDelegate)delegate
            {
                var bindingExpression = control.GetBindingExpression(Selector.SelectedItemProperty);  //Чтобы рботало должны совпадать свойства с ValidateRule на что установленно в xamle ВАЖНО!!!!
                bindingExpression?.UpdateSource();
                return resul = !Validation.GetHasError(control);
            });
            return (bool)resul;
        }
    }

    public class ValidationControl : ValidationRule
    {
        public string Names { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            switch (Names)
            {
                case "TextBoxinn":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext1);
                    else
                        return ValidationResult.ValidResult;
                case "comboBox":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext);
                    else
                        return ValidationResult.ValidResult;
                case "TextBoxgod":
                    if (value == null || Equals(value, string.Empty))
                        return new ValidationResult(false, Err.Errtext1);
                    else
                        return ValidationResult.ValidResult;
                default:
                    throw new InvalidCastException();
            }
        }
    }

    public class Err
    {
        public static string Errtext = "Не выбран шаблон отчета!!!";
        public static string Errtext1 = "Не введен ИНН!!!";
    }
}
