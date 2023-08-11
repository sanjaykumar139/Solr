using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolrDemo.Model;
using SolrNet.Commands.Parameters;
using SolrNet;

namespace SolrDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolrController : ControllerBase
    {
        private readonly ISolrReadOnlyOperations<SolrModel> _solr;
        public SolrController(ISolrReadOnlyOperations<SolrModel> solr)
        {
            _solr = solr;
        }
        [HttpGet]
        public async Task<SolrModel> Search1(string searchString)
        {
            var solrResult = (await _solr.QueryAsync(new SolrMultipleCriteriaQuery(new ISolrQuery[]
              {
                  // SolrQueryByField("_template", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"),
                  //new SolrQueryByField("_language", "da"),
                  //new SolrQueryByField("price_c", "6.99,USD"),
                  //new SolrQueryByField("author_s", "Roger Zelazny"),
                  new SolrQueryByField("name", searchString)
              }, 
              SolrMultipleCriteriaQuery.Operator.OR), 
              new QueryOptions { Rows = 10 })
              ).FirstOrDefault();

            if (solrResult != null)
                return solrResult;

            return null;
        }
    }
}
