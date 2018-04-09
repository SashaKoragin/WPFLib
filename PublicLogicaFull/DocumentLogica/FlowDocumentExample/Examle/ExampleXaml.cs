

namespace PublicLogicaFull.DocumentLogica.FlowDocumentExample.Examle
{
    /// <summary>
    /// Класс для образцов
    /// </summary>
   public class ExampleXaml
    {
        /// <summary>
        /// Образец с ИНН xml
        /// </summary>
        public static string SnuOneForm = "<?xml version=\"1.0\"?>\n" +
                                 "<SnuOneForm xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"SnuOneForm.xsd\">\n" +
                                 "     <INN INN=\"504602844980\"/>\n" +
                                 "     <INN INN =\"773112462764\"/>\n" +
                                 "</SnuOneForm>";

        /// <summary>
        /// Образец ФПД для регистрации
        /// </summary>
        public static string TreatmentFpd = "<?xml version=\"1.0\"?>\n" +
                                            "<TreatmentFPD xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"FpdReg.xsd\">\n" +
                                            "	  <Fpd FpdId=\"212206294\"/>\n" +
                                            "     <Fpd FpdId=\"82990935\"/>\n" +
                                            "     <Fpd FpdId=\"82990935\"/>\n" +
                                            "</ TreatmentFPD >";
        /// <summary>
        /// Образец массовой обработки ИНН
        /// </summary>
        public static string CollectionInn = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                             "<INNList xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"FullInnCount.xsd\">\n" + 
                                             "  <ListInn NumColection = \"1\" CountInn=\"4\">\n" +
                                             "     <MyInnn>d500306578530/503009784020/504601612560/772904428090</MyInnn>\n" +
                                             "  </ListInn>\n" +
                                             "  <ListInn NumColection = \"2\" CountInn=\"2\">\n" +
	                                         "     <MyInnn>500303703461/775101147891</MyInnn>\n" +
                                             "  </ListInn>" +
                                             "  <ListInn NumColection = \"3\" CountInn=\"3\">\n" +
                                             "     <MyInnn >500303703461/775101147891/772809074772</MyInnn>\n" +
                                             "  </ListInn>" +
                                             "</INNList>";
    }
}
