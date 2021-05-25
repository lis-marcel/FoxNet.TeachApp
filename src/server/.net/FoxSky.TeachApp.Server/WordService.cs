using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoxSky.TeachApp.Service
{
    public class WordService : ServiceBase
    {
        public int AddWord(WordData wordData)
        {
            var w = new Word() { UserId = wordData.UserId, CategoryId = wordData.CategoryId, Phrase = wordData.Phrase, Translation = wordData.Translation, Note = wordData.Translation };
            var db = GetContext();
            var res = db.Words.Add(w);
            db.SaveChanges();

            return res.Entity.WordId;
        }

        public IList<WordData> GetAllWords(int userId)
        {
            var db = GetContext();
            var res = new List<WordData>();

            return db.Words
                .Where(w => w.UserId == userId)
                .Select(w => new WordData() 
                { 
                    WordId = w.WordId,
                    CategoryId = w.CategoryId,
                    Phrase = w.Phrase,
                    Translation = w.Translation,
                    Note = w.Note
                })
                .ToList();
        }

        public WordData GetWord(int wordId)
        {
            var db = GetContext();
            var word = db.Words.SingleOrDefault(w => w.WordId == wordId);

            return word != null ?
                new WordData() { CategoryId = word.CategoryId, Phrase = word.Phrase, Translation = word.Translation, Note = word.Note } : null;
        }

        public void EditWord(WordData wordData)
        {
            var db = GetContext();
            var word = db.Words.SingleOrDefault(w => w.WordId == wordData.WordId);

            if (word == null)
            {
                db.SaveChanges();
            }

            else
            {
                word.CategoryId = wordData.CategoryId;
                word.Phrase = wordData.Phrase;
                word.Note = wordData.Note;
                word.Translation = wordData.Translation;
                db.SaveChanges();
            }
        }

        public void DeleteWord(int wordId)
        {
            var db = GetContext();
            var res = db.Words.Single(d => d.WordId == wordId);
            db.Words.Remove(res);

            db.SaveChanges();
        }
    }
}
