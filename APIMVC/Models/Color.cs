namespace APIMVC.Models
{

    public class Color
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public CDatum[] data { get; set; }
        public CSupport support { get; set; }
    }

    public class CSupport
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class CDatum : DogPicture
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }

}
