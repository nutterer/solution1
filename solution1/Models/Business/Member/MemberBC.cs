using database.Database;
using solution1.Models.Business.Base;
using solution1.Models.ModelApp.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace solution1.Models.Business.Member
{
    public class MemberBC : BaseBC
    {
        public List<smUser> getUsers(string userID = "")
        {
            var users = new List<smUser>();
            if (!string.IsNullOrEmpty(userID))
                users = qDB.smUsers.Where(w => w.UserID == userID).ToList();
            else
                users = qDB.smUsers.ToList();

            return users;
        }
        public UserCookiesModel bindlogin(string UserName ,string Password)
        {
            var user = new UserCookiesModel();
            var dataUser = qDB.smUsers.Where(w => w.UserName == UserName && w.Password == Password).FirstOrDefault();
            if (dataUser != null)
            {
                user.UserID = dataUser.UserID;
                user.UserName = dataUser.UserName;
                user.IsAdmin = dataUser.IsAdmin;
            }
            else
            {
                user.UserID = null;
                user.UserName = null;
                return user = null;
            }

            return user;
        }
        public smUser bindSave(smUser model)
        {
            var data = new smUser();
            data.UserID = Guid.NewGuid().ToString();
            data.IsAdmin = model.IsAdmin;
            data.UserName = model.UserName;
            data.Password = model.Password;
            saveDefault<smUser>(data);

            return data;
        }
        public smUser bindEdit(smUser model)
        {
            var data = qDB.smUsers.Where(w => w.UserID == model.UserID).FirstOrDefault();
            data.UserID = model.UserID;
            data.IsAdmin = model.IsAdmin;
            data.UserName = model.UserName;
            data.Password = model.Password;
            qDB.Entry(data).State = EntityState.Modified;
            qDB.SaveChanges();

            return data;
        }
        public bool bindDelete(string UserID)
        {
            sqlCommandExcute("DELETE From smUser where UserID = '" + UserID + "'");

            return isResult;
        }

        

    }
}