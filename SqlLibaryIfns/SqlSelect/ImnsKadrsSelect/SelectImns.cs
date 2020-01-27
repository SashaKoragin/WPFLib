using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                             RTRIM(IM) as IM,
                                             RTRIM(OT) as OT,
                                             RTRIM(FM)as FM,
                                             RTRIM(STATUS.STATUS) as STATUS,
                                             RTRIM(KSV.NAME) as STATUS_NAME  FRom dbo.EMPLOYERS_TBL as ActualUser
                                     JOIN (  Select I2.LINK_EMPL as LINKS, STAFF_LINK,I2.LINK From ITEM_MOVE I1
                                     Join ( Select LINK_EMPL as  LINK_EMPL, MAX(LINK) as LINK From ITEM_MOVE
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

    }
}
