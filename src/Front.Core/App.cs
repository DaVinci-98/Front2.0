using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Front.Core.ViewModels;

namespace Front.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<RootViewModel>();
        }
    }
}
