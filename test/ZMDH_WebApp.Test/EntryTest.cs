using System;
using Xunit;
using ZMDH_WebApp.Controllers;
using ZMDH_WebApp.Data;
using ZMDH_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            
            var client = new Client() {};
            c.Add(client);

            c.SaveChanges();

            return c;
        }

        [Fact]
        public async Task AddToDatabaseTest()
        {
            // Create database instance and controller instance.
            var context = CreateContext("0");
            EntryController c = new EntryController(context);

            // Enumerate all entries to list.
            List<Entry> elist = new List<Entry>();
            foreach (var item in context.Entries) {
                elist.Add(item);
            }

            Assert.Equal(3, elist.Count);
        }

        [Fact]
        public async Task TestIndex()
        {
            // Create database instance and controller instance.
            var context = CreateContext("1");
            EntryController c = new EntryController(context);

            // Get model from view result.
            var viewResult = Assert.IsType<ViewResult>(await c.Index());
            var model = Assert.IsAssignableFrom<List<Entry>>(viewResult.ViewData.Model);

            Assert.Equal(3, model.Count);
            Assert.Equal("John Doe", model[0].FullName);
        }

        [Fact]
        public void DetailsTest()
        {
            // Create database instance and controller instance.
            var context = CreateContext("2");
            EntryController c = new EntryController(context);

            // Get record data from view.
            var viewResult = c.Details(1);
            
            Assert.Equal(1, viewResult.Id);
        }

        [Fact]
        public async Task CreateTestAsync()
        {
            // Create database instance and controller instance.
            var context = CreateContext("3");
            EntryController c = new EntryController(context);

            // Create new entry record.
            Entry entry = context.Entries.Find(1);
            entry.Id = 4;
            entry.FullName = "New Record";

            await c.Create(entry);

            // Get model from view result.
            var viewResult = Assert.IsType<ViewResult>(await c.Index());
            var model = Assert.IsAssignableFrom<List<Entry>>(viewResult.ViewData.Model);

            Assert.Equal("New Record", context.Entries.Find(entry.Id).FullName);
        }

        [Fact]
        public async Task EditTestAsync()
        {
            // Create database instance and controller instance.
            var context = CreateContext("4");
            EntryController c = new EntryController(context);

            // Create new entry.
            Entry entry = context.Entries.Find(1);
            entry.FullName = "Empty";

            await c.Edit(1, entry);

            // Get model from view result.
            var viewResult = Assert.IsType<ViewResult>(await c.Index());
            var model = Assert.IsAssignableFrom<List<Entry>>(viewResult.ViewData.Model);

            Assert.Equal("Empty", context.Entries.Find(1).FullName);
        }

        [Fact]
        public async Task DeleteConfirmedTest()
        {
            // Create database instance and controller instance.
            var context = CreateContext("5");
            EntryController c = new EntryController(context);

            await c.DeleteConfirmed(1);

            Assert.Null(context.Entries.Find(1));
        }
    }
}