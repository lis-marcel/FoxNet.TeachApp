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
    [Route("webapi/word")]

    public class WordController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public int AddWord(WordData wordData)
        {
            return new WordService().AddWord(wordData);
        }

        [HttpGet]
        [Route("all/{userId}")]
        public IList<WordData> GetAllWords(int userId)
        {
            return new WordService().GetAllWords(userId);
        }

        [HttpGet]
        [Route("get/{id}")]
        public WordData GetWord(int wordId)
        {
            return new WordService().GetWord(wordId);
        }

        [HttpPost]
        [Route("edit")]
        public void EditWord(WordData wordData)
        {
            new WordService().EditWord(wordData);
        }

        [HttpPost]
        [Route("delete")]
        public void DeleteWord(int wordId)
        {
            new WordService().DeleteWord(wordId);
        }
    }
}
