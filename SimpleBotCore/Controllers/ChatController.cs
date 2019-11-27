using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBotCore.Services;

namespace SimpleBotCore.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly ChatService service;

        public ChatController (ChatService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            service.Insert(new Model.Chat{ conversa = "aaa", DataConversa = System.DateTime.Now});
            return View();
        }
    }
}