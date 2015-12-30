namespace Abonamenty.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SubscriptionContext : DbContext
    {
        public SubscriptionContext()
            : base("name=SubscriptionContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<calibrator> calibrators { get; set; }
        public virtual DbSet<calibrators_functions> calibrators_functions { get; set; }
        public virtual DbSet<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
        public virtual DbSet<certificate> certificates { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<device> devices { get; set; }
        public virtual DbSet<devices_rents> devices_rents { get; set; }
        public virtual DbSet<function> functions { get; set; }
        public virtual DbSet<gauge> gauges { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<model_of_gauges> model_of_gauges { get; set; }
        public virtual DbSet<office> offices { get; set; }
        public virtual DbSet<rent> rents { get; set; }
        public virtual DbSet<subscription> subscriptions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tariff> tariffs { get; set; }
        public virtual DbSet<type> types { get; set; }
        public virtual DbSet<usage> usages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<calibrator>()
                .HasMany(e => e.calibrators_functions)
                .WithOptional(e => e.calibrator)
                .HasForeignKey(e => e.calibrator_id);

            modelBuilder.Entity<calibrator>()
                .HasMany(e => e.calibrators_model_of_gauges)
                .WithOptional(e => e.calibrator)
                .HasForeignKey(e => e.calibrator_id);

            modelBuilder.Entity<client>()
                .HasMany(e => e.gauges)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<client>()
                .HasMany(e => e.offices)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<device>()
                .HasMany(e => e.devices_rents)
                .WithOptional(e => e.device)
                .HasForeignKey(e => e.device_id);

            modelBuilder.Entity<function>()
                .HasMany(e => e.calibrators)
                .WithOptional(e => e.function)
                .HasForeignKey(e => e.function_functionId);

            modelBuilder.Entity<function>()
                .HasMany(e => e.calibrators_functions)
                .WithOptional(e => e.function)
                .HasForeignKey(e => e.function_id);

            modelBuilder.Entity<gauge>()
                .HasMany(e => e.certificates)
                .WithRequired(e => e.gauge)
                .HasForeignKey(e => e.gauge_id);

            modelBuilder.Entity<genre>()
                .HasMany(e => e.devices)
                .WithOptional(e => e.genre)
                .HasForeignKey(e => e.genre_id);

            modelBuilder.Entity<model_of_gauges>()
                .HasMany(e => e.calibrators_model_of_gauges)
                .WithOptional(e => e.model_of_gauges)
                .HasForeignKey(e => e.model_of_gaug_id);

            modelBuilder.Entity<model_of_gauges>()
                .HasMany(e => e.gauges)
                .WithRequired(e => e.model_of_gauges)
                .HasForeignKey(e => e.model_of_gauge_id);

            modelBuilder.Entity<office>()
                .HasMany(e => e.gauges)
                .WithOptional(e => e.office)
                .HasForeignKey(e => e.office_id);

            modelBuilder.Entity<rent>()
                .HasMany(e => e.devices_rents)
                .WithOptional(e => e.rent)
                .HasForeignKey(e => e.rent_id);

            modelBuilder.Entity<subscription>()
                .HasMany(e => e.clients)
                .WithOptional(e => e.subscription)
                .HasForeignKey(e => e.subscription_id);

            modelBuilder.Entity<subscription>()
                .HasMany(e => e.rents)
                .WithRequired(e => e.subscription)
                .HasForeignKey(e => e.subscription_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tariff>()
                .HasMany(e => e.subscriptions)
                .WithRequired(e => e.tariff)
                .HasForeignKey(e => e.tariff_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<type>()
                .HasMany(e => e.model_of_gauges)
                .WithRequired(e => e.type)
                .HasForeignKey(e => e.type_id);

            modelBuilder.Entity<usage>()
                .HasMany(e => e.model_of_gauges)
                .WithRequired(e => e.usage)
                .HasForeignKey(e => e.usage_id);

            modelBuilder.Ignore<ViewModel.CheckboxControlViewModelBase>();
            modelBuilder.Entity<ViewModel.CheckboxControlViewModelBase>().Ignore(x => x.IsChecked);
        }
    }
}
