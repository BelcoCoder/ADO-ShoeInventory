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
    public class BrandRepository
    {
        public List<Brand> AllBrands()
        {
            List<Brand> list = new List<Brand>();
            string sql = @"SELECT * FROM tblBrands";
            DataTable dt = DataHelper.GetTable(sql);

            foreach (DataRow item in dt.Rows)
            {
                Brand b = new Brand();
                b.Id = (int)item["Id"];
                b.Name = item["Name"].ToString();
                list.Add(b);
            }
            return list;
        }

        public bool AddBrand(Shoe newBrand, out int id)
        {
            string sql = "INSERT INTO tblBrands (Name) VALUES (@brandName)";

            SqlParameter p1 = new SqlParameter("brandName", newBrand.BrandId);

            bool result = DataHelper.RunCommand(sql, p1);
            if (result)
            {
                string sql2 = "SELECT MAX(Id) FROM tblBrands";
                DataTable dt = DataHelper.GetTable(sql2);
                id = (int)dt.Rows[0][0];
            }
            else
                id = -1;
            return result;
        }

        public bool RemoveBrand(int id)
        {
            string sql = "DELETE FROM tblBrands" + "WHERE Id=@id";

            SqlParameter p1 = new SqlParameter("id", id);

            return DataHelper.RunCommand(sql, p1);
        }

        public bool UpdateBrand(Brand uBrand)
        {
            string sql = "UPDATE tblBrands SET Name=@brandName WHERE Id=@id";

            SqlParameter p1 = new SqlParameter("id", uBrand.Id);
            SqlParameter p2 = new SqlParameter("model", uBrand.Name);

            return DataHelper.RunCommand(sql, p1, p2);
        }
    }
}
