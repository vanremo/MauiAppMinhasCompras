using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        // Propriedade calculada (não vai para o banco SQLite)
        [Ignore]
        public double Total => Quantidade * Preco;
    }
}
