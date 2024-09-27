using AutoMapper;
using manga.Domain.Dtos;
using mangas.Domain.Entities;


namespace manga.Services.MappingsM;

public class RequestCreateMappingProfile : Profile 
{
  public RequestCreateMappingProfile()
  {
    CreateMap<MangaCreateDTO, Manga>()
     .AfterMap(
      (src, dest)=>
      {
        dest.PublicationDate = DateTime.Now;
      }
     );
  }
}