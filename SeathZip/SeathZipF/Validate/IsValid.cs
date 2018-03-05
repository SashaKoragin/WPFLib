using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace SeathZip.SeathZipF.Validate
{
    class IsValid
    {
        internal delegate object MyDelegate();

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

        public static bool IsSelectcom2(Control control)
        {
            object resul = null;
            resul = control.Dispatcher.Invoke(DispatcherPriority.Background, (MyDelegate)delegate
            {
                var bindingExpression = control.GetBindingExpression(Selector.SelectedItemProperty); //Чтобы рботало должны совпадать свойства с ValidateRule на что установленно в xamle ВАЖНО!!!!
                bindingExpression?.UpdateSource();
                return resul = !Validation.GetHasError(control);
            });
            return (bool)resul;
        }

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

    }
}
