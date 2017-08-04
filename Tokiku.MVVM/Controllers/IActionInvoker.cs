namespace Tokiku.MVVM
{
    public interface IActionInvoker
    {
        bool InvokeAction(ControllerContext controllerContext, string actionName);
    }
}