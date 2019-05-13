using Aleff.Pizzaria.Domain.Features.Flavors;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Data.Seed
{
    public static class SeedExtensions
    {
        /// <summary>
        /// Método seed utilizado para criar o usuário padrão para a aplicação.
        /// ALERTA: ESTE MÉTODO DEVE SER UTILIZADO SOMENTE PARA O PROPÓSITO DESCRITO ACIMA. 
        /// NÃO UTILIZÁ-LO PARA POPULAR O BANCO COM DADOS NÃO NECESSÁRIOS PARA A INICIALIZAÇÃO DA APLICAÇÃO
        /// </summary>
        /// <param name="builder"></param>
        public static void Seed(this ModelBuilder builder)
        {
            #region Sizes
            var sizes = new List<Size>();
            sizes.Add(new Size()
            {
                Id = 1,
                ESize = ESize.Small,
                PreparationTime = 15,
                Value = 20
            });
            sizes.Add(new Size()
            {
                Id = 2,
                ESize = ESize.Medium,
                PreparationTime = 20,
                Value = 30
            });
            sizes.Add(new Size()
            {
                Id = 3,
                ESize = ESize.Large,
                PreparationTime = 25,
                Value = 40
            });
            #endregion

            #region Flavors
            var flavors = new List<Flavor>();
            flavors.Add(new Flavor()
            {
                Id = 1,
                Name = "Calabresa",
                PreparationTime = 0
            });
            flavors.Add(new Flavor()
            {
                Id = 2,
                Name = "Marguerita",
                PreparationTime = 0
            });
            flavors.Add(new Flavor()
            {
                Id = 3,
                Name = "Portuguesa",
                PreparationTime = 5
            });
            #endregion
            

            builder.Entity<Flavor>().HasData(flavors);
            builder.Entity<Size>().HasData(sizes);
        }
    }
}
