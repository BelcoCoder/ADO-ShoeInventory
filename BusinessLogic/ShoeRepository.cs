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
    public class ShoeRepository
    {
        public List<Shoe> GetByBrand(int brandId)
        {
            List<Shoe> list = new List<Shoe>();
            string sql = "SELECT * FROM tblShoes WHERE BrandId=" + brandId;
            DataTable dt = DataHelper.GetTable(sql);

            foreach (DataRow item in dt.Rows)
            {
                Shoe s = new Shoe();
                s.Id = (int)item["Id"];
                s.BrandId = (int)item["BrandId"];
                s.Model = item["Model"].ToString();
                s.Sex = (Sex)(int)item["Sex"];
                s.Kind = (Kind)(int)item["Kind"];
                list.Add(s);
            }
            return list;
        }

        public List<Shoe> AllShoes()
        {
            List<Shoe> list = new List<Shoe>();
            string sql = @"SELECT s.*, b.Name FROM tblShoes s INNER JOIN tblBrands b ON s.BrandId = b.Id";
            DataTable dt = DataHelper.GetTable(sql);

            foreach (DataRow item in dt.Rows)
            {
                Shoe s = new Shoe();
                s.Id = (int)item["Id"];
                s.BrandId = (int)item["BrandId"];
                s.Model = item["Model"].ToString();
                s.Sex = (Sex)(int)item["Sex"];
                s.Kind = (Kind)(int)item["Kind"];
                s.Brand = new Brand();
                s.Brand.Id = (int)item["BrandId"];
                s.Brand.Name = item["BrandName"].ToString();
                list.Add(s);
            }
            return list;
        }

        public bool AddShoe(Shoe newShoe)
        {
            string sql = "INSERT INTO tblShoes" + "(BrandId, Model, Sex, Kind)" + "VALUES(@brandId, @model, @sex, @kind)";

            SqlParameter p1 = new SqlParameter("brandId", newShoe.BrandId);
            SqlParameter p2 = new SqlParameter("model", newShoe.Model);
            SqlParameter p3 = new SqlParameter("sex", newShoe.Sex);
            SqlParameter p4 = new SqlParameter("kind", newShoe.Kind);

            return DataHelper.RunCommand(sql, p1, p2, p3, p4);
        }

        public bool RemoveShoe(int id)
        {
            string sql = "DELETE FROM tblShoes" + "WHERE Id=@id";

            SqlParameter p1 = new SqlParameter("id", id);

            return DataHelper.RunCommand(sql, p1);
        }

        public bool UpdateShoe(Shoe uShoe)
        {
            string sql = "UPDATE tblShoes" + "SET BrandId=@brandId," + "Model=@model," + "Sex=@sex," + "Kind=@kind" + "WHERE Id=@id";

            SqlParameter p1 = new SqlParameter("brandId", uShoe.BrandId);
            SqlParameter p2 = new SqlParameter("model", uShoe.Model);
            SqlParameter p3 = new SqlParameter("sex", uShoe.Sex);
            SqlParameter p4 = new SqlParameter("kind", uShoe.Kind);
            SqlParameter p5 = new SqlParameter("id", uShoe.Id);

            return DataHelper.RunCommand(sql, p1, p2, p3, p4, p5);
        }
    }
}
