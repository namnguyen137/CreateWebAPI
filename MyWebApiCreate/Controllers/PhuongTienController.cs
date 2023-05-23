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
    public class PhuongTienController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public PhuongTienController(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        //[HttpPost]
        //public IActionResult Create(TransportModel Model)
        //{
        //    try
        //    {
        //        PhuongTien _Transport = new PhuongTien
        //        {
        //            Name = Model.Name,
        //            Buy_Date = Model.Buy_Date,
        //            Buy_Name = Model.Buy_Name
        //        };
        //        dbContext.Add(_Transport);
        //        dbContext.SaveChanges();
        //        return Ok(new
        //        {
        //            Notice = "Save success !!!",
        //            Data = _Transport,
        //        });

        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        public IActionResult Create(TransportModel Model)
        {
            try
            {
                School _Transport = new School
                {
                    Quantity = Model.Quantity,
                };
                dbContext.Add(_Transport);
                dbContext.SaveChanges();
                return Ok(new
                {
                    Notice = "Save success !!!",
                    Data = _Transport,
                });

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetAllTransport = dbContext.PhuongTiens.ToList();
            return Ok(GetAllTransport);
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(string id)
        {
            try
            {
                var FindID = dbContext.PhuongTiens.SingleOrDefault(x => x.Id == int.Parse(id));
                if (FindID != null)
                {
                    return Ok(FindID);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult EditTransport(string id, TransportModel trans)
        {
            var findId = dbContext.PhuongTiens.SingleOrDefault(x => x.Id == int.Parse(id));
            if (findId != null)
            {
                findId.Name = trans.Name;
                findId.Buy_Date = trans.Buy_Date;
                findId.Buy_Name = trans.Buy_Name;
                dbContext.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = trans
                });
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                //var findId = dbContext.PhuongTiens.SingleOrDefault(x => x.Id == Guid.Parse(id));
                //dbContext.PhuongTiens.Remove(findId);
                dbContext.PhuongTiens.Remove(dbContext.PhuongTiens.SingleOrDefault(x => x.Id == int.Parse(id)));
                return Ok(
                    new
                    {
                        success = true
                    });
            }
            catch
            {
                return BadRequest();
            }


        }
    }
}
