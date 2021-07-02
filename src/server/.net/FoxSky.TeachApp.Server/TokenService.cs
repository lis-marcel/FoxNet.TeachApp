using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;

namespace FoxSky.TeachApp.Service.Data
{
    public class TokenService : ServiceBase
    {
        /*public int GenerateToken(UserData userData)
        {
            var t = new TokenData() { UserId = userData.UserId, Value = Guid.NewGuid().ToString() };

            var db = GetContext();
            var res = db.Tokens.Add(t);
            db.SaveChanges();

            return res.Entity.TokenId;
        }*/
    }
}
