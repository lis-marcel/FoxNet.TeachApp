using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoxSky.TeachApp.Service
{
    public class WordService
    {
        private DbStorageContext context;

        public WordService()
        {
        }

        public WordService(DbStorageContext context)
        {
            this.context = context;
        }

        private DbStorageContext GetContext()
        {
            if (context == null)
            {
                context = DbStorageFactory.GetInstance();
            }

            return context;
        }

        public int AddWord(WordData wordData)
        {
            var w = new Word() { UserId = wordData.UserId, CategoryId = wordData.CategoryId, Phrase = wordData.Phrase, Note = wordData.Note, Translation = wordData.Translation };
            var db = GetContext();
            var res = db.Words.Add(w);
            db.SaveChanges();

            return res.Entity.WordId;
        }

        public WordData GetWord(int wordId)
        {
            var db = GetContext();
            var word = db.Words.SingleOrDefault(u => u.WordId == wordId);

            return word != null ?
                new WordData() { CategoryId = word.CategoryId, Phrase = word.Phrase, Note = word.Note, Translation = word.Translation } :
                null;
        }

        public void EditWord(WordData wordData)
        {
            var db = GetContext();
            var word = db.Words.SingleOrDefault(d => d.WordId == wordData.WordId);

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
