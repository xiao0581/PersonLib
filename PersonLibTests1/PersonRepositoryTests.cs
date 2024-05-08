using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib.Tests
{
    [TestClass()]
    public class PersonRepositoryTests
    {

        
        private static PersonRepository _repo;
        private static PersonDbContext _dbContext;
        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
          
                var optionsBuilder = new DbContextOptionsBuilder<PersonDbContext>();
                optionsBuilder.UseSqlServer(Connection._connectionString);
                _dbContext = new PersonDbContext(optionsBuilder.Options);
                _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Persons");
                _repo = new PersonRepository(_dbContext);
                _repo.Add(new Person { Name = "xiao", Age = 19 ,Bpm=68});
                _repo.Add(new Person { Name = "alex", Age = 20 , Bpm = 60 });
                _repo.Add(new Person { Name = "mei", Age = 10, Bpm = 70 });
                _repo.Add(new Person { Name = "morten", Age = 80 , Bpm = 63 });

           
        }
      

        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Person> persons = _repo.GetAll();
            Assert.AreEqual(4, persons.Count());
          
        }

       

        [TestMethod()]
        public void AddTest()
        {
           Person person = new Person { Name = "thor", Age = 19, Bpm = 68 };
            _repo.Add(person);
            Assert.AreEqual(5, _repo.GetAll().Count());
        }

        [TestMethod()]
        public void DeleteTest()
        {
           Person p = _repo.Delete(1);
            Assert.AreEqual(4, _repo.GetAll().Count());
        }

        [TestMethod()]
        public void updateTest()
        {
            Person person=_repo.update(2, new Person { Name = "alex", Age = 20, Bpm = 70 });
            Assert.AreEqual(70, person.Bpm);
           
        }
    }
}