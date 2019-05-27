using MediatR;
using NFCCardEmulation.Application.Shops.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Shops.Queries
{
    public class GetShopDetailsQuery : IRequest<ShopDetailsModel>
    {
        public int Id { get; set; }
    }
}
