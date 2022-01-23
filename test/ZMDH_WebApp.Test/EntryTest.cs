using System;
using Xunit;
using ZMDH_WebApp.Controllers;
using ZMDH_WebApp.Data;
using ZMDH_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ZMDH_WebApp.Test
{
    public class EntryTest
    {
        public DBManager CreateContext(string db)
        {
            DbContextOptions<DBManager> options = new DbContextOptionsBuilder<DBManager>().UseInMemoryDatabase(db).Options;
            var c = new DBManager(options);
            c.Add(new Entry() {Id = 1, FullName = "John Doe", BirthDate = "01/01/2001", ZipCode = "1234AB", CityName = "Rotterdam", HouseNumber = "1", PhoneNumber = "123456789", EmailAddress = "email@email.com", ConditionId = 1, GuardianName = "", EmailAddressGuardian = "", Condition = new Condition()});
            c.Add(new Entry() {Id = 2, FullName = "Mary Doe", BirthDate = "01/01/2005", ZipCode = "1234AB", CityName = "Den Hague", HouseNumber = "3", PhoneNumber = "123456789", EmailAddress = "email@email.com", ConditionId = 1, GuardianName = "", EmailAddressGuardian = "", Condition = new Condition()});
            c.Add(new Entry() {Id = 3, FullName = "Jane Alison", BirthDate = "01/01/1995", ZipCode = "1234AB", CityName = "Rotterdam", HouseNumber = "5", PhoneNumber = "123456789", EmailAddress = "email@email.com", ConditionId = 1, GuardianName = "", EmailAddressGuardian = "", Condition = new Condition()});
            
            c.SaveChanges();

            return c;
        }

        [Fact]
        public void TestIndex()
        {
            var context = CreateContext("MijnDatabase");

            EntryController c = new EntryController(context);
            var viewResult = Assert.IsType<ViewResult>(c.Index());
            // Assert.Equal(3, context.Entries);
        }
    }
}
