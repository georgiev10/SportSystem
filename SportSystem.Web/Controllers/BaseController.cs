using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportSystem.Data;

namespace SportSystem.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        public ISportSystemData Data { get; private set; }
    }

}