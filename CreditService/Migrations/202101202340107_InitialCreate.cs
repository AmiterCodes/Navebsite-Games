namespace CreditService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccountDetails",
                c => new
                    {
                        identificationNumber = c.Int(nullable: false, identity: true),
                        holderName = c.String(),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.identificationNumber);
            
            CreateTable(
                "dbo.CreditCardDetails",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        CardVerificationValue = c.String(),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        BankAccount_identificationNumber = c.Int(),
                    })
                .PrimaryKey(t => t.CardNumber)
                .ForeignKey("dbo.BankAccountDetails", t => t.BankAccount_identificationNumber)
                .Index(t => t.BankAccount_identificationNumber);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        AmountDollar = c.Double(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        From_CardNumber = c.String(maxLength: 128),
                        To_identificationNumber = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.CreditCardDetails", t => t.From_CardNumber)
                .ForeignKey("dbo.BankAccountDetails", t => t.To_identificationNumber)
                .Index(t => t.From_CardNumber)
                .Index(t => t.To_identificationNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "To_identificationNumber", "dbo.BankAccountDetails");
            DropForeignKey("dbo.Transactions", "From_CardNumber", "dbo.CreditCardDetails");
            DropForeignKey("dbo.CreditCardDetails", "BankAccount_identificationNumber", "dbo.BankAccountDetails");
            DropIndex("dbo.Transactions", new[] { "To_identificationNumber" });
            DropIndex("dbo.Transactions", new[] { "From_CardNumber" });
            DropIndex("dbo.CreditCardDetails", new[] { "BankAccount_identificationNumber" });
            DropTable("dbo.Transactions");
            DropTable("dbo.CreditCardDetails");
            DropTable("dbo.BankAccountDetails");
        }
    }
}
