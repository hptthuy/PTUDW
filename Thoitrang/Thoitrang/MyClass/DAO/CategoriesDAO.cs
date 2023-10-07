using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
   
    public class CategoriesDAO
    {
        private MyDBContext db = new MyDBContext(); 


        //INDEX=SELECT* FROM
        public List<Categories> getList() // danh sách trả về là list // getlist là tên hàm
        {
            return db.Categories.ToList();
            //trả về hàng trong category
        }
        public List<Categories> getList(string status = "All")//status 1, 2 hiển thị- 0 ẩn đi // giá trị mặc định là all tức là tất cả các giá trị đều hiển thị 
        {
            List<Categories> list = null;
            switch (status)
            {
                case "Index"://status = 1,2
                    {
                        list = db.Categories.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash": //status = 0
                    {
                        list = db.Categories.Where(m => m.Status == 0).ToList();
                        break;
                       
                    }
                default: //status = 0
                    {
                        list = db.Categories.ToList();
                        break;
                    }
            }
            return list;
        }
        public Categories getRow(int? id)
        {
            if (id == null)
            {  
                return null; 
            }
            else
            {
                return db.Categories.Find(id);
            }

        }
        public int Insert (Categories row)
        {
            db.Categories.Add(row);
            return db.SaveChanges();
        }
        public int Update (Categories row)
        {
            db.Entry(row).State = EntityState.Modified;
           return db.SaveChanges();
        }
        public int Delete (Categories row)
        {
            db.Categories.Remove(row);
            return db.SaveChanges();
        }
           
    }
}
