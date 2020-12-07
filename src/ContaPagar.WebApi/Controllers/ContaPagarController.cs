using Microsoft.AspNetCore.Mvc;
using ContaPagar.Application.Services.Interfaces;
using ContaPagar.Application.ViewModels;

namespace ContaPagar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaPagarController : ApiController
    {
        private readonly IContaPagarService _contaPagarService;

        public ContaPagarController(IContaPagarService contaPagarService) : base()
        {
            _contaPagarService = contaPagarService;
        }

        // SEARCH: api/ContaPagar
        [HttpGet]
        public IActionResult Search()
        {
            return Response( _contaPagarService.GetAll());
        }

        // GET: api/ContaPagar/5
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var viewModel = _contaPagarService.GetById(id);

            return Response(viewModel);
        }        

        // POST: api/ContaPagar
        [HttpPost]
        public IActionResult Post(AddContaPagarViewModel addContaPagarViewModels)
        {
            if (!ModelState.IsValid)
                return Response(addContaPagarViewModels);

            _contaPagarService.AdicionarContaPagar(addContaPagarViewModels);

            return Response(addContaPagarViewModels);
        }

        // PUT: api/ContaPagar/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UpdateContaPagarViewModel updateContaPagarViewModels)
        {
            if (!ModelState.IsValid)
                return Response(updateContaPagarViewModels);            

            _contaPagarService.AlterarContaPagar(updateContaPagarViewModels);

            return Response(_contaPagarService.GetById(id));
        }

        // DELETE: api/ContaPagar/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_contaPagarService.GetById(id) == null)
                throw new System.Exception("O Conta a pagar informado não existe!");

            _contaPagarService.Delete(id);

            return Response();
        }
    }
}