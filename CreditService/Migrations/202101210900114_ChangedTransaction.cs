namespace CreditService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTransaction : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "From_CardNumber", newName: "CardNumber");
            RenameIndex(table: "dbo.Transactions", name: "IX_From_CardNumber", newName: "IX_CardNumber");
            DropColumn("dbo.Transactions", "creditCardNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "creditCardNumber", c => c.String());
            RenameIndex(table: "dbo.Transactions", name: "IX_CardNumber", newName: "IX_From_CardNumber");
            RenameColumn(table: "dbo.Transactions", name: "CardNumber", newName: "From_CardNumber");
        }
    }
}
