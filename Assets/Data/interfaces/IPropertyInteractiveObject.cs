/// <summary>
/// File for the content of interfaces: IFlay, IFlicker, IInitialization, IInteractable
/// </summary>
public class IPropertyInteractiveObject
{ }
public interface IFlay
{
    void Flay();
}
public interface IFlicker
{
    void Flicker();
}
public interface IAction
{
    void Action();
}
public interface IInitialization
{
    void Action();
}
public interface IInteractable : IAction, IInitialization
{
    bool IsInteractable { get; }
}
