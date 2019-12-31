using Ninject.Modules;

namespace EPAM_entity.Configs
{
    public class Ninject : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}