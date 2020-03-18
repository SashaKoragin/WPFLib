using System.DirectoryServices.AccountManagement;
using System.Linq;
using ServiceAutomation.LoginAD.XsdShemeLogin;

namespace ServiceAutomation.LoginAD.Login
{
    public class LoginIdentificationUser
    {

        public Identification AuthUserService(Identification identification)
        {
            if (identification.Login != null)
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, null, identification.Login, identification.Password))
                {
                    if (context.ValidateCredentials(identification.Login, identification.Password))
                    {
                        using (var users = new UserPrincipal(context))
                        {
                            users.SamAccountName = identification.Login;
                            
                            using (var searcher = new PrincipalSearcher(users))
                            {
                                var user = searcher.FindOne() as UserPrincipal;
                                if (user != null)
                                {
                                    var group = user.GetGroups();
                                    identification.GroupRuleServer = new string[group.Count()];
                                    var i = 0;
                                    foreach (var gr in group)
                                    {
                                        identification.GroupRuleServer[i] = gr.Name;
                                         i++;
                                    }
                                    identification.Name = user.Name;
                                    identification.ErrorMessage = null;
                                    identification.IsError = false;
                                    return identification;
                                }
                            }
                        }
                        identification.ErrorMessage = "Пользователь не найден!!!";
                        identification.IsError = true;
                        return identification;
                    }
                    identification.ErrorMessage = "Не правильный логин/пароль!!!";
                    identification.IsError = true;
                    return identification;
                }
            }
            identification.ErrorMessage = "Пользователь не введен!!!";
            identification.IsError = true;
            return identification;
        }
    }
}