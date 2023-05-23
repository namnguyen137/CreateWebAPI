using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiCreate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(hangHoas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //LinQ [object] Query
                //var FindHangHoa = hangHoas.SingleOrDefault();
                var FindHangHoa = hangHoas.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));
                if (FindHangHoa == null)
                {
                    return NotFound();
                }
                return Ok(FindHangHoa);
            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            
            var hangHoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
            };
            hangHoas.Add(hangHoa);
            return Ok(new
            {
                Success = true, Data = hangHoa
            });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                //var guidID = Guid.Parse(id);
                var FindID = hangHoas.Where(x => x.MaHangHoa == Guid.Parse(id)).FirstOrDefault();
                if (FindID == null)
                {
                    return NotFound();
                }
                var DeleteHangHoa = hangHoas.Remove(FindID);
                return Ok(new
                {
                    ThongBao = "Don Hang da duoc xoa",
                    Success = true,
                    Data = FindID,

                }
                ) ;

            }
            catch
            {
               return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult GetEditHangHoa(HangHoa HangHoaEdit)
        {
            try
            {
                var FindHangHoa = hangHoas.SingleOrDefault(x => x.MaHangHoa == HangHoaEdit.MaHangHoa);
                if (FindHangHoa == null)
                {
                    return NotFound();
                }else
                {
                    FindHangHoa.TenHangHoa = HangHoaEdit.TenHangHoa;
                    FindHangHoa.DonGia = HangHoaEdit.DonGia;
                }

                return Ok(FindHangHoa);
            }
            catch
            {
                return BadRequest();
            }

        }




    }
}
