using System.Composition.Hosting;
using System.Reflection;

namespace Store.Core.DataLayer.Mapping
{
    public class StoreEntityMapper : EntityMapper
    {
        public StoreEntityMapper()
        {
            var assemblies = new[] { typeof(StoreDbContext).GetTypeInfo().Assembly };

            var configuration = new ContainerConfiguration().WithAssembly(typeof(StoreDbContext).GetTypeInfo().Assembly);

            using (var container = configuration.CreateContainer())
            {
                Mappings = container.GetExports<IEntityMap>();
            }
        }
    }
}
