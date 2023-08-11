using SolrNet.Attributes;

namespace SolrDemo.Model
{
    public class SolrModel
    {
        [SolrField("price_c")]
        public string price { get; set; }

        [SolrField("author_s")]
        public string author { get; set; }

        [SolrField("name")]
        public string name { get; set; }
    }
}
