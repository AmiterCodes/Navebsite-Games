namespace CreditService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notautogeneratekeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCardDetails", "BankAccount_identificationNumber", "dbo.BankAccountDetails");
            DropForeignKey("dbo.Transactions", "identificationNumber", "dbo.BankAccountDetails");
            DropPrimaryKey("dbo.BankAccountDetails");
            AlterColumn("dbo.BankAccountDetails", "identificationNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BankAccountDetails", "identificationNumber");
            AddForeignKey("dbo.CreditCardDetails", "BankAccount_identificationNumber", "dbo.BankAccountDetails", "identificationNumber");
            AddForeignKey("dbo.Transactions", "identificationNumber", "dbo.BankAccountDetails", "identificationNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "identificationNumber", "dbo.BankAccountDetails");
            DropForeignKey("dbo.CreditCardDetails", "BankAccount_identificationNumber", "dbo.BankAccountDetails");
            DropPrimaryKey("dbo.BankAccountDetails");
            AlterColumn("dbo.BankAccountDetails", "identificationNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BankAccountDetails", "identificationNumber");
            AddForeignKey("dbo.Transactions", "identificationNumber", "dbo.BankAccountDetails", "identificationNumber", cascadeDelete: true);
            AddForeignKey("dbo.CreditCardDetails", "BankAccount_identificationNumber", "dbo.BankAccountDetails", "identificationNumber");
        }
    }
}
