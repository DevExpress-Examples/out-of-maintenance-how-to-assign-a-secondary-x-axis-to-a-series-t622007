using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondaryAxesXSample {
    class ProductAggregate {
        public String ProductName {get;set;}
        public String CategoryName { get; set; }
        public decimal ExtendedPrice { get; set; }
    }

    class ChartModel {
        public IReadOnlyCollection<SalesPerson> SalesPersons { get; private set; }
        public IReadOnlyCollection<String> Categories { get; private set; }

        public ChartModel() {
            SalesPersons = new NwindDbContext().SalesPersons/*.ToList().GroupBy(p => p.ProductName).Select(
                g => new ProductAggregate {
                    ProductName = g.Key,
                    CategoryName = g.Select(p => p.CategoryName).FirstOrDefault(),
                    ExtendedPrice = g.Aggregate((decimal)0, (e, p) => (p.Extended_Price.HasValue) ? e + p.Extended_Price.Value : e)
                })*/
                .OrderBy(p => p.ExtendedPrice)
                .ToList();
            Categories = SalesPersons.Select(p => p.CategoryName).Distinct().ToList();
        }
    }
}
