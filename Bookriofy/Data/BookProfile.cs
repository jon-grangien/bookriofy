using AutoMapper;

namespace Bookriofy.Data
{
	public class BookProfile : Profile
	{
		public BookProfile()
		{
			CreateMap<Bookriofy.GraphQL.IGetBooks_Books, Book>()
				.ForMember(b => b.Id, opt => opt.MapFrom(b => b.Id))
				.ForMember(b => b.Title, opt => opt.MapFrom(b => b.Title))
				.ForMember(b => b.Description, opt => opt.MapFrom(b => b.Description))
				.ForMember(b => b.ImageLink, opt => opt.MapFrom(b => b.ImageLink))
				.ForMember(b => b.PublishedYear, opt => opt.MapFrom(b => b.PublishedYear))
				.ForMember(b => b.AuthorId, opt => opt.MapFrom(b => b.Author.Id));
		}
	}
}