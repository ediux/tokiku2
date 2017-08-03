namespace Tokiku.ViewModels
{
    public interface ILoginViewModel
    {
        string Password { get; set; }
        string SaveModelController { get; set; }
        string UserName { get; set; }

        void Login(object Parameter);
    }
}