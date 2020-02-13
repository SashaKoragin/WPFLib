using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Automation;
using LibaryAIS3Windows.Window.Otdel.Analitic.TeskText;
using AutoIt;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.It;
using LibaryAIS3Windows.AutomationsUI.Otdels.Okp2;
using LibaryAIS3Windows.AutomationsUI.Otdels.RaschetBud;
using LibaryAIS3Windows.AutomationsUI.Otdels.Registration;
using LibaryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie;
using LibaryAIS3Windows.AutomationsUI.PublicElement;
using LibaryAIS3Windows.ExitLogica.ExitTaskFull;
using LibaryAIS3Windows.Function.PublicFunc;
using LibaryAIS3Windows.Mode.Okp4.PravoZorI;
using LibaryAIS3Windows.Mode.Okp4.SnuFormirovanie;
using LibaryAIS3Windows.Mode.RaschetBudg.Migration;
using LibaryAIS3Windows.Mode.Reg.StatusReg;
using LibaryAIS3Windows.RegxFull.RaschetBudg;
using LibaryAIS3Windows.SqlModel.SqlLk2;
using LibaryAIS3Windows.Window;
using LibaryAIS3Windows.Window.Otdel.Okp3.Usn;
using LibaryAIS3Windows.Window.Otdel.Okp4.PravoZorI;
using LibaryAIS3Windows.Window.Otdel.Okp4.Print;
using LibaryAIS3Windows.Window.Otdel.Okp4.Snu;
using LibaryAIS3Windows.Window.Otdel.Orn.Nbo;
using LibaryAIS3Windows.Window.Otdel.RaschetBudg.Migration;
using LibaryAIS3Windows.Window.Otdel.RaschetBudg.Vedomost1;
using LibaryAIS3Windows.Window.Otdel.Reg.ActualStatus;
using LibaryAIS3Windows.Window.Otdel.Reg.Fpd;
using LibaryAIS3Windows.Window.Otdel.Reg.IdFace;
using LibaryAIS3Windows.Window.Otdel.Uregulirovanie.UtverzdenieSz;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;


