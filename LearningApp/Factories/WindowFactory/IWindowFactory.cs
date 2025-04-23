using System.Threading.Tasks;
using LearningApp.Utils.Enum;

namespace LearningApp.Factories.WindowFactory;

public interface IWindowFactory
{
    void Show(AppWindowNames windowName);
    Task<TResult> ShowDialog<TResult>(AppWindowNames windowName);
}