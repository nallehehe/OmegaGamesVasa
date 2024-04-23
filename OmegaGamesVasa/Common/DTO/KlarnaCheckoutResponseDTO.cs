using Common.DTO.Klarna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class KlarnaResponseDTO
    {
        public string order_id { get; set; }
        public string name { get; set; }
        public string purchase_country { get; set; }
        public string purchase_currency { get; set; }
        public string locale { get; set; }
        public string status { get; set; }
        public KlarnaAddressDTO billing_address { get; set; }
        public KlarnaAddressDTO shipping_address { get; set; }
        public int order_amount { get; set; }
        public int order_tax_amount { get; set; }
        public KlarnaOrderProductDTO[] order_lines { get; set; }
        public KlarnaCustomerDTO customer { get; set; }
        public KlarnaMerchantUrlsDTO merchant_urls { get; set; }
        public string html_snippet { get; set; }
        public string merchant_reference1 { get; set; }
        public string merchant_reference2 { get; set; }
        public DateTime started_at { get; set; }
        public DateTime completed_at { get; set; }
        public DateTime last_modified_at { get; set; }
        public KlarnaOptionsDTO options { get; set; }
        public Attachment attachment { get; set; }
        public External_Payment_Methods[] external_payment_methods { get; set; }
        public External_Checkouts[] external_checkouts { get; set; }
        public string[] shipping_countries { get; set; }
        public Shipping_Options[] shipping_options { get; set; }
        public string merchant_data { get; set; }
        public Gui gui { get; set; }
        public Merchant_Requested merchant_requested { get; set; }
        public Selected_Shipping_Option selected_shipping_option { get; set; }
        public bool recurring { get; set; }
        public string recurring_token { get; set; }
        public string recurring_description { get; set; }
        public string[] billing_countries { get; set; }
        public string[] tags { get; set; }
        public Discount_Lines[] discount_lines { get; set; }
    }

    public class Additional_Checkbox
    {
        public string text { get; set; }
        public bool _checked { get; set; }
        public bool required { get; set; }
    }

    public class Additional_Checkboxes
    {
        public string text { get; set; }
        public bool _checked { get; set; }
        public bool required { get; set; }
        public string id { get; set; }
    }

    public class Attachment
    {
        public string body { get; set; }
        public string content_type { get; set; }
    }

    public class Gui
    {
        public string[] options { get; set; }
    }

    public class Merchant_Requested
    {
        public bool additional_checkbox { get; set; }
        public Additional_Checkboxes1[] additional_checkboxes { get; set; }
    }

    public class Additional_Checkboxes1
    {
        public string id { get; set; }
        public bool _checked { get; set; }
    }

    public class Selected_Shipping_Option
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string promo { get; set; }
        public int price { get; set; }
        public bool preselected { get; set; }
        public int tax_amount { get; set; }
        public int tax_rate { get; set; }
        public string shipping_method { get; set; }
        public Delivery_Details delivery_details { get; set; }
        public string tms_reference { get; set; }
        public Selected_Addons[] selected_addons { get; set; }
    }

    public class Delivery_Details
    {
        public string carrier { get; set; }
        public KlarnaProduct product { get; set; }
        public Timeslot timeslot { get; set; }
        public Pickup_Location pickup_location { get; set; }
    }

    public class KlarnaProduct
    {
        public string name { get; set; }
        public string identifier { get; set; }
    }

    public class Timeslot
    {
        public string id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Pickup_Location
    {
        public string id { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
    }

    public class Address
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

    public class Selected_Addons
    {
        public string type { get; set; }
        public int price { get; set; }
        public string external_id { get; set; }
        public string user_input { get; set; }
    }

    public class Product_Identifiers
    {
        public string brand { get; set; }
        public string color { get; set; }
        public string category_path { get; set; }
        public string global_trade_item_number { get; set; }
        public string manufacturer_part_number { get; set; }
        public string size { get; set; }
    }

    public class Shipping_Attributes
    {
        public int weight { get; set; }
        public Dimensions dimensions { get; set; }
        public string[] tags { get; set; }
    }

    public class Dimensions
    {
        public int height { get; set; }
        public int width { get; set; }
        public int length { get; set; }
    }

    public class External_Payment_Methods
    {
        public string name { get; set; }
        public int fee { get; set; }
        public string description { get; set; }
        public string[] countries { get; set; }
        public string label { get; set; }
        public string redirect_url { get; set; }
        public string image_url { get; set; }
    }

    public class External_Checkouts
    {
        public string name { get; set; }
        public int fee { get; set; }
        public string description { get; set; }
        public string[] countries { get; set; }
        public string label { get; set; }
        public string redirect_url { get; set; }
        public string image_url { get; set; }
    }

    public class Shipping_Options
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string promo { get; set; }
        public int price { get; set; }
        public bool preselected { get; set; }
        public int tax_amount { get; set; }
        public int tax_rate { get; set; }
        public string shipping_method { get; set; }
        public Delivery_Details1 delivery_details { get; set; }
        public string tms_reference { get; set; }
        public Selected_Addons1[] selected_addons { get; set; }
    }

    public class Delivery_Details1
    {
        public string carrier { get; set; }
        public Product1 product { get; set; }
        public Timeslot1 timeslot { get; set; }
        public Pickup_Location1 pickup_location { get; set; }
    }

    public class Product1
    {
        public string name { get; set; }
        public string identifier { get; set; }
    }

    public class Timeslot1
    {
        public string id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Pickup_Location1
    {
        public string id { get; set; }
        public string name { get; set; }
        public Address1 address { get; set; }
    }

    public class Address1
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

    public class Selected_Addons1
    {
        public string type { get; set; }
        public int price { get; set; }
        public string external_id { get; set; }
        public string user_input { get; set; }
    }

    public class Discount_Lines
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public int unit_price { get; set; }
        public int tax_rate { get; set; }
        public int total_amount { get; set; }
        public int total_tax_amount { get; set; }
        public string reference { get; set; }
        public string merchant_data { get; set; }
    }

}
