using Microsoft.EntityFrameworkCore;
using System;
using TesteAPI.Context;
using TesteAPI.Models;

namespace TesteAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;
        public PersonRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(Person person)
        {
            FormattableString query = $"insert into person (Name, Email) values ({person.Name},{person.Email})";
            int rowsAffected = await _appDbContext.Database.ExecuteSqlAsync(query);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            FormattableString query = $"delete from person where Id = {id}";
            int rowsAffected = await _appDbContext.Database.ExecuteSqlAsync(query);
            return rowsAffected > 0;
        }

        public async Task<List<Person>> FindAll()
        {
            FormattableString query = $"select * from person";
            return await _appDbContext.Database.SqlQuery<Person>(query).ToListAsync();
        }

        public async Task<Person> FindById(long id)
        {
            FormattableString query = $"select * from person where Id = {id}";
            return await _appDbContext.Database.SqlQuery<Person>(query).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            FormattableString query = $"update person set Name={person.Name}, Email={person.Email} where Id = {person.Id}";
            int rowsAffected = await _appDbContext.Database.ExecuteSqlAsync(query);
            return rowsAffected > 0;

        }
    }
}
