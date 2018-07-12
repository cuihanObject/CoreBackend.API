using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBackend.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = "1weigaung@qq.com";
        private readonly string _mailForm = "1weiguang@163.com";
        private readonly ILogger<CloudMailService> _logger;

        public CloudMailService(ILogger<CloudMailService> logger)
        {
            _logger = logger;
        }
        public void SendEmail(string subject, string msg)
        {
            //Debug.WriteLine($"从{_mailForm}给{_mailTo}通过{nameof(LocalMailService)}发送了邮件");
            _logger.LogInformation($"从{_mailForm}给{_mailTo}通过{nameof(LocalMailService)}发送了邮件");
        }
    }
}
