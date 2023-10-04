

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
        /// <summary>
        /// Образец Фид Земля и Имущество
        /// </summary>
        public static string ZemlyOrImyShestvoFid = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                             "<FidFactZemlyOrImushestvo xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"FidZemlyOrImushestvo.xsd\">\n" +
                                             "     <Fid FidZemlyOrImushestvo=\"72428058864\"/>\n" +
                                             "     <Fid FidZemlyOrImushestvo=\"71470728214\"/>\n" +
                                             "</FidFactZemlyOrImushestvo>";
        /// <summary>
        /// Образец ФИД ЛИЦА
        /// </summary>
        public static string FaceFid = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                             "<Face xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"FaceFid.xsd\">\n" +
                                             "     <Fid FidFace=\"100031408033\"/>\n" +
                                             "     <Fid FidFace=\"100221670111\"/>\n" +
                                             "</Face>";
        /// <summary>
        /// Образец 14-Работа с лицами правообладателями (01,11)
        /// </summary>
        public static string VisualIdentId = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                             "<VisualIdent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"VisualId.xsd\">\n" +
                                             "     <IdZapros VisualId=\"98781525\"/>\n" +
                                             "     <IdZapros VisualId=\"98781577\"/>\n" +
                                             "</VisualIdent>";

        /// <summary>
        /// Результат списка для запуска Тех процесса!
        /// </summary>
        public static string TaxArrears = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                            "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                            "  <TaxArrears Inn=\"7751098112\" Kpp=\"775101001\"/>\n" +
                                            "  <TaxArrears Inn=\"7751098112\" Kpp=\"775101001\"/>\n" +
                                            "  <TaxArrears Inn=\"110500384499\"/>\n" +
                                            "</AutoGenerateSchemes>";
        /// <summary>
        /// Модель адреса для изменения индекса
        /// </summary>
        public static string RegAddressXml = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                             "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                             "  <AddressModel Fid=\"100069531676\" Inn=\"772578431375\" Address=\"108831, Российская Федерация, г Москва, г Щербинка, кв-л Южный, д. 2, кв. 42\" IndexOld=\"108852\" IndexNew=\"108831\"/>\n" +
                                             "  <AddressModel Fid=\"100058968097\" Inn=\"771701149808\" Address=\"108831, Российская Федерация, г Москва, г Щербинка, кв-л Южный, д. 2, кв. 12\" IndexOld=\"108852\" IndexNew=\"108831\"/>\n" +
                                             "  <AddressModel Fid=\"100152043770\" Inn=\"772583930186\" Address=\"108831, Российская Федерация, г Москва, г Щербинка, кв-л Южный, д. 2, кв. 42\" IndexOld=\"108852\" IndexNew=\"108831\"/>\n" +
                                             "</AutoGenerateSchemes>";

        /// <summary>
        /// Модель акта судебных решений
        /// </summary>
        public static string JudicialAct = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                           "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                           "  <JudicialAct Inn=\"772578431375\" NumberAkt=\"48\"/>\n" +
                                           "  <JudicialAct Inn=\"771701149808\" NumberAkt=\"51\"/>\n" +
                                           "  <JudicialAct Inn=\"772583930186\" NumberAkt=\"20\"/>\n" +
                                           "</AutoGenerateSchemes>";
        /// <summary>
        /// Модель на проведения технической корректировки
        /// </summary>
        public static string TechAdjustmentStatement = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                                       "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                                       "  <FaceStatement Inn=\"772578431375\" NumberStatement=\"48\" DateTimeStatement=\"2022-02-07T00:00:00\" />\n" +
                                                       "  <FaceStatement Inn=\"771701149808\" NumberStatement=\"51\" DateTimeStatement=\"2022-02-07T00:00:00\"/>\n" +
                                                       "  <FaceStatement Inn=\"772583930186\" NumberStatement=\"20\" DateTimeStatement=\"2022-01-16T00:00:00\"/>\n" +
                                                       "</AutoGenerateSchemes>";
        /// <summary>
        /// Модель на проведения уточнения платежа
        /// </summary>
        public static string IncomeJournal = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                             "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                             "  <IncomeJournal Number=\"1\" Inn=\"502499333103\" DateTimePayment=\"2022-10-01T00:00:00\" Summ=\"5900\" Ifns=\"Инспекция ФНС России по г. Красногорск\" InnMo=\"5024002119\" KppMo=\"502401001\" Oktmo=\"46744000\"  />\n" +
                                             "  <IncomeJournal Number=\"2\" Inn=\"504040838086\" DateTimePayment=\"2022-12-17T00:00:00\" Summ=\"16023\" Ifns=\"Межрайонная ИФНС России № 1 по Московской области (г. Раменское + г. Бронницы + г. Жуковский)\" InnMo=\"5040004804\" KppMo=\"502401001\" Oktmo=\"46768000\"/>\n" +
                                             "  <IncomeJournal Number=\"3\" Inn=\"771555920829\" DateTimePayment=\"2022-12-17T00:00:00\" Summ=\"5341\" Ifns=\"Инспекция ФНС России по г. Красногорск\" InnMo=\"5024002119\" KppMo=\"502401001\" Oktmo=\"46744000\"/>\n" +
                                             "</AutoGenerateSchemes>";
        /// <summary>
        /// Однозначная идентификация
        /// </summary>
        public static string IdentytiFace = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                             "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                             "  <IdentytiFace Id=\"1000976525738\" />\n" +
                                             "  <IdentytiFace Id=\"1000976525869\" />\n" +
                                             "  <IdentytiFace Id=\"1000976527727\" />\n" +
                                             "</AutoGenerateSchemes>";

        public static string InnFace = "<?xml version =\"1.0\"encoding=\"UTF-8\"?>\n" +
                                       "<AutoGenerateSchemes xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"AutoGenerateSchemes.xsd\">\n" +
                                       "  <InnFace Inn=\"230205491185\" />\n" +
                                       "  <InnFace Inn=\"550727971530\" />\n" +
                                       "  <InnFace Inn=\"507404107700\" />\n" +
                                       "</AutoGenerateSchemes>";
    }
}
