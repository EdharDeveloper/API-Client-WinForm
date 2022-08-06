using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Client_WinForm.ModelApi
{
    public class ModelNews
    {

        public class Rootobject
        {
            public string status { get; set; }
            public string copyright { get; set; }
            public int num_results { get; set; }
            public Result[] results { get; set; }
        }

        public class Result
        {
            public string uri { get; set; }
            public string url { get; set; }
            public long id { get; set; }
            public long asset_id { get; set; }
            public string source { get; set; }
            public string published_date { get; set; }
            public string updated { get; set; }
            public string section { get; set; }
            public string subsection { get; set; }
            public string nytdsection { get; set; }
            public string adx_keywords { get; set; }
            public object column { get; set; }
            public string byline { get; set; }
            public string type { get; set; }
            public string title { get; set; }
            public string _abstract { get; set; }
            public string[] des_facet { get; set; }
            public string[] org_facet { get; set; }
            public string[] per_facet { get; set; }
            public string[] geo_facet { get; set; }
            public Medium[] media { get; set; }
            public int eta_id { get; set; }
        }

        public class Medium
        {
            public string type { get; set; }
            public string subtype { get; set; }
            public string caption { get; set; }
            public string copyright { get; set; }
            public int approved_for_syndication { get; set; }
            public MediaMetadata[] mediametadata { get; set; }
        }

        public class MediaMetadata
        {
            public string url { get; set; }
            public string format { get; set; }
            public int height { get; set; }
            public int width { get; set; }
        }

    }
}
