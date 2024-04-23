using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Klarna
{
    public class KlarnaAddressDTO
    {
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string street_address { get; set; }
        public string street_address2 { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
        public string house_extension { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string care_of { get; set; }
    }
}
