using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var banners = await _repository.GetAllAsync();
            return banners.Select(b => new GetBannerQueryResult
            {
                BannerID = b.BannerID,
                Title = b.Title,
                Description = b.Description,
              VideoDescription = b.VideoDescription,
              VideoUrl=b.VideoUrl
            }).ToList();
        }
    }
}
