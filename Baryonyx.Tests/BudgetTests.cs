using System;
using System.Collections.Generic;
using System.Linq;
using Baryonyx.Tests.Setup;
using BaryonyxBudgeting.Controllers;
using Budgets;
using Budgets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Baryonyx.Tests
{
    public class BudgetTests
    {
        private readonly IConfiguration _configuration;
        private List<IdentityUser> users;

        public BudgetTests()
        {
            // MockUsers();
            _configuration = IdentityMocking.InitConfiguration();
        }

        

        // public void MockUsers()
        // {
        //     users = new List<IdentityUser>
        //     {
        //         new IdentityUser("User1") {Email = "user1@bb.com"},
        //         new IdentityUser("User2") {Email = "user2@bb.com"}
        //     };
        // }
        //
        // [Fact]
        // public void CreateBudget()
        // {
        //     var userManager = IdentityMocking.MockUserManager(users);
        //     // Arrange
        //     var context = new Mock<IBudgetRepository>();
        //
        //     var controller = new BudgetController(context.Object, userManager.Object, _configuration);
        //
        //     // Act
        //     controller.UpdateBudget(new Budget
        //         {Title = "Budget1", Total = 100m, UserId = "1", TimeFrame = BudgetTimeFrame.Monthly});
        //     controller.UpdateBudget(new Budget 
        //         {Title = "Budget2", Total = 100m, UserId = "1", TimeFrame = BudgetTimeFrame.Quarterly});
        //     controller.UpdateBudget(new Budget
        //         {Title = "Budget3", Total = 100m, UserId = "1", TimeFrame = BudgetTimeFrame.Annually});
        //     controller.UpdateBudget(new Budget
        //         {Title = "Budget4", Total = 100m, UserId = "2", TimeFrame = BudgetTimeFrame.Monthly});
        //     controller.UpdateBudget(new Budget
        //         {Title = "Budget5", Total = 200m, UserId = "2", TimeFrame = BudgetTimeFrame.Monthly});
        //     
        //     Assert.Equal(5, context.Object.Budgets.Count());
        //     Assert.Equal(3, context.Object.GetUserBudgets("1").Count());
        // }
    }
}