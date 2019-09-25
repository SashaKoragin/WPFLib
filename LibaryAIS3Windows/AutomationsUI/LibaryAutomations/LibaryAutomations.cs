using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using AutoIt;
using LibaryAIS3Windows.Window;

namespace LibaryAIS3Windows.AutomationsUI.LibaryAutomations
{
   public class LibaryAutomations
    {
        public int ProcessId { get; set; }
        public AutomationElement RootAutomationElements { get; set; }

        public AutomationElement FindElement { get; set; }

        private Condition Conditions { get; set; }
        /// <summary>
        /// Подключение к процессу
        /// </summary>
        /// <param name="nameWindowsAis3"></param>
        public LibaryAutomations(string nameWindowsAis3)
        {
            RootAutomationElements = AutomationElement.FromHandle(AutoItX.WinGetHandle(nameWindowsAis3));
            ProcessId = RootAutomationElements.Current.ProcessId;
        }
        /// <summary>
        /// Поиск элемента по полю
        /// </summary>
        /// <param name="nameAutomationId"></param>
        /// <param name="auto">Поиск по циклу по формуле если нет в корневом элементе то ищем потомка</param>
        /// <returns></returns>
        public void FindFirstElement(string nameAutomationId, AutomationElement auto = null)
        {
            var recursion = nameAutomationId.Split('\\');
            foreach (var str in recursion)
            {
                Conditions = AddCondition(str);
                if (auto == null)
                {
                    FindElement = RootAutomationElements.FindFirst(TreeScope.Children, Conditions);
                    auto = FindElement;
                }
                else
                {
                    FindElement = FindElement.FindFirst(TreeScope.Children, Conditions) ??
                                  FindElement.FindFirst(TreeScope.Subtree, Conditions);
                }
            }
        }
        /// <summary>
        /// Поиск всех дочерних элементов у ветке
        /// </summary>
        /// <param name="parent">Элемент</param>
        /// <returns></returns>
        public List<AutomationElement> GetChildren(AutomationElement parent)
        {
            if (parent == null)
            {
                throw new ArgumentException();
            }
            List<AutomationElement> result = new List<AutomationElement>();
            TreeWalker tw = TreeWalker.ControlViewWalker;
            AutomationElement child = tw.GetLastChild(parent);
            while (child != null)
            {
                result.Add(child);
                child = tw.GetNextSibling(child);
            }
            return result;
        }


        /// <summary>
        /// Поставить фокус на элемент
        /// </summary>
        public void InvekePattern(AutomationElement element)
        {
            var pattrn = element.GetCurrentPattern(InvokePatternIdentifiers.Pattern); //  pattern.(pattern.);
            var valueauto = (InvokePattern)pattrn;
            valueauto.Invoke();
        }
        /// <summary>
        /// Проставить значение в найденный элемент
        /// </summary>
        public void SetValuePattern(string value)
        {
            var pattrn = FindElement.GetCurrentPattern(ValuePatternIdentifiers.Pattern);
            var valueauto = (ValuePattern)pattrn;
            valueauto.SetValue(value);
        }
        /// <summary>
        /// Получить значение элемента
        /// </summary>
        public string ParseElement(AutomationElement element)
        {
            object patternObj;
            if (element.TryGetCurrentPattern(ValuePatternIdentifiers.Pattern, out patternObj))
            {
                var valuePattern = (ValuePattern) patternObj;
                return  valuePattern.Current.Value;
            }
            return null;
        }




        /// <summary>
        /// Функция Id окна
        /// </summary>
        /// <param name="nameAutomationId">Имя Id</param>
        /// <returns></returns>
        private Condition AddCondition(string nameAutomationId)
        {
           var parametr = nameAutomationId.Split(':');
            if (parametr[0] == "Name")
             {
                return new AndCondition(
            new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
            new PropertyCondition(AutomationElement.NameProperty, parametr[1]));
            }
            if (parametr[0] == "AutomationId")
            {
                return new AndCondition(
                  new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                  new PropertyCondition(AutomationElement.AutomationIdProperty, parametr[1]));
            }
            return null;
        }
    }
}
