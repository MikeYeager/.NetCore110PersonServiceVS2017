using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Controllers
{
    //[Authorize]
    [Route("api/person")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : Controller
    {
        [Route("{searchString}")]
        public IEnumerable<Person> Get(string searchString)
        {
            using (var context = new DemoDbContext())
            {
                var people = context.Person.AsNoTracking().Where(p =>
                    p.FirstName.StartsWith(searchString)
                    || p.LastName.StartsWith(searchString)
                    || p.Email.StartsWith(searchString)
                    || p.Phone.StartsWith(searchString))
                    .ToList();
                return people;
            }
        }

        [Route("{id:guid}")]
        public Person Get(Guid id)
        {
            using (var context = new DemoDbContext())
            {
                var person = context.Person.AsNoTracking().FirstOrDefault(p => p.Id == id);

                return person;
            }
        }

        [Route("")]
        public Guid Post([FromBody]Person personToSave)
        {
            using (var context = new DemoDbContext())
            {
                var person = context.Person.FirstOrDefault(p => p.Id == personToSave.Id);
                if (person == null)
                {
                    person = new Person();
                    context.Person.Add(person);
                }

                person.Id = personToSave.Id;
                person.FirstName = personToSave.FirstName;
                person.LastName = personToSave.LastName;
                person.Email = personToSave.Email;
                person.Phone = personToSave.Phone;

                if (personToSave.Id == Guid.Empty) person.Id = Guid.NewGuid();
                context.SaveChanges();

                return person.Id;
            }
        }

        [Route("getcountwhereemailcontains/{emailDomain}")]
        public int GetCountWhereEmailContains(string emailDomain)
        {
            using (var context = new DemoDbContext())
            {
                var count = context.Person.Where(p => p.Email.Contains(emailDomain)).Count();
                return count;
            }
        }
    }
}
