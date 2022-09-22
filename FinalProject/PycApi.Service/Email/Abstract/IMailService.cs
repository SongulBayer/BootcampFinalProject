using PycApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Service
{
    public interface IMailService 
    {
       public void SendEmail(MailDto request);
    }
}
