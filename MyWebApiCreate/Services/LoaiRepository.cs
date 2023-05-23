using MyWebApiCreate.Data;
using MyWebApiCreate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _DbContext;

        public LoaiRepository(MyDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai()
            {
                TenLoai = loai.TenLoai
            };
            _DbContext.Add(_loai);
            _DbContext.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var data = _DbContext.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (data != null)
            {
                _DbContext.Remove(data);
                _DbContext.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _DbContext.Loais.Select(loai => new LoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
            }).ToList();
            return loais;
        }

        public LoaiVM GetById(int id)
        {
            var data = _DbContext.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (data != null)
            {
                return new LoaiVM()
                {
                    MaLoai = data.MaLoai,
                    TenLoai = data.TenLoai
                };
            }
            return null;
        }

        public void Update(LoaiVM loai)
        {
            var data = _DbContext.Loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            if (data != null)
            {
                data.TenLoai = loai.TenLoai;
                _DbContext.SaveChanges();
            }

        }
    }
}
