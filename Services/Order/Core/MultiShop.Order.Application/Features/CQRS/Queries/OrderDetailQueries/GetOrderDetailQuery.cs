using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
   
    public class GetOrderDetailQuery
    {
        public GetOrderDetailQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
