﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;

namespace LibaryAIS3Windows.ButtonFullFunction.PublicGlobalFunction
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
            AutoIt.AutoItX.Sleep(500);
        }
        /// <summary>
        /// Поиск элемента и ожидания нажатия на элемент
        /// </summary>
        /// <param name="libraryAutomation">Элемент</param>
        /// <param name="searсhPatternElement">Pattern элемент</param>
        public static void WindowElementClick(LibaryAutomations libraryAutomation, string searсhPatternElement)
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
    }

    public class GetFile
    {
        public string NameFile { get; set; }
        public string NamePath { get; set; }
        public DateTime DateWrite { get; set; }
        public string ExtensionsFile { get; set; }
    }
}
