namespace CadastroAnuncio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CadastroAnuncioMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CadastroAnuncioModel", "FiltroNomeCliente", c => c.String(maxLength: 100));
            AddColumn("dbo.CadastroAnuncioModel", "FIltroDataTermino", c => c.DateTime());
            AddColumn("dbo.CadastroAnuncioModel", "FiltroDataInicio", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CadastroAnuncioModel", "FiltroDataInicio");
            DropColumn("dbo.CadastroAnuncioModel", "FIltroDataTermino");
            DropColumn("dbo.CadastroAnuncioModel", "FiltroNomeCliente");
        }
    }
}
