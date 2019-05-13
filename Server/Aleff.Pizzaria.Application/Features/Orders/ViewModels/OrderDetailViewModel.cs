using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Application.Features.Orders.ViewModels
{
    public class OrderDetailViewModel
    {
        public string Size { get; set; }
        public string Flavor { get; set; }
        public string Customizations { get; set; }
        public string Amount { get; set; }
        public string PreparationTime { get; set; }
    }
}
