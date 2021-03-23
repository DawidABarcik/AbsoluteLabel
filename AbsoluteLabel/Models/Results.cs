using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    public class IndividualSearchResult
    {
        public string wrapperType { get; set; }
        public string kind { get; set; }
        public int trackId { get; set; }
        public string artistName { get; set; }
        public string trackName { get; set; }
        public string trackCensoredName { get; set; }
        public string trackViewUrl { get; set; }
        public string previewUrl { get; set; }
        public string artworkUrl100 { get; set; }
        public DateTime releaseDate { get; set; }



}

    public class SearchResult
    {
        public List<IndividualSearchResult> results { get; set; }
    }

