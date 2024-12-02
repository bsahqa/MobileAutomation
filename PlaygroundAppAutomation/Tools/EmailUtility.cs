using Mailosaur;
using Mailosaur.Models;
using NUnit.Framework;
using System;

namespace MobileAutomation.Tools
{
	public class EmailUtility
	{
		// Mailosaur configuration
		private static readonly string apiKey = "onh0qqVGB9EWPqYrL4dOQ2dO1lCujbOi";
		private static readonly string serverId = "slacejt6";
		private static readonly string serverDomain = $"serverId.mailosaur.net";
		private MailosaurClient mailosaur = new MailosaurClient(apiKey);
		#region Reading Emails

		public Message GetMessage(string emailAddress)
		{
			try
			{
				var criteria = new SearchCriteria()
				{
					Subject = emailAddress
				};
				var message = mailosaur.Messages.Get(serverId, criteria, 5000);

				return message;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Assert.Fail($"Failed to retrieve email from Mailosaur after 5 seconds. Search criteria was: {emailAddress}");
				return null;
			}
		}
		#endregion
	}
}
