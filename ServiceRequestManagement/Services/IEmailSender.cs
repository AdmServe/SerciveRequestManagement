using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceRequestManagment.Models;

namespace ServiceRequestManagment.Services
{
	public interface IEmailSender
	{
		void SendEmail(Message message); 
	}
}
