namespace SavingVariables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConstantTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Constants", "ConstantName", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Constants", "ConstantName");
        }
    }
}
