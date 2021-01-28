namespace CreditService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "To_identificationNumber", "dbo.BankAccountDetails");
            DropIndex("dbo.Transactions", new[] { "To_identificationNumber" });
            RenameColumn(table: "dbo.Transactions", name: "To_identificationNumber", newName: "identificationNumber");
            AddColumn("dbo.Transactions", "creditCardNumber", c => c.String());
            AlterColumn("dbo.Transactions", "identificationNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "identificationNumber");
            AddForeignKey("dbo.Transactions", "identificationNumber", "dbo.BankAccountDetails", "identificationNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "identificationNumber", "dbo.BankAccountDetails");
            DropIndex("dbo.Transactions", new[] { "identificationNumber" });
            AlterColumn("dbo.Transactions", "identificationNumber", c => c.Int());
            DropColumn("dbo.Transactions", "creditCardNumber");
            RenameColumn(table: "dbo.Transactions", name: "identificationNumber", newName: "To_identificationNumber");
            CreateIndex("dbo.Transactions", "To_identificationNumber");
            AddForeignKey("dbo.Transactions", "To_identificationNumber", "dbo.BankAccountDetails", "identificationNumber");
        }
    }
}
