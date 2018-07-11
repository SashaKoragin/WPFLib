using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyteIfns.Adress
{
    /// <summary>
    /// Адреса удаленного сервера для пост запроса главное что бы служба
    /// была запущена от имени regions\7751_svc_admin
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Тестовый адрес
        /// </summary>
        public static string AdressTest = @"http://localhost:8181/ServiceRest/Test";

        /// <summary>
        /// Тестовый адрес 1
        /// </summary>
        public static string AdressTest1 = @"http://localhost:8181/ServiceRest/Test1";

        /// <summary>
        /// Ошибки во время слияния i7751-w00000745 localhost
        /// </summary>
        public static string AddresError = @"http://localhost:8181/ServiceRest/SqlFaceError";

        /// <summary>
        /// Добавление лица на слияние
        /// </summary>
        public static string AddresFaceAdd = @"http://localhost:8181/ServiceRest/SqlFaceAdd";
    }
}