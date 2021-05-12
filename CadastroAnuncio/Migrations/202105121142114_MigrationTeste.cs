namespace CadastroAnuncio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTeste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CadastroAnuncioModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeAnuncio = c.String(maxLength: 100),
                        NomeCliente = c.String(maxLength: 100),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                        InvestimentoDia = c.Double(nullable: false),
                        ValorTotalInvestido = c.Double(nullable: false),
                        QtdMaxVizualizacao = c.Decimal(precision: 18, scale: 2),
                        QtdMaxClique = c.Decimal(precision: 18, scale: 2),
                        QtdMaxCompartilhamento = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CadastroAnuncioModel");
        }
    }
}
