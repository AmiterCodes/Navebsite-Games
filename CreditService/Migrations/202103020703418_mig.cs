namespace CreditService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccountDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HolderName = c.String(),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditCardDetails",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        CardVerificationValue = c.String(),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardNumber)
                .ForeignKey("dbo.BankAccountDetails", t => t.BankAccountId, cascadeDelete: true)
                .Index(t => t.BankAccountId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        AmountDollar = c.Double(nullable: false),
                        CardNumber = c.String(maxLength: 128),
                        identificationNumber = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        To_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.CreditCardDetails", t => t.CardNumber)
                .ForeignKey("dbo.BankAccountDetails", t => t.To_Id)
                .Index(t => t.CardNumber)
                .Index(t => t.To_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "To_Id", "dbo.BankAccountDetails");
            DropForeignKey("dbo.Transactions", "CardNumber", "dbo.CreditCardDetails");
            DropForeignKey("dbo.CreditCardDetails", "BankAccountId", "dbo.BankAccountDetails");
            DropIndex("dbo.Transactions", new[] { "To_Id" });
            DropIndex("dbo.Transactions", new[] { "CardNumber" });
            DropIndex("dbo.CreditCardDetails", new[] { "BankAccountId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.CreditCardDetails");
            DropTable("dbo.BankAccountDetails");
        }
    }
}
