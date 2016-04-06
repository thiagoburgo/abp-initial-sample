using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Abp.EntityFramework;

namespace Clintech.ClinApps.Repositories.DbContexts
{
    public class S4DbContext : AbpDbContext
    {
        public S4DbContext()
            : base("S4ConnStringName")
        {
        }

        //Esse construtor é usado nos testes
        public S4DbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            IEnumerable<Type> typesEntityTypeConfiguration =
                Assembly.GetExecutingAssembly().GetTypes().Where(type => type.BaseType != null && type.BaseType.IsGenericType
                            && !type.ContainsGenericParameters
                            && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            List<Type> typesToRegister = typesEntityTypeConfiguration.ToList();
            if (typesToRegister.Any())
            {
                foreach (Type type in typesToRegister)
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(configurationInstance);
                    this.Logger.DebugFormat("Mapeamento do EntityFramework registrado com sucesso para '{0}'", type.FullName);
                }
            }
            else
            {
                this.Logger.Warn("Não foram encontradas entidades para registrar mapeamento no Entity.");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
