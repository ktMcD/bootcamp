using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumingAPIs.Models
{

    public class Rootobject
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
    }

    public class Response
    {
        public Holiday[] holidays { get; set; }
    }

    public class Holiday
    {
        public string name { get; set; }
        public string description { get; set; }
        public Country country { get; set; }
        public Date date { get; set; }
        public string[] type { get; set; }
        public string primary_type { get; set; }
        public string canonical_url { get; set; }
        public string urlid { get; set; }
        public string locations { get; set; }
        public object states { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Date
    {
        public string iso { get; set; }
        public Datetime datetime { get; set; }
    }

    public class Datetime
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }

}


