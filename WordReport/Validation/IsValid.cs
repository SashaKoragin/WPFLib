using System.Windows.Controls;
using System.Windows.Threading;

namespace WordReport.Validation
{
    class IsValid
    {
        internal delegate object MyDelegate();

        public static bool IsSeathZn(Control control)
        {
            object resul = null;
            resul = control.Dispatcher.Invoke(DispatcherPriority.Background, (MyDelegate)delegate
            {
                var bindingExpression = control.GetBindingExpression(TextBox.TextProperty);  //Чтобы рботало должны совпадать свойства с ValidateRule на что установленно в xamle ВАЖНО!!!!
                bindingExpression?.UpdateSource();
                return resul = !System.Windows.Controls.Validation.GetHasError(control);
            });
            return (bool)resul;
        }

    }
}
