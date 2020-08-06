﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using ServiceRequestManagment.Models;

namespace ServiceRequestManagment.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly EmailConfiguration _emailConfig;

		public EmailSender(EmailConfiguration emailConfig)
		{
			this._emailConfig = emailConfig;
		}

		public void SendEmail(Message message)
		{
			var emailMessage = CreateEmailMessage(message);

			Send(emailMessage);
		}


		private void Send(MimeMessage emailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect(_emailConfig.SmtpServer, _emailConfig.port, true);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					client.Authenticate(_emailConfig.Username, _emailConfig.Password);
					client.Send(emailMessage);

				}
				catch
				{
					throw;
				}
				finally
				{
					client.Disconnect(true);
					client.Dispose();
				}
			}
			
		}

		private MimeMessage CreateEmailMessage(Message message)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
			emailMessage.To.AddRange(message.To);
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

			return emailMessage;
		}
	}
}
