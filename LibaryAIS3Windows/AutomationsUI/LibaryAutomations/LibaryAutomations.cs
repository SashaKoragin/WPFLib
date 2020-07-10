using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Automation;
using AutoIt;
using LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck;
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
                           FindElement.SetFocus();
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
                string path = @"d:\MyTest.txt";
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

        /// <summary>
        /// Поиск всех дочерних элементов
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <returns></returns>
        public AutomationElementCollection SelectAutomationColrction(AutomationElement element)
        {
           return element.FindAll(TreeScope.Children, Condition.TrueCondition);
        }

        /// <summary>
        /// Поставить фокус на элемент
        /// </summary>
        public void InvokePattern(AutomationElement element)
        {
            try
            {
                element.SetFocus();
                var pattern = element.GetCurrentPattern(InvokePatternIdentifiers.Pattern);
                var valueAuto = (InvokePattern)pattern;
                valueAuto.Invoke();
            }
            catch
            {
                // ignored
            }
        }

        private string DefaultActionPattern(AutomationElement element)
        {
            if (element != null)
            {
                element.SetFocus();
                if (element.TryGetCurrentPattern(LegacyIAccessiblePatternIdentifiers.Pattern, out var patternObj))
                {
                    var valuePattern = (LegacyIAccessiblePattern)patternObj;
                    return valuePattern.Current.DefaultAction;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameAutomationId"></param>
        public void IsExpandOpen(string nameAutomationId)
        {
            if (IsEnableElements(nameAutomationId)!=null)
            {
                var expand = DefaultActionPattern(FindElement);
                if(expand == "Expand")
                {
                    InvokePattern(FindElement);
                }
            }
        }

        /// <summary>
        /// Toggle Pattern
        /// </summary>
        /// <param name="element"></param>
        public string TogglePattern(AutomationElement element)
        {
            if (element != null)
            {
                element.SetFocus();
                if (element.TryGetCurrentPattern(TogglePatternIdentifiers.Pattern, out var patternObj))
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
            var pattern = FindElement.GetCurrentPattern(ValuePatternIdentifiers.Pattern);
            var valueAuto = (ValuePattern)pattern;
            valueAuto.SetValue(value);
        }
        /// <summary>
        /// Элемент и  название в ComboBox которое нужно поставить 
        /// </summary>
        /// <param name="automationElement">Элемент автоматизации</param>
        /// <param name="itemNameComboBox">Наименование которое должно стоять в ComboBox</param>
        public void SelectItemCombobox(AutomationElement automationElement, string itemNameComboBox, int milesecond = 1000)
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
                    AutoItX.Sleep(milesecond);
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
                    AutoItX.Sleep(milesecond);
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
        /// Эта функция для Выявления максимального года в ComboBox
        /// </summary>
        /// <param name="automationElement">Элемент  ComboBox</param>
        /// <returns>Максимальный год</returns>
        public int SelectItemComboboxMaxYear(AutomationElement automationElement)
        {
            automationElement.SetFocus();
            var isExit =Convert.ToInt32(ParseElementLegacyIAccessiblePatternIdentifiers(automationElement));
            var isUp = 0;
            while (true)
            {
                if (isExit == isUp)
                {
                    return isExit;
                }
                if (isExit < DateTime.Now.Year)
                {
                    isExit = Convert.ToInt32(ParseElementLegacyIAccessiblePatternIdentifiers(automationElement));
                    AutoItX.Send(string.Format(ButtonConstant.UpCountClick, 1));
                    AutoItX.Sleep(1000);
                    if (IsEnableElements(PreCheckElementNameIndividualCards.ErrorYear, null, true,1) != null)
                    {
                        ClickElements(PreCheckElementNameIndividualCards.ErrorYear, null, true);
                        if (IsEnableElements(PreCheckElementNameIndividualCards.ErrorData, null, true) != null)
                        {
                            ClickElements(PreCheckElementNameIndividualCards.ErrorData, null, true);
                        }
                    }
                    isUp = Convert.ToInt32(ParseElementLegacyIAccessiblePatternIdentifiers(automationElement));
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
                element.SetFocus();
                if (element.TryGetCurrentPattern(LegacyIAccessiblePatternIdentifiers.Pattern, out var patternObj))
                {
                    var valuePattern = (LegacyIAccessiblePattern)patternObj;
                    return  valuePattern.Current.Value;
                }
            }
            return null;
        }
        /// <summary>
        /// Статус элемента
        /// </summary>
        /// <param name="element">Наименование элемента</param>
        /// <returns>Статус элемента</returns>
        public uint? ParseElementLegacyIAccessiblePatternIdentifiersState(AutomationElement element)
        {
            if (element != null)
            {
                if (element.TryGetCurrentPattern(LegacyIAccessiblePatternIdentifiers.Pattern, out var patternObj))
                {
                    var valuePattern = (LegacyIAccessiblePattern)patternObj;
                    var status = valuePattern.Current.State;
                    return status;
                }
            }
            return null;
        }


        /// <summary>
        /// Получить значение элемента из патерна LegacyIAccessiblePatternIdentifiers
        /// </summary>
        public string ParseValuePattern(AutomationElement element)
        {
            if (element != null)
            {
                element.SetFocus();
                if (element.TryGetCurrentPattern(ValuePattern.Pattern, out var patternObj))
                {
                    var valuePattern = (ValuePattern)patternObj;
                    return valuePattern.Current.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Получение цвета элемента пикселя
        /// </summary>
        /// <param name="element">Автоматизированный элемент</param>
        /// <returns></returns>
        public string GetColorPixel(AutomationElement element)
        {
            element.SetFocus();
            var clickPoint = element.GetClickablePoint();
            var hexPixel = AutoItX.PixelGetColor((int)clickPoint.X, (int)clickPoint.Y);
            var v = Convert.ToString(hexPixel, 16);
            return Convert.ToString(hexPixel, 16);
        }

        /// <summary>
        /// Проверяет доступен ли элемент и записывает его  в  FindElement
        /// </summary>
        /// <param name="nameAutomationId">Поиск элемента</param>
        /// <param name="auto">Есть ли элемент</param>
        /// <param name = "isSubtree" >Искать в Subtree последний элемент</param>
        /// <param name="countsecond">Количество обращений к элементу</param>
        public AutomationElement IsEnableElements(string nameAutomationId, AutomationElement auto = null, bool isSubtree = false,int countsecond =40,int isFocus = 0)
        {
            var isEnable = false;
            var i = 0;
            while (!isEnable)
            {
                FindFirstElement(nameAutomationId, auto, isSubtree);
                if (FindElement != null)
                {
                    if (isFocus == 0)
                    {
                        isEnable = FindElement.Current.IsEnabled;
                    }
                    if(isFocus == 1)
                    {
                        isEnable = FindElement.Current.IsKeyboardFocusable;
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
        /// <param name="numClicks">Количество нажатий</param>
        /// <param name="countSecond">Количество обращений к элементу</param>
        /// <param name="x">Координата смещения если не ловит элемент</param>
        /// <param name="y">Координата смещения если не ловит элемент</param>
        public bool ClickElements(string nameAutomationId, AutomationElement auto = null, bool isSubtree = false, int countSecond = 25,int x = 0,int y = 0, int numClicks = 1)
        {
            var isClicks = false;
            if (IsEnableElements(nameAutomationId, auto, isSubtree, countSecond) != null)
            {
                var clickPoint = FindElement.GetClickablePoint();
                AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickPoint.X + x, (int)clickPoint.Y + y,numClicks);
                isClicks = true;
            }
            return isClicks;
        }
        /// <summary>
        /// Нажать на элемент без поиска
        /// </summary>
        /// <param name="auto">Элемент</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="numClicks">Количество кликов</param>
        public void ClickElement(AutomationElement auto, int x = 0, int y = 0, int numClicks = 1)
        {
            var clickPoint = auto.GetClickablePoint();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickPoint.X + x, (int)clickPoint.Y + y, numClicks);
        }


        /// <summary>
        /// Функция Id окна
        /// </summary>
        /// <param name="nameAutomationId">Имя Id</param>
        /// <returns></returns>
        private Condition AddCondition(string nameAutomationId)
        {
           var parameter = nameAutomationId.Split(':');
            if (parameter[0] == "Name")
            {
                return new AndCondition(
                    new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                    new PropertyCondition(AutomationElement.NameProperty, parameter[1]));
            }
            if (parameter[0] == "AutomationId")
            {
                return new AndCondition(
                  new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                  new PropertyCondition(AutomationElement.AutomationIdProperty, parameter[1]));
            }
            if (parameter[0] == "ControlType")
            {
                return new AndCondition(
                  new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                  new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                  new PropertyCondition(AutomationElement.AutomationIdProperty, parameter[1])
                  );
            }
            if (parameter[0] == "ClassName")
            {
                return new AndCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                    new PropertyCondition(AutomationElement.ClassNameProperty,parameter[1]));
            }
            if (parameter[0] == "NativeWindowHandle")
            {
                return new AndCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                    new PropertyCondition(AutomationElement.NativeWindowHandleProperty, parameter[1]));
            }
            if(parameter[0]== "LocalizedControlType")
            {
                return new AndCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, ProcessId),
                          new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, parameter[1]));
            }
            return null;
        }
    }
}
