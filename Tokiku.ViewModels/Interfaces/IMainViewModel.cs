namespace Tokiku.ViewModels
{
    public interface IMainViewModel : IBaseViewModelWithLoginedUser
    {
        MainViewModel Query();
    }
}