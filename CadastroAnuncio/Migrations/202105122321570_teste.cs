namespace CadastroAnuncio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CadastroAnuncioModel", "QtdMaxVizualizacao", c => c.Double());
            AlterColumn("dbo.CadastroAnuncioModel", "QtdMaxClique", c => c.Double());
            AlterColumn("dbo.CadastroAnuncioModel", "QtdMaxCompartilhamento", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CadastroAnuncioModel", "QtdMaxCompartilhamento", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CadastroAnuncioModel", "QtdMaxClique", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CadastroAnuncioModel", "QtdMaxVizualizacao", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
