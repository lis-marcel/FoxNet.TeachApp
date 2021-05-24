using FoxSky.TeachApp.Service;
using FoxSky.TeachApp.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.WebApi.Controllers
{
    [ApiController]
    [Route("/administration/category")]
    public class CategoriesController : Controller
    {
        [HttpPost]
        [Route("add")]
        public int AddCategory(CategoryData categoryData)
        {
            return new CategoryData().AddCategory(categoryData);
        }
    }
}
