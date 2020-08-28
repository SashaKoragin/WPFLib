using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoIt;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;

namespace LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction
{
    public class PublicGlobalFunction
    {

        /// <summary>
        /// Поиск последнего файла в папке
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="searсhPattern">Pattern Search</param>
        /// <returns>Возврат последнего файла</returns>
        public static GetFile ReturnNameLastFileTemp(string path,string searсhPattern)
        {
            var listFile = new List<GetFile>();
            var pdf = Directory.GetFiles(path, searсhPattern);
            foreach (var patching in pdf)
            {
                listFile.Add(new GetFile
                {
                    DateWrite = Directory.GetLastWriteTime(patching),
                    NameFile = Path.GetFileName(patching),
                    NamePath = patching,
                    ExtensionsFile = Path.GetExtension(patching)
                });
            }
            var list = listFile.FirstOrDefault(file => file.DateWrite == listFile.Max(files => files.DateWrite));
            return list;
        }
        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public static void DeleteFile(string fileName)
        {
            File.Delete(fileName);
        }

        /// <summary>
        /// Закрытие процесса обработки файла
        /// </summary>
        /// <param name="name">Наименование процесса</param>
        public static void CloseProcessProgram(string name)
        {
            while (true)
            {
                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(name);
                foreach (var process in processes)
                {
                    process?.CloseMainWindow();
                }
                if(processes.Length == 0)
                {
                    break;
                }
            }
            AutoItX.Sleep(500);
        }
        /// <summary>
        /// Убить процесс обработки файла
        /// </summary>
        /// <param name="name">Наименование процесса</param>
        public static void KillProcessProgram(string name)
        {
            while (true)
            {
                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(name);
                foreach (var process in processes)
                {
                    process.WaitForExit(2000);
                    process?.Kill();
                    process.WaitForExit(4000);
                    process.Close();
                    process.Dispose();
                }
                if (processes.Length == 0)
                {
                    break;
                }
            }
            AutoItX.Sleep(500);
        }
        /// <summary>
        /// Поиск элемента и ожидания нажатия на элемент
        /// </summary>
        /// <param name="libraryAutomation">Элемент</param>
        /// <param name="searсhPatternElement">Pattern элемент</param>
        public static void WindowElementClick(LibraryAutomations libraryAutomation, string searсhPatternElement)
        {
            var isProcess = true;
            while (isProcess)
            {
                if (libraryAutomation.IsEnableElements(searсhPatternElement, null, true,1) != null)
                {
                    libraryAutomation.ClickElements(searсhPatternElement, null, true);
                    isProcess = false;
                }
            }
        }
        /// <summary>
        /// Ждать завершение кнопки Update на Аис 3 если нет данных выход из цикла
        /// </summary>
        /// <param name="libraryAutomation">Автоматизационный элемент</param>
        /// <param name="searсhPatternElementGrid">Grid для поиска Caption</param>
        public static string GridNotDataIsWaitUpdate(LibraryAutomations libraryAutomation, string searсhPatternElementGrid)
        {
           var isExit = true;
            while (isExit)
            {
                if (libraryAutomation.IsEnableElements(string.Concat(searсhPatternElementGrid, "\\Name:Caption"), null, false, 1,0,true) == null)
                {
                    isExit = false;
                }
                if(libraryAutomation.FindElement != null)
                {
                    if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindElement) == "Данные, удовлетворяющие заданным условиям не найдены.")
                    {

                        isExit = false;
                        return "Данные, удовлетворяющие заданным условиям не найдены.";
                    }
                    if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindElement) == "")
                    {
                        isExit = false;
                        return "";
                    }
                }
            }
            return null;
        }
    }

    public class GetFile
    {
        public string NameFile { get; set; }
        public string NamePath { get; set; }
        public DateTime DateWrite { get; set; }
        public string ExtensionsFile { get; set; }
    }
}
