namespace DataValidation.Controllers
{
    public interface IMapper
    {
        T1 Map<T, T1>(T t);
        T1 Map<T, T1>(T t, T1 v);
    }
}