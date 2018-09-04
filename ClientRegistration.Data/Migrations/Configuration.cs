namespace ClientRegistration.Data.Migrations
{
    using ClientRegistration.Data.Context;
    using ClientRegistration.Data.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            //context.BusinessAdmin.AddOrUpdate(
            //    new BusinessAdmin
            //    {
            //        BusAdminId=1,
            //        fullNames="Xolani G",
            //        Email="xoani@law.co.za",
            //        IdNumber="9309876789098",
            //        PostalAddress="A34 Centurion 3456",
            //        userName="Xolani",
            //        RegistrationDate=Convert.ToDateTime("2018-07-12"),
            //        phoneNumber="0815333567",
            //        Role="BusinessAdmin",
            //        Password="1234567",
            //        ConfirmPassword="1234567"
            //    });
        }
    }
}
