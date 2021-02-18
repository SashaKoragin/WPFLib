using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using AisPoco.Ifns51.ToAis;
using LibraryAIS3Windows.Window.Otdel.Analitic.TeskText;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using EfDatabaseAutomation.Automation.BaseLogica.IdentificationFace;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibaryXMLAutoInventarization.Model.ModelSelectAll;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.It;
using LibraryAIS3Windows.AutomationsUI.Otdels.RaschetBud;
using LibraryAIS3Windows.AutomationsUI.Otdels.Registration;
using LibraryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ExitLogica.ExitTaskFull;
using LibraryAIS3Windows.Function.PublicFunc;
using LibraryAIS3Windows.Mode.Okp4.PravoZorI;
using LibraryAIS3Windows.Mode.Okp4.SnuFormirovanie;
using LibraryAIS3Windows.Mode.RaschetBudg.Migration;
using LibraryAIS3Windows.Mode.Reg.StatusReg;
using LibraryAIS3Windows.RegxFull.RaschetBudg;
using LibraryAIS3Windows.SqlModel.SqlLk2;
using LibraryAIS3Windows.Window;
using LibraryAIS3Windows.Window.Otdel.Okp3.Usn;
using LibraryAIS3Windows.Window.Otdel.Okp4.PravoZorI;
using LibraryAIS3Windows.Window.Otdel.Okp4.Print;
using LibraryAIS3Windows.Window.Otdel.Okp4.Snu;
using LibraryAIS3Windows.Window.Otdel.Orn.Nbo;
using LibraryAIS3Windows.Window.Otdel.Reg.ActualStatus;
using LibraryAIS3Windows.Window.Otdel.Reg.Fpd;
using LibraryAIS3Windows.Window.Otdel.Reg.IdFace;
using LibraryAIS3Windows.Window.Otdel.Uregulirovanie.UtverzdenieSz;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using LibraryAIS3Windows.AutomationsUI.Otdels.Okp2;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;
using LibraryAIS3Windows.ButtonFullFunction.Okp2Function;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;
using LibraryAIS3Windows.ButtonFullFunction.Okp1Function;


namespace LibraryAIS3Windows.ButtonsClikcs
{
    public class KclicerButton
    {


        private const string LogTreb =
            @"��������� �����������������\�������������� �������������\���������� �� ������\������ ���������� �� ������";

        /// <summary>
        /// ����� ������������� ���������� ������
        /// </summary>
        private const string VisualBank =
            @"��������� �����������������\���������� � ������� �����\06. ������� �������� ������ ��\01. ���������� ������ ��������� �����";

        /// <summary>
        /// ��������� �������� ����� ������� ������������ ��������
        /// </summary>
        private const string ModeBranch =
            @"����� ��������� �����������������\���������� ����\1.06. ������������ � ������ C��\1. �������� ������ �� ������������ ��� ��� ��������� ������";

        /// <summary>
        /// ����� ������� ������������ ���������������� �������
        /// </summary>
        private const string ModeBranchUser =
            @"���������� ����/1.08. ��������� �� �� �������� �������������\��������� �������� � ��";

        /// <summary>
        /// ������������� �������� � ������
        /// </summary>
        private const string Okp4Pravo =
            @"��������� �����������������\�������������\02. ������������� ������ �� �������� �������������\14. �� � ������������� �������� � ������ �� ������������������  � ������� ���������� � ������ ������������ �� �� � ��";

        private const string ModeBranchUserRegZemla =
            @"��������� �����������������\�������������\05. �������������� � �������� ���������� � ��������� �������\03. ��������� ���  �� �� - �� - ������ ����������� ��������� ����������";

        /// <summary>
        /// �������� ������ �� ������������ ���
        /// </summary>
        private const string SnuZayvki =
            @"��������� �����������������\���������� ����\1.06. ������������ � ������ C��\1. �������� ������ �� ������������ ��� ��� ��������� ������";

        /// <summary>
        /// ������ �����������
        /// </summary>
        private const string PrintBranch =
            @"��������� �����������������\���������� ����\1.06. ������������ � ������ C��\2. �������� ���";

        /// <summary>
        /// ���������� ������
        /// </summary>
        private const string ActualStatus =
            @"��������� �����������������\��� ��\1. ��� �� (��). ����������� � ���������� ����, ��������� � ��� ��\2.01. ��. ���������� ���������";

        /// <summary>
        /// ����������� �����������
        /// </summary>
        private const string TechnicalUpdate =
            @"��������� �����������������\���������������� ���� ������������������\15.02.02. ���������. ����������� �����������\ ���������� ����\15.02.02.01. ���������. ����������� �����������. ���������� ����";

        /// <summary>
        /// ��������� ���������� �������������
        /// </summary>
        private const string FaceRosreestr =
            @"��������� �����������������\�������������\14. ������ � ������ � ����������������� ��������, �� ������� ��������� ���������� ���������";

        private const string Usn =
            @"����� �������\����������� ������ ��������� ��������\���������� ���������� ������� ���������������\���������� ���";

