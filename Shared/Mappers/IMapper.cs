namespace Shared.Mappers
{
    public interface IMapper<F, T>
    {
        T Map(F entity);
    }
}
