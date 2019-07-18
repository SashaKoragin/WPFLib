using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.SelectImnsKadr
{
   public class ImnsKadr
   {
        /// <summary>
        /// Выборка уволенных пользователей из IMNS51
        /// </summary>
        public string IsNotActualUser = @"Select face.TAB_NUM,face.NEW_POST,sub.NAME From dbo.STAFF staf
                      Join(Select I1.TAB_NUM, FM, IM, OT, NEW_SUBDIV, NEW_POST, STAFF_LINK FROM ITEM_MOVE I1
                             Join (Select LINK_EMPL, MAX(LINK) as LINK From ITEM_MOVE
                                   GROUP BY LINK_EMPL) I2 on I1.LINK = I2.LINK
                             Join EMPLOYERS_TBL emp on emp.LINK=I2.LINK_EMPL and emp.DATE_OUT is not null) face on face.STAFF_LINK = staf.LINK
                      LEFT Join dbo.SUBDIV sub on sub.LINK_UP = staf.SUBDIV_LINK For Xml Auto";
        /// <summary>
        /// Выборка Актуальных пользователей из IMNS51
        /// </summary>
       public string IsAktual = @"Select face.TAB_NUM,face.NEW_POST,sub.NAME From dbo.STAFF staf
                      Join (Select I1.TAB_NUM,FM,IM,OT,NEW_SUBDIV,NEW_POST,STAFF_LINK FROM ITEM_MOVE I1
                             Join (Select LINK_EMPL, MAX(LINK) as LINK From ITEM_MOVE
                                   GROUP BY LINK_EMPL) I2 on I1.LINK = I2.LINK 
                             Join EMPLOYERS_TBL emp on emp.LINK=I2.LINK_EMPL and emp.DATE_OUT is null) face on face.STAFF_LINK = staf.LINK
                     LEFT Join dbo.SUBDIV sub on sub.LINK_UP = staf.SUBDIV_LINK For Xml Auto";
   }
}