        /// <summary>
        /// ��������� ���� ��� ������������� �������� ������ �� ������������ ��� ��
        /// ����� ��������� �����������������\���������� ����\1.06. ������������ � ������ C��\1. �������� ������ �� ������������ ��� ��� ��������� ������
        /// </summary>
        public void Click1(string pathjurnalerror, string pathjurnalok, string inn)
        {
            while (true)
            {
                WindowsAis3 win = new WindowsAis3();
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 180,
                    win.WindowsAis.Y + win.Y1 + 120);
                AutoItX.WinWait(WindowsAis3.Text, WindowsAis3.WinWait, 3);
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.WinWait) == 1)
                {
                    break;
                }
            }

            AutoItX.Sleep(1000);
            AutoItX.WinActivate(WindowsAis3.Text, WindowsAis3.WinWait);
            AutoItX.ClipPut(inn);
            AutoItX.Send(ButtonConstant.Down2);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButUpdate[0], SnuForm.ButUpdate[1],
                ButtonConstant.MouseLeft);
            AutoItX.Sleep(3000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButCancel[0], SnuForm.ButCancel[1],
                        ButtonConstant.MouseLeft);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, inn, ModeBranch,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.UpdateDataSource) == 1)
                {
                    AutoItX.Send(ButtonConstant.CtrlA);
                    AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButNext[0], SnuForm.ButNext[1],
                        ButtonConstant.MouseLeft);
                    AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                    AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButCreateZ[0], SnuForm.ButCreateZ[1],
                        ButtonConstant.MouseLeft);
                    AutoItX.WinWait(SnuText.DialogWin);
                    AutoItX.WinActivate(SnuText.DialogWin);
                    AutoItX.Send(ButtonConstant.Enter);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, inn, "����������");
                    break;
                }
            }
        }

        /// <summary>
        /// ��������� ���� ��� ������������� ��������� �������� � �� ����� �����������
        /// ���������������� �������
        /// ����� ���������� ����/1.08. ��������� �� �� �������� �������������\��������� �������� � ��
        /// </summary>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">���� � ����������� �������</param>
        /// <param name="usefilter">������������� ���� ���� ������ ��� ������ ���� ������ �� �� ������ ������</param>
        public void Click2(string pathjurnalerror, string pathjurnalok, bool usefilter)
        {
            try
            {
                while (true)
                {
                    WindowsAis3 win = new WindowsAis3();
                    if (usefilter)
                    {
                        win.ControlGetPos1(WindowsAis3.GridMain[0], WindowsAis3.GridMain[1], WindowsAis3.GridMain[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 7,
                            win.WindowsAis.Y + win.Y1 + 55, 2);
                        AutoItX.WinWait(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 30);
                    }
                    else
                    {
                        win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1],
                            WindowsAis3.WinRequest[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                            win.WindowsAis.Y + win.Y1 + 80);
                        AutoItX.WinWait(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 30);
                    }

                    if (AutoItX.WinExists(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid) == 1)
                    {
                        break;
                    }
                }

                var fid = ReadWindow.Read.Reades.ReadForm(Mode.Reg.Yvedomlenie.Yvedomlenia.FidText);
                while (true)
                {
                    AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[0],
                        Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[1], ButtonConstant.MouseLeft);
                    AutoItX.WinWait(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                        Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText, 10);
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText) == 1)
                    {
                        break;
                    }
                }

                AutoItX.Sleep(2000);
                ClikcCheker.Cheker.Chekerfid();
                AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                    Mode.Reg.Yvedomlenie.Yvedomlenia.Update[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Update[1],
                    ButtonConstant.MouseLeft);
                while (true)
                {
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            WindowsAis3.DataNotFound) == 1)
                    {
                        AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1],
                            ButtonConstant.MouseLeft);
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ModeBranchUser,
                            WindowsAis3.DataNotFound);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft);
                        break;
                    }

                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFidUser) == 1)
                    {
                        AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1],
                            ButtonConstant.MouseLeft);
                        AutoItX.MouseWheel(ButtonConstant.Wheel, 2);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[1], ButtonConstant.MouseLeft);
                        AutoItX.Send(ButtonConstant.Down2);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Save[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Save[1], ButtonConstant.MouseLeft);
                        AutoItX.Sleep(500);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, "����������");
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, "������ ���������� ���� ��������!!!",
                    ModeBranchUser, e.Message);
            }
        }

        /// <summary>
        /// ��������� ���� ��� ������������� ��������� �������� � �� ����� �����������
        /// ��������� �����������������\�������������\05. �������������� � �������� ���������� � ��������� �������\03. ��������� ���  �� �� - �� - ������ ����������� ��������� ����������
        /// � ���-�� ������ ������� �������� ��� �����
        /// ��������� �����������������\�������������\06. �������������� � �������� ���������� � ������� ������������\03. ��������� ���  �� �� - �� - ������ ����������� ��������� ����������
        /// </summary>
        /// <param name="pathjurnalerror">������ ������</param>
        /// <param name="pathjurnalok">������ ��������</param>
        /// <param name="fpd">��� ��������</param>
        public void Click3(string fpd, string pathjurnalerror, string pathjurnalok)
        {
            string copyfio = null;
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fpd);
            AutoItX.Send(ButtonConstant.Down9);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd, ModeBranchUserRegZemla,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextFidUser) == 1)
                {
                    while (true)
                    {
                        string fio = ReadWindow.Read.Reades.ReadForm(Mode.Reg.ZemlyFpd.Zemly.FioUser);
                        string id = ReadWindow.Read.Reades.ReadForm(Mode.Reg.ZemlyFpd.Zemly.FidText);
                        if (fio.Equals(copyfio))
                        {
                            AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                            AutoItX.Send(ButtonConstant.F3);
                            break;
                        }

                        if (id.Equals(FpdText.TextUslovie) || id.Equals(FpdText.Text4) || id.Equals(FpdText.Text11))
                            //��� ���������� ����� ������� ������� �� ���� !!!!!!!!!!!!!!!!
                        {
                            while (true)
                            {
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330,
                                    win.WindowsAis.Y + 90);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(WindowsAis3.Text, FpdText.TextCun, 5);
                                if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextCun) == 1)
                                {
                                    AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.ZemlyFpd.Zemly.SpisokCun[0],
                                        Mode.Reg.ZemlyFpd.Zemly.SpisokCun[1], ButtonConstant.MouseLeft);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Sleep(1000);
                                    FpdText fpdtext = new FpdText();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + fpdtext.WinVisualPageControl.X + 675,
                                        win.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 110);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + fpdtext.WinVisualPageControl.X + 40,
                                        win.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 90);
                                    AutoItX.Send(ButtonConstant.Down13);
                                    AutoItX.Send(ButtonConstant.Right5);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Down1);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + fpdtext.WinVisualTool.X + 80,
                                        win.WindowsAis.Y + fpdtext.WinVisualTool.Y + 10);
                                    while (true)
                                    {
                                        if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextUnfl) == 1)
                                        {
                                            while (true)
                                            {
                                                FpdText fpdtextnew = new FpdText();
                                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                                    win.WindowsAis.X + fpdtextnew.WinVisualTool.X + 150,
                                                    win.WindowsAis.Y + fpdtextnew.WinVisualTool.Y + 10);
                                                AutoItX.WinWait(FpdText.TextVnimanie, FpdText.TextOk, 5);
                                                if (AutoItX.WinExists(FpdText.TextVnimanie, FpdText.TextOk) == 1)
                                                {
                                                    AutoItX.WinActivate(FpdText.TextVnimanie, FpdText.TextOk);
                                                    AutoItX.Send(ButtonConstant.Enter);
                                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fpd,
                                                        "����������");
                                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                                        fpdtext.WinCoordinat.X + fpdtext.WinCoordinat.Width - 15,
                                                        fpdtext.WinCoordinat.Y + 160);
                                                    break;
                                                }
                                            }

                                            break;
                                        }

                                        if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                                        {
                                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,
                                                fpd + "/" + fio, "������� ��� ��� ������ �����������",
                                                WindowsAis3.DataNotFound);
                                            AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                                fpdtext.WinCoordinat.X + fpdtext.WinCoordinat.Width - 15,
                                                fpdtext.WinCoordinat.Y + 160);
                                            break;
                                        }
                                    }

                                    break;
                                }

                                if (AutoItX.WinExists(FpdText.TextVnimanie, FpdText.TextIdent) == 1)
                                {
                                    AutoItX.WinActivate(FpdText.TextVnimanie, FpdText.TextIdent);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio,
                                        ModeBranchUserRegZemla, FpdText.TextIdent);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio,
                                ModeBranchUserRegZemla, id);
                        }

                        AutoItX.Sleep(1000);
                        AutoItX.ControlFocus(WindowsAis3.AisNalog3, WindowsAis3.Text, WindowsAis3.GridWinAis3);
                        AutoItX.Send(ButtonConstant.Tab);
                        copyfio = fio;
                        fio = null;
                        id = null;
                    }

                    break;
                }
            }
        }


        /// <summary>
        /// ������������ ����� 
        /// ��������� �����������������\���������� ����\1.06. ������������ � ������ C��\1. �������� ������ �� ������������ ��� ��� ��������� ������
        /// </summary>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">���� � ����������� ���</param>
        /// <param name="massinn">�������� ���</param>
        public void Click4(string pathjurnalerror, string pathjurnalok, string massinn)
        {
            while (true)
            {
                AutoItX.WinActivate(WindowsAis3.AisNalog3);
                AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButSrtnal[0], SnuForm.ButSrtnal[1],
                    ButtonConstant.MouseLeft);
                AutoItX.WinWait(WindowsAis3.Text, WindowsAis3.WinWait, 5);
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.WinWait) == 1)
                {
                    AutoItX.WinActivate(WindowsAis3.Text, WindowsAis3.WinWait);
                    break;
                }
            }

            AutoItX.ClipPut(massinn);
            AutoItX.Send(ButtonConstant.Down2);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButUpdate[0], SnuForm.ButUpdate[1],
                ButtonConstant.MouseLeft);
            AutoItX.Sleep(5000);
            AutoItX.Send(ButtonConstant.CtrlA);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButNext[0], SnuForm.ButNext[1], ButtonConstant.MouseLeft);
            AutoItX.Sleep(500);
            AutoItX.WinActivate(WindowsAis3.AisNalog3);
            AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButClose[0], SnuForm.ButClose[1],
                ButtonConstant.MouseLeft);
            AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButCreateZ[0], SnuForm.ButCreateZ[1],
                ButtonConstant.MouseLeft);
            AutoItX.WinWait(SnuText.DialogWin, SnuText.Snu, 10);
            if (AutoItX.WinExists(SnuText.DialogWin, SnuText.Snu) != 0)
            {
                AutoItX.Send(ButtonConstant.Enter);
            }

            AutoItX.WinWait(WindowsAis3.Text, SnuText.Null, 3);
            if (AutoItX.WinExists(WindowsAis3.Text, SnuText.Null) != 0)
            {
                AutoItX.Send(ButtonConstant.Enter);
                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, massinn, SnuZayvki,
                    "������ ������������������ ����!!!");
            }
        }

        /// <summary>
        /// ������������ ����� 
        /// ��������� �����������������\�������������\07. �������������� � �������� �����, ������������� � �������� ��
        /// </summary>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">���� � ������� �����������</param>
        /// <param name="fid">�������� ���</param>
        public void Click5(string pathjurnalerror, string pathjurnalok, string fid)
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fid);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.Text, PravoZorI.Fid) == 1)
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 395, win.WindowsAis.Y + 90);
                    AutoItX.Send(ButtonConstant.Down3);
                    AutoItX.Send(ButtonConstant.Enter);
                    while (true)
                    {
                        if (AutoItX.WinExists(PravoZorI.WinTitle) == 1)
                        {
                            AutoItX.WinActivate(PravoZorI.WinTitle);
                            AutoItX.Send(ButtonConstant.Enter);
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo,
                                PravoZorI.ErrorText);
                            AutoItX.Send(ButtonConstant.F3);
                            break;
                        }

                        if (AutoItX.WinExists(PravoZorI.WinRemoveSved) == 1)
                        {
                            AutoItX.ControlSend(PravoZorI.WinRemoveSved, PravoZorI.Exlusive, Pravo.EditDate,
                                DateTime.Now.ToString("d"));
                            AutoItX.ControlFocus(PravoZorI.WinRemoveSved, Pravo.EditNum[0], Pravo.EditNum[1]);
                            AutoItX.Send(PravoZorI.EditString, 1);
                            AutoItX.ControlClick(PravoZorI.WinRemoveSved, Pravo.ComboboxEdit[0], Pravo.ComboboxEdit[1],
                                ButtonConstant.MouseLeft);
                            AutoItX.Send(ButtonConstant.Down3);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.ControlClick(PravoZorI.WinRemoveSved, Pravo.ButtonOk[0], Pravo.ButtonOk[1],
                                ButtonConstant.MouseLeft);
                            while (true)
                            {
                                if (AutoItX.WinExists(PravoZorI.WinTitle, PravoZorI.ErrorText2) == 1)
                                {
                                    AutoItX.WinActivate(PravoZorI.WinTitle);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo,
                                        PravoZorI.ErrorText2);
                                    AutoItX.Send(ButtonConstant.F3);
                                    break;
                                }

                                if (AutoItX.WinExists(PravoZorI.WinTitle, PravoZorI.OkDelete) == 1)
                                {
                                    AutoItX.Sleep(1000);
                                    AutoItX.WinActivate(PravoZorI.WinTitle);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid,
                                        "���������� ��� �����");
                                    AutoItX.Send(ButtonConstant.F3);
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    break;
                }
            }
        }

        ///  <summary>
        /// ������������ ����� 
        /// ����� �������\�������������� �������������\05.09 ������ ������������ ������� �� �����/�������/������� ���������\05.09 ������� �������� ������� �� �����/�������/������� ���������\������� ����������� �������������� ������
        /// � ����� ����� 
        /// ����� �������\�������������� �������������\05.09.01(06.01) ������������ ��������� � ����� �������� ������ (��������� ���������)\05.09.01(06.01) ������������ ��������� �� �������� ������ (���������)\05.09.01(06.01) ������������ ������� � ������ �� ���������� ��\������� ����������� �������������� ������
        /// </summary>
        public string Click6()
        {
            int i = 0;
            WindowsAis3 win = new WindowsAis3();
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                    win.WindowsAis.Y + win.Y1 + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, ZachetVozvrat.Nachalnic, 5);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, ZachetVozvrat.Nachalnic) == 1)
                {
                    break;
                }

                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }

                i++;
            }

            //����������� ��������� ���� �� ���������
            var countdocstring = ReadWindow.Read.Reades.ReadFormNotActiv(Mode.Analitic.Task.TaskZn.Signature);
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 550,
                    win.WindowsAis.Y + win.Y1 + 75);
                var countdocstringcontrol =
                    ReadWindow.Read.Reades.ReadFormNotActiv(Mode.Analitic.Task.TaskZn.Signature);
                if (!countdocstring.Equals(countdocstringcontrol))
                {
                    break;
                }
            }

            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 205,
                    win.WindowsAis.Y + win.Y1 + 85);
                AutoItX.WinWait(ZachetVozvrat.TitleClose, ZachetVozvrat.TextWin, 10);
                if (AutoItX.WinExists(ZachetVozvrat.TitleClose, ZachetVozvrat.TextWin) == 1)
                {
                    AutoItX.WinActivate(ZachetVozvrat.TitleClose);
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.WinWait(ZachetVozvrat.TitleExit, ZachetVozvrat.WorkOk, 10);
                    AutoItX.Send(ButtonConstant.Enter);
                    break;
                }
            }

            return Status.StatusAis.Status3;
        }

        /// <summary>
        /// ������ ����������� � �������� � ��2
        /// ����� : ��������� �����������������\���������� ����\1.06. ������������ � ������ C��\2. �������� ���
        /// </summary>
        /// <param name="date">���� �����������</param>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">������������� �����������</param>
        /// <param name="inn">������ ���</param>
        /// <param name="conectionstring">������ ���������� � ��</param>
        /// <param name="ischec">����������� ���� true ,false</param>
        /// <param name="islk2">��������� �� ��2 ��� ���?</param>
        public void Click7(DateTime date, string pathjurnalerror, string pathjurnalok, string inn,
            string conectionstring, bool ischec, bool islk2)
        {
            var listinn = new List<string>();
            string copyinn = null;
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            if (ischec)
            {
                win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                    win.WindowsAis.Y + win.Y1 + 35);
                AutoItX.ClipPut(date.ToString("dd.MM.yyyy"));
                AutoItX.Send(ButtonConstant.Down10);
                AutoItX.Send(ButtonConstant.Right5);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.Send(ButtonConstant.CtrlV);
            }

            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(inn);
            AutoItX.Send(ButtonConstant.Down20);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, inn, PrintBranch,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.AisNalog3, PrintSnu.Inn) == 1)
                {
                    string innais = ReadWindow.Read.Reades.ReadForm(Mode.Okp4.PrintSnu.PrintSnuControl.InnText);
                    if (innais.Equals(copyinn))
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,
                            PublicFunc.NotArray(listinn, inn), PrintBranch, PrintSnu.InnNotSnu);
                        AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                        AutoItX.Send(ButtonConstant.F3);
                        break;
                    }

                    if (islk2)
                    {
                        Lk2 lk2 = new Lk2();
                        if (lk2.SqlLk(conectionstring, innais))
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch,
                                PrintSnu.NotLk2);
                        }
                        else
                        {
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 90);
                            AutoItX.WinWait(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1], 2);
                            if (AutoItX.WinExists(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1]) == 1)
                            {
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch,
                                    PrintSnu.ErrorElectronSys[1]);
                                AutoItX.Send(ButtonConstant.Enter);
                            }
                            else
                            {
                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, innais, PrintSnu.Woked);
                                Process.ProcessLibary.Process("FoxitPhantom.exe", 12000);
                            }
                        }
                    }
                    else
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 90);
                        AutoItX.WinWait(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1], 2);
                        if (AutoItX.WinExists(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1]) == 1)
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch,
                                PrintSnu.ErrorElectronSys[1]);
                            AutoItX.Send(ButtonConstant.Enter);
                        }
                        else
                        {
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, innais, PrintSnu.Woked);
                            Process.ProcessLibary.Process("FoxitPhantom.exe", 12000);
                        }
                    }

                    AutoItX.ControlFocus(Mode.Okp4.PrintSnu.PrintSnuControl.GridText[0], "",
                        Mode.Okp4.PrintSnu.PrintSnuControl.GridText[1]);
                    AutoItX.Send(ButtonConstant.Tab);
                    listinn.Add(innais); //���������� �������� � ������
                    copyinn = innais;
                }
            }
        }

        /// <summary>
        /// ������������� ����� 
        /// ��������� �����������������\��� ��\1. ��� �� (��). ����������� � ���������� ����, ��������� � ��� ��\2.01. ��. ���������� ���������
        /// </summary>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">���� � �����������</param>
        /// <param name="fid">��� ��������</param>
        public void Click8(string pathjurnalerror, string pathjurnalok, string fid)
        {
            AutoItX.WinActivate(WindowsAis3.AisNalog3);
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fid);
            AutoItX.Send(ButtonConstant.Right6);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.F5);
            AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.FidText, 5000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ActualStatus,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.FidText) == 1)
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 435, win.WindowsAis.Y + 95);
                    AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.StateSved);
                    if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.StateSved) == 1)
                    {
                        AutoItX.WinActivate(WindowsAis3.AisNalog3);
                        AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox[0], StatusReg.ComboBox[1]);
                        AutoItX.Send(StatusText.IsklFl);
                        AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox1[0], StatusReg.ComboBox1[1]);
                        AutoItX.Send(StatusText.IsklFlError);
                        AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1]);
                        AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1],
                            DateTime.Now.ToString("d"));
                        AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1]);
                        AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1],
                            DateTime.Now.ToString("d"));
                        AutoItX.ControlClick(WindowsAis3.AisNalog3, StatusReg.ButtonSelect[0],
                            StatusReg.ButtonSelect[1]);
                        while (true)
                        {
                            if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                            {
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.Sleep(2000);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 435,
                                    win.WindowsAis.Y + 95);
                                AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.StateSved);
                                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.StateSved) == 1)
                                {
                                    AutoItX.WinActivate(WindowsAis3.AisNalog3);
                                    AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox[0],
                                        StatusReg.ComboBox[1]);
                                    AutoItX.Send(StatusText.VkllFl);
                                    AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateStatus[0],
                                        StatusReg.DateStatus[1]);
                                    AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateStatus[0],
                                        StatusReg.DateStatus[1], DateTime.Now.ToString("d"));
                                    AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateActual[0],
                                        StatusReg.DateActual[1]);
                                    AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateActual[0],
                                        StatusReg.DateActual[1], DateTime.Now.ToString("d"));
                                    AutoItX.ControlClick(WindowsAis3.AisNalog3, StatusReg.ButtonSelect[0],
                                        StatusReg.ButtonSelect[1]);
                                    AutoItX.WinWait(StatusText.DialogWin[0], StatusText.DialogWin[1], 5000);
                                    if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                                    {
                                        AutoItX.Send(ButtonConstant.Enter);
                                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid,
                                            StatusText.FidOk);
                                        AutoItX.Sleep(2000);
                                        win.ControlGetPos1(WindowsAis3.ControlPanel[0], WindowsAis3.ControlPanel[1],
                                            WindowsAis3.ControlPanel[2]);
                                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 85,
                                            win.WindowsAis.Y + win.Y1 + 10, 2);
                                        break;
                                    }
                                }
                            }

                            if (AutoItX.WinExists(StatusText.ErrorStateWin[0], StatusText.ErrorStateWin[1]) == 1)
                            {
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.Sleep(2000);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ActualStatus,
                                    StatusText.FidError);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                    win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                break;
                            }
                        }
                    }
                }

                break;
            }
        }

        /// <summary>
        /// ������������� ����� 
        /// ��������� �����������������\���������������� ���� ������������������\15.02.02. ���������. ����������� �����������\ ���������� ����\15.02.02.01. ���������. ����������� �����������. ���������� ����
        /// </summary>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">���� � �����������</param>
        /// <param name="fid">��� ��������</param>
        public void Click9(string pathjurnalerror, string pathjurnalok, string fid)
        {
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fid);
            AutoItX.Send(ButtonConstant.Down1);
            AutoItX.Send(ButtonConstant.Right6);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.F5);
            AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.FidTextFace, 5000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, TechnicalUpdate,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.FidTextFace) == 1)
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 540, win.WindowsAis.Y + 100);
                    AutoItX.WinWait(StatusText.DialogWin[0], StatusText.DialogWin[1], 5000);
                    if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                    {
                        AutoItX.Send(ButtonConstant.Enter);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, StatusText.FidOk);
                        AutoItX.Sleep(3000);
                        win.ControlGetPos1(WindowsAis3.ControlPanel[0], WindowsAis3.ControlPanel[1],
                            WindowsAis3.ControlPanel[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 85,
                            win.WindowsAis.Y + win.Y1 + 10, 2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// ��������� ��������
        /// </summary>
        /// <param name="statusButton">������</param>
        public void Click10(StatusButtonMethod statusButton)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(RashetBudElementName.DateGrid);
            var addObjectPl = new AddObjectDb();
            RegxStart regStart = new RegxStart();
            var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("List"));
            var listNotNull = listMemo.Where(elem => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                         libraryAutomation.SelectAutomationColrction(elem)
                                                             .Cast<AutomationElement>().First(elemMemo =>
                                                                 elemMemo.Current.Name.Contains(
                                                                     "����� ���������� ��������� (3)"))) != ""
                                                     && libraryAutomation.GetColorPixel(libraryAutomation
                                                         .SelectAutomationColrction(elem)
                                                         .Cast<AutomationElement>().First(elemMemo =>
                                                             elemMemo.Current.Name.Contains("��������� ���������"))) !=
                                                     "e79621").ToArray();
            foreach (var automationElement in listNotNull)
            {
                if (statusButton.Iswork)
                {
                    var kbkOnKbk = new ModelKbkOnKbk();
                    automationElement.SetFocus();

                    kbkOnKbk.IdDoc = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("����� ���������� ��������� (3)"))));

                    kbkOnKbk.InnPayer = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("��� ����������� (60)"))).Trim();

                    kbkOnKbk.KbkIfns = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� (104)")));

                    kbkOnKbk.Kbk100Before = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name == "���"));

                    kbkOnKbk.Oktmo105 = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("����� (�����) (105)")));

                    kbkOnKbk.OktmoUfk = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name == "����� (�����)"));


                    kbkOnKbk.TpPayerBefore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("��������� ������� (106)")));

                    kbkOnKbk.StatusPayerBefore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("��� ������� (110)")));

                    kbkOnKbk.Payment = Convert.ToDecimal(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����� (7)"))));

                    kbkOnKbk.InnBank = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("��� ���������� (61)")));

                    kbkOnKbk.KppBank = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("��� ���������� (103)")));

                    if ((String.IsNullOrWhiteSpace(kbkOnKbk.Oktmo105) ||
                         Regex.Matches(kbkOnKbk.Oktmo105, @"(0{6})").Count > 0) ||
                        (String.IsNullOrWhiteSpace(kbkOnKbk.OktmoUfk) ||
                         Regex.Matches(kbkOnKbk.OktmoUfk, @"(0{6})").Count > 0))
                    {
                        kbkOnKbk.StatusError = "#E80A0A";
                        kbkOnKbk.Conclusion = "�������� ��������� �� �������� ���� ��������� �����!!!";
                        addObjectPl.AddModelKbkOnKbk(kbkOnKbk);
                    }
                    else
                    {
                        PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.StartUtoch);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(RashetBudElementName.WindowsStartYes, null, true) !=
                                null)
                            {
                                libraryAutomation.ClickElements(RashetBudElementName.WindowsStartYes, null, true);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(RashetBudElementName.SendKbk, null, true) !=
                                        null)
                                    {
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        if (regStart.UseNalog(libraryAutomation, kbkOnKbk))
                        {
                            PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                RashetBudElementName.Utverjdenie);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(RashetBudElementName.WinUtoch, null, true) !=
                                    null)
                                {
                                    libraryAutomation.ClickElements(RashetBudElementName.WinUtoch, null, true);
                                    break;
                                }
                            }

                            kbkOnKbk.StatusError = "#50D413";
                            kbkOnKbk.Conclusion = "��������� ��������� �������!!!";
                            addObjectPl.AddModelKbkOnKbk(kbkOnKbk);
                        }
                        else
                        {
                            //����� �� ���������
                            PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                RashetBudElementName.ButtonNotUtoch);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(RashetBudElementName.WinNotUtoch, null, true) !=
                                    null)
                                {
                                    libraryAutomation.ClickElements(RashetBudElementName.WinNotUtoch, null, true);
                                    break;
                                }
                            }

                            kbkOnKbk.StatusError = "#E80A0A";
                            kbkOnKbk.Conclusion = "�� ������� ��� � �� ������ �� ����������!!!";
                            addObjectPl.AddModelKbkOnKbk(kbkOnKbk);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ������� ��������� �������� ��
        /// </summary>
        /// <param name="statusButton">������ �������� ������</param>
        /// <param name="select">������� ������</param>
        /// <param name="reportMigration">���� � ������ �������� ��������</param>
        /// <param name="code">��� ���������� ������</param>
        /// <param name="collectionException">����������� ���</param>
        public void Click11(StatusButtonMethod statusButton, SelectVibor select, string reportMigration, string code,
            ObservableCollection<string> collectionException)
        {
            var rowNumber = 1;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.SendParameter(string.Concat(Migration.GridPanel, 1), "10");
            libraryAutomation.SendParameter(
                @select.Sel.Num == 1 ? string.Concat(Migration.GridPanel, 17) : string.Concat(Migration.GridPanel, 16),
                code);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, Migration.UpdateGrid);
            PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Migration.GridData);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(string.Concat(Migration.GridDataRow, rowNumber), null, true,
                           30)) != null)
            {
                automationElement.SetFocus();
                if (statusButton.Iswork)
                {
                    MigrationParse model = new MigrationParse() {ReportMigration = new ReportMigration[1]};
                    ReportMigration report = new ReportMigration
                    {
                        NameOrg = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("������������/��� ��"))),
                        Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��"))),
                        Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��"))),
                        Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��")))
                    };
                    report.CodeIfns = select.Sel.Num == 1
                        ? libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("�� ���������� ������")))
                        : libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("�� ����������� ������")));
                    var find = collectionException.Where(i => i == report.Inn);
                    if (!find.Any())
                    {
                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Migration.ViewProcess);
                        while (true)
                        {
                            AutomationElement automationElementError;
                            if ((automationElementError =
                                    libraryAutomation.IsEnableElements(Migration.PathFullError, null, true)) != null)
                            {
                                report.Date = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElementError)
                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�����")));

                                report.Stage = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElementError)
                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����")));
                                report.Problem = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElementError)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("�������")));
                                model.ReportMigration[0] = report;
                                LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateReportMigration(reportMigration, model);
                                WindowsAis3 win = new WindowsAis3();
                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                    win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }

                AutoItX.Sleep(1000);
                rowNumber++;
            }
        }

        /// <summary>
        /// ��������� ������ ��������� �����������������\�������������\14. ������ � ������ � ����������������� ��������, �� ������� ��������� ���������� ���������\01. ��������� - ��, �� ������� ���������  ����������  ������������� � �������� ��� ���
        /// ��������� �����������������\�������������\14. ������ � ������ � ����������������� ��������, �� ������� ��������� ���������� ���������\11. ��������� � ������� �� ��������� ��, �� ������� �������� �������� �� ���������� ������������ � ��� �� ���� �� ��
        /// </summary>
        /// <param name="idvisual">�� ���������</param>
        /// <param name="pathjurnalerror">���� � ������� � ��������</param>
        /// <param name="pathjurnalok">���� � ������� � �������������</param>
        /// <param name="ischeked">���������� �������</param>
        /// <param name="isbranch">��������� ����� 11</param>
        public void Click12(string idvisual, string pathjurnalerror, string pathjurnalok, bool ischeked, bool isbranch)
        {

            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            if (ischeked)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 362,
                    win.WindowsAis.Y + win.Y1 + 50);
            }

            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(idvisual);
            AutoItX.Send(ButtonConstant.Down1);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, idvisual, FaceRosreestr,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if ((AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdVisual) == 1) ||
                    (AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdVisualTs) == 1))
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330, win.WindowsAis.Y + 90);
                    AutoItX.Send(ButtonConstant.Down1);
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.WinWait(WindowsAis3.AisNalog3, WindowsAis3.WinWait, 10);
                    if (AutoItX.WinExists(WindowsAis3.AisNalog3, WindowsAis3.WinWait) == 1)
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 655,
                            win.WindowsAis.Y + win.Y1 + 55);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                            win.WindowsAis.Y + win.Y1 + 35);
                        if (!isbranch)
                        {
                            AutoItX.Send(ButtonConstant.Down13);
                            AutoItX.Send(ButtonConstant.Right5);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.Send(ButtonConstant.Delete);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.Send(ButtonConstant.Down1);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.Send(ButtonConstant.Delete);
                            AutoItX.Send(ButtonConstant.Enter);
                        }

                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 95, win.WindowsAis.Y + 40);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 240, win.WindowsAis.Y + 80);
                        while (true)
                        {
                            if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                            {

                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                    win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, idvisual,
                                    FaceRosreestr, WindowsAis3.DataNotFound);
                                break;
                            }

                            if (AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdFl) == 1)
                            {
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330,
                                    win.WindowsAis.Y + 80);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(IdFace.WinInfo[0], IdFace.WinInfo[1]);
                                if (AutoItX.WinExists(IdFace.WinInfo[0], IdFace.WinInfo[1]) == 1)
                                {
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    break;
                                }
                            }
                        }

                        AutoItX.Send(ButtonConstant.F3);
                        break;
                    }
                }
            }

        }

        ///  <summary>
        /// ������������ ����� 
        /// ����� �������\����������� ������ (��������� ��������)\��������� ���������� ���\������������� ����� ����������
        /// </summary>
        public string Click13()
        {
            int i = 0;
            WindowsAis3 win = new WindowsAis3();
            AutoItX.Sleep(2000);
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                    win.WindowsAis.Y + win.Y1 + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, NboText.TitelList, 15);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, NboText.TitelList) == 1)
                {
                    break;
                }

                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }

                i++;
            }

            //�����������
            win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 45,
                win.WindowsAis.Y + win.Y1 + 80);
            AutoItX.WinWait(WindowsAis3.AisNalog3, NboText.TitelList, 15);
            while (true)
            {
                AutoItX.WinWait(NboText.Protokol[0], NboText.Protokol[1], 2);
                var texthieden = ReadWindow.Read.Reades.HidenTextReturn(WindowsAis3.AisNalog3);
                if (AutoItX.WinExists(NboText.Protokol[0], NboText.Protokol[1]) == 1)
                {
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                        win.WindowsAis.Y + 160);
                    break;
                }

                if (AutoItX.WinExists(NboText.TitleError2[0], NboText.TitleError2[1]) == 1)
                {
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                        win.WindowsAis.Y + 160);
                    break;
                }

                if (texthieden.Contains(NboText.Strfind) || texthieden.Contains(NboText.Strfind2))
                {
                    win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 815,
                        win.WindowsAis.Y + win.Y1 + 80);
                    while (true)
                    {

                        if (AutoItX.WinExists(NboText.TitleOk[0], NboText.TitleOk[1]) == 1)
                        {
                            AutoItX.WinActivate(NboText.TitleOk[0]);
                            AutoItX.Send(ButtonConstant.Enter);
                            break;
                        }

                        if (AutoItX.WinExists(NboText.TitleError[0], NboText.TitleError[1]) == 1)
                        {
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                                win.WindowsAis.Y + 160);
                            break;
                        }
                    }

                    break;
                }
            }

            //������� � ����
            return Status.StatusAis.Status3;
        }

        ///  <summary>
        /// ������������ ����� 
        /// ����� �������\����������� ������ ��������� ��������\���������� ���������� ������� ���������������\���������� ���
        /// </summary>
        public string Click14(bool coordinete, string pathjurnalerror, string pathjurnalok)
        {
            int i = 0;
            UsnText usn = new UsnText();
            usn.Coordinate(coordinete);
            WindowsAis3 win = new WindowsAis3();
            CardDeclr card = new CardDeclr();
            AutoItX.Sleep(2000);
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                    win.WindowsAis.Y + win.Y1 + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, UsnText.ElemHost, 15);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, UsnText.ElemHost) == 1)
                {
                    break;
                }

                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }

                i++;
            }

            while (true)
            {

                win.ControlGetPos1(UsnText.WinSnr[0], UsnText.WinSnr[1], UsnText.WinSnr[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 790,
                    win.WindowsAis.Y + win.Y1 + usn.IsOpen);
                AutoItX.WinWait(WindowsAis3.AisNalog3, UsnText.TitleUsn, 15);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, UsnText.TitleUsn) == 1)
                {
                    AutoItX.Send(ButtonConstant.Down1);
                    card.Id = ReadWindow.Read.Reades.ReadCtrlC();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 45, win.WindowsAis.Y + 86);
                    AutoItX.Sleep(2000);
                    AutoItX.Send(ButtonConstant.Right1);
                    card.Error = ReadWindow.Read.Reades.ReadCtrlCno();
                    AutoItX.Send(ButtonConstant.Right1);
                    card.DescriptionError = ReadWindow.Read.Reades.ReadCtrlCno();
                    if (card.Error == "������")
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, card.Id, Usn,
                            card.DescriptionError);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                            win.WindowsAis.Y + 160);
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                            win.WindowsAis.Y + 160);
                        AutoItX.WinWait(UsnText.UserWork[0], UsnText.UserWork[1], 5);
                        AutoItX.Send(ButtonConstant.Enter);
                        break;
                    }
                    else
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 120, win.WindowsAis.Y + 80);
                        AutoItX.WinWaitClose(WindowsAis3.AisNalog3, UsnText.TitleUsn, 15);
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 170,
                            win.WindowsAis.Y + win.Y1 + usn.Sender);
                        AutoItX.WinWait(UsnText.VvodVxod[0], UsnText.VvodVxod[1], 15);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.Sleep(3000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 160,
                            win.WindowsAis.Y + win.Y1 + usn.Finish);
                        AutoItX.Sleep(3000);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, card.Id, "���������� ��� ������!!!");
                        break;
                    }
                }
            }

            return Status.StatusAis.Status3;
        }

        /// <summary>
        /// ������������� ���������� ������ ������ ��� �����
        /// </summary>
        /// <param name="statusButton">������ ��� ������������</param>
        /// <param name="pathJournalOk">���� � ����������</param>
        /// <param name="dataPickerSettings">��������� ��� ��������</param>
        public void Click15(StatusButtonMethod statusButton, string pathJournalOk,
            DataPickerRuleItModel dataPickerSettings)
        {
            string dates = null;
            UserRules userRule = new UserRules();
            int j = 0;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksCountRow);
            libraryAutomation.SetValuePattern(dataPickerSettings.CountRow);
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksDbStart);
            libraryAutomation.SetValuePattern(dataPickerSettings.DateStart.ToString("dd.MM.yyyy"));
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksDbFinish);
            libraryAutomation.SetValuePattern(dataPickerSettings.DateFinish.ToString("dd.MM.yyyy"));
            libraryAutomation.ClickElements(PublicElementName.UpdateButton);
            var i = 1;
            libraryAutomation.IsEnableElement(ItElementName.Grid);
            while (libraryAutomation.IsEnableElements(string.Concat(ItElementName.GridJournalRows, i)) != null)
            {
                i++;
                if (statusButton.Iswork)
                {
                    var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                    foreach (AutomationElement element in listMemo)
                    {
                        if (element.Current.Name == "����")
                        {
                            dates = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(element);
                        }

                        if (element.Current.Name == "�����")
                        {
                            libraryAutomation.FindFirstElement(PublicElementName.ViewButton);
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            libraryAutomation.IsEnableElement(ItElementName.HistoryJournal);
                            var historyJournals = libraryAutomation
                                .SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>()
                                .Where(elem => elem.Current.Name.Contains("List"));
                            foreach (var history in historyJournals)
                            {
                                var historyRule = libraryAutomation.SelectAutomationColrction(history);
                                if (historyRule.Cast<AutomationElement>()
                                    .Any(elem => elem.Current.Name.Contains("Appointments")))
                                {
                                    userRule.User = new User[1];
                                    userRule.User[0] = new User
                                    {
                                        Dolj = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Doljnost)),
                                        Fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Name)),
                                        Otdel = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Department)),
                                        SysName = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Logon)),
                                        Number =
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(element),
                                        Dates = dates
                                    };
                                    var listHistory = historyRule.Cast<AutomationElement>()
                                        .Where(elem => elem.Current.Name.Contains("Appointments"));
                                    foreach (AutomationElement rule in listHistory)
                                    {
                                        //��������� ������ ����� ������������
                                        var allElements = libraryAutomation.SelectAutomationColrction(rule);
                                        foreach (var rules in allElements.Cast<AutomationElement>())
                                        {
                                            if (userRule.User[0].Rule == null)
                                            {
                                                userRule.User[0].Rule = new Rule[listHistory.Count()];
                                            }

                                            if (userRule.User[0].Rule[j] == null)
                                            {
                                                userRule.User[0].Rule[j] = new Rule();
                                            }

                                            //������ �����
                                            var valueless = libraryAutomation
                                                .ParseElementLegacyIAccessiblePatternIdentifiers(rules);
                                            switch (rules.Current.Name)
                                            {
                                                case "������������":
                                                    userRule.User[0].Rule[j].Name = valueless;
                                                    break;
                                                case "���":
                                                    userRule.User[0].Rule[j].Types = valueless;
                                                    break;
                                                case "��������":
                                                    userRule.User[0].Rule[j].Pushed = valueless;
                                                    break;
                                                case "���� ������":
                                                    userRule.User[0].Rule[j].DateStart = valueless;
                                                    break;
                                                case "���� ���������":
                                                    userRule.User[0].Rule[j].DateFinish = valueless;
                                                    break;
                                                case "��������":
                                                    userRule.User[0].Rule[j].Context = valueless;
                                                    break;
                                            }
                                        }

                                        j++;
                                    }
                                }

                                libraryAutomation.FindFirstElement(PublicElementName.BackButton);
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                break;
                            }

                            j = 0;
                            break;
                        }
                    }

                    LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileRule(pathJournalOk, userRule);
                    userRule.User = null;
                }
                else
                {
                    break;
                }

                AutoItX.Send(ButtonConstant.Tab);
            }
        }

        ///  <summary>
        /// ������������� �����
        /// ����� �������\�������������� �������������\05.09 ����������� � ������������� �������� ���������� � ��\05.09 ��������� � �������� ������� � ������ (��������) ���������� �������� � ��
        /// </summary>
        /// <param name="pathJournalError">���� � ������� ���������</param>
        /// <param name="pathJournalOk">���� � ������� ������������</param>
        public string Click16(string pathJournalError, string pathJournalOk)
        {
            int i = 0;
            WindowsAis3 win = new WindowsAis3();
            while (true)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 355, win.WindowsAis.Y + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, SluzZ.WinLk, 10);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, SluzZ.WinLk) == 1)
                {
                    break;
                }

                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }

                i++;
            }

            if (AutoItX.WinExists(WindowsAis3.AisNalog3, SluzZ.WinLk) == 1)
            {
                AutoItX.Sleep(500);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 250, win.WindowsAis.Y + 80);
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 580, win.WindowsAis.Y + 80);
                AutoItX.WinWait(SluzZ.WinClose[0], SluzZ.WinClose[1]);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.Sleep(1000);
            }

            return "����������!!!";
        }

        /// <summary>
        /// ��������� ������� ����������
        /// 05.08.03.0X.03. ����������� ���������� �� ������
        /// </summary>
        /// <param name="statusButton">������ ������� ����� ����������</param>
        /// <returns></returns>
        public void Click17(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(SettlementDebts.JournalDocuments, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.IsEnableElements(SettlementDebts.SumT, elemental);
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartBeforeQ);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    libraryAutomationCheck.IsEnableElements(SettlementDebts.JournalSum, null, true);
                    var isChecked = false;
                    while (true)
                    {
                        if (isChecked)
                        {
                            if (libraryAutomation.IsEnableElements(SluzZ.WinErrorNalog, null, false, 5) != null)
                            {
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                libraryAutomation.ClickElements(SettlementDebts.ButtonSettlement);
                            }

                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSettlement) == null) continue;
                        libraryAutomation.ClickElements(SettlementDebts.ButtonSettlement);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SluzZ.WinCloseNalog, null, false, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSend, null, false, 1) == null)
                            continue;
                        libraryAutomation.ClickElements(SettlementDebts.ButtonSend);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ��������� ���������� ����������� ����������
        /// </summary>
        /// <param name="statusButton">������ ������� ����� ����������</param>
        /// <param name="pathJournalOk">���� ���������� ������������</param>
        public void Click18(StatusButtonMethod statusButton, string pathJournalOk)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elementAuto;
            while ((elementAuto =
                       libraryAutomation.IsEnableElements(RegistrationElementName.JurnalsDocumentsFirstElement, null,
                           true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.IsEnableElements(RegistrationElementName.Doc, elementAuto);
                    libraryAutomation.FindElement.SetFocus();
                    var id = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .FindElement);
                    libraryAutomation.FindFirstElement(RegistrationElementName.IsErrorDocument);
                    var clickPoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint.X, (int) clickPoint.Y);
                    libraryAutomation.IsEnableElements(RegistrationElementName.Qweshions);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsCreate);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsOk);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsCancel);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.Qweshions);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.WinOk);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, id,
                        "���������� �� ��������� ��� ������");
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ���������� ������� �������������� ������������� 05.08.10.01.0X.02 ���������� �������.
        /// </summary>
        /// <param name="statusButton">������ �������</param>
        /// <param name="pathJournalOk">���� � ������������ ���������</param>
        public void Click19(StatusButtonMethod statusButton, string pathJournalOk)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while (libraryAutomation.IsEnableElements(UregulirovanieElementName.JurnalsUserOperationSpravki) != null)
            {
                if (statusButton.Iswork)
                {
                    var clickRows = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� �������"))
                        .GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickRows.X, (int) clickRows.Y);
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var clickPoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint.X, (int) clickPoint.Y);
                    AutoItX.WinWait("��� �����-3 ���� ", "���:");
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.InnResh));
                    var fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.FioResh));
                    var sum = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.SummResh));
                    libraryAutomation.IsEnableElements(UregulirovanieElementName.SaveUser);
                    var clickPoint1 = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint1.X, (int) clickPoint1.Y);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SendSenderZadoljenost, null,
                                true, 1) != null)
                        {
                            var clickPoint2 = libraryAutomation.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint2.X, (int) clickPoint2.Y);
                        }
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"{sum} {inn} {fio}",
                        "���������� ���������� ������� � ��������� �������� � ������������� ������������ � ���������");
                }
                else
                {
                    break;
                }
            }
        }


        /// <summary>
        /// ���������� ������� �������������� ������������� 05.08.10.01.0X.02 ���������� �������.
        /// </summary>
        /// <param name="statusButton">������ �������</param>
        /// <param name="pathJournalOk">���� � ������������ ���������</param>
        public void Click20(StatusButtonMethod statusButton, string pathJournalOk)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);

            while (libraryAutomation.IsEnableElements(UregulirovanieElementName.JurnalsUserOperationSpravki) != null)
            {
                if (statusButton.Iswork)
                {
                    var clickRows = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� �������"))
                        .GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickRows.X, (int) clickRows.Y);
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var clickPoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint.X, (int) clickPoint.Y);
                    AutoItX.WinWait("��� �����-3 ���� ", "���:");
                    var num = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.Number));
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.Inn));
                    var fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.Fio));
                    libraryAutomation.IsEnableElements(UregulirovanieElementName.SaveUser);
                    AutoItX.Sleep(500);
                    var clickPoint1 = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint1.X, (int) clickPoint1.Y);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SendSender, null, true, 1) !=
                            null)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SaveProject, null, true, 1) !=
                            null)
                        {
                            var clickPoint2 = libraryAutomation.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint2.X, (int) clickPoint2.Y);
                        }
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOkExeptions, null, true,
                                1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SendSender, null, true, 1) !=
                            null)
                        {
                            var clickPoint3 = libraryAutomation.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint3.X, (int) clickPoint3.Y);
                        }
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"{num} {inn} {fio}",
                        "���������� ���������� ������� � ������ ��������");
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ��������� �����������������\���������� � ������� �����\06. ������� �������� ������ ��\01. ���������� ������ ��������� �����
        /// </summary>
        /// <param name="id">��� ��������</param>
        /// <param name="pathJournalError">������ ������</param>
        /// <param name="pathJournalOk">������ ���������</param>
        public void Click21(string id, string pathJournalError, string pathJournalOk)
        {
            WindowsAis3 win = new WindowsAis3();
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(id);
            AutoItX.Send(ButtonConstant.Down3);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            while (true)
            {
                if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.UpdateButton, null, false, 1))
                {
                    if (libraryAutomation.IsEnableElements(
                            RegistrationElementNameVisualBank.JurnalsDocumentsFirstElementBank, null, true) != null)
                    {
                        libraryAutomation.FindElement.SetFocus();
                        if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.Identification, null,
                            false, 5))
                        {
                            while (true)
                            {
                                if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank
                                    .StartIdentification))
                                {
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(RegistrationElementNameVisualBank.WinOk,
                                                null, true, 1) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        }

                                        if (libraryAutomation.IsEnableElements(
                                                RegistrationElementNameVisualBank.WinOkEnd, null, true, 1) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            if (libraryAutomation.ClickElements(
                                                RegistrationElementNameVisualBank.Return))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathJournalError, id, VisualBank,
                                        "�� ������ ���������������� ����. ���� �� �������!");
                                    libraryAutomation.ClickElements(RegistrationElementNameVisualBank.ReturnList, null,
                                        false, 10);
                                    if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.Return, null,
                                        false, 10))
                                    {
                                        return;
                                    }
                                }

                                break;
                            }

                            break;
                        }
                    }
                    else
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathJournalError, id, VisualBank,
                            "�� ������� �������� ��� �������������");
                        if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.Return, null, false, 10))
                        {
                            return;
                        }
                    }
                }
            }

            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, id, "���������� ������������� �������!");
        }

        /// <summary>
        /// ��������� �����������������\�������������� �������������\���������� �� ������\������ ���������� �� ������
        /// ������������ ���������� � �������� +3 ��� �� ������
        /// </summary>
        /// <param name="statusButton">������ ���������</param>
        /// <param name="pathJournalError">������ ������</param>
        /// <param name="pathJournalOk">������ ������������</param>
        public void Click22(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(Trebovanie.JurnalsTrebovanie);
            var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row"));
            foreach (var automationElement in listMemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    var valueDate = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���� ��")));

                    var valueNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����� ��")));

                    var valueInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));

                    var valueTypeNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��������� ��")));

                    var valueStatusEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("������ ��������")));

                    libraryAutomation.ClickElements(Trebovanie.ListPanel);
                    if (libraryAutomation.ClickElements(Trebovanie.Open, null, false, 5))
                    {
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Trebovanie.Save) != null)
                            {
                                libraryAutomation.ClickElements(Trebovanie.TabIfo, null, false, 10);
                                libraryAutomation.SelectItemCombobox(
                                    libraryAutomation.IsEnableElements(Trebovanie.ComboBoxSelect), "�������");
                                var dateVAdd = Convert.ToDateTime(valueDate).AddDays(valueTypeNp == "��" ? 5 : 3);
                                if (dateVAdd.DayOfWeek == DayOfWeek.Saturday)
                                    dateVAdd = dateVAdd.AddDays(2);
                                if (dateVAdd.DayOfWeek == DayOfWeek.Sunday)
                                    dateVAdd = dateVAdd.AddDays(1);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Date) == null) continue;
                                    libraryAutomation.SetValuePattern(dateVAdd.ToString("dd.MM.yy"));
                                    var date = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.FindElement);
                                    if (date != "")
                                    {
                                        break;
                                    }
                                }

                                //������ �������� ���������� �������
                                //if (valueStatusEnd != "���������� �������" & valueTypeNp == "��")
                                //{
                                libraryAutomation.SelectItemCombobox(
                                    libraryAutomation.IsEnableElements(Trebovanie.ComboboxSend), "���������� �������");
                                //}
                                //if (valueStatusEnd != "�� ������� ���" & valueTypeNp != "��")
                                //{
                                //    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboboxSend),"�� ������� ���");
                                //}
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Save) == null) continue;
                                    libraryAutomation.ClickElements(Trebovanie.Save);
                                    break;
                                }

                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Back) == null) continue;
                                    libraryAutomation.ClickElements(Trebovanie.Back);
                                    break;
                                }

                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                    $"����� ��: {valueNumber}; ��� ����:{valueTypeNp} ���� ��: {valueDate}; ���� ��������: {dateVAdd}; ��� �����������������: {valueInn}",
                                    "���������� �������� �������!");
                                break;
                            }

                            if (libraryAutomation.IsEnableElements(Trebovanie.Back) != null)
                            {
                                //������ ���� ��� ��������� �� ��������
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathJournalError, valueNumber,
                                    LogTreb, "�� ������� ������ ���������!");
                                libraryAutomation.ClickElements(Trebovanie.Back, null, false, 10);
                                break;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// �������������� �������������/05.09 ����������� � ������������� �������� ���������� � ��\
        /// 05.09 ��������� � �������� ������� �� ������  ���������� �������� � ��
        /// </summary>
        /// <param name="statusButton">������ ���������</param>
        /// <param name="pathJournalError">������ ������</param>
        /// <param name="pathJournalOk">������ ������������</param>
        public void Click23(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(RecouncementLk.JurnalsRecouncement, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(RecouncementLk.RowInn, elemental));
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    var isChecked = "";
                    while (true)
                    {
                        if (isChecked == "" || string.IsNullOrWhiteSpace(isChecked))
                        {
                            isChecked = libraryAutomationCheck.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomationCheck.IsEnableElements(RecouncementLk.CheckDataLk2));
                            if (isChecked != "") break;
                        }

                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckStatusLk2) == null) continue;
                        libraryAutomation.ClickElements(RecouncementLk.CheckStatusLk2);
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(RecouncementLk.WinOkEndUser, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckExit, null, true) == null) continue;
                        libraryAutomation.ClickElements(RecouncementLk.CheckExit);
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                        $"��� �����������������: {inn}; ���� ��������: {isChecked}",
                        "���������� ������� �������� � �� �������!");
                }
                else
                {
                    break;
                }
            }

        }

        /// <summary>
        /// ����� �������\�������������� �������������\05.08.09.02. ��������� ������������� �� ���� ��������� �� ��. ������������ 
        /// ��������� ������� � ��������� � ��������� �� ���� ��������� ��
        /// \05.08.09.02.03 ����������� � ���������� ��������� � ��������� �� ���� ��������� ��
        /// \05.08.09.02.03.06. ������� �������������� ��������� � ��������� �� ���� ��������� ��
        /// </summary>
        /// <param name="statusButton">������ ���������</param>
        /// <param name="pathJournalError">������ ������</param>
        /// <param name="pathJournalOk">������ ������������</param>
        public void Click24(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(SignatureHeadProperty.JournalSignature, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    var isChecked = false;
                    while (true)
                    {
                        if (isChecked)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.ButtonSignatureAll) == null)
                            continue;
                        libraryAutomation.ClickElements(SignatureHeadProperty.ButtonSignatureAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.EndSignature, null, true) ==
                            null) continue;

                        var listMemo = libraryAutomation
                            .SelectAutomationColrction(
                                libraryAutomationCheck.IsEnableElements(SignatureHeadProperty.JoirnalAllSignature))
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listMemo)
                        {
                            var valuesInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("���")));
                            var valuesAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("�����")));
                            var valuesScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("�����")));
                            var valuesFio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem =>
                                        elem.Current.Name.Contains("��� �����������������")));

                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"��� �����������������: {valuesInn}; ��� ��: {valuesFio} �����: {valuesAddress}; �����: {valuesScore} ",
                                "��������� ������������� ������� �������!");
                        }

                        libraryAutomation.ClickElements(SignatureHeadProperty.EndSignature);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ������������� ����� �������\�������������� �������������\05.08.09.02.
        /// ��������� ������������� �� ���� ��������� �� ��.������������ ��������� ������� � ��������� � ��������� �� ���� ��������� ��\05.08.09.02.02 
        /// ����������� � ���������� ��������� �������\05.08.09.02.02.04. ����������� ��������� �������
        /// ������� ��� ����������� ��������� �������
        /// </summary>
        /// <param name="statusButton">������ ���������</param>
        /// <param name="pathJournalError">������ ������</param>
        /// <param name="pathJournalOk">������ ������������</param>
        public void Click25(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextStatementOfficeNote.JournalStatementOffice, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    var isChecked = false;
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    while (true)
                    {
                        libraryAutomation.IsEnableElements(TextStatementOfficeNote.IsCheck);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.TogglePattern(libraryAutomation.FindElement) == "On")
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        if (isChecked)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.ButtonIsCheckAll) == null)
                            continue;
                        libraryAutomation.ClickElements(TextStatementOfficeNote.ButtonIsCheckAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.Exit, null, true) == null)
                            continue;
                        var listMemo = libraryAutomation
                            .SelectAutomationColrction(
                                libraryAutomationCheck.IsEnableElements(TextStatementOfficeNote
                                    .JournalAllStatementOffice)).Cast<AutomationElement>()
                            .Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listMemo)
                        {
                            var valuesInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("���")));
                            var valuesAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("�����")));
                            var valuesScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("�����")));
                            var valuesFio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem =>
                                        elem.Current.Name.Contains("��� �����������������")));
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"��� �����������������: {valuesInn}; ��� ��: {valuesFio} �����: {valuesAddress}; �����: {valuesScore} ",
                                "����������� ������������� ��������� ������� ������ �������!");
                        }

                        libraryAutomation.ClickElements(TextStatementOfficeNote.Exit);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ������������� ����� �������\�������������� �������������\05.08.09.02. ��������� ������������� �� ���� ��������� �� ��. 
        /// ������������ ��������� ������� � ��������� � ��������� �� ���� ��������� ��\
        /// 05.08.09.02.02 ����������� � ���������� ��������� �������\05.08.09.02.02.06. ���������� ��������� �������
        /// </summary>
        /// <param name="statusButton">������ ���������</param>
        /// <param name="pathJournalError">������ ������</param>
        /// <param name="pathJournalOk">������ ������������</param>
        public void Click26(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    var isChecked = false;
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    while (true)
                    {
                        libraryAutomation.IsEnableElements(TextSignatureOfficeNote.IsCheck);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.TogglePattern(libraryAutomation.FindElement) == "On")
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        if (isChecked)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.ButtonIsCheckAll) == null)
                            continue;
                        libraryAutomation.ClickElements(TextSignatureOfficeNote.ButtonIsCheckAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.Exit, null, true) == null)
                            continue;
                        var listMemo = libraryAutomation
                            .SelectAutomationColrction(
                                libraryAutomationCheck.IsEnableElements(TextSignatureOfficeNote
                                    .JournalAllStatementOffice)).Cast<AutomationElement>()
                            .Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listMemo)
                        {
                            var valuesInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("���")));
                            var valuesAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("�����")));
                            var valuesScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("�����")));
                            var valuesFio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem =>
                                        elem.Current.Name.Contains("��� �����������������")));
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"��� �����������������: {valuesInn}; ��� ��: {valuesFio} �����: {valuesAddress}; �����: {valuesScore} ",
                                "���������� ������������� ��������� ������� ������ �������!");
                        }

                        libraryAutomation.ClickElements(TextSignatureOfficeNote.Exit);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ������� ��� ����� ��������� �����������������\����������� ������ (��������� ��������)\129. ��������� ��������������\2. ������ ��������� ��������������
        /// </summary>
        /// <param name="statusButton">������ �����</param>
        /// <param name="pathJournalOk">������</param>
        /// <param name="pathPdfTemp">���� � Temp</param>
        /// <param name="datePicker">���� ������ �����������</param>
        public void Click27(StatusButtonMethod statusButton, string pathJournalOk, string pathPdfTemp, DatePickerAdd datePicker)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var senderSelect = new SelectAll().SelectSenderJournal(Environment.UserName);
            if (senderSelect == null)
            {
                throw new InvalidOperationException($"������������ ������������� �������� �� ���������!");
            }

            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal, rowNumber), null, false, 50)) != null)
            {
                var taxFace = new TaxJournal();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    taxFace.LoginUser = Environment.UserName;
                    taxFace.IdDelo = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�� ����"))));
                    taxFace.DateError = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("���� ����������� ���������"))));
                    taxFace.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    taxFace.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    taxFace.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����")));
                    taxFace.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��")));
                    var status = libraryAutomation.SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>()
                        .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                        .First(elem => elem.Current.Name.Contains(""));
                    var color = libraryAutomation.GetColorPixel(status);
                    taxFace.Color = color;
                    AddObjectDb dbAutomation = null;
                    switch (color)
                    {
                        case "ff":
                            //������ ���� ����������
                            var listDocMemo = libraryAutomationDoc
                                .SelectAutomationColrction(
                                    libraryAutomationDoc.FindFirstElement(Journal129AndJournal121.DocAllJournal))
                                .Cast<AutomationElement>().Distinct()
                                .Where(elem => elem.Current.Name.Contains("select0 row"));

                            //������ ��� ��� ������� �����
                            var isActYellowAndGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("���"))) == "1160100" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000" ||
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "ffff00"
                            );

                            //����� ����������� �� ���������
                            var isIzvestia = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("���"))) == "1165213");

                            //������� ��� �����
                            var isActGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("���"))) == "1160100" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000"
                            );

                            //����� �������� ���������
                            var isIzvestiaGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("���"))) == "1165213" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000"
                            );

                            //���� �� ������� �������
                            var isReshenie = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("���"))) == "1165022"
                            );

                            //����������� ���������
                            if (isActYellowAndGreen != null && isIzvestia == null)
                            {
                                //��������� ����������� ��������� �� ���� ��� ������ ������
                                libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.Izveshenie);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.ButtonSved);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null,
                                            true) != null)
                                    {
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                        libraryAutomation.SetValuePattern("366.2");
                                        libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                        AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                        AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                        while (true)
                                        {
                                            if (libraryAutomation.IsEnableElements(
                                                    Journal129AndJournal121.WindowDateTime, null, true) != null)
                                            {
                                                taxFace.DateIzveshenie = datePicker.Date;
                                                libraryAutomation.SetValuePattern(datePicker.Date.ToString("dd.MM.yy"));
                                                libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                                libraryAutomation.SetValuePattern("10");
                                                libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowsOk);
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                                break;
                                            }
                                        }

                                        break;
                                    }
                                }

                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null,
                                            true) != null)
                                    {
                                        libraryAutomation.ClickElements(Journal129AndJournal121.FaceName, null, true);
                                        libraryAutomation.SelectItemCombobox(
                                            libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign),
                                            senderSelect);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                            Journal129AndJournal121.Save);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                            Journal129AndJournal121.SignAll);
                                        break;
                                    }
                                }

                                globalFunction.SignAndSendDoc(libraryAutomation);
                                taxFace.IsLk3 = globalFunction.IsLk3;
                                taxFace.IsMail = globalFunction.IsMail;
                                taxFace.IsTks = globalFunction.IsTks;
                                globalFunction.SendJournalClose();
                                taxFace.MessageInfo = "��������� ������� ����������!!!";
                                taxFace.TypeDocument = "���������";
                                globalFunction.AddFile(ref taxFace, pathPdfTemp);
                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                    $"���� ���������: 9 �� ����: {taxFace.IdDelo}; ���� ����������� ���������: {taxFace.DateError}; ��� �����������������: {taxFace.Inn}; ���: {taxFace.Kpp}; ������������: {taxFace.NameFace}; ���: {taxFace.Fid}; ���� �������� ���������: {taxFace.DateIzveshenie.Value.ToString("dd.MM.yy")} ���: {Convert.ToInt32(taxFace.IsTks)}; �����: {Convert.ToInt32(taxFace.IsMail)}; ��3: {Convert.ToInt32(taxFace.IsLk3)} ���� � ����� ���� ������:{taxFace.FullPath}",
                                    taxFace.MessageInfo);
                                dbAutomation = new AddObjectDb();
                                dbAutomation.AddTaxJournal(taxFace);
                            }
                            else
                            {
                                //����������� �������                            
                                if (isActGreen != null && isIzvestiaGreen != null && isReshenie == null)
                                {
                                    //��������� ������������ ��� � ��������� �������
                                    libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                        Journal129AndJournal121.OpenReshenia);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                        Journal129AndJournal121.Reshenia);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                        Journal129AndJournal121.PublicInfo);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia,
                                                null, true) != null)
                                        {
                                            taxFace.DateIzveshenie = datePicker.DateResh;
                                            libraryAutomation.SetValuePattern(datePicker.DateResh.ToString("dd.MM.yy"));
                                            while (true)
                                            {
                                                if (libraryAutomation.IsEnableElements(
                                                        Journal129AndJournal121.ResheniaFaceSignOpen, null, true) !=
                                                    null)
                                                {
                                                    libraryAutomation.ClickElements(
                                                        Journal129AndJournal121.ResheniaFaceSignOpen, null, true);
                                                    libraryAutomation.SelectItemCombobox(
                                                        libraryAutomation.IsEnableElements(Journal129AndJournal121
                                                            .ResheniaFaceSign), senderSelect, 0);
                                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                                        Journal129AndJournal121.Save);
                                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                                        Journal129AndJournal121.SignAll);
                                                    break;
                                                }
                                            }

                                            break;
                                        }
                                    }

                                    globalFunction.SignAndSendDoc(libraryAutomation);
                                    taxFace.IsLk3 = globalFunction.IsLk3;
                                    taxFace.IsMail = globalFunction.IsMail;
                                    taxFace.IsTks = globalFunction.IsTks;
                                    WindowsAis3 win = new WindowsAis3();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    AutoItX.Sleep(1000);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                        Journal129AndJournal121.OpenClosedComplex);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                        Journal129AndJournal121.ClosedComplex);
                                    taxFace.MessageInfo = "������� ������� ����������!!!";
                                    taxFace.TypeDocument = "�������";
                                    globalFunction.AddFile(ref taxFace, pathPdfTemp);
                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                        $"���� ���������: 9 �� ����: {taxFace.IdDelo}; ���� ����������� ���������: {taxFace.DateError}; ��� �����������������: {taxFace.Inn}; ���: {taxFace.Kpp}; ������������: {taxFace.NameFace}; ���: {taxFace.Fid}; ���� �������� �������: {taxFace.DateIzveshenie.Value.ToString("dd.MM.yy")} ���: {Convert.ToInt32(taxFace.IsTks)}; �����: {Convert.ToInt32(taxFace.IsMail)}; ��3: {Convert.ToInt32(taxFace.IsLk3)} ���� � ����� ���� ������:{taxFace.FullPath}",
                                        taxFace.MessageInfo);
                                    dbAutomation = new AddObjectDb();
                                    dbAutomation.AddTaxJournal(taxFace);
                                }
                            }

                            break;
                        case "ff0000":
                            libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                            PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                Journal129AndJournal121.EditTask);
                            PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                            globalFunction.SignAndSendDoc(libraryAutomation);
                            taxFace.IsLk3 = globalFunction.IsLk3;
                            taxFace.IsMail = globalFunction.IsMail;
                            taxFace.IsTks = globalFunction.IsTks;
                            globalFunction.SendJournalClose();
                            taxFace.MessageInfo = "��� ������� ���������!!!";
                            taxFace.TypeDocument = "���";
                            globalFunction.AddFile(ref taxFace, pathPdfTemp);
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"���� ���������: 12 �� ����: {taxFace.IdDelo}; ���� ����������� ���������: {taxFace.DateError}; ��� �����������������: {taxFace.Inn}; ���: {taxFace.Kpp}; ������������: {taxFace.NameFace}; ���: {taxFace.Fid}; ���: {Convert.ToInt32(taxFace.IsTks)}; �����: {Convert.ToInt32(taxFace.IsMail)}; ��3: {Convert.ToInt32(taxFace.IsLk3)}",
                                taxFace.MessageInfo);
                            dbAutomation = new AddObjectDb();
                            dbAutomation.AddTaxJournal(taxFace);
                            break;
                        default:
                            taxFace.MessageInfo = "���� ��������� �� ���������";
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"���� ���������: {color} �� ����: {taxFace.IdDelo}; ���� ����������� ���������: {taxFace.DateError}; ��� �����������������: {taxFace.Inn}; ���: {taxFace.Kpp}; ������������: {taxFace.NameFace}; ���: {taxFace.Fid}; ���: {Convert.ToInt32(taxFace.IsTks)}; �����: {Convert.ToInt32(taxFace.IsMail)}; ��3: {Convert.ToInt32(taxFace.IsLk3)}",
                                taxFace.MessageInfo);
                            dbAutomation = new AddObjectDb();
                            dbAutomation.AddTaxJournal(taxFace);
                            break;
                    }
                }
                else
                {
                    break;
                }

                rowNumber++;
            }
        }

        /// <summary>
        /// ��������� �����������������\����������� ������ (��������� ��������)\121. ����������� ��������� ��������\03. ������ ��������� ���������� (��������), �������� � ��� (���)
        /// </summary>
        /// <param name="statusButton">������ �����</param>
        /// <param name="pathPdfTemp">���� � Temp</param>
        /// <param name="datePicker">���� ������ �����������</param>
        public void Click28(StatusButtonMethod statusButton, string pathPdfTemp, DatePickerAdd datePicker)
        {
            Okp2ActAndSolutionAndNotification createActAndSolutionAndNotification =
                new Okp2ActAndSolutionAndNotification(pathPdfTemp);
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var senderSelect = new SelectAll().SelectSenderJournal(Environment.UserName);
            if (senderSelect == null)
            {
                throw new InvalidOperationException($"������������ ������������� �������� �� ���������!");
            }

            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
            PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
            {
                var journal = new TaxJournal121();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    journal.LoginUser = Environment.UserName;
                    journal.RegNumDeclaration = Convert.ToInt32(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem =>
                                elem.Current.Name.Contains("���. ����� ���������� (�������)"))));
                    journal.Period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�������� ������")));
                    journal.God = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�������� ���"))));
                    journal.Knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    journal.NameKnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��������")));

                    //������� � ������ 20.11.4.1 �� ��� 1151111
                    //journal.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    //    .SelectAutomationColrction(automationElement)
                    //    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��")));

                    journal.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����������������")));
                    journal.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    journal.IdComplex = Convert.ToInt32(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�� ���������"))));
                    journal.DateStartCheck = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("���� ������ ��������"))));
                    journal.DateFinishCheck = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("���� �������� �� ����������"))));
                    var dateEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��������� �����")));
                    journal.DateFinishKnp = string.IsNullOrWhiteSpace(dateEnd)
                        ? (DateTime?) null
                        : Convert.ToDateTime(dateEnd);
                    journal.DateStartDeclaration = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("���� ������������� ����������"))));
                    journal.DateFinishDeclaration = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("����  ������������� ����������"))));
                    var status = libraryAutomation.SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "")
                        .ToList();

                    var dateEndValidation = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("���� ��������� ��������")));
                    var dateCloseValidation = string.IsNullOrWhiteSpace(dateEndValidation)
                        ? (DateTime?) null
                        : Convert.ToDateTime(dateEndValidation);

                    journal.GlobalColor = libraryAutomation.GetColorPixel(status[1]);
                    journal.GlobalProcessColor = libraryAutomation.GetColorPixel(status[2]);
                    //����� � ������� �� ��������� ���������
                    var panel = libraryAutomation
                        .SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.PanelDoc))
                        .Cast<AutomationElement>().ToArray();
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.IshDoc, panel[1], false, 1) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.IshDoc, panel[1], false, 1);
                        AutoItX.Sleep(5000);
                    }
                    var listDocMemo = libraryAutomation
                        .SelectAutomationColrction(
                            libraryAutomation.FindFirstElement(Journal129AndJournal121.JournalIsh, panel[1]))
                        .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row"))
                        .ToArray();
                    //���������� ���� ������� � ��������� �� ������ ���
                    switch (journal.Knd)
                    {
                        case "1151085":
                            createActAndSolutionAndNotification.CreateForm1151085(libraryAutomation, listDocMemo,
                                journal, datePicker, senderSelect, dateCloseValidation);
                            break;
                        case "1151006":
                            createActAndSolutionAndNotification.CreateForm1151006(libraryAutomation, listDocMemo,
                                journal, datePicker, senderSelect, dateCloseValidation);
                            break;
                        case "1151111":
                            var summNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation.SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("����� �� ������ ��")));
                            var colorError = libraryAutomation.GetColorPixel(status[4]);
                            createActAndSolutionAndNotification.CreateForm1151111(libraryAutomation, listDocMemo,
                                journal, datePicker, senderSelect, dateCloseValidation, summNp, colorError);
                            break;
                        case "1151020":
                            createActAndSolutionAndNotification.CreateForm1151020(libraryAutomation, journal);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    break;
                }

                automationElement.SetFocus();
                rowNumber++;
            }
        }

        /// <summary>
        /// Parse ������ ��� ��������� ������� �� ����������
        /// </summary>
        /// <param name="statusButton">������ ������</param>
        /// <param name="srvToLoad">������ � �������</param>
        /// <param name="serviceGetOrPost">������� �� ������</param>
        /// <param name="pathTemp">���� ���������� Temp</param>
        /// <param name="pathDownLoads">���� ���������� ������� �� �����</param>
        /// <param name="yearReport">�������� ��� �� ��������</param>
        public void Click29(StatusButtonMethod statusButton, List<SrvToLoad> srvToLoad, string serviceGetOrPost,
            string pathTemp, string pathDownLoads, int yearReport)
        {
            var function = new PreCheckFunction();
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            PublicGlobalFunction.CloseProcessProgram("EXCEL");
            foreach (var model in srvToLoad)
            {
                if (statusButton.Iswork)
                {
                    var sw = model.Tree.Split('\\').Last();
                    var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
                    if (model.INN != null)
                    {
                        switch (sw)
                        {
                            case "1.01. ����������������� �������������� �����������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.03. �������� �� ����� ����������� � ��":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.12. �������� � ��������, ������������������, ���� ������������ ��������������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.18. �������� �� �������� ������������� ���������� ����������� � ���������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.19. �������� �� �������� ������������� ���������� ����������� � �����":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.20. �������� �� �������� ������������� ���������� ����������� � ���������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "2.02. ������� ��������� �������� �� ����� ����������� � ��":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "01. �������� � ��������������� ����������� ����������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "01. ��������� ������ ��, ��, ��":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "7. �������������� �������� ������������������":
                                function.IndividualCards(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp, yearReport);
                                break;
                            case "4.01. ������ � ������ �� �������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "���������� �������, �������":
                                function.BankSpr(statusButton, libraryAutomation, model, fullTree, serviceGetOrPost,
                                    pathDownLoads);
                                break;
                            case "������ ���������� ���":
                                function.DeclarationIntelligenceUl(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp, yearReport);
                                break;
                            case "1. ������ ���������� ���":
                                function.DeclarationIntelligenceUl(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp, yearReport);
                                break;
                            case "1.18. �������� �� �������� ������������� ����������� ���� � ���������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.19. �������� �� �������� ������������� ����������� ���� � �����":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "1.20. �������� �� �������� ������������� ����������� ���� � ���������":
                                function.ParseDataBase(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "����� ��":
                                function.FindUlStatement(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathTemp);
                                break;
                            case "���� ����������� ������":
                                function.ShoppingSaleBook(statusButton, libraryAutomation, model, fullTree,
                                    serviceGetOrPost, pathDownLoads);
                                break;
                        }
                    }
                }
                else
                {
                    statusButton.Iswork = false;
                }
            }
        }

        /// <summary>
        /// ����������� ������� � ������������� ������� � ��������������
        /// </summary>
        /// <param name="statusButton">������ ������</param>
        public void Click30(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal, rowNumber), null, false, 50)) != null)
            {
                var taxFace129 = new TaxJournal129();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    taxFace129.LoginUser = Environment.UserName;
                    taxFace129.IdDelo = Convert.ToInt32(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�� ����"))));
                    taxFace129.DateError = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("���� ����������� ���������"))));
                    taxFace129.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    taxFace129.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    taxFace129.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����")));
                    taxFace129.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��")));
                    taxFace129.StateColor =
                        $"#{libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name != "Column Headers").ToArray()[0])}";
                    taxFace129.StateTaxPayerColor =
                        $"#{libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name != "Column Headers").ToArray()[1])}";
                    //Red #ff0000
                    taxFace129.MessageInfo = "���� �� ������������� �� ������ �������� (������� ������� �� ����)";
                    if (taxFace129.StateColor.Equals("#ff0000"))
                    {
                        if (taxFace129.StateColor.Equals("#ff0000") & taxFace129.StateTaxPayerColor.Equals("#ff0000"))
                        {
                            taxFace129.MessageInfo = "���������������� ���� � �����";
                        }
                        else
                        {
                            taxFace129.MessageInfo = taxFace129.Kpp.Contains("7751")
                                ? "��������� ������������ ������������"
                                : "����������� ����������� � ��. ��";
                        }

                        libraryAutomation.ClickElements(Journal129AndJournal121.ButonState);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinDialogComment, null,
                                    true) != null)
                            {
                                libraryAutomation.SetValuePattern(taxFace129.MessageInfo);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.WinDialogSave);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.WinOk);
                                break;
                            }
                        }
                    }

                    var dbAutomation = new AddObjectDb();
                    dbAutomation.AddJournal129(taxFace129);
                }
                else
                {
                    break;
                }

                rowNumber++;
            }
        }

        /// <summary>
        /// ������� ������������� ������ ���������� ���������������� �������
        /// ����� �������\�������������� �������������\05.09 ������������ ������� �� ������ �� ���������\���������� ������������� ��
        /// </summary>
        /// <param name="statusButton">������ ������</param>
        public void Click31(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.ClickElements(PublicElementName.StartBeforeQ);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.Sign, null, true) != null)
                        {
                            libraryAutomation.ClickElements(TextSignatureOfficeNote.Sign);
                            break;
                        }
                    }

                    PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk);
                    PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk1);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ������� ��� ������������� ��� �� ��
        /// �������� �� �����
        /// ��������� �����������������\���������� ����\2.01. �������� � ������� ��\5.01. �� ������������������ ���������� ������
        /// </summary>
        /// <param name="statusButton">������ ������</param>
        /// <param name="statusSelect">������ �������</param>
        public void Click32(StatusButtonMethod statusButton, int? statusSelect)
        {
            IdentificationAddorEditFace identification = new IdentificationAddorEditFace();
            var identificationFaceList = identification.SelectDocument(statusSelect); //�������� 500
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (identificationFaceList.Count == 0) return;
            var listSelect = new List<Documen2Ndfl>();
            int[] memoNumWin = {5, 6, 7, 11}; //�� ������� ����
            var sw = IdentificationElementName.TreeIdentification.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(IdentificationElementName.TreeIdentification);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var doc in identificationFaceList)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                    {
                        if (libraryAutomation.FindFirstElement(
                                string.Concat(IdentificationElementName.GridIdentification, 3), null, true) != null)
                        {
                            libraryAutomation.FindFirstElement(IdentificationElementName.Memo,
                                libraryAutomation.FindElement, true);
                            libraryAutomation.FindElement.SetFocus();
                            SendKeys.SendWait(ButtonConstant.Enter);
                            SendKeys.SendWait("");
                            AutoItX.Sleep(200);
                            SendKeys.SendWait(doc.IdDoc.ToString());
                            SendKeys.SendWait(ButtonConstant.Enter);
                            break;
                        }
                    }

                    while (true)
                    {
                        AutoItX.Sleep(1000);
                        PublicGlobalFunction.WindowElementClick(libraryAutomation,
                            IdentificationElementName.Update2NDFL);
                        if (PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation,
                                IdentificationElementName.Grid) ==
                            "������, ��������������� �������� �������� �� �������.")
                        {
                            doc.ErrorNameStatus = $"������ �������� �� ������ � ��� 3";
                            identification.UpdateDocument(doc);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(string.Concat(IdentificationElementName.GridData, 1),
                                null, false, 50) != null)
                        {
                            AutomationElement automationElement = libraryAutomation.FindElement;
                            doc.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��")));
                            if (doc.IdFile == null) //� ������ ���������� �� ������ �� ��������� 
                            {
                                doc.IdFile = Convert.ToInt64(Regex.Replace(
                                    libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("�� �����"))), @"\s+", ""));
                                doc.Ifns = 7751;
                                doc.Yars = Convert.ToInt32(
                                    libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("�������� ���"))));
                                doc.FName = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("������� ��")));
                                doc.IName = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("��� ��")));
                                doc.OName = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("�������� ��")));
                                doc.Fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("��� ��")));
                                doc.Document = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem =>
                                            elem.Current.Name.Contains("��������, �������������� ��������")));
                                doc.SeriaNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("����� � ����� ���������")));
                                var dateR = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("���� ��������")));
                                doc.DateNameUser = string.IsNullOrWhiteSpace(dateR)
                                    ? null
                                    : (DateTime?) Convert.ToDateTime(dateR);
                                doc.InnOrganization = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("��� ��")));
                                doc.NameOrganization =
                                    libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                        .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("������������ ��")));
                            }

                            PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                IdentificationElementName.Setting);
                            SendKeys.SendWait(ButtonConstant.Down1);
                            SendKeys.SendWait(ButtonConstant.Enter);
                            while (true)
                            {
                                if (libraryAutomation.FindFirstElement(IdentificationElementName.GridWin, null, true) ==
                                    null) continue;
                                foreach (var memo in memoNumWin)
                                {
                                    if (libraryAutomation.FindFirstElement(
                                            string.Concat(IdentificationElementName.GridWinList, memo), null, true) !=
                                        null)
                                    {
                                        libraryAutomation.FindFirstElement(IdentificationElementName.Memo,
                                            libraryAutomation.FindElement, true);
                                        libraryAutomation.FindElement.SetFocus();
                                        SendKeys.SendWait(ButtonConstant.Enter);
                                        SendKeys.SendWait(ButtonConstant.Enter);
                                    }
                                }

                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    IdentificationElementName.WinUpdete);
                                break;
                            }

                            if (PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation,
                                    IdentificationElementName.GridDataWin) ==
                                "������, ��������������� �������� �������� �� �������.")
                            {
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    IdentificationElementName.WinCancel);
                                automationElement.SetFocus();
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    IdentificationElementName.Setting);
                                SendKeys.SendWait(ButtonConstant.Down2);
                                SendKeys.SendWait(ButtonConstant.Enter);
                                AutoItX.Sleep(500);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    IdentificationElementName.Update2NDFL);
                                AutomationElement automationElementMemo;
                                while ((automationElementMemo =
                                           libraryAutomation.IsEnableElements(
                                               string.Concat(IdentificationElementName.GridData, 1), null, false,
                                               50)) != null)
                                {
                                    var idCun = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation
                                            .SelectAutomationColrction(automationElementMemo)
                                            .Cast<AutomationElement>().First(elem =>
                                                elem.Current.Name.Contains("�� ������ � �� ���")));
                                    doc.ErrorNameStatus = $"���� �� ������� ����� ������� ������ � ��� �� {idCun}";
                                    identification.UpdateDocument(doc);
                                    break;
                                }
                            }
                            else
                            {
                                var rowNumber = 1;
                                AutomationElement automationElementFace;
                                var listMemo = new List<AutomationElement>();
                                while ((automationElementFace =
                                           libraryAutomation.IsEnableElements(
                                               string.Concat(IdentificationElementName.GridDataFaceWin, rowNumber),
                                               null, true, 5)) != null)
                                {
                                    var dateRClarification =
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>().First(elem =>
                                                    elem.Current.Name.Contains("���� �������")));
                                    var fidClarification = Convert.ToInt64(Regex.Replace(
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("��� ����"))), @"\s+", ""));
                                    var idFacesClarification = Convert.ToInt64(Regex.Replace(
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>().First(elem =>
                                                    elem.Current.Name.Contains("�� �� � ����"))), @"\s+", ""));
                                    var innClarification =
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("���")));
                                    var fNameClarification =
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("������� ��")));
                                    var iNameClarification =
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>()
                                                .First(elem => elem.Current.Name.Contains("��� ��")));
                                    var oNameClarification =
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>().First(elem =>
                                                    elem.Current.Name.Contains("�������� ��")));
                                    var dateNameUserClarification = string.IsNullOrWhiteSpace(dateRClarification)
                                        ? null
                                        : (DateTime?) Convert.ToDateTime(dateRClarification);
                                    var statusClarification =
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation
                                                .SelectAutomationColrction(automationElementFace)
                                                .Cast<AutomationElement>().First(elem =>
                                                    elem.Current.Name.Contains("������������ ������� ��������")));
                                    listSelect.Add(new Documen2Ndfl()
                                    {
                                        Fid = fidClarification,
                                        IdFl = idFacesClarification,
                                        InnUtoch = innClarification,
                                        FNameUtoch = fNameClarification,
                                        INameUtoch = iNameClarification,
                                        ONameUtoch = oNameClarification,
                                        DateNameUserUtoch = dateNameUserClarification,
                                        StatusSved = statusClarification
                                    });
                                    listMemo.Add(automationElementFace);
                                    libraryAutomation.ClickElement(automationElementFace, 0, 15);
                                    rowNumber++;
                                }

                                var isDouble = listSelect.Where(x => x.StatusSved == "������� � ��");
                                var firstFace = listSelect.FirstOrDefault(x => x.StatusSved == "������� � ��");
                                if (firstFace != null)
                                {
                                    if (isDouble.Count() == 1)
                                    {
                                        doc.Fid = firstFace.Fid;
                                        doc.IdFl = firstFace.IdFl;
                                        doc.InnUtoch = firstFace.InnUtoch;
                                        doc.FNameUtoch = firstFace.FNameUtoch;
                                        doc.INameUtoch = firstFace.INameUtoch;
                                        doc.ONameUtoch = firstFace.ONameUtoch;
                                        doc.DateNameUserUtoch = firstFace.DateNameUserUtoch;
                                        doc.StatusSved = firstFace.StatusSved;
                                        doc.ErrorNameStatus = $"������ �������� ���������������!!!";
                                        AutomationElement selectElement = null;
                                        listMemo.ForEach(element =>
                                        {
                                            var fidElem = libraryAutomation.SelectAutomationColrction(element)
                                                .Cast<AutomationElement>().First(elem =>
                                                    elem.Current.Name.Contains("�� �� � ����"));
                                            var parameter = Regex.Replace(
                                                libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                    fidElem), @"\s+", "");
                                            if (string.Equals(parameter, firstFace.IdFl.ToString()))
                                            {
                                                selectElement = element;
                                            }
                                        });
                                        libraryAutomation.ClickElement(selectElement, 0, 0, 2);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                            IdentificationElementName.WinSelect);
                                        identification.UpdateDocument(doc);
                                    }
                                    else
                                    {
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                            IdentificationElementName.WinCancel);
                                        automationElement.SetFocus();
                                        doc.ErrorNameStatus =
                                            $"������� ��������� ��� �� �������� ������� � �� ���������������� �������� ����!�� ��� {isDouble.Select(x => x.IdFl.ToString()).Aggregate((element, next) => element + (string.IsNullOrWhiteSpace(element) ? string.Empty : "/") + next)}";
                                        identification.UpdateDocument(doc);
                                    }
                                }
                                else
                                {
                                    doc.Fid = listSelect[0].Fid;
                                    doc.IdFl = listSelect[0].IdFl;
                                    doc.InnUtoch = listSelect[0].InnUtoch;
                                    doc.FNameUtoch = listSelect[0].FNameUtoch;
                                    doc.INameUtoch = listSelect[0].INameUtoch;
                                    doc.ONameUtoch = listSelect[0].ONameUtoch;
                                    doc.DateNameUserUtoch = listSelect[0].DateNameUserUtoch;
                                    doc.StatusSved = listSelect[0].StatusSved;
                                    doc.ErrorNameStatus = $"������ ����/��� �� �������� ������� � ��!";
                                    identification.UpdateDocument(doc);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                        IdentificationElementName.WinCancel);
                                }
                            }

                            break;
                        }
                    }

                    listSelect.Clear();
                    PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, IdentificationElementName.Grid);
                    while (true)
                    {
                        PublicGlobalFunction.WindowElementClick(libraryAutomation,
                            IdentificationElementName.GridFilter);
                        if (libraryAutomation.FindFirstElement(
                                string.Concat(IdentificationElementName.GridIdentification, 3), null, true) != null)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            identification.Dispose();
            WindowsAis3 win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                win.WindowsAis.Y + 160);
        }


        /// <summary>
        /// ��������� �����������������\����������� ������ (��������� ��������)\121. ����������� ��������� ��������\03. ������ ��������� ���������� (��������), �������� � ��� (���)
        /// ������ ����� ��� ���������� ������������ ������� ��� ��������� ��� 1 ���
        /// </summary>
        /// <param name="statusButton">������ �����</param>
        public void Click33(StatusButtonMethod statusButton)
        {
            StaticMode121 staticMode = new StaticMode121();
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
            PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, IdentificationElementName.Grid);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 50)) != null)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    var knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    //����� � ������� �� ���������
                    var panel = libraryAutomation
                        .SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.PanelDoc))
                        .Cast<AutomationElement>().ToArray();
                    ;
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Error, panel[1], false, 1) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.Error, panel[1], false, 1);
                    }

                    //������ ���������
                    var listDocError = libraryAutomation
                        .SelectAutomationColrction(
                            libraryAutomation.FindFirstElement(Journal129AndJournal121.JournalIsh, panel[1]))
                        .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row"))
                        .ToArray();
                    //���������� ���� ������� � ��������� �� ������ ���
                    switch (knd)
                    {
                        case "1151001":
                            staticMode.StaticMode1Nk1151001And1151006(libraryAutomation, listDocError);
                            break;
                        case "1151006":
                            staticMode.StaticMode1Nk1151001And1151006(libraryAutomation, listDocError);
                            break;
                    }
                }
                else
                {
                    break;
                }

                rowNumber++;
            }
        }

        /// <summary>
        /// ������������� �������� ������������ ���� �������� � �������� ���������!
        /// ��������� �����������������\����������� ������ (��������� ��������)\121. ����������� ��������� ��������\04. ������ ����������, ���������� � ���� ��������� ��������
        /// </summary>
        /// <param name="statusButton">������ ������� ������� ������������ ���� ��������!</param>
        public void Click34(StatusButtonMethod statusButton)
        {
            Okp2ActAndSolutionAndNotification createActAndSolutionAndNotification =
                new Okp2ActAndSolutionAndNotification(null);
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121Tree04);
            var kndNotSendA01 = new[] {"1160098", "1160099", "115050", "1165009"}; //�� ���� ��� �� ���������� � �01
            PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            var dbAutomation = new AddObjectDb();
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    var regNumber = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���. �����"))));

                    string dateSend = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("���� ��������/���� ��������")));

                    string dateDelivery = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���� ��������")));

                    string knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));

                    var panel = libraryAutomation
                        .SelectAutomationColrction(
                            libraryAutomation.FindFirstElement(Journal129AndJournal121.SendMailGrid))
                        .Cast<AutomationElement>().ToArray();
                    AutoItX.Sleep(1000);
                    PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.Sender,
                        panel[1]);
                    if (!dbAutomation.IsExistsDocument(regNumber))
                    {
                        var journalDelivery = new TaxJournalDelivery();
                        journalDelivery.LoginUser = Environment.UserName;
                        journalDelivery.RegNumber = regNumber;
                        journalDelivery.DateDocument = Convert.ToDateTime(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("���� ���������"))));
                        journalDelivery.Number = Convert.ToInt32(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�����"))));
                        journalDelivery.Knd = knd;
                        journalDelivery.NameDocument =
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��������")));
                        journalDelivery.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                        journalDelivery.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                        journalDelivery.TypeFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ����")));
                        journalDelivery.RegNumDeclaration = Convert.ToInt64(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("���. ����� ����������"))));
                        journalDelivery.NameDeclaration =
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("�������� ����������")));
                        journalDelivery.God = Convert.ToInt32(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�������� ���"))));

                        if (!string.IsNullOrEmpty(dateDelivery) && !kndNotSendA01.Contains(knd))
                        {
                            journalDelivery.DateSend = Convert.ToDateTime(dateSend);
                            journalDelivery.DateDelivery = Convert.ToDateTime(dateDelivery);
                            createActAndSolutionAndNotification.SendA01(libraryAutomation);
                        }
                        else
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DocumentSendDelivery, null,
                                    true, 1) != null)
                            {
                                createActAndSolutionAndNotification.AddDateDelivery(libraryAutomation,
                                    ref journalDelivery);
                            }
                            else
                            {
                                journalDelivery.DateDelivery = DateTime.Now;
                                journalDelivery.DateSend = DateTime.Now;
                            }
                        }

                        AutoItX.Sleep(3000);
                        createActAndSolutionAndNotification.SaveAndUpdateDocumet(journalDelivery);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dateDelivery) && !kndNotSendA01.Contains(knd))
                        {
                            createActAndSolutionAndNotification.SendA01(libraryAutomation);
                        }

                        rowNumber++;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ������ �� ������� �� �� ������ 
        /// </summary>
        /// <param name="inn">���</param>
        /// <param name="kpp">���</param>
        public void Click35(string inn, string kpp)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (libraryAutomation.IsEnableElement(ProcessStartSash.StartW))
            {
                libraryAutomation.IsEnableElements(ProcessStartSash.InnInput, null, true);
                libraryAutomation.SetValuePattern(inn);
                if (kpp != null)
                {
                    libraryAutomation.IsEnableElements(ProcessStartSash.KppInput, null, true);
                    libraryAutomation.SetValuePattern(kpp);
                }

                PublicGlobalFunction.WindowElementClick(libraryAutomation, ProcessStartSash.StartW);
            }
        }

        /// <summary>
        /// ���� ���������� � �������� ������ � ������
        /// </summary>
        /// <param name="statusButton">������ �������</param>
        /// <param name="pathJournalInfoRule">���� ���������� ����������</param>
        public void Click36(StatusButtonMethod statusButton, string pathJournalInfoRule)
        {
            var rowNumber = 1;
            var tree = "��������� �����������������\\����\\���������� ������� ���������������\\��� ����";
            var sw = tree.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (!libraryAutomation.IsEnableExpandTree(tree)) return;
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ApplicationTab);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.ButtonAdd);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, ItElementName.AutoInfo);
            libraryAutomation.IsEnableElement(ItElementName.GridRule);

            if (File.Exists(pathJournalInfoRule))
            {
                var readFileInfoRule = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
                var fileInfoRuleTemplate = (InfoRuleTemplate)readFileInfoRule.ReadXml(pathJournalInfoRule, typeof(InfoRuleTemplate));
                var nameAttributes = fileInfoRuleTemplate.SystemAis.Last().Name;
                var index = 0;
                    libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>()
                       .Where(elem => elem.Current.Name.Contains("List`"))
                       .ToList().ForEach(element =>
                        {
                            if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(element)
                                   .Cast<AutomationElement>()
                                   .First(elem => elem.Current.Name.Contains("����������"))) == nameAttributes)
                            {
                               rowNumber = index;
                            }
                            index++;
                       }); 
                readFileInfoRule.DeleteAtributXml(pathJournalInfoRule, $"/InfoRuleTemplate/SystemAis[@Name=\"{nameAttributes}\"]");
            }

            AutomationElement automationElementRow;
            while ((automationElementRow = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListRow, rowNumber), null, true, 30)) != null)
            {
                if (statusButton.Iswork)
                {
                
                    var infoRuleTemplate = new InfoRuleTemplate() { SystemAis = new SystemAis[1] };
                    automationElementRow.SetFocus();
                    SendKeys.SendWait(ButtonConstant.Plus);

                    infoRuleTemplate.SystemAis[0] = new SystemAis()
                    {
                         Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                             libraryAutomation.SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("����������")))
                    };

                    var foldersNumber = 1;
                    var listFolder = libraryAutomation
                        .SelectAutomationColrction(automationElementRow).Cast<AutomationElement>()
                        .Where(elem => elem.Current.Name.Contains("Folders row"));
                    infoRuleTemplate.SystemAis[0].Folders = new Folders[listFolder.Count()];

                        AutomationElement automationElementFolder;
                        while ((automationElementFolder = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListFolders, rowNumber, foldersNumber), null, true, 30)) != null)
                        {
                             automationElementFolder.SetFocus();
                             SendKeys.SendWait(ButtonConstant.Plus);

                             infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1] = new Folders()
                               {
                                  Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                     libraryAutomation.SelectAutomationColrction(automationElementFolder)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�����")))
                               };

                             var tasksNumber = 1;
                             var listTask = libraryAutomation
                                .SelectAutomationColrction(automationElementFolder).Cast<AutomationElement>()
                                .Where(elem => elem.Current.Name.Contains("Tasks row"));

                             infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks = new Tasks[listTask.Count()];

                                 AutomationElement automationElementTask;
                                 while ((automationElementTask = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListTasks, rowNumber, foldersNumber, tasksNumber), null,true, 1)) != null)
                                 {
                                     automationElementTask.SetFocus();
                                     SendKeys.SendWait(ButtonConstant.Plus);

                                     infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1] = new Tasks()
                                         {
                                             Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                 libraryAutomation.SelectAutomationColrction(automationElementTask)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("������"))),
                                             TypeTask = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                 libraryAutomation.SelectAutomationColrction(automationElementTask)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���"))),
                                             Curator = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                 libraryAutomation.SelectAutomationColrction(automationElementTask)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�������")))
                                         };

                                     var rolesNumber = 1;

                                     var listRole = libraryAutomation
                                         .SelectAutomationColrction(automationElementTask).Cast<AutomationElement>()
                                         .Where(elem => elem.Current.Name.Contains("Roles row"));
                                     infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1]
                                         .RolesTemplate = new RolesTemplate[listRole.Count()];


                                           AutomationElement automationElementRole;
                                           while ((automationElementRole = libraryAutomation.IsEnableElements(string.Format(ItElementName.ListRoles, rowNumber, foldersNumber, tasksNumber, rolesNumber), null, true, 1)) != null)
                                           {
                                               automationElementRole.SetFocus();
                                               SendKeys.SendWait(ButtonConstant.Plus);

                                               infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1]
                                                   .RolesTemplate[rolesNumber - 1] = new RolesTemplate()
                                               {
                                                   Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                       libraryAutomation.SelectAutomationColrction(automationElementRole)
                                                           .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����")))
                                               };
                                               var taskTemplateNumber = 1;

                                               var listTaskTemplate = libraryAutomation
                                                   .SelectAutomationColrction(automationElementRole).Cast<AutomationElement>()
                                                   .Where(elem => elem.Current.Name.Contains("TaskTemplates row"));
                                               infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1].Tasks[tasksNumber - 1]
                                                   .RolesTemplate[rolesNumber - 1].Templates = new Templates[listTaskTemplate.Count()];
                                               
                                                    AutomationElement automationElementTaskTemplate;
                                                    while ((automationElementTaskTemplate =libraryAutomation.IsEnableElements(string.Format(ItElementName.ListTaskTemplates, rowNumber, foldersNumber, tasksNumber, rolesNumber, taskTemplateNumber), null, true, 1)) != null)
                                                    {
                                                        automationElementTaskTemplate.SetFocus();

                                                        infoRuleTemplate.SystemAis[0].Folders[foldersNumber - 1]
                                                            .Tasks[tasksNumber - 1].RolesTemplate[rolesNumber - 1]
                                                            .Templates[taskTemplateNumber - 1] = new Templates()
                                                        {
                                                            Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                libraryAutomation.SelectAutomationColrction(automationElementTaskTemplate)
                                                                    .Cast<AutomationElement>()
                                                                    .First(elem => elem.Current.Name.Contains("������"))),
                                                            Category = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                libraryAutomation.SelectAutomationColrction(automationElementTaskTemplate)
                                                                    .Cast<AutomationElement>()
                                                                    .First(elem => elem.Current.Name.Contains("���������")))
                                                        };
                                                        taskTemplateNumber++;
                                               }
                                               automationElementRole.SetFocus();
                                               SendKeys.SendWait(ButtonConstant.Minus);
                                               rolesNumber++;
                                     }
                                     automationElementTask.SetFocus();
                                     SendKeys.SendWait(ButtonConstant.Minus);
                                     tasksNumber++;
                                 }
                                 automationElementFolder.SetFocus();
                                 SendKeys.SendWait(ButtonConstant.Minus);
                                 foldersNumber++;
                        }
                        automationElementRow.SetFocus();
                        SendKeys.SendWait(ButtonConstant.Minus);
                        LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileInfoRuleTemplate(pathJournalInfoRule, infoRuleTemplate);
                        rowNumber++;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ����������� ��������� ������������
        /// </summary>
        /// <param name="statusButton">������ �������</param>
        public void Click37(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(PublicElementName.PublicTaxViewTask, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartUser);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ApproveInspector,null,true)!=null)
                        {
                            if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindElement) == "������� ����������")
                            {
                                while (true)
                                {
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Approve);
                                    if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.ApproveInspector)) == "������� ���������� �����������")
                                    {
                                        break;
                                    }
                                    AutoItX.Sleep(10000);
                                }
                                break;
                            }
                        }
                    }
                    WindowsAis3 win = new WindowsAis3();
                    AutoItX.Sleep(1000);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                    AutoItX.Sleep(2000);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
