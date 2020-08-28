namespace LibraryAIS3Windows.ButtonsClikcs.ClikcCheker
{
    /// <summary>
    /// Класс для проставления галочек мышкой
    /// </summary>
   public class Cheker
    {
        /// <summary>
        /// Проставление галочки в дочернем диалоговом окне 
        /// Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ
        /// </summary>
        public static void Chekerfid()
        {
            var win = new Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie();
            AutoIt.AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WinVisualIdentification.X + win.WindowsIdentification.X + 670, win.WinVisualIdentification.Y +win.WindowsIdentification.Y+ 65, 1);
        }
    }
}
