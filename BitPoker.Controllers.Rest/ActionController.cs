﻿using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace BitPoker.Controllers.Rest
{
    public class ActionController : BaseController, IActionController
    {
		public BitPoker.Repository.IHandRepository HandRepo { get; set; }
	
		public BitPoker.Repository.IMessagesRepository MessageRepo { get; set; }
	
		public ActionController()
		{
			base.PrivateKey = System.Configuration.ConfigurationManager.AppSettings["BitcoinPrivateKey"];
			HandRepo = new BitPoker.Repository.Mocks.HandRepository();
			MessageRepo = new BitPoker.Repository.Mocks.MessageRepo();
		}
	
		[HttpGet]
		public IEnumerable<BitPoker.Models.Messages.ActionMessage> Get(string id)
		{
			return MessageRepo.All().Where(m => m.HandId.ToString() == id);
		}
	
		[HttpPost]
		public void Post(BitPoker.Models.Messages.ActionMessage message)
		{
			if (base.Verify(message) == true)
			{
				Models.Hand hand = HandRepo.All().Single(h => h.Id.ToString() == message.HandId.ToString());
			
				if (hand != null)
				{
	
				}
			}
		}
    }
}