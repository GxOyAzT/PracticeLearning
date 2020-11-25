using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsMale { get; set; }
    }

    public interface IGetPeopleFromDb
    {
        List<PersonModel> Get();
    }

    public class GetPeopleFromDb : IGetPeopleFromDb
    {
        public List<PersonModel> Get()
        {
            return new List<PersonModel>()
            {
                new() { Id = 1, FullName = "Name1", IsMale = false },
                new() { Id = 2, FullName = "Name2", IsMale = false },
                new() { Id = 3, FullName = "Name3", IsMale = true },
                new() { Id = 4, FullName = "Name4", IsMale = false }
            };
        }
    }

    public interface IGetAllFemales
    {
        public List<PersonModel> Get();
    }

    public class GetAllFemales : IGetAllFemales
    {
        public GetAllFemales(IGetPeopleFromDb getPeopleFromDb)
        {
            _getPeopleFromDb = getPeopleFromDb;
        }

        IGetPeopleFromDb _getPeopleFromDb { get; }

        public List<PersonModel> Get()
        {
            return _getPeopleFromDb.Get().Where(e => e.IsMale is false).ToList();
        }
    }
}
