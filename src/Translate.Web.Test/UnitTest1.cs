using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Translate.Web.Data;
using Translate.Web.Interfaces;
using Translate.Web.Models;
using Translate.Web.Repository;

namespace Translate.Web.Test
{
    public class Tests
    {
        private ApplicationDbContext _context;
        private IFunTranslateRepository _funTranslateRepository;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDB");
            _context = new ApplicationDbContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();
            _funTranslateRepository = new FunTranslateRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void CreateTranslate()
        {
            FunTranslate translate = new FunTranslate
            {
                Text = "leetspeak",
                Translation = "leetspeak",
                Translated = "l33tsp34k"
            };
            var isAdded = _funTranslateRepository.Add(translate);
            var newTranslate = _funTranslateRepository.GetAll().Find(x => x.Id == translate.Id);
            Assert.IsTrue(isAdded);
        }

        [Test]
        public void Test2()
        {
            FunTranslate translate = new FunTranslate
            {
                Text = "leetspeak",
                Translation = "leetspeak",
                Translated = "l33tsp34k"
            };
            var isAdded = _funTranslateRepository.Add(translate);
            var newTranslate = _funTranslateRepository.GetAll().Find(x => x.Id == translate.Id);
            Assert.That(newTranslate.Translation, Is.EqualTo(translate.Translation), "Translation are equal");
        }
    }
}