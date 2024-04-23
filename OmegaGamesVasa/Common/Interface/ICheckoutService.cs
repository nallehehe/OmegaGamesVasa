using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.Klarna;

namespace Common.Interface
{
    public interface ICheckoutService
    {
        public Task<string> CreateOrder(OrderDTO order);
        public Task<KlarnaOrderDTO> GetOrder(string order_id);
    }
}
