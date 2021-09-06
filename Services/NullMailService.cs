﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasteryShop.Services
{
    public class NullMailService : IMailService
    {
        private ILogger<NullMailService> _logger { get; }

        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }


        public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To {to} Subject {subject} Body {body}");
        }
    }
}
