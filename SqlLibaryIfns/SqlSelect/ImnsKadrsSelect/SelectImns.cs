
using System;

namespace SqlLibaryIfns.SqlSelect.ImnsKadrsSelect
{
   public class SelectImns
    {
        /// <summary>
        /// Выборка всех актуальных пользователей
        /// </summary>
        public string ActualUsers = @"Select RTRIM(TAB_NUM) as TAB_NUM,
                                             RTRIM(DICTIONARY_POST.NAME) as NEW_POST,
                                             RTRIM(DSK.NAME) as NAME,
											 RTRIM(DS.CODE) as CODE,
                                             RTRIM(IM) as IM,
                                             RTRIM(OT) as OT,
                                             RTRIM(FM)as FM,
                                             RTRIM(STATUS.STATUS) as STATUS,
                                             RTRIM(KSV.NAME) as STATUS_NAME,DATE_IN FRom dbo.EMPLOYERS_TBL as ActualUser
                                     JOIN (  Select I2.LINK_EMPL as LINKS, STAFF_LINK,I2.LINK From ITEM_MOVE I1
                                     Join ( Select LINK_EMPL as  LINK_EMPL, MAX(LINK) as LINK From ITEM_MOVE
                                            Where ACTIVE = 1
                                            GROUP BY LINK_EMPL ) as I2  on I1.LINK = I2.LINK ) as T on T.LINKS=ActualUser.LINK
                                     JOIN dbo.FACES_MAIN_TBL AS FM ON FM.LINK = ActualUser.FACE_LINK
                                     JOIN dbo.STAFF STAF on STAF.LINK = T.STAFF_LINK
                                     JOIN dbo.SUBDIV AS DS ON STAF.SUBDIV_LINK = DS.LINK_UP
                                     JOIN dbo.DICTIONARY_SUBDIV_KLASSIF AS DSK ON DS.LINK_EX = DSK.LINK
                                     JOIN DICTIONARY_POST ON STAF.POST_LINK= DICTIONARY_POST.LINK
                                     JOIN (Select State.LINK_EMPL,STATUS.STATUS From dbo.EMPLOYERS_STATUS STATUS
                                     JOIN(Select LINK_EMPL,max(DATE) as DATE From dbo.EMPLOYERS_STATUS
                                          Where DATE < Getdate()
                                          GROUP BY LINK_EMPL) State on State.LINK_EMPL = STATUS.LINK_EMPL and State.DATE = STATUS.DATE) as STATUS on STATUS.LINK_EMPL = ActualUser.LINK
                                     JOIN dbo.STATUS_TYPES AS KSV ON STATUS.STATUS = KSV.LINK
                                    Where DATE_OUT is null For Xml Auto";

        /// <summary>
        /// Отбор пользователей для табелей
        /// </summary>
        public string UserReportCard = @"Select 
                                             RTRIM(FM)+' '+RTRIM(IM)+' '+RTRIM(OT) as Fio,
                                             RTRIM(TAB_NUM) as Tab_num,
                                             RTRIM(DICTIONARY_POST.NAME) as New_post,
                                             RTRIM(KSV.LINK) as Status_link,
                                             Date_in,
                                             Date_out
                                         From dbo.EMPLOYERS_TBL as UsersReportCard
                                           JOIN(Select I2.LINK_EMPL as LINKS, STAFF_LINK, I2.LINK From ITEM_MOVE I1
                                           Join (Select LINK_EMPL as  LINK_EMPL, MAX(LINK) as LINK From ITEM_MOVE
                                                 Where ACTIVE = 1
                                                 GROUP BY LINK_EMPL ) as I2 on I1.LINK = I2.LINK ) as T on T.LINKS=UsersReportCard.LINK
                                            JOIN dbo.FACES_MAIN_TBL AS FM ON FM.LINK = UsersReportCard.FACE_LINK
                                            JOIN dbo.STAFF STAF on STAF.LINK = T.STAFF_LINK
                                            JOIN dbo.SUBDIV AS DS ON STAF.SUBDIV_LINK = DS.LINK_UP
                                            JOIN dbo.DICTIONARY_SUBDIV_KLASSIF AS DSK ON DS.LINK_EX = DSK.LINK
                                            JOIN DICTIONARY_POST ON STAF.POST_LINK= DICTIONARY_POST.LINK
                                            JOIN (Select State.LINK_EMPL, STATUS.STATUS From dbo.EMPLOYERS_STATUS STATUS
                                            JOIN(Select LINK_EMPL, max(DATE) as DATE From dbo.EMPLOYERS_STATUS
                                                 Where DATE<Getdate()
                                                 GROUP BY LINK_EMPL) State on State.LINK_EMPL = STATUS.LINK_EMPL and State.DATE = STATUS.DATE) as STATUS on STATUS.LINK_EMPL = UsersReportCard.LINK
                                            JOIN dbo.STATUS_TYPES AS KSV ON STATUS.STATUS = KSV.LINK
                                        Where DSK.NAME = '{0}' and(DATE_OUT is NULL or DATE_OUT > '{1}')
                                        ORDER BY DICTIONARY_POST.LINK
                                        For Xml Auto";

