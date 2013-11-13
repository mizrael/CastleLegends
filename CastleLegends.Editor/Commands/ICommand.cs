
namespace CastleLegends.Editor.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
