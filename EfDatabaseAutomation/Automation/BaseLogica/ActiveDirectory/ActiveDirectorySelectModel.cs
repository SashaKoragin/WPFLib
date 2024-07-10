using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDatabaseAutomation.Automation.BaseLogica.ActiveDirectory
{
    public class ActiveDirectorySelectModel
    {
        /// <summary>
        /// Вытащить все группы пользователя по табельному номеру
        /// </summary>
        /// <param name="idUserDomain"></param>
        /// <returns></returns>
        public string[] SelectAllGroupUser(string idUserDomain)
        {
            string[] groups;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "regions.tax.nalog.ru"))
            {
                using (var user = UserPrincipal.FindByIdentity(context, idUserDomain))
                {
                    if (user != null)
                    {
                        var group = user.GetGroups();
                        {
                            groups = new string[@group.Count()];
                            var i = 0;
                            foreach (var gr in @group)
                            {
                                groups[i] = gr.Name;
                                i++;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return groups;
        }

    }
}
