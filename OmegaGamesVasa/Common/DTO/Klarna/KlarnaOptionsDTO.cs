using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Klarna
{
    public class KlarnaOptionsDTO
    {
        public bool require_validate_callback_success { get; set; }
        public string acquiring_channel { get; set; }
        public bool vat_removed { get; set; }
        public bool allow_separate_shipping_address { get; set; }
        public string color_button { get; set; }
        public string color_button_text { get; set; }
        public string color_checkbox { get; set; }
        public string color_checkbox_checkmark { get; set; }
        public string color_header { get; set; }
        public string color_link { get; set; }
        public bool date_of_birth_mandatory { get; set; }
        public string shipping_details { get; set; }
        public bool title_mandatory { get; set; }
        public Additional_Checkbox additional_checkbox { get; set; }
        public bool national_identification_number_mandatory { get; set; }
        public string additional_merchant_terms { get; set; }
        public bool phone_mandatory { get; set; }
        public string radius_border { get; set; }
        public string[] allowed_customer_types { get; set; }
        public bool show_subtotal_detail { get; set; }
        public Additional_Checkboxes[] additional_checkboxes { get; set; }
        public bool verify_national_identification_number { get; set; }
        public bool auto_capture { get; set; }
        public bool require_client_validation { get; set; }
        public bool enable_discount_module { get; set; }
        public bool show_vat_registration_number_field { get; set; }
    }
}
