Imports System.Linq
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System

Namespace SecondaryAxesXSample

    Partial Public Class NwindDbContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=NwindDbContext")
        End Sub

        Public Overridable Property SalesPersons() As DbSet(Of SalesPerson)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of SalesPerson)().Property(Function(e) e.UnitPrice).HasPrecision(10, 4)

            modelBuilder.Entity(Of SalesPerson)().Property(Function(e) e.ExtendedPrice).HasPrecision(19, 4)
        End Sub
    End Class
End Namespace
