namespace NorthWind2.Services
{
    public interface IMapper<TInput, TOut>
    {
        TOut Map(TInput viewModel);
    }
}