        /// <summary>
        /// Диапазоны отпусков
        /// </summary>
        public string ItemVacation = @"Select DATE_BEGIN as Date_begin,
                                              DATE_END as Date_end,
                                              CODE as Code
                                              From ITEM_VACATION as ItemVacation 
                                              INNER JOIN DICTIONARY_VACATION as TypeVacation on TypeVacation.LINK = ItemVacation.TYPE_LINK
                                              Where TAB_NUM = '{0}' and YEAR(DATE_BEGIN) = '{1}' For Xml Auto";
        /// <summary>
        /// Больничные листы
        /// </summary>
        public string Disability = @"Select Disability.DATE1 as Date_start_disability,
                                            Disability.DATE2 as Date_finish_disability
                                     FROM  dbo.FACES_MAIN_TBL AS FM 
                                     INNER JOIN dbo.EMPLOYERS_TBL AS E ON FM.LINK = E.FACE_LINK
                                     INNER JOIN dbo.SDOC_DIS as Disability ON Disability.LINK_EMPL = E.LINK
                                     Where E.TAB_NUM= '{0}' and YEAR(Disability.DATE1) = '{1}' For Xml Auto";
        /// <summary>
        /// Даты командировки
        /// </summary>
        public string Business = @"Select Business.DATE_BEGIN as BusinessStart, Business.DATE_END as BusinessFinish From dbo.ITEM_TRAVEL as Business
						           Where TAB_NUM = '{0}' and YEAR(DATE_BEGIN) = '{1}' For Xml Auto";

        /// <summary>
        /// Номер последнего приказа о переводе
        /// </summary>
        public string LastOrder = @"Declare @nLINK_EMPL int
                                    Set @nLINK_EMPL = (Select E.LINK FROM dbo.FACES_MAIN_TBL as FM 
                                                       INNER JOIN dbo.EMPLOYERS_TBL AS E ON FM.LINK = E.FACE_LINK
									                   Where TAB_NUM = '{0}')
                                    SELECT LTRIM(RTRIM(NUMBER)) +' от '+CONVERT(varchar,DATE,104) as LastOrder FROM ORDERS_REESTR as Orders_Reestr 
                                           JOIN (SELECT MAX(LINK) as LINK2 FROM ORDERS_REESTR WHERE link in (SELECT ORDER_LINK FROM dbo.GET_ORDERS_BY_EMPL(@nLINK_EMPL)) 
                                           and NAME_LINK = 2) as MaxLink on MaxLink.LINK2 = ORDERS_REESTR.LINK
                                           WHERE link in (SELECT ORDER_LINK FROM dbo.GET_ORDERS_BY_EMPL(@nLINK_EMPL))  For Xml Auto";
    }
}
