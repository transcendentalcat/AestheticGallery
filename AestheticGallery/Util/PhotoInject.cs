using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject.Modules;

namespace NLayerApp.WEB.Util
{
    public class PhotoInject : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhotoService>().To<PhotoService>();
        }
    }
}