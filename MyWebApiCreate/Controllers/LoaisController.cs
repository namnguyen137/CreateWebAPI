using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiCreate.Data;
using MyWebApiCreate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public LoaisController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var LoaiList = _dbContext.Loais.ToList();
            return Ok(LoaiList);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var LoaiFind = _dbContext.Loais.Where(x => x.MaLoai == id).FirstOrDefault();
            if (LoaiFind == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(LoaiFind);
            }

        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateLoai(LoaiModel loai)
        {
            try
            {
                Loai _loai = new Loai
                {
                    TenLoai = loai.TenLoai
                };
                _dbContext.Add(_loai);
                _dbContext.SaveChanges();
                return Ok(_loai);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditHangHoa(int id, LoaiModel _loai)
        {
            try
            {
                var findProduct = _dbContext.Loais.SingleOrDefault(x => x.MaLoai == id);
                if (findProduct == null)
                {
                    return NotFound();

                }
                else
                {
                    findProduct.TenLoai = _loai.TenLoai;
                    _dbContext.SaveChanges();
                    return Ok(new
                    {
                        Notice = "Edit Success ",
                        data = _loai

                    });
                }

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
