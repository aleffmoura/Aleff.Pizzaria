using Aleff.Pizzaria.Domain.Features.Flavors;
using Aleff.Pizzaria.Domain.Features.Pizzas.Customizations;
using Aleff.Pizzaria.Domain.Features.Sizes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Pizzas
{
    public class Pizza : Entity
    {
        public int FlavorId { get; set; } = 0;
        public int SizeId { get; set; } = 0;
        public virtual Size Size { get; set; } = new Size();
        public virtual Flavor Flavor { get; set; } = new Flavor();
        public string Customizations { get; set; } = string.Empty;

        public double GetAmountFromCustomizations()
        {
            double amount = 0;
            foreach (var item in Customizations.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var type = Type.GetType($"Aleff.Pizzaria.Domain.Features.Pizzas.Customizations.{item.Trim()}");
                var custom = (ICustom)Activator.CreateInstance(type);
                amount += custom.GetValue();
            }
            return amount;
        }
        public double GetAditionalTimeFromCustomizations()
        {
            double aditionalTime = 0;
            foreach (var item in Customizations.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var type = Type.GetType($"Aleff.Pizzaria.Domain.Features.Pizzas.Customizations.{item.Trim()}");
                var custom = (ICustom)Activator.CreateInstance(type);
                aditionalTime += custom.GetAditionalTime();
            }
            return aditionalTime;
        }
        public string GetCustomizationsDetails()
        {
            string details = string.Empty;
            foreach (var item in Customizations.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var type = Type.GetType($"Aleff.Pizzaria.Domain.Features.Pizzas.Customizations.{item.Trim()}");
                var custom = (ICustom)Activator.CreateInstance(type);
                details += $"{item.Trim()}: R${custom.GetValue()}, ";
            }
            return details.TrimEnd(' ').TrimEnd(',');
        }

    }
}
