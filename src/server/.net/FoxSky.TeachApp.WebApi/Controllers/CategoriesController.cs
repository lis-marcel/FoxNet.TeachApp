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
    [Route("webapi/category")]
    public class CategoriesController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public int AddCategory([FromBody] CategoryData categoryData)
        {
            return new CategoryService().AddCategory(categoryData);
        }

        [HttpGet]
        [Route("all")]
        public IList<CategoryData> GetAllCategories()
        {
            return new CategoryService().GetAllCategories();
        }

        [HttpGet]
        [Route("get/{id}")]
        public CategoryData GetCategory(int wordId)
        {
            return new CategoryService().GetCategory(wordId);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteCategory(int categoryId)
        {
            new CategoryService().DeleteCategory(categoryId);
        }
    }
}
