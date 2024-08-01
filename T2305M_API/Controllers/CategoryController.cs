using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2305M_API.Entities;
using T2305M_API.DTO.ResponseModel;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2305M_API.Controllers
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : Controller
    {
        private readonly T2305mApiContext _context;
        public CategoryController(T2305mApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            List<CategoryResponse> data = new List<CategoryResponse>();
            foreach(var item in categories)
            {
                data.Add(new CategoryResponse(item));
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Get(int id)
        {
            try
            {
                Category category = _context.Categories.Find(id);
                if (category == null)
                    throw new Exception("Category not found");
                return Ok(new CategoryResponse(category));
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
           
        }


        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Hello POST");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Hello PUT");
        }
    }
}

