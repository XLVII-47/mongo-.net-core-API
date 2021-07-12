using BranchsApi.Models;
using BranchsApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BranchsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _branchService;

        public BranchController(BranchService branchService)
        {
            _branchService = branchService;
        }

       
        [HttpGet]
        public ActionResult<List<Branch>> Get() =>
            _branchService.Get();


        [HttpGet("{id}")]
        public ActionResult<Branch> Get(int id)
        {
            var branch = _branchService.Get(id);

            if (branch == null)
            {
                return NotFound();
            }

            return branch;
        }


        [HttpPost]
        public ActionResult<Branch> Create(Branch branch)
        {
            _branchService.Create(branch);

            return NoContent();
        }


       
        [HttpPut("{id}")]
        public IActionResult Update(int id, Branch branchIn)
        {
            var branch = _branchService.Get(id);

            if (branch == null)
            {
                return NotFound();
            }

            _branchService.Update(id, branchIn);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var branch = _branchService.Get(id);

            if (branch == null)
            {
                return NotFound();
            }

            _branchService.Remove(branch.id);

            return NoContent();
        }
       
    }
}
