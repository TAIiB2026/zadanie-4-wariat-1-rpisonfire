using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduktyController : ControllerBase
    {
        private readonly GetDataInterface _getDataService;
        private readonly FormSubmitInterface _formSubmitService;

        public ProduktyController(GetDataInterface getDataService, FormSubmitInterface formSubmitService)
        {
            _getDataService = getDataService;
            _formSubmitService = formSubmitService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produkt>> Get()
        {
            return Ok(_getDataService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Produkt> GetByID(int id)
        {
            var produkt = _getDataService.GetByID(id);
            if (produkt == null)
                return NotFound();
            return Ok(produkt);
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Produkt produkt)
        {
            var result = _formSubmitService.Post(produkt.Nazwa, produkt.Cena, produkt.DataWaznosci);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Produkt produkt)
        {
            var result = _formSubmitService.Put(id, produkt.Nazwa, produkt.Cena, produkt.DataWaznosci);
            if (!result)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _getDataService.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
