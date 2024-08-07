﻿namespace SqlLibaryIfns.SqlSelect.ImnsKadrsSelect
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
                                            Where ACTIVE = 1 and DATE_END > GETDATE()
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
        /// Отбор пользователей для табелей новая полная выборка обрабатывающая ошибку перевода сотрудника а также подтягивает график рабочего времени
        /// </summary>
        public string UserReportCard = @"Select Fio,Tab_num,New_post,Status_link, Date_in,Date_out,LINK as Link,Link_Gr,NAME as NameGr  From (
                                          Select Fio,Tab_num,New_post,Status_link,max(Date_in) as Date_in,Date_out,LINK,Link_Users, TT.Link_Gr, TT.NAME From 
                                         (Select 
                                             RTRIM(FM)+' '+RTRIM(IM)+' '+RTRIM(OT) as Fio,
                                             RTRIM(UsersReportCard.TAB_NUM) as Tab_num,
											 DSK.NAME,
                                             RTRIM(DICTIONARY_POST.NAME) as New_post,
                                             RTRIM(KSV.LINK) as Status_link,
                                            ISNULL(Model.Date_in,UsersReportCard.Date_in) as Date_in,
                                             UsersReportCard.Date_out as Date_out,
											 DICTIONARY_POST.LINK,
											 UsersReportCard.LINK as Link_Users
                                         From dbo.EMPLOYERS_TBL as UsersReportCard
                                           JOIN(Select I2.LINK_EMPL as LINKS, STAFF_LINK, I2.LINK From ITEM_MOVE I1
                                           Join (Select LINK_EMPL as  LINK_EMPL, MAX(LINK) as LINK From ITEM_MOVE
                                                 Where ACTIVE = 1 and DATE_END > GETDATE()
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
											FULL Join (
											
											       Select RTRIM(IM.FM)+' '+RTRIM(IM.IM)+' '+RTRIM(IM.OT) as Fio,
											       RTRIM(IM.TAB_NUM) as Tab_num, RTRIM(NEW_SUBDIV) as New_subdiv, RTRIM(NEW_POST) as New_post, IM.STATUS,IM.DATE_BEGIN as Date_in,Date_END2 as Date_out,DICTIONARY_POST.LINK From dbo.ITEM_MOVE AS IM
	                                               INNER JOIN dbo.ORDERS AS O ON IM.ORDER_LINK = O.LINK AND IM.NEW_FACE = 0
	                                               INNER JOIN dbo.EMPLOYERS_TBL ON dbo.EMPLOYERS_TBL.TAB_NUM = IM.TAB_NUM
											       JOIN DICTIONARY_POST ON IM.POST= DICTIONARY_POST.NAME 
											       Where IM.SUBDIV<>IM.NEW_SUBDIV) as Model on Model.Tab_num = UsersReportCard.TAB_NUM and Model.New_subdiv = DSK.NAME
											UNION ALL
	                                        Select  RTRIM(IM.FM)+' '+RTRIM(IM.IM)+' '+RTRIM(IM.OT) as Fio,
											 RTRIM(IM.TAB_NUM) as Tab_num, RTRIM(SUBDIV) as Old_post, RTRIM(POST), IM.STATUS, Date_in, DATEADD(day,-1,IM.DATE_BEGIN),DICTIONARY_POST.LINK,dbo.EMPLOYERS_TBL.LINK as Link_Users From dbo.ITEM_MOVE AS IM
	                                        INNER JOIN dbo.ORDERS AS O ON IM.ORDER_LINK = O.LINK AND IM.NEW_FACE = 0
	                                        INNER JOIN dbo.EMPLOYERS_TBL ON dbo.EMPLOYERS_TBL.TAB_NUM = IM.TAB_NUM
											JOIN DICTIONARY_POST ON IM.POST= DICTIONARY_POST.NAME
											Where IM.SUBDIV<>IM.NEW_SUBDIV
											) as UsersReportCard
									   JOIN (Select v.LINK_EMPL,v.DATE_BEGIN,v.LINK as Link_Gr,v.NAME  From 
										   (Select  EMPLOYERS_GRAPHICS.LINK_EMPL,EMPLOYERS_GRAPHICS.DATE_BEGIN,GRAPH.LINK,GRAPH.NAME From EMPLOYERS_GRAPHICS
                                                  JOIN GRAPH on GRAPH.LINK = EMPLOYERS_GRAPHICS.LINK_GRAPHIC
                                                  Where EMPLOYERS_GRAPHICS.DATE_BEGIN <= DATEADD(month,1,'{0}') ) v
                                                  left join (Select EMPLOYERS_GRAPHICS.LINK_EMPL,EMPLOYERS_GRAPHICS.DATE_BEGIN,GRAPH.LINK,GRAPH.NAME From EMPLOYERS_GRAPHICS
                                                  JOIN GRAPH on GRAPH.LINK = EMPLOYERS_GRAPHICS.LINK_GRAPHIC
                                                                      Where EMPLOYERS_GRAPHICS.DATE_BEGIN <=  DATEADD(month,1,'{1}')) v2 on v.LINK_EMPL = v2.link_empl
                                                                      and v2.date_begin > v.DATE_BEGIN
                                                                      where v2.link_empl is null
                                                  ) as TT on TT.LINK_EMPL = UsersReportCard.Link_Users
                                        Where UsersReportCard.NAME = '{2}' and (DATE_OUT is NULL or DATE_OUT > '{3}') 

                                        GROUP BY Fio,Tab_num,New_post,Status_link,Date_out,LINK,Link_Users,TT.Link_Gr, TT.NAME
										)  as UsersReportCard
										ORDER BY UsersReportCard.Link
										For Xml Auto";
        /// <summary>
        /// Диапазоны отпусков
        /// </summary>
        public string ItemVacation = @"Select DATE_BEGIN as Date_begin,
                                              CASE WHEN DATE_BEGIN <= DATE_3 THEN DATE_3
	                                          ELSE DATE_END 
	                                          END as Date_end,
                                       CODE as Code From dbo.VACATION_REAL as ItemVacation  
	                                   INNER JOIN DICTIONARY_VACATION as TypeVacation on TypeVacation.LINK = ItemVacation.TYPE_LINK
	                                   Where ItemVacation.TAB_NUM = '{0}' and YEAR(ItemVacation.DATE_BEGIN) = '{1}' and( ItemVacation.DATE_3 is null or ItemVacation.DATE_3 >= ItemVacation.DATE_BEGIN)
	                                   For Xml Auto";
        /// <summary>
        /// Новые отпуска
        /// </summary>
        public string ItemVacationNew = @"Select DATE_BEGIN as Date_begin,
                                                 CASE WHEN DATE_BEGIN <= DATE_3 THEN DATE_3
	                                             ELSE DATE_END 
	                                             END as Date_end,
                                          CODE as Code From dbo.VACATION_REAL as ItemVacation  
	                                      INNER JOIN DICTIONARY_VACATION as TypeVacation on TypeVacation.LINK = ItemVacation.TYPE_LINK
	                                      Where ItemVacation.TAB_NUM = '{0}' and (YEAR(ItemVacation.DATE_BEGIN) = '{1}' or 
									                                           YEAR(CASE WHEN DATE_BEGIN <= DATE_3 THEN DATE_3
	                                                                           ELSE DATE_END END)  = '{2}') and ( ItemVacation.DATE_3 is null or ItemVacation.DATE_3 >= ItemVacation.DATE_BEGIN)
	                                   For Xml Auto";

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
        public string Business = @"Select Business.DATE_BEGIN as BusinessStart, 
                                   CASE WHEN Business.DATE_BEGIN = ITEM_TRAVEL_BREAK.DATE_BREAK_REAL THEN ITEM_TRAVEL_BREAK.DATE_BREAK_REAL
	                               ELSE Business.DATE_END 
	                               END as BusinessFinish From dbo.ITEM_TRAVEL as Business
                                   Left Join ITEM_TRAVEL_BREAK on Business.TAB_NUM = ITEM_TRAVEL_BREAK.TAB_NUM and
                                        (ITEM_TRAVEL_BREAK.NEW_DATE_END = Business.DATE_BEGIN OR ITEM_TRAVEL_BREAK.DATE_BREAK_REAL = Business.DATE_BEGIN )
                                   Where Business.TAB_NUM = '{0}' and YEAR(Business.DATE_BEGIN) = '{1}' and (ITEM_TRAVEL_BREAK.NEW_DATE_END is null OR Business.DATE_BEGIN = ITEM_TRAVEL_BREAK.DATE_BREAK_REAL)
                                   For Xml Auto";

        /// <summary>
        /// Номер последнего приказа о переводе
        /// </summary>
        public string LastOrder = @"Declare @nLINK_EMPL int 
                                    Set @nLINK_EMPL = (Select E.LINK FROM dbo.FACES_MAIN_TBL as FM  
                                                       INNER JOIN dbo.EMPLOYERS_TBL AS E ON FM.LINK = E.FACE_LINK 
                                                       Where TAB_NUM = '{0}')

                                    if Exists(SELECT NUMBER FROM ORDERS_REESTR as Orders_Reestr 
                                              JOIN (SELECT MAX(LINK) as LINK2 
                                                    FROM ORDERS_REESTR WHERE link in (SELECT ORDER_LINK FROM dbo.GET_ORDERS_BY_EMPL(@nLINK_EMPL)) and NAME_LINK = 2) as MaxLink on MaxLink.LINK2 = ORDERS_REESTR.LINK           
                                              WHERE link in (SELECT ORDER_LINK FROM dbo.GET_ORDERS_BY_EMPL(@nLINK_EMPL)))
                                        begin
                                            SELECT LTRIM(RTRIM(NUMBER)) +' от '+CONVERT(varchar,DATE,104) as LastOrder FROM ORDERS_REESTR as Orders_Reestr 
	                                        JOIN (SELECT MAX(LINK) as LINK2 FROM ORDERS_REESTR WHERE link in (SELECT ORDER_LINK FROM dbo.GET_ORDERS_BY_EMPL(@nLINK_EMPL)) and NAME_LINK = 2) as MaxLink on MaxLink.LINK2 = ORDERS_REESTR.LINK           
                                            WHERE link in (SELECT ORDER_LINK FROM dbo.GET_ORDERS_BY_EMPL(@nLINK_EMPL))  For Xml Auto
                                        end
                                    Else 
                                        begin 
	                                        SELECT Top 1 'ДАННЫЕ НА ПРИКАЗ О ПЕРЕВОДЕ ОТСУТСТВУЮТ' as LastOrder 
	                                        FROM ORDERS_REESTR as Orders_Reestr  For Xml Auto
                                        end";
    }
}
