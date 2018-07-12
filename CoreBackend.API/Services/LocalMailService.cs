using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBackend.API.Services
{
    
    public interface IMailService
    {
        void SendEmail(string subject, string msg);
    }

    public class LocalMailService:IMailService
    {
        private readonly string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        private readonly string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];

        //private string _mailTo = "ch987654322@163.com";
        //private string _mailFrom = "940647609@qq.com";
        public void SendEmail(string subject, string msg)
        {
            Debug.WriteLine($"邮件由{_mailFrom}发送给了{_mailTo}，请注意查收！");
        }
        
    }
}
