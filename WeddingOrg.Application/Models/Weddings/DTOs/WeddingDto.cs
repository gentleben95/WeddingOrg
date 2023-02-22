using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingOrg.Application.Models.Weddings.DTOs
{
        public record WeddingDto(string dateOfSigningTheContract, string dateOfTheWedding,
            string brideName, string? bridePhoneNumber,
            string? brideEmail, string? brideInstagram,
            string groomName, string? groomPhoneNumber,
            string? groomEmail, string? groomInstagram);

}
