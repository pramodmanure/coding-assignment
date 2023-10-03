namespace MarketingCodingAssignment.Models
{
    public class SearchResultsViewModel
    {
        public int RecordsCount
        {
            get; set;
        }

        public IEnumerable<FilmLuceneRecord>? Films
        { 
            get; set; 
        }

    }
}
