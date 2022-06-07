using database.Database;
using solution1.Models.Business.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solution1.Models.Business.Home
{
    public class HomeBC : BaseBC
    {
        public List<smGood> getUser(string goodsID = "")
        {
            var goods = new List<smGood>();
            if (!string.IsNullOrEmpty(goodsID))
                goods = qDB.smGoods.Where(w => w.GoodsID == goodsID).ToList();
            else
                goods = qDB.smGoods.ToList();

            return goods;
        }

        public smGood bindSave(smGood model)
        {
            var data = new smGood();
            data.GoodsID = Guid.NewGuid().ToString();
            data.GoodsNo = model.GoodsNo;
            data.GoodsName = model.GoodsName;
            data.Price = model.Price;
            saveDefault<smGood>(data);

            return data;
        }
        public smGood bindEdit(smGood model)
        {
            var data = qDB.smGoods.Where(w => w.GoodsID == model.GoodsID).FirstOrDefault();
            data.GoodsID = model.GoodsID;
            data.GoodsNo = model.GoodsNo;
            data.GoodsName = model.GoodsName;
            data.Price = model.Price;
            qDB.Entry(data).State = EntityState.Modified;
            qDB.SaveChanges();

            return data;
        }

        public bool bindDelete(string goodsID)
        {
            sqlCommandExcute("DELETE From smGood where GoodsID = '" + goodsID + "'");

            return isResult;
        }
       
    }
}