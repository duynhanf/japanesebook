using System;
using System.Collections.Generic;
using JapaneseBook.Model.Entities;

namespace JapaneseBook.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService : ICommonService
    {
        /*
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;
        ISlideRepository _slideRepository;
        public CommonService(IFooterRepository footerRepository,IUnitOfWork unitOfWork,ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _slideRepository = slideRepository;
        }
        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x=>x.Status);
        }

    */
        public Footer GetFooter()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slide> GetSlides()
        {
            throw new NotImplementedException();
        }
    }
}
