using Aleff.Pizzaria.Domain.Features.Pizzas.Customizations;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Orders
{
    public enum EStatus
    {
        Under_Construction,
        Built
    }
    public class Order : Entity
    {
        private double _preparationTime = 0;
        private double _amount = 0;

        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; } = new Pizza();
        public double Amount
        {
            get
            {
                CalculateAmount();
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        public double PreparationTime
        {
            get
            {
                CalculatePreparationTime();
                return _preparationTime;
            }
            set
            {
                _preparationTime = value;
            }
        }

        private void CalculateAmount()
        {
            if (_amount == 0)
            {
                _amount = Pizza.Size.Value;
                _amount += Pizza.GetAmountFromCustomizations();
            }
        }
        private void CalculatePreparationTime()
        {
            if (_preparationTime == 0)
            {
                _preparationTime = Pizza.Size.PreparationTime + Pizza.Flavor.PreparationTime;
                _preparationTime += Pizza.GetAditionalTimeFromCustomizations();
            }
        }


        public string GetCustomizationsDetails()
        {
            string detailPizza = Pizza.GetCustomizationsDetails();
            if (!string.IsNullOrEmpty(detailPizza))
            {
                return $"Adicionais de: {detailPizza}";
            }
            return detailPizza;
        }
    }
}
