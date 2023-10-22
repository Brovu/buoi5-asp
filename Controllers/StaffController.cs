using DataBase_Nhom2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DataBase_Nhom2.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Staff(string filter, int ?id)
        {
            /*m => m.tenNhanVien.ToLower().Contains(filter.ToLower()) == true & (*/
            CompanyEntities1 db = new CompanyEntities1();
            List<NhanVien> listNews = db.NhanViens.Where(m => m.maPhong == id | id == null).ToList();
            Dictionary<int, decimal> phongBanLuongTotal = new Dictionary<int, decimal>();

            foreach (var nv in listNews)
            {
                int? maPhong = nv.maPhong;
                decimal luong = nv.luong ?? 0m;
                if (maPhong.HasValue)
                {
                    if (phongBanLuongTotal.ContainsKey(maPhong.Value))
                    {
                        phongBanLuongTotal[maPhong.Value] += luong;
                    }
                    else
                    {
                        phongBanLuongTotal[maPhong.Value] = luong;
                    }

                }
                ViewBag.Total = phongBanLuongTotal;


            }

            if (listNews.Count == 0)
            {
                return View(db.NhanViens.ToList());

            } else
            {
                ViewBag.Number = listNews.Count;
                return View(listNews);

            }
        }

        public ActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(NhanVien model, HttpPostedFileBase ImageFile)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            if (ImageFile.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Images/");
                string path = rootFolder + ImageFile.FileName;
                ImageFile.SaveAs(path);

                model.hinhAnh = "/Images/" + ImageFile.FileName;
            }
            comp.NhanViens.Add(model);
            comp.SaveChanges();
            return RedirectToAction("Staff");
        }

        public ActionResult EditStaff(int id)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            NhanVien nv = comp.NhanViens.Find(id);
            return View(nv);
        }

        [HttpPost]
        public ActionResult EditStaff(NhanVien model, HttpPostedFileBase ImageFile2)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            if (ImageFile2.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Images/");
                string path = rootFolder + ImageFile2.FileName;
                ImageFile2.SaveAs(path);

                model.hinhAnh = "/Images/" + ImageFile2.FileName;
            }
            var newNv = comp.NhanViens.Find(model.maNhanVien);

            newNv.maNhanVien = model.maNhanVien;
            newNv.tenNhanVien = model.tenNhanVien;
            newNv.ngaySinh = model.ngaySinh;
            newNv.hinhAnh = model.hinhAnh;
            newNv.maPhong = model.maPhong;
            comp.SaveChanges();
            return RedirectToAction("Staff");
        }

        public ActionResult DeleteStaff(int id)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            var model = comp.NhanViens.Find(id);
            comp.NhanViens.Remove(model);
            comp.SaveChanges();
            return RedirectToAction("Staff");

        }

    }
}