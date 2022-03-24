using AutoMapper;

namespace Bookriofy.Data
{
	public class AuthorProfile : Profile
	{
		public AuthorProfile()
		{
			CreateMap<Bookriofy.GraphQL.IGetAuthors_Authors, Author>()
				.ForMember(b => b.Id, opt => opt.MapFrom(b => b.Id))
				.ForMember(b => b.Name, opt => opt.MapFrom(b => b.Name))
				.ForMember(b => b.Bio, opt => opt.MapFrom(b => b.Bio));

			CreateMap<Bookriofy.GraphQL.IOnAuthorAdded_AuthorAdded, Author>()
				.ForMember(b => b.Id, opt => opt.MapFrom(b => b.Id))
				.ForMember(b => b.Name, opt => opt.MapFrom(b => b.Name))
				.ForMember(b => b.Bio, opt => opt.MapFrom(b => b.Bio));
		}
	}
}
