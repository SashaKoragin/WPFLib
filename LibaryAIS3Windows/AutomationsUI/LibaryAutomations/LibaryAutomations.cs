using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using AutoIt;
using LibaryAIS3Windows.ButtonsClikcs;


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
        /// <param name="isSubtree">Искать в Subtree последний элемент</param>
        /// <returns></returns>
        public AutomationElement FindFirstElement(string nameAutomationId, AutomationElement auto = null,bool isSubtree=false)
        {
            var recursion = nameAutomationId.Split('\\');
            FindElement = auto;
            var i = 1;
            foreach (var str in recursion)
            {
             try
               {
                 Conditions = AddCondition(str);
                  if (auto == null)
                  {
                      FindElement = RootAutomationElements.FindFirst(TreeScope.Children, Conditions);
                      auto = FindElement;
                  }
                  else
                  {
                   if(FindElement != null)
                    {
                       if (isSubtree)
                       {
                         if (recursion.Length == i)
                          {
                           FindElement = FindElement.FindFirst(TreeScope.Subtree, Conditions);
                           return FindElement;
                          }
                       }
                        FindElement = FindElement.FindFirst(TreeScope.Children, Conditions) ?? FindElement.FindFirst(TreeScope.Subtree, Conditions);
                    }
                   else
                   {
                      return null;
                   }
                  }
                  i++;
              }
              catch
              {
                    return null;
              }
            }
            return FindElement;
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
            TreeWalker tw = TreeWalker.RawViewWalker;
            
            AutomationElement child = tw.GetFirstChild(parent);
            while (child != null)
            {
                result.Add(child);
                string path = @"c:\MyTest.txt";
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    var values = ParseElementLegacyIAccessiblePatternIdentifiers(child);
                    sw.WriteLine(child.Current.Name + ":"+child.Current.AutomationId + ":" + values);
                 }
                child = tw.GetNextSibling(child);
                


            }
            foreach (var automationElement in result)
            {
                GetChildren(automationElement);
            }
            return result;
        }


        public AutomationElementCollection SelectAutomationColrction(AutomationElement element)
        {
           return element.FindAll(TreeScope.Children, Condition.TrueCondition);
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
        /// Toggle Pattern
        /// </summary>
        /// <param name="element"></param>
        public string TogglePattern(AutomationElement element)
        {
            if (element != null)
            {
                object patternObj;
                if (element.TryGetCurrentPattern(TogglePatternIdentifiers.Pattern, out patternObj))
                {
                    var valuePattern = (TogglePattern)patternObj;
                    return valuePattern.Current.ToggleState.ToString();
                }
            }
            return null;
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
        /// Элемент и  название в ComboBox которое нужно поставить 
        /// </summary>
        /// <param name="automationElement">Элемент автоматизации</param>
        /// <param name="itemNameComboBox">Наименование которое должно стоять в ComboBox</param>
        public void SelectItemCombobox(AutomationElement automationElement, string itemNameComboBox)
        {
            automationElement.SetFocus();
            var isDown = "";
            var isExit = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
            var isUp = "";
            var isEnable = true;
            while (true)
            {
                if (isExit == itemNameComboBox)
                {
                    break;
                }
                if (isEnable)
                {
                    AutoItX.Send(string.Format(ButtonConstant.UpCountClick, 1));
                    isDown = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
                    if (isDown != isUp)
                    {
                        isExit = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
                        isUp = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
                    }
                    else
                    {
                        isEnable = false;
                    }
                }
                else
                {
                    AutoItX.Send(string.Format(ButtonConstant.DownCountClick, 1));
                    isUp = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
                    if (isDown != isUp)
                    {
                        isExit = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
                        isDown = ParseElementLegacyIAccessiblePatternIdentifiers(automationElement);
                    }
                    else
                    {
                        isEnable = true;
                    }
                }
            }
        }
        /// <summary>
        /// Получить значение элемента из патерна LegacyIAccessiblePatternIdentifiers
        /// </summary>
        public string ParseElementLegacyIAccessiblePatternIdentifiers(AutomationElement element)
        {
            if (element != null)
            {
               object patternObj;
               if (element.TryGetCurrentPattern(LegacyIAccessiblePatternIdentifiers.Pattern, out patternObj))
               {
                  var valuePattern = (LegacyIAccessiblePattern)patternObj;
                  return  valuePattern.Current.Value;
               }
            }
            return null;
        }
        /// <summary>
        /// Проверяет доступен ли элемент и записывает его  в  FindElement
        /// </summary>
        /// <param name="nameAutomationId">Поиск элемента</param>
        /// <param name="auto">Есть ли элемент</param>
        /// <param name = "isSubtree" >Искать в Subtree последний элемент</param>
        /// <param name="countsecond">Колличество обращений к элементу</param>
        public AutomationElement IsEnableElements(string nameAutomationId, AutomationElement auto = null, bool isSubtree = false,int countsecond =25,int isFocus = 0)
        {
            var isenable = false;
            var i = 0;
            while (!isenable)
            {
                FindFirstElement(nameAutomationId, auto, isSubtree);
                if (FindElement != null)
                {
                    if (isFocus == 0)
                    {
                        isenable = FindElement.Current.IsEnabled;
                    }
                    if(isFocus == 1)
                    {
                        isenable = FindElement.Current.IsKeyboardFocusable;
                    }
                    
                }
                if (i == countsecond)
                {
                    return null;
                }
                i++;
            }
            return FindElement;
        }
        /// <summary>
        /// Поиск и нажатие на элемент!!!
        /// </summary>
        /// <param name="nameAutomationId">Поиск элемента</param>
        /// <param name="auto">Есть ли элемент</param>
        /// <param name = "isSubtree" >Искать в Subtree последний элемент</param>
        /// <param name="countsecond">Колличество обращений к элементу</param>
        /// <param name="x">Координата смещения если не ловит элемент</param>
        /// <param name="y">Координата смещения если не ловит элемент</param>
        public bool CliksElements(string nameAutomationId, AutomationElement auto = null, bool isSubtree = false,int countsecond = 25,int x = 0,int y = 0)
        {
            var isClicks = false;
            if (IsEnableElements(nameAutomationId, auto, isSubtree, countsecond) != null)
            {
                var clickablePoint = FindElement.GetClickablePoint();
               // AutoItX.MouseMove((int)clickablePoint.X+x, (int)clickablePoint.Y+y);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint.X + x, (int)clickablePoint.Y + y);
                isClicks = true;
            }
            return isClicks;
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
            if (parametr[0] == "ControlType")
            {
                return new AndCondition(
                  new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                  new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                  new PropertyCondition(AutomationElement.AutomationIdProperty, parametr[1])
                  );
            }
            if (parametr[0] == "ClassName")
            {
                return new AndCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                    new PropertyCondition(AutomationElement.ClassNameProperty,parametr[1]));
            }
            if (parametr[0] == "NativeWindowHandle")
            {
                return new AndCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                    new PropertyCondition(AutomationElement.NativeWindowHandleProperty, parametr[1]));
            }
            return null;
        }
    }
}
