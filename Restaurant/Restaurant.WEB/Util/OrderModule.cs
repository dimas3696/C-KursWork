using Ninject.Modules;
using Restaurant.BLL.Services;
using Restaurant.BLL.Interfaces;

namespace Restaurant.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<IDishService>().To<DishService>();
        }
    }
}