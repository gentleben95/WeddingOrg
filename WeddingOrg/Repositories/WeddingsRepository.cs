using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading;
using WeddingOrg.Data;
using WeddingOrg.DTOs;
using WeddingOrg.Exceptions;
using WeddingOrg.Models;

namespace WeddingOrg.Repositories
{
    public class WeddingsRepository : IWeddingsRepository
    {
        public readonly ApplicationDbContext _dbContext;
        
        public WeddingsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken)
        {
            var wedding = await _dbContext.Weddings
                .Include(x => x.Bride)
                .Include(x => x.Groom)   
                .ToListAsync(cancellationToken);
            //var photograph = await _dbContext.Photographers.ToListAsync(cancellationToken);
            //var cameraman = await _dbContext.Cameramen.ToListAsync(cancellationToken);
            //var restaurant = await _dbContext.Restaurants.ToListAsync(cancellationToken);
            //return (wedding, photograph, cameraman, restaurant);
            return wedding;
        }
        public async Task<Wedding>? GetWeddingsById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(w => w.Id == id);
            //if (wedding == default)
            //{
            //    throw new WeddingNotFoundException($"Wedding with {id} does not exist.");
            //}
            return wedding;
        }
        
        public async Task<int> CreateWeedingBGPCR(UpdateWholeWeddingDto dto, CancellationToken cancellationToken)
        {
            Photographer photographer = new() { Facebook = dto.photographerFacebook, Instagram = dto.photographerInstagram };
            await _dbContext.AddAsync(photographer, cancellationToken);
            Cameraman cameraman = new() { Facebook = dto.cameramanFacebook, Instagram = dto.cameramanInstagram };
            await _dbContext.AddAsync(cameraman, cancellationToken);
            Restaurant restaurant = new() { Facebook = dto.restaurantFacebook, Instagram = dto.restaurantInstagram };
            await _dbContext.AddAsync(restaurant, cancellationToken);
            Bride bride = new Bride()
            {
                Name = dto.brideName,
                PhoneNumber = dto.bridePhoneNumber,
                Email = dto.brideEmail,
                Instagram = dto.brideInstagram
            };
            await _dbContext.Brides.AddAsync(bride, cancellationToken);
            Groom groom = new Groom()
            {
                Name = dto.groomName,
                PhoneNumber = dto.groomPhoneNumber,
                Email = dto.groomEmail,
                Instagram = dto.groomInstagram
            };
            await _dbContext.Grooms.AddAsync(groom, cancellationToken);
            Wedding wedding = new Wedding() { DateOfSigningTheContract = dto.dateOfSigningTheContract, DateOfTheWedding = dto.dateOfTheWedding };
            await _dbContext.Weddings.AddAsync (wedding, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return wedding.Id;
        }
        public async Task<int> DeleteWeddingById(int id, CancellationToken cancellationToken)
        {
            var weddingDeletion = await _dbContext.Weddings.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Weddings.Remove(weddingDeletion);            
            _dbContext.SaveChangesAsync();            
            return weddingDeletion.Id;
        }
        public async Task<int> ChangeWeddingDates(int weddingId, UpdateWholeWeddingDto dto, CancellationToken cancellationToken)
        {
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(w => w.Id == weddingId, cancellationToken);
            wedding.DateOfSigningTheContract = dto.dateOfSigningTheContract;
            wedding.DateOfTheWedding = dto.dateOfTheWedding;
            wedding.Bride.Name = dto.brideName;
            wedding.Bride.PhoneNumber = dto.bridePhoneNumber;
            wedding.Bride.Email = dto.brideEmail;  
            wedding.Bride.Instagram = dto.brideInstagram;
            wedding.Groom.Name = dto.groomName;
            wedding.Groom.PhoneNumber = dto.groomPhoneNumber;
            wedding.Groom.Email = dto.groomEmail;
            wedding.Groom.Instagram= dto.groomInstagram;
            // No i jak zrobić resztę? Czy Bride i Groom ma być jak wyżej czy:
            // var bride = await_dbContext.Brides.SingleOrDefaultAsync(b => b.Id == dto.brideId) itd itp
            // var groom = await_dbContext.Grooms.SingleOrDefaultAsync(b => b.Id == dto.brideId) itd itp
            // A photograper, cameraman i restaurant? Jak ich tu zrobic? Bo w sumie BRide,Groom,Photo itd trzeba po ID tez osobno znalezc?
            _dbContext.SaveChangesAsync();
            return wedding.Id;
        }

        //public void CreateBride(string brideName, string bridePhoneNumber, 
        //    string brideEmail, string brideInstagram)
        //{
        //    Bride bride = new Bride() { Name = brideName, PhoneNumber = bridePhoneNumber, 
        //        Email= brideEmail, Instagram = brideInstagram };
        //    _dbContext.Brides.Add(bride);
        //    _dbContext.SaveChanges();
        //}
        //public void CreateGroom(string groomName, string groomPhoneNumber, 
        //    string groomEmail, string groomInstagram)
        //{
        //    Groom groom = new Groom()
        //    {
        //        Name = groomName,
        //        PhoneNumber = groomPhoneNumber,
        //        Email = groomEmail,
        //        Instagram = groomInstagram
        //    };
        //    _dbContext.Grooms.Add(groom);
        //    _dbContext.SaveChanges();
        //}
        //public void CreateWedding(string contractId)
        //{
        //    Wedding wedding = new Wedding() { ContractId = contractId };
        //    _dbContext.Weddings.Add(wedding);
        //}
        //public void CreatePhotographer(string facebook, string instagram)
        //{
        //    var photographer = new Photographer() { Facebook = facebook, Instagram = instagram };
        //    _dbContext.Photographers.Add(photographer);
        //    _dbContext.SaveChanges();  
        //}
        //public void CreateCameraman(string facebook, string instagram)
        //{
        //    var cameraman = new Cameraman() { Facebook = facebook, Instagram = instagram };
        //    _dbContext.Cameramen.Add(cameraman);
        //    _dbContext.SaveChanges();
        //}
        //public void CreateRestaurant(string facebook, string instagram)
        //{
        //    var restaurant = new Restaurant() { Facebook = facebook, Instagram = instagram };
        //    _dbContext.Restaurants.Add(restaurant);
        //    _dbContext.SaveChanges();
        //}

    }
}
