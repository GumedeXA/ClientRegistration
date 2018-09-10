namespace ClientRegistration.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wave26migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerReview",
                c => new
                    {
                        CustomerReviewId = c.Int(nullable: false, identity: true),
                        CustId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                        Ratings = c.Int(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerReviewId)
                .ForeignKey("dbo.Customer", t => t.CustId)
                .ForeignKey("dbo.Review", t => t.ReviewId)
                .Index(t => t.CustId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        ProductOrderId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductOrderId)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Product", "Discount", c => c.Double(nullable: false));
            AddColumn("dbo.Product", "ProductImage", c => c.Binary());
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.BusinessAdmin", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.BusinessAdmin", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.Vendor", "VendorRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.Vendor", "VendorName", c => c.String(nullable: false));
            AlterColumn("dbo.Vendor", "VendorPostalAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Vendor", "VendorEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Vendor", "TelephoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "IdNumber", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Customer", "PostalAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrder", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.CustomerReview", "ReviewId", "dbo.Review");
            DropForeignKey("dbo.Review", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CustomerReview", "CustId", "dbo.Customer");
            DropIndex("dbo.ProductOrder", new[] { "OrderId" });
            DropIndex("dbo.ProductOrder", new[] { "ProductId" });
            DropIndex("dbo.Review", new[] { "ProductId" });
            DropIndex("dbo.CustomerReview", new[] { "ReviewId" });
            DropIndex("dbo.CustomerReview", new[] { "CustId" });
            AlterColumn("dbo.Customer", "Role", c => c.String());
            AlterColumn("dbo.Customer", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Customer", "PostalAddress", c => c.String());
            AlterColumn("dbo.Customer", "IdNumber", c => c.String(maxLength: 13));
            AlterColumn("dbo.Vendor", "TelephoneNumber", c => c.String());
            AlterColumn("dbo.Vendor", "VendorEmail", c => c.String());
            AlterColumn("dbo.Vendor", "VendorPostalAddress", c => c.String());
            AlterColumn("dbo.Vendor", "VendorName", c => c.String());
            AlterColumn("dbo.Vendor", "VendorRegNo", c => c.String());
            AlterColumn("dbo.BusinessAdmin", "Role", c => c.String());
            AlterColumn("dbo.BusinessAdmin", "ConfirmPassword", c => c.String());
            DropColumn("dbo.Product", "Quantity");
            DropColumn("dbo.Product", "ProductImage");
            DropColumn("dbo.Product", "Discount");
            DropTable("dbo.ProductOrder");
            DropTable("dbo.Order");
            DropTable("dbo.Review");
            DropTable("dbo.CustomerReview");
        }
    }
}
