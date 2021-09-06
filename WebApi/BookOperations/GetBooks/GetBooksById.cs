using System;
using System.Linq;
using AutoMapper;
using WebApi.common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByIdModel Model { get; set; }
        public int Id { get; set; }

        public GetBooksById(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetByIdModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == Id);
            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap yok !");

            GetByIdModel model = _mapper.Map<GetByIdModel>(book);

            return model;

        }
    }

    public class GetByIdModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}