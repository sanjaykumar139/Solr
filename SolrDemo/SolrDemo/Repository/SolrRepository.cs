using SolrDemo.Model;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace SolrDemo.Repository
{
    public class SolrRepository
    {
        private readonly ISolrReadOnlyOperations<SolrModel> _solr;

        public SolrRepository(ISolrReadOnlyOperations<SolrModel> solr)
        {
            _solr = solr;
        }

        public async Task<IEnumerable<SolrModel>> Search(string searchString)
        {
            var results = await _solr.QueryAsync(searchString);

            return results;
        }


    }
}