namespace LibaryAIS3Windows.ButtonsClikcs
{
    public class KclicerButton
    {
        private const string ModeBranchVedomost1 =
            @"��������� �����������������\������� � ��������\��������� ������������ �����������\��������� ������������ �����������. ������ 1";


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
        /// <param name="pathjurnalerror">���� � ������� ������</param>
        /// <param name="pathjurnalok">���� � ������� ��</param>
        /// <param name="logica">������ �������</param>
        /// <param name="isTp">����������� ��</param>
        public void Click10(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok, int logica,
            bool isTp)
        {
            var libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            libaryAutomations.FindFirstElement(RashetBudElementName.DateGrid);
            var listmemo = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement)
                .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List"));
            foreach (var automationElement in listmemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    RegxStart regxstart = new RegxStart();
                    regxstart.RaschDoc = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��������� ��������")));
                    regxstart.RaspredPl = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    regxstart.InnPlatel = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("��� ����������� (60)")));
                    regxstart.Inn = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ���������� (61)")));
                    regxstart.Kpp = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ���������� (103)")));
                    regxstart.Platej = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����� (7)")));
                    regxstart.Kbk100 = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    regxstart.KbkIfns = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� (104)")));
                    regxstart.Oktmo = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libaryAutomations
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("����� (�����) (105)")));
                    if (String.IsNullOrWhiteSpace(regxstart.Oktmo) ||
                        string.Equals(regxstart.IsMathRegx("(0{6})", regxstart.Oktmo), "000000"))
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, regxstart.RaschDoc,
                            ModeBranchVedomost1, "�� �������� ����� ���� ���������");
                    }
                    else
                    {
                        while (true)
                        {
                            if (libaryAutomations.IsEnableElements(RashetBudElementName.StartUtoch) == null) continue;
                            libaryAutomations.CliksElements(RashetBudElementName.StartUtoch);
                            break;
                        }

                        AutoItX.WinWait(Vedomost1Win.ViesneniePl[0], Vedomost1Win.ViesneniePl[1]);
                        AutoItX.Send(ButtonConstant.Enter);
                        regxstart.UseNalog(logica, isTp);
                        while (true)
                        {
                            if (libaryAutomations.IsEnableElements(RashetBudElementName.Utverjdenie) == null) continue;
                            libaryAutomations.CliksElements(RashetBudElementName.Utverjdenie);
                            break;
                        }

                        if ((AutoItX.WinWait(Vedomost1Win.Utoch[0], Vedomost1Win.Utoch[1], 1) == 1) ||
                            (AutoItX.WinWait(Vedomost1Win.Utoch2[0], Vedomost1Win.Utoch2[0], 1) == 1))
                        {
                            AutoItX.Sleep(500);
                            AutoItX.Send(ButtonConstant.Enter);
                        }

                        if (regxstart.InnPlatel.Length != 10)
                        {
                            AutoItX.WinWait(Vedomost1Win.IsData[0], Vedomost1Win.IsData[1], 2);
                            AutoItX.Sleep(500);
                            AutoItX.Send(ButtonConstant.Enter);
                        }

                        AutoItX.WinWaitClose("��� �����-3 ���� ", "���������� ���������");
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok,
                            regxstart.RaschDoc + " ���������� ���: " + regxstart.KbkIfns + " ������ " +
                            regxstart.Kbk100, "������� ��������");
                    }
                }
            }
        }

        /// <summary>
        /// ������� ��������� �������� ��
        /// </summary>
        /// <param name="isparse">����� ����������� ���� </param>
        /// <param name="reportMigration">���� � ����� � ���������</param>
        /// <param name="copyid">�� �������� ������� ������</param>
        /// <param name="collectionExeption">��������� ��� ����������</param>
        public string Click11(bool isparse, string reportMigration, string copyid,
            ObservableCollection<string> collectionExeption)
        {
            string ident = copyid;
            WindowsAis3 win = new WindowsAis3();
            MigrationParse model = new MigrationParse() {ReportMigration = new ReportMigration[1]};
            ReportMigration report = new ReportMigration();
            copyid = null;
            copyid = ReadWindow.Read.Reades.ReadForm(Migration.Identity);
            if (copyid.Equals(ident))
            {
                return copyid;
            }

            report.NameOrg = ReadWindow.Read.Reades.ReadForm(Migration.NameOrganization);
            report.CodeIfns = ReadWindow.Read.Reades.ReadForm(
                AutoItX.WinExists(Migration.PeredachaOrPriem[0], Migration.PeredachaOrPriem[1]) == 1
                    ? Migration.CodeIfnsPeredacha
                    : Migration.CodeIfnsPriem);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 75);
            AutoItX.WinWait(WindowsAis3.AisNalog3, Migration.MigrationNp, 2);
            if (!isparse)
            {
                while (true)
                {
                    AutoItX.Sleep(5000);
                    var isEnable = AutoItX.ControlCommand(AutoItX.WinGetHandle(Migration.Button[0]),
                        AutoItX.ControlGetHandle(AutoItX.WinGetHandle(Migration.Button[0]), Migration.Button[2]),
                        "IsEnabled", "");
                    if (isEnable == "1")
                    {
                        AutoItX.ControlClick(Migration.Button[0], Migration.Button[1], Migration.Button[2]);
                        break;
                    }

                    win.ControlGetPos1(WindowsAis3.UltraGridDataMigration[0], WindowsAis3.UltraGridDataMigration[1],
                        WindowsAis3.UltraGridDataMigration[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 45,
                        win.WindowsAis.Y + win.Y1 + 35);
                }

                AutoItX.WinWait(TextMigration.WindiwWarning[0], TextMigration.WindiwWarning[1]);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.WinWait(TextMigration.WindiwInfo[0], TextMigration.WindiwInfo[1]);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.WinWait(WindowsAis3.AisNalog3, WindowsAis3.UpdateDataSource);
                AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.UpdateDataSource);
                AutoItX.Send(ButtonConstant.Tab2);
                return copyid;
            }

            report.Fid = ReadWindow.Read.Reades.ReadForm(Migration.FidMemo);
            report.Inn = ReadWindow.Read.Reades.ReadForm(Migration.InnMemo);
            var find = collectionExeption.Where(i => i == report.Inn);
            if (!find.Any())
            {
                AutoItX.Send(ButtonConstant.Tab);
                report.Kpp = ReadWindow.Read.Reades.ReadCtrlCno();
                win.ControlGetPos1(WindowsAis3.UltraGridDataMigration[0], WindowsAis3.UltraGridDataMigration[1],
                    WindowsAis3.UltraGridDataMigration[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 90,
                    win.WindowsAis.Y + win.Y1 + 35, 2);
                report.Date = ReadWindow.Read.Reades.ReadCtrlC();
                AutoItX.Send(ButtonConstant.Tab2);
                report.Stage = ReadWindow.Read.Reades.ReadCtrlC();
                AutoItX.Send(ButtonConstant.Tab2);
                report.Problem = ReadWindow.Read.Reades.ReadCtrlC();
                model.ReportMigration[0] = report;
                LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateReportMigration(reportMigration, model);
            }

            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                win.WindowsAis.Y + 160);
            AutoItX.Sleep(500);
            AutoItX.Send(ButtonConstant.Tab4);
            return copyid;
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksCountRow);
            libraryAutomation.SetValuePattern(dataPickerSettings.CountRow);
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksDbStart);
            libraryAutomation.SetValuePattern(dataPickerSettings.DateStart.ToString("dd.MM.yyyy"));
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksDbFinish);
            libraryAutomation.SetValuePattern(dataPickerSettings.DateFinish.ToString("dd.MM.yyyy"));
            libraryAutomation.FindFirstElement(PublicElementName.UpdateButton);
            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
            libraryAutomation.IsEnableElements(ItElementName.GridJournal);
            var i = 1;
            while (libraryAutomation.FindFirstElement(string.Format(ItElementName.GridJournalRows, i)) != null)
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
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                            libraryAutomation.IsEnableElements(ItElementName.HistoryJournal);
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
                                libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                                libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                                libraryAutomation.CliksElements(SettlementDebts.ButtonSettlement);
                            }
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSettlement) == null) continue;
                        libraryAutomation.CliksElements(SettlementDebts.ButtonSettlement);
                        isChecked = true;
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SluzZ.WinCloseNalog, null, false, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSend, null, false, 1) == null) continue;
                        libraryAutomation.CliksElements(SettlementDebts.ButtonSend);
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                    libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsCreate);
                    libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsOk);
                    libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsCancel);
                    libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.Qweshions);
                    libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.WinOk);
                    libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);

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
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                if (libraryAutomation.CliksElements(RegistrationElementNameVisualBank.UpdateButton, null, false, 1))
                {
                    if (libraryAutomation.IsEnableElements(
                            RegistrationElementNameVisualBank.JurnalsDocumentsFirstElementBank, null, true) != null)
                    {
                        libraryAutomation.FindElement.SetFocus();
                        if (libraryAutomation.CliksElements(RegistrationElementNameVisualBank.Identification, null,
                            false, 5))
                        {
                            while (true)
                            {
                                if (libraryAutomation.CliksElements(RegistrationElementNameVisualBank
                                    .StartIdentification))
                                {
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(RegistrationElementNameVisualBank.WinOk,
                                                null, true, 1) != null)
                                        {
                                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                                        }

                                        if (libraryAutomation.IsEnableElements(
                                                RegistrationElementNameVisualBank.WinOkEnd, null, true, 1) != null)
                                        {
                                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                                            if (libraryAutomation.CliksElements(
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
                                    libraryAutomation.CliksElements(RegistrationElementNameVisualBank.ReturnList, null,
                                        false, 10);
                                    if (libraryAutomation.CliksElements(RegistrationElementNameVisualBank.Return, null,
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
                        if (libraryAutomation.CliksElements(RegistrationElementNameVisualBank.Return, null, false, 10))
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
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
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

                    libraryAutomation.CliksElements(Trebovanie.ListPanel);
                    if (libraryAutomation.CliksElements(Trebovanie.Open, null, false, 5))
                    {
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Trebovanie.Save) != null)
                            {
                                libraryAutomation.CliksElements(Trebovanie.TabIfo, null, false, 10);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboBoxSelect),"�������");
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
                                if (valueStatusEnd != "���������� �������" & valueTypeNp == "��")
                                {
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboboxSend),"���������� �������");
                                }
                                if (valueStatusEnd != "�� ������� ���" & valueTypeNp != "��")
                                {
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboboxSend),"�� ������� ���");
                                }
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Save) == null) continue;
                                    libraryAutomation.CliksElements(Trebovanie.Save);
                                    break;
                                }
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Back) == null) continue;
                                    libraryAutomation.CliksElements(Trebovanie.Back);
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
                                libraryAutomation.CliksElements(Trebovanie.Back, null, false, 10);
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                        libraryAutomation.CliksElements(RecouncementLk.CheckStatusLk2);
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(RecouncementLk.WinOkEndUser, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckExit, null, true) == null) continue;
                        libraryAutomation.CliksElements(RecouncementLk.CheckExit);
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                        libraryAutomation.CliksElements(SignatureHeadProperty.ButtonSignatureAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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

                        libraryAutomation.CliksElements(SignatureHeadProperty.EndSignature);
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
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
                        libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
                        libraryAutomation.CliksElements(TextStatementOfficeNote.ButtonIsCheckAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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

                        libraryAutomation.CliksElements(TextStatementOfficeNote.Exit);
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
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
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
                        libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
                        libraryAutomation.CliksElements(TextSignatureOfficeNote.ButtonIsCheckAll);
                        isChecked = true;
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
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
                        libraryAutomation.CliksElements(TextSignatureOfficeNote.Exit);
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
        public void Click27(StatusButtonMethod statusButton, string pathJournalOk)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.CliksElements(Okp2ElementName.UpdateData);
            libraryAutomation.IsEnableElements(Okp2ElementName.AllTaxJournal+Okp2ElementName.ElementJournal,null,false,50);
            var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(Okp2ElementName.AllTaxJournal)).Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row"));
            foreach (var automationElement in listMemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    var id = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("�� ����")));
                    var dateTimeTax = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���� ����������� ���������")));
                    var valueInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    var kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("���")));
                    var face = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("����")));
                    var fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("��� ��")));
                    libraryAutomation.CliksElements(Okp2ElementName.OpenComplex,null,true);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(Okp2ElementName.EditTask, null, true) != null)
                        {
                            libraryAutomation.CliksElements(Okp2ElementName.EditTask, null, true);
                            break;
                        }
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(Okp2ElementName.SignAll, null, true) != null)
                        {
                            libraryAutomation.CliksElements(Okp2ElementName.SignAll, null, true);
                            break;
                        }
                    }
                    AutoItX.WinWait(Okp2ElementName.ViewName);
                    AutoItX.WinActivate(Okp2ElementName.ViewName);
                    LibaryAutomations libraryAutomationSign = new LibaryAutomations(Okp2ElementName.ViewName);
                    while (true)
                    {
                        if (libraryAutomationSign.IsEnableElements(Okp2ElementName.ViewPrint, null, true) != null)
                        {
                            libraryAutomationSign.InvekePattern(libraryAutomationSign.IsEnableElements(Okp2ElementName.ViewPrint));
                            while (true)
                            {
                                var toggel = libraryAutomationSign.TogglePattern(libraryAutomationSign.FindElement);
                                if (toggel == "Off" || toggel == null)
                                {
                                    if (libraryAutomationSign.IsEnableElements(Okp2ElementName.ViewCheks, null, true) != null)
                                    {
                                        libraryAutomationSign.FindElement.SetFocus();
                                        libraryAutomationSign.InvekePattern(libraryAutomationSign.FindElement);
                                    }
                                }
                                if (toggel == "On")
                                {
                                    AutoItX.WinActivate(Okp2ElementName.ViewName);
                                    libraryAutomationSign.InvekePattern(libraryAutomationSign.IsEnableElements(Okp2ElementName.Sign));
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    bool isLk3;
                    bool isMail;
                    bool isTks;
                    while (true)
                    {
                        AutoItX.WinActivate(WindowsAis3.AisNalog3);
                        if (libraryAutomation.IsEnableElements(Okp2ElementName.SendAll, null, true) != null)
                        {
                            libraryAutomation.CliksElements(Okp2ElementName.SendAll);
                        }
                        if (libraryAutomation.IsEnableElements(Okp2ElementName.SendDocument, null, true) != null)
                        {
                            var auto = libraryAutomation.FindElement;
                            libraryAutomation.IsEnableElements(Okp2ElementName.Tks, auto);
                            isTks = libraryAutomation.FindElement.Current.IsEnabled;
                            libraryAutomation.IsEnableElements(Okp2ElementName.Mail, auto);
                            isMail = libraryAutomation.FindElement.Current.IsEnabled;
                            libraryAutomation.IsEnableElements(Okp2ElementName.Lk3, auto);
                            isLk3 = libraryAutomation.FindElement.Current.IsEnabled;
                            libraryAutomation.CliksElements(Okp2ElementName.Close, auto, false, 25, -30, 30);
                            break;
                        }
                    }
                    WindowsAis3 win = new WindowsAis3();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                    AutoItX.Sleep(1000);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"�� ����: {id}; ���� ����������� ���������: {dateTimeTax}; ��� �����������������: {valueInn}; ���: {kpp}; ������������: {face}; ���: {fid}; ���: {Convert.ToInt32(isTks)}; �����: {Convert.ToInt32(isMail)}; ��3: {Convert.ToInt32(isLk3)}", "�������� ����������� ������� ��������!!!");
                }
                else
                {
                    break;
                }
            }
        }
    }
}