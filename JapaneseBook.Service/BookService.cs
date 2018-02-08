using System.Collections.Generic;
using System.Linq;
using JapaneseBook.Data.Infrastructure;

namespace JapaneseBook.Service
{
    public interface IBookService
    {

    }

        public class BookService : IBookService
    {

    }
        /*
        public interface IBookService
        {
            Book Add(Book Book);

            void Update(Book Book);

            Book Delete(int id);

            IEnumerable<Book> GetAll();

            IEnumerable<Book> GetAll(string keyword);

            IEnumerable<Book> GetLastest(int top);

            IEnumerable<Book> GetHotBook(int top);

            IEnumerable<Book> GetListBookByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);

            IEnumerable<Book> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

            IEnumerable<Book> GetReatedBooks(int id, int top);

            IEnumerable<string> GetListBookByName(string name);

            Book GetById(int id);

            void Save();

            IEnumerable<Tag> GetListTagByBookId(int id);

            Tag GetTag(string tagId);

            void IncreaseView(int id);

            IEnumerable<Book> GetListBookByTag(string tagId,int page,int pagesize,out int totalRow);

            bool SellBook(int BookId, int quantity);
        }

        public class BookService : IBookService
        {
            private IBookRepository _BookRepository;
            private ITagRepository _tagRepository;
            private IBookTagRepository _BookTagRepository;

            private IUnitOfWork _unitOfWork;

            public BookService(IBookRepository BookRepository, IBookTagRepository BookTagRepository,
                ITagRepository _tagRepository, IUnitOfWork unitOfWork)
            {
                this._BookRepository = BookRepository;
                this._BookTagRepository = BookTagRepository;
                this._tagRepository = _tagRepository;
                this._unitOfWork = unitOfWork;
            }

            public Book Add(Book Book)
            {
                var Book = _BookRepository.Add(Book);
                _unitOfWork.Commit();
                if (!string.IsNullOrEmpty(Book.Tags))
                {
                    string[] tags = Book.Tags.Split(',');
                    for (var i = 0; i < tags.Length; i++)
                    {
                        var tagId = StringHelper.ToUnsignString(tags[i]);
                        if (_tagRepository.Count(x => x.ID == tagId) == 0)
                        {
                            Tag tag = new Tag();
                            tag.ID = tagId;
                            tag.Name = tags[i];
                            tag.Type = CommonConstants.BookTag;
                            _tagRepository.Add(tag);
                        }

                        BookTag BookTag = new BookTag();
                        BookTag.BookID = Book.ID;
                        BookTag.TagID = tagId;
                        _BookTagRepository.Add(BookTag);
                    }
                }
                return Book;
            }

            public Book Delete(int id)
            {
                return _BookRepository.Delete(id);
            }

            public IEnumerable<Book> GetAll()
            {
                return _BookRepository.GetAll();
            }

            public IEnumerable<Book> GetAll(string keyword)
            {
                if (!string.IsNullOrEmpty(keyword))
                    return _BookRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
                else
                    return _BookRepository.GetAll();
            }

            public Book GetById(int id)
            {
                return _BookRepository.GetSingleById(id);
            }

            public void Save()
            {
                _unitOfWork.Commit();
            }

            public void Update(Book Book)
            {
                _BookRepository.Update(Book);
                if (!string.IsNullOrEmpty(Book.Tags))
                {
                    string[] tags = Book.Tags.Split(',');
                    for (var i = 0; i < tags.Length; i++)
                    {
                        var tagId = StringHelper.ToUnsignString(tags[i]);
                        if (_tagRepository.Count(x => x.ID == tagId) == 0)
                        {
                            Tag tag = new Tag();
                            tag.ID = tagId;
                            tag.Name = tags[i];
                            tag.Type = CommonConstants.BookTag;
                            _tagRepository.Add(tag);
                        }
                        _BookTagRepository.DeleteMulti(x => x.BookID == Book.ID);
                        BookTag BookTag = new BookTag();
                        BookTag.BookID = Book.ID;
                        BookTag.TagID = tagId;
                        _BookTagRepository.Add(BookTag);
                    }

                }
            }

            public IEnumerable<Book> GetLastest(int top)
            {
                return _BookRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
            }

            public IEnumerable<Book> GetHotBook(int top)
            {
                return _BookRepository.GetMulti(x => x.Status && x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(top);

            }

            public IEnumerable<Book> GetListBookByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
            {
                var query = _BookRepository.GetMulti(x => x.Status && x.CategoryID == categoryId);

                switch (sort)
                {
                    case "popular":
                        query = query.OrderByDescending(x => x.ViewCount);
                        break;
                    case "discount":
                        query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                        break;
                    case "price":
                        query = query.OrderBy(x => x.Price);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                }

                totalRow = query.Count();

                return query.Skip((page - 1) * pageSize).Take(pageSize);
            }

            public IEnumerable<string> GetListBookByName(string name)
            {
                return _BookRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
            }

            public IEnumerable<Book> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
            {
                var query = _BookRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

                switch (sort)
                {
                    case "popular":
                        query = query.OrderByDescending(x => x.ViewCount);
                        break;
                    case "discount":
                        query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                        break;
                    case "price":
                        query = query.OrderBy(x => x.Price);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                }

                totalRow = query.Count();

                return query.Skip((page - 1) * pageSize).Take(pageSize);
            }

            public IEnumerable<Book> GetReatedBooks(int id, int top)
            {
                var Book = _BookRepository.GetSingleById(id);
                return _BookRepository.GetMulti(x => x.Status && x.ID != id && x.CategoryID == Book.CategoryID).OrderByDescending(x => x.CreatedDate).Take(top);
            }

            public IEnumerable<Tag> GetListTagByBookId(int id)
            {
                return _BookTagRepository.GetMulti(x => x.BookID == id, new string[] { "Tag" }).Select(y => y.Tag);
            }

            public void IncreaseView(int id)
            {
                var Book = _BookRepository.GetSingleById(id);
                if (Book.ViewCount.HasValue)
                    Book.ViewCount += 1;
                else
                    Book.ViewCount = 1;
            }

            public IEnumerable<Book> GetListBookByTag(string tagId, int page, int pageSize, out int totalRow)
            {
               var model = _BookRepository.GetListBookByTag(tagId, page, pageSize, out totalRow);
                return model;
            }

            public Tag GetTag(string tagId)
            {
               return _tagRepository.GetSingleByCondition(x=>x.ID==tagId);
            }

            //Selling Book
            public bool SellBook(int BookId, int quantity)
            {
                var Book = _BookRepository.GetSingleById(BookId);
                if (Book.Quantity < quantity)
                    return false;
                Book.Quantity -= quantity;
                return true;
            }
        }

        */
    }