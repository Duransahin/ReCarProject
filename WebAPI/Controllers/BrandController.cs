using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BrandController:ControllerBase
    {
        IBrandService _brandeService;
        public BrandController(IBrandService brandeService)
        {
            _brandeService = brandeService;
        }
        public IActionResult GetAll()
        {
            var result = _brandeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult Add(Brand brand)
        {
            var result = _brandeService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult Update(Brand brand)
        {
            var result = _brandeService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult Delete(Brand brand)
        {
            var result = _brandeService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult GetByBrandsId(int brandId)
        {
            var result = _brandeService.GetByBrandsId(brandId);
            if (result.Success)
            {
                return  Ok(result);
            }
            return BadRequest(result);
        }
    }
}
