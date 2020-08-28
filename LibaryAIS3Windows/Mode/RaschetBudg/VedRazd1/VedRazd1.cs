namespace LibraryAIS3Windows.Mode.RaschetBudg.VedRazd1
{
   public class VedRazd1
    {

        /// <summary>
        /// Расположение Кода БК при уточнении Ведомость 1
        /// </summary>
        internal static string[] Status =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:taddDecisionFormerPersonStatus]"
        };

        /// <summary>
        /// Нажатие вызвать окно выбора Налога
        /// </summary>
        internal static string[] SelectKbk =
        {
            "...",
            "[NAME:tabtnKBK]"
        };
        /// <summary>
        /// Нажатие вызвать окно выбора Налога
        /// </summary>
        internal static string[] WinNalog =
        {
            "Налог",
            "Всего строк:"
        };

        /// <summary>
        /// Выбор налога Кбк
        /// </summary>
        internal static string[] SelectKbkStart =
        {
            "Выбрать",
            "[NAME:_btnOk]"
        };
        /// <summary>
        /// Ближайший элемент от которого отталкиваемся
        /// </summary>
        internal static string[] Ifns =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtDecision_IFNS_Recipient]"
        };

        /// <summary>
        /// Выбор ТП
        /// </summary>
        internal static string[] SelectTp =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:taddDecisionTaxPaymentReason]"
        };

    }
}
