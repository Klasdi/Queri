using Microsoft.AspNetCore.Mvc;
using Queri.Model;
using Queri.RequestModel;
using Queri.Services;

namespace Queri.Controllers
{
    [Route("api/surveys/interviews/results")]
    public class ResultsController : ControllerBase
    {
        private readonly ResultsServicesDto _resultsServicesDto;
        public ResultsController(ResultsServicesDto resultsServicesDto)
        {
            _resultsServicesDto = resultsServicesDto;
        }

        [HttpPost]
        public async Task<IActionResult> SaveResult([FromBody] SaveResultRequest request)
        {
            var nextQuestion = await _resultsServicesDto.PostResults(request);

            return Ok(new { NextQuestionId = nextQuestion?.Id });
        }
    }
}
