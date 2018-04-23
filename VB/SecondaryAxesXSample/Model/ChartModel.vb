Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace SecondaryAxesXSample
    Friend Class ProductAggregate
        Public Property ProductName() As String
        Public Property CategoryName() As String
        Public Property ExtendedPrice() As Decimal
    End Class

    Friend Class ChartModel
        Private privateSalesPersons As IReadOnlyCollection(Of SalesPerson)
        Public Property SalesPersons() As IReadOnlyCollection(Of SalesPerson)
            Get
                Return privateSalesPersons
            End Get
            Private Set(ByVal value As IReadOnlyCollection(Of SalesPerson))
                privateSalesPersons = value
            End Set
        End Property
        Private privateCategories As IReadOnlyCollection(Of String)
        Public Property Categories() As IReadOnlyCollection(Of String)
            Get
                Return privateCategories
            End Get
            Private Set(ByVal value As IReadOnlyCollection(Of String))
                privateCategories = value
            End Set
        End Property

        Public Sub New()
            SalesPersons = (New NwindDbContext()).SalesPersons.OrderBy(Function(p) p.ExtendedPrice).ToList() '.ToList().GroupBy(p => p.ProductName).Select(
'                g => new ProductAggregate {
'                    ProductName = g.Key,
'                    CategoryName = g.Select(p => p.CategoryName).FirstOrDefault(),
'                    ExtendedPrice = g.Aggregate((decimal)0, (e, p) => (p.Extended_Price.HasValue) ? e + p.Extended_Price.Value : e)
'                })
            Categories = SalesPersons.Select(Function(p) p.CategoryName).Distinct().ToList()
        End Sub
    End Class
End Namespace
