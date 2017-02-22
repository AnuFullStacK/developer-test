using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Appointments.Builders;

namespace OrangeBricks.Web.Tests.Controllers.Appointments.Builders
{

public static class ExtentionMethods
{
    public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
    {
        dbSet.Provider.Returns(data.Provider);
        dbSet.Expression.Returns(data.Expression);
        dbSet.ElementType.Returns(data.ElementType);
        dbSet.GetEnumerator().Returns(data.GetEnumerator());
        return dbSet;
    }
}

[TestFixture]
public class SlotViewModelBuilderTests
{
    private IOrangeBricksContext _context;

    [SetUp]
    public void SetUp()
    {
        _context = Substitute.For<IOrangeBricksContext>();
    }

    [Test]
    public void BuildShouldReturnAtleastOneScheduleforaProperty()
    {
        // Arrange
        var builder = new SlotViewModelBuilder(_context);

            var schedules = new List<Models.Schedule>{
            new Models.Schedule{ Id=1, StartDatetime=Convert.ToDateTime("21/02/2017 09:00:00"),  EndDatetime=Convert.ToDateTime("21/02/2017 11:00:00"),PropertyId=1},
            };

            var mockSet = Substitute.For<IDbSet<Models.Schedule>>()
                .Initialize(schedules.AsQueryable());

            _context.Schedules.Returns(mockSet);

            var appointments = new List<Models.Appointment> { };
            var mockApptSet = Substitute.For<IDbSet<Models.Appointment>>()
                .Initialize(appointments.AsQueryable());

            _context.Appointments.Returns(mockApptSet);
            int PropertyId=1;
        // Act
        var viewModel = builder.Build(PropertyId);
        // Assert
        Assert.That(viewModel.Count, Is.EqualTo(1));
    }


}
}

