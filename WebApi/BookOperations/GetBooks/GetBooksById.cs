using System;
using System.Linq;
using WebApi.common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksById(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GetByIdModel Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == id);
            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap yok !");

            GetByIdModel model = new GetByIdModel();
            model.Title = book.Title;
            model.Genre = ((GenreEnum)book.GenreId).ToString();
            model.PageCount = book.PageCount;
            model.PublishDate = book.PublishDate;

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