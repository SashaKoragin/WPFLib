using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonsClikcs;



namespace LibraryAIS3Windows.AutomationsUI.LibaryAutomations
{
   public class LibraryAutomations : IDisposable
    {
        /// <summary>
        /// Все месяца календаря АИС 3
        /// </summary>
        private static Dictionary<int,string> Calendar = new Dictionary<int, string>()
        {
            {1, "января"},
            {2, "февраля"},
            {3, "марта"},
            {4, "апреля"},
            {5, "мая"},
            {6, "июня"},
            {7, "июля"},
            {8, "августа"},
            {9, "сентября"},
            {10, "октября"},
            {11, "ноября"},
            {12, "декабря"}
        };

        public int ProcessId { get; set; }
        public AutomationElement RootAutomationElements { get; set; }

        public AutomationElement FindElement { get; set; }

        public LibraryAutomations NewPreviousSiblingWindows { get; set; }
        private Condition Conditions { get; set; }
        /// <summary>
        /// Подключение к процессу
        /// </summary>
        /// <param name="nameWindowsAis3"></param>
       
        public LibraryAutomations()
        {
            RootAutomationElements = AutomationElement.RootElement;
            ProcessId = RootAutomationElements.Current.ProcessId;
        }

        public LibraryAutomations(string nameWindowsAis3)
        {
            RootAutomationElements = AutomationElement.FromHandle(AutoItX.WinGetHandle(nameWindowsAis3));
            ProcessId = RootAutomationElements.Current.ProcessId;
        }
        /// <summary>
        /// Подключение к процессу через AutomationElement Tree
        /// </summary>
        public LibraryAutomations(AutomationElement element)
        {
            RootAutomationElements = element;
            ProcessId = RootAutomationElements.Current.ProcessId;
        }


        /// <summary>
        /// Подключение к процессу!
        /// </summary>
        /// <param name="nameProcess">Наименоване процессу</param>
        public LibraryAutomations(IntPtr nameProcess)
        {

            RootAutomationElements = AutomationElement.FromHandle(nameProcess);
            ProcessId = RootAutomationElements.Current.ProcessId;
        }
        /// <summary>
        /// Поиск окна при открытии вне потока Windows
        /// </summary>
        public void SelectGetPreviousSiblingWindows()
        {
            NewPreviousSiblingWindows = null;
            while (NewPreviousSiblingWindows == null)
            {
                NewPreviousSiblingWindows = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(RootAutomationElements));
            }
        }


        /// <summary>
        /// Подстановка параметра в условие поля
        /// </summary>
        /// <param name="fullPathParameter">Полный индекс условия</param>
        /// <param name="parameter">Параметр</param>
        public void SendParameter(string fullPathParameter,string parameter)
        {
            if (FindFirstElement(fullPathParameter, null, true) == null) return;
            FindFirstElement("Name:Значение", FindElement, true);
            FindElement.SetFocus();
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait(parameter);
        }


