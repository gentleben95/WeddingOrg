using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeddingOrg;
using WeddingOrg.Data;
using WeddingOrg.DTOs;
using WeddingOrg.Models;
using WeddingOrg.Repositories;

namespace WeddingOrgTests
{
    public class WeddingRepositoryTests
    {
        [Theory]
        [InlineData()]
        public async Task<IEnumerable<Wedding>> GetWeddingsBridesGrooms_ShouldShowAllWeddings(ApplicationDbContext dbContext, CancellationToken cancellationToken)
        {


            // Arrange
            var wedding = new Wedding
                .Include(x => x.Bride)
                .Include(x => x.Groom)
                .ToListAsync(cancellationToken);
            var url = "http://localhost:5001/api/Weddings/";

            // Act
            var response = await wedding.GetWeddings(url);
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadAsAsync<IEnumerable<User>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.Equal(2, users.Count);
            //Assert.Contains(users, u => u.Name == "John");
            //Assert.Contains(users, u => u.Name == "Jane");
        }
    }
}
