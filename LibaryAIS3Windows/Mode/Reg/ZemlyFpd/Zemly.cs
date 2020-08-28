namespace LibraryAIS3Windows.Mode.Reg.ZemlyFpd
{
    /// <summary>
    /// Элементы в ветки Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов
    /// </summary>
    public class Zemly
    {
        /// <summary>
        /// Расположение Фида в форме
        /// </summary>
        internal static string[] FidText =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtC]"
        };

        /// <summary>
        /// ФИО
        /// </summary>
        internal static string[] FioUser =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtNAME]"
        };

        /// <summary>
        /// Раскрывающийся список ЦУН
        /// </summary>
        internal static string[] SpisokCun =
        {
            "Поиск лица по заданным параметрам в Витрине лиц ЦУН",
            "[NAME:ultraExpandableGroupBox6]"
        };
    }
}
