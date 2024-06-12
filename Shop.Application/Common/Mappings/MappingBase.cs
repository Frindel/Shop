using AutoMapper;

namespace TodoCalendar.Application.Common.Mappings
{
    public abstract class MappingBase<T>
    {
        public virtual void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