        /// <summary>
        /// Поиск элемента по полю
        /// </summary>
        /// <param name="nameAutomationId"></param>
        /// <param name="auto">Поиск по циклу по формуле если нет в корневом элементе то ищем потомка</param>
        /// <param name="isSubtree">Искать в Subtree последний элемент</param>
        /// <param name="isChildren">Искать в Children последний элемент</param>
        /// <returns></returns>
        public AutomationElement FindFirstElement(string nameAutomationId, AutomationElement auto = null,bool isSubtree=false, bool isChildren = false, char separator = ':')
        {
            var recursion = nameAutomationId.Split('\\');
            FindElement = auto;
            var i = 1;
            foreach (var str in recursion)
            {
             try
             {
                 Conditions = AddCondition(str, separator);
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
                         if (isChildren)
                         {
                             if (recursion.Length == i)
                             {
                                 FindElement.SetFocus();
                                 FindElement = FindElement.FindFirst(TreeScope.Children, Conditions);
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
                    sw.WriteLine(child.Current.ClassName + ":"+child.Current.AutomationId + ":" + values);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public void SelectionComboBoxPattern(AutomationElement element)
        {
            ClickElement(element, -65);
            var pattern = element.GetCurrentPattern(SelectionItemPattern.Pattern);
            var select = (SelectionItemPattern)pattern;
            if (select.Current.IsSelected)
            {
                Debug.WriteLine($"{element.Current.Name} - {select.Current.IsSelected}");
            }
            else
            {
                Debug.WriteLine($"{element.Current.Name} - {select.Current.IsSelected}");
                ClickElement(element, -65);
            }
        }

        /// <summary>
        /// Проверка элемента на выбор
        /// </summary>
        /// <param name="element">Элемент проверка на выбор</param>
        public string SelectionComboBoxPatternIsSelect(AutomationElement element)
        {
            var pattern = element.GetCurrentPattern(SelectionPatternIdentifiers.Pattern);
            var select = (SelectionPattern)pattern;
            if (select.Current.GetSelection().Count() > 0)
            {
                return select.Current.GetSelection()[0].Current.Name;
            }
            return "";
        }

        /// <summary>
        /// Паттерн закрытия окна! 
        /// </summary>
        /// <param name="element"></param>
        public void CloseWindowPattern(AutomationElement element)
        {
            WindowPattern windowPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
            AutoItX.Sleep(2000);
            windowPattern.Close();
        }
        /// <summary>
        /// Паттерн прокрутки до элемента нажатия
        /// </summary>
        /// <param name="nameAutomationId"></param>
        public void ScrollPatternViewElement(string nameAutomationId)
        {
            var isProcess = true;
            while (isProcess)
            {
                if (IsEnableElements(nameAutomationId, null, false, 5) != null)
                {
                    FindElement.SetFocus();
                    if (FindElement.TryGetCurrentPattern(ScrollItemPatternIdentifiers.Pattern, out var patternObj))
                    {
                        var valuePattern = (ScrollItemPattern)patternObj;
                        valuePattern.ScrollIntoView();
                        isProcess = false;
                    }
                }
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
        /// Раскрытие элемента Автоматизации
        /// </summary>
        /// <param name="nameAutomationId">Имя элемента</param>
        public bool IsExpandOpen(string nameAutomationId)
        {
            if (IsEnableElements(nameAutomationId,null,false,5)!=null)
            {
                var expand = DefaultActionPattern(FindElement);
                if(expand == "Expand")
                {
                    InvokePattern(FindElement);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Закрытие элемента Автоматизации
        /// </summary>
        /// <param name="nameAutomationId">Имя элемента</param>
        public bool IsExpandClose(string nameAutomationId)
        {
            if (IsEnableElements(nameAutomationId, null, false, 5) != null)
            {
                var expand = DefaultActionPattern(FindElement);
                if (expand == "Collapse")
                {
                    InvokePattern(FindElement);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка на доступ и раскрытия элемента 
        /// </summary>
        /// <param name="fullTreeAis3">Полная ветка АИС 3 "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации"</param>
        /// <returns></returns>
        public bool IsEnableExpandTree(string fullTreeAis3)
        {
            var arrayTree = fullTreeAis3.Split('\\');
            foreach (var tree in arrayTree)
            {
                var fullTree = string.Concat(PublicElementName.FullTree,$"Name:{tree}");
                var isTrue = IsExpandOpen(fullTree);
                if (!isTrue)
                {
                    return false;
                }
            }
            return true;
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
        /// Проставить значение в найденный элемент
        /// </summary>
        public void SetLegacyIAccessibleValuePattern(string value)
        {
            var pattern = FindElement.GetCurrentPattern(LegacyIAccessiblePatternIdentifiers.Pattern);
            var valueAuto = (LegacyIAccessiblePattern)pattern;
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
                    SendKeys.SendWait(string.Format(ButtonConstant.UpCountClick, 1));
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
                    SendKeys.SendWait(string.Format(ButtonConstant.DownCountClick, 1));
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
        /// Контроль даты календаря который нелзя спарсить
        /// </summary>
        /// <param name="dateTime">Дата и время которое надо подставить</param>
        public void DateControlComboboxNotValue(DateTime dateTime)
        {
            var yearAutomation = Convert.ToInt32(FindElement.Current.Name.Split(' ')[2].Trim());
            var yearControl = dateTime.Year;
            while (yearAutomation != yearControl)
            {
                FindElement.SetFocus();
                ClickElement(FindElement, -110, 0);
                AutoItX.Send(yearAutomation > yearControl
                             ? string.Format(ButtonConstant.DownCountClick, 1)
                             : string.Format(ButtonConstant.UpCountClick, 1));
                AutoItX.Sleep(100);
                yearAutomation = Convert.ToInt32(FindElement.Current.Name.Split(' ')[2].Trim());
            }

            var mouthAutomation = FindElement.Current.Name.Split(' ')[1].Trim();
            var mouthControl = Calendar.FirstOrDefault(x => x.Key == dateTime.Month).Value;
            while (mouthAutomation != mouthControl)
            {
                
                ClickElement(FindElement, -165);
                AutoItX.Send(string.Format(ButtonConstant.UpCountClick, 1));
                AutoItX.Sleep(100);
                mouthAutomation = FindElement.Current.Name.Split(' ')[1].Trim();
            }
            
            var dayAutomation = Convert.ToInt32(FindElement.Current.Name.Split(' ')[0].Trim());
            var dayControl = dateTime.Day;
            while (dayAutomation != dayControl)
            {
                FindElement.SetFocus();
                ClickElement(FindElement, -180);
                AutoItX.Send(string.Format(ButtonConstant.UpCountClick, 1));
                AutoItX.Sleep(100);
                dayAutomation = Convert.ToInt32(FindElement.Current.Name.Split(' ')[0].Trim());
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
                    SendKeys.SendWait(string.Format(ButtonConstant.UpCountClick, 1));
                    AutoItX.Sleep(1000);
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
            return Convert.ToString(hexPixel, 16);
        }

        /// <summary>
        /// Проверяет доступен ли элемент и записывает его  в  FindElement
        /// </summary>
        /// <param name="nameAutomationId">Поиск элемента</param>
        /// <param name="auto">Есть ли элемент</param>
        /// <param name = "isSubtree" >Искать в Subtree последний элемент</param>
        /// <param name="countsecond">Количество обращений к элементу</param>
        /// <param name="isFocus">Включен: (IsEnabled 0) и (IsKeyboardFocusable 1)</param>
        /// <param name="isChildren">Искать в Children последний элемент</param>
        public AutomationElement IsEnableElements(string nameAutomationId, AutomationElement auto = null, bool isSubtree = false,  int countsecond =40, int isFocus = 0, bool isChildren = false, char separator = ':')
        {
            var isEnable = false;
            var i = 0;
            while (!isEnable)
            {
                FindFirstElement(nameAutomationId, auto, isSubtree, isChildren, separator);
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
                AutoItX.Sleep(50);
                i++;
            }
            return FindElement;
        }
        /// <summary>
        /// Опасная функция проверка и продолжение если элемент включен
        /// </summary>
        /// <param name="nameAutomationId">Поиск элемента</param>
        public bool IsEnableElement(string nameAutomationId)
        {
            var isEnable = false;
            while (!isEnable)
            {
                FindFirstElement(nameAutomationId, null, false, false);
                if (FindElement != null)
                {
                        isEnable = FindElement.Current.IsEnabled;
                }
            }
            return isEnable;
        }

        /// <summary>
        /// Опасная функция ожидание отключения элемента
        /// </summary>
        /// <param name="nameAutomationId">Поиск элемента</param>
        public bool IsEnableElementTrue(string nameAutomationId, AutomationElement auto = null, bool isSubtree = false)
        {
            var isEnable = true;
            LegacyIAccessiblePattern valuePattern;
            uint status = 0;
            while (isEnable)
            {
                FindFirstElement(nameAutomationId, auto,isSubtree);
                try
                {
                    if (FindElement.TryGetCurrentPattern(LegacyIAccessiblePatternIdentifiers.Pattern, out var patternObj))
                    {
                        valuePattern = (LegacyIAccessiblePattern)patternObj;
                        status = valuePattern.Current.State;
                        if (status != 0)
                        {
                            return false;
                        }
                        status = 0;
                    }
                }
                catch
                {
                    //ignore
                }
            }
            return false;
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
            try
            {
                var isClicks = true;
                if (IsEnableElements(nameAutomationId, auto, isSubtree, countSecond) != null)
                {
                    var clickPoint = FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickPoint.X + x, (int)clickPoint.Y + y, numClicks);
                    isClicks = false;
                }
                return isClicks;
            }
            catch
            {
                //ignore
            }
            return true;
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
            Point clickPoint = new Point() { X=0,Y=0};
            while (clickPoint.X == 0)
            {
                try
                {
                    clickPoint = auto.GetClickablePoint();
                }
                catch
                {
                    //ignor NotClickablePoint
                }
            }
            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickPoint.X + x, (int)clickPoint.Y + y, numClicks);
        }
        /// <summary>
        /// Поиск и нажатие на нужное наименование из списка ОПАСНО не всегда кликабельно
        /// </summary>
        /// <param name="nameAutomationIdComboBox">Поиск и нажатие элемент списка</param>
        /// <param name="nameListItem">Элемент в списке</param>
        /// <param name="nameComboBox">Наименование списка</param>
        public void FindTextComboboxIsToFocusAndClickElement(string nameAutomationIdComboBox, string nameListItem, string nameComboBox = "LocalizedControlType:панель", char separator = ':', bool isChildren = false, bool isSubtree = true)
        {
                IsEnableElements(nameAutomationIdComboBox, null, isSubtree, 40,0, isChildren, separator);
                var memo = SelectAutomationColrction(FindElement);
                memo[0].SetFocus();
                ClickElement(memo[0]);
                IsEnableElements(nameComboBox);
                var elemList = SelectAutomationColrction(FindElement);
                var selectElement = SelectAutomationColrction(elemList[0]);
                var elemClick = selectElement.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == nameListItem);
                elemClick.SetFocus();
                ClickElement(elemClick);
        }


        /// <summary>
        /// Функция Id окна
        /// </summary>
        /// <param name="nameAutomationId">Имя Id</param>
        /// <returns></returns>
        private Condition AddCondition(string nameAutomationId, char separator = ':')
        {
           var parameter = nameAutomationId.Split(separator);
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
            //Переделать поиск по контроллерам тест писать
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

        /// <summary>
        /// Disposing
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                FindElement = null;
                RootAutomationElements = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}
