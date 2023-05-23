using MyWebApiCreate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Services
{
    public class LoaiRepositoryInMemory : ILoaiRepository
    {
        static List<LoaiVM> loais = new List<LoaiVM>()
        {
            new LoaiVM() { MaLoai = 1, TenLoai = "Chai"},
            new LoaiVM() { MaLoai = 2, TenLoai = "Loa"},
            new LoaiVM() { MaLoai = 3, TenLoai = "Nuoc Hoa"},
            new LoaiVM() { MaLoai = 4, TenLoai = "Tai nghe"}
        };

        public LoaiVM Add(LoaiModel loai)
        {
            var data = new LoaiVM()
            {
                MaLoai = loais.Count + 1,
                TenLoai = loai.TenLoai
            };
            loais.Add(data);
            return data;
        }

        public void Delete(int id)
        {
            var data = loais.SingleOrDefault(x => x.MaLoai == id);
            loais.Remove(data);
        }

        public List<LoaiVM> GetAll()
        {
            return loais;
        }

        public LoaiVM GetById(int id)
        {
            return loais.SingleOrDefault(x => x.MaLoai == id);
        }

        public void Update(LoaiVM loai)
        {
            var data = loais.SingleOrDefault(x => x.MaLoai == loai.MaLoai);
            if(data != null)
            {
                data.TenLoai = loai.TenLoai;
            }
        }
    }
}
