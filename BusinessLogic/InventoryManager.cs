using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InventoryManager
    {
        public List<Inventory> InventoryReport()
        {
            List<Inventory> list = new List<Inventory>();
            string sql = @"SELECT s.*, a.Model, m.Name FROM tblInventory s INNER JOIN tblShoes a ON s.ShoeId = a.Id INNER JOIN tblBrands m ON a.BrandId = m.Id ORDER BY ShoeId, No";

            DataTable dt = DataHelper.GetTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                Inventory I = new Inventory();
                I.Count = (int)item["Count"];
                I.ShoeId = (int)item["ShoeId"];
                I.No = (byte)item["No"];
                I.Id = (int)["Id"];
                I.Model = item["Model"].ToString();
                I.Brand = item["Brand"].ToString();
                list.Add(I);
            }
            return list;
        }

        public bool CreateInventoryMovement(InventoryMovement i)
        {
            SqlParameter p1 = new SqlParameter("sId", i.ShoeId);
            SqlParameter p2 = new SqlParameter("count", i.Count);
            SqlParameter p3 = new SqlParameter("no", i.No);
            SqlParameter p4 = new SqlParameter("type", i.Type);

            string sql = "exec dbo.CreateInventoryMovement @sId, @count, @no, @type";

            return DataHelper.RunCommand(sql, p1, p2, p3, p4);
        }
    }
}
