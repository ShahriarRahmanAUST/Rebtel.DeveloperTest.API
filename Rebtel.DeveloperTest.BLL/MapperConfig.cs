
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rebtel.DeveloperTest.SL;
using System.Security.Cryptography.X509Certificates;

namespace Rebtel.DeveloperTest.BLL
{
    public class BookSL
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int NumberOfCopies { get; set; }
        public int Pages { get; set; }
    }

    public class AvaiableBook
    {
        public int BookId { get; set; }
        public int TotalBook { get; set; }
        public int TotalBorrowerd { get; set; }

    }


    public class MapperConfig
    {
        private static Mapper? mapper;


        public static Mapper Mapper {
            get
            {
                if (mapper is null)
                    mapper = InitializeAutomapper();
                return mapper;
            }
        }
        private static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Book, BookSL>(); 
                cfg.CreateMap<Borrower, BorrowerSL>();
            });
            return new Mapper(config);            
        }
    }
}
