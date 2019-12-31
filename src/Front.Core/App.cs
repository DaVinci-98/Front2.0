using Front.Core.Services;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Front.Core.ViewModels;
using MvvmCross;

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
