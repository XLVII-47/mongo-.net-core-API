using BranchsApi.Models;
using BranchsApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BranchsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LayerController: ControllerBase
    {
        private readonly LayerService _layerService;

        public LayerController(LayerService layerService)
        {
            _layerService = layerService;
        }

        [HttpGet]
        public ActionResult<List<extendLayer>> Get() =>
           _layerService.Get();

        [HttpGet("{id}")]
        public ActionResult<List<extendLayer>> Get(int id) =>
           _layerService.Get(id);

        [HttpPost]
        public ActionResult<extendLayer> Create(extendLayer layer)
        {
            _layerService.Create(layer);

            return NoContent();
        }
    }
}
