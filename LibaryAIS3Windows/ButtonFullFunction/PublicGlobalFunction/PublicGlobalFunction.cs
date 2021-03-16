using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Automation;
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
        public static GetFile ReturnNameLastFileTemp(string path, string searсhPattern)
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
        /// Определяет блокировку файла
        /// </summary>
        /// <param name="file">Файл</param>
        /// <returns></returns>
        public static bool IsFileLocked(GetFile file)
        {
            try
            {
                using (FileStream stream = new FileInfo(file.NamePath).Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                    return false;
                }
            }
            catch
            {
                return true;
            }
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
                if (processes.Length == 0)
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
        /// Дожидаемся и сохраняем XLSX 2010 и закрываем
        /// </summary>
        public static void ExcelSaveAndClose()
        {
            AutoItX.ProcessWait("EXCEL.EXE", 60000);
            var processExcel = FindIntPtr("[CLASS:XLMAIN]");
            LibraryAutomations libraryAutomationXlsx = new LibraryAutomations(processExcel);
            try
            {
                var save = "ClassName:MsoCommandBar\\ClassName:MsoWorkPane\\ClassName:NUIPane\\ClassName:NetUIHWNDElement\\ClassName:NetUInetpane\\ClassName:NetUIElement\\Name:Сохранить";
                var closeLicense = "ClassName:NetUIHWNDElement\\ClassName:NetUINetUIDialog\\Name:Закрыть";
                while (true)
                {
                    var allClass = libraryAutomationXlsx.SelectAutomationColrction(libraryAutomationXlsx.RootAutomationElements);
                    if (libraryAutomationXlsx.IsEnableElements(save, allClass[1]) != null)
                    {
                        AutoItX.Send("^s");
                        AutoItX.Sleep(2000);
                        break;
                    }
                    if (libraryAutomationXlsx.IsEnableElements(closeLicense, allClass[0]) != null)
                    {
                        libraryAutomationXlsx.InvokePattern(libraryAutomationXlsx.FindElement);
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                AutoItX.Send("^s");
                libraryAutomationXlsx.Dispose();
                CloseProcessProgram("EXCEL");
            }
        }

        /// <summary>
        /// Поиск элемента и ожидания нажатия на элемент
        /// </summary>
        /// <param name="libraryAutomation">Элемент</param>
        /// <param name="searсhPatternElement">Pattern элемент</param>
        public static void WindowElementClick(LibraryAutomations libraryAutomation, string searсhPatternElement, AutomationElement auto = null)
        {
            var isProcess = true;
            while (isProcess)
            {
                if (libraryAutomation.IsEnableElements(searсhPatternElement, auto, true, 1) != null)
                {
                    libraryAutomation.ClickElements(searсhPatternElement, auto, true);
                    isProcess = false;
                }
            }
        }
        /// <summary>
        /// Ждать завершение кнопки Update на Аис 3 если нет данных выход из цикла
        /// </summary>
        /// <param name="libraryAutomation">Автоматизационный элемент</param>
        /// <param name="searсhPatternElementGrid">Grid для поиска Caption</param>
        public static string GridNotDataIsWaitUpdate(LibraryAutomations libraryAutomation, string searсhPatternElementGrid, AutomationElement auto = null)
        {
            var isExit = true;
            while (isExit)
            {
                if (libraryAutomation.IsEnableElements(string.Concat(searсhPatternElementGrid, "\\Name:Caption"), auto, false, 1, 0, true) == null)
                {
                    isExit = false;
                }
                if (libraryAutomation.FindElement != null)
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
        private static IntPtr FindIntPtr(string nameClass)
        {
            bool IsExists = false;
            IntPtr processExcel = IntPtr.Zero;
            while (!IsExists){
                AutoItX.WinActivate(nameClass);
                AutoItX.WinWaitActive(nameClass);
                processExcel = AutoItX.WinGetHandle(nameClass);
                if (processExcel != IntPtr.Zero)
                {
                    IsExists = true;
                }
            }
            return processExcel;
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
