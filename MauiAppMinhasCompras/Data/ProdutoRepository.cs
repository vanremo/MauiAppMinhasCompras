using MauiAppMinhasCompras.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MauiAppMinhasCompras.Data
{
    public class ProdutoRepository
    {
        private readonly SQLiteConnection _db;

        public ProdutoRepository(string dbPath)
        {
            // Cria conexão com o banco SQLite
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Produto>(); // Cria a tabela se não existir
        }

        // Salvar produto
        public void SaveProduto(Produto produto)
        {
            if (produto.Id != 0)
            {
                _db.Update(produto);
            }
            else
            {
                _db.Insert(produto);
            }
        }

        // Retornar todos os produtos
        public List<Produto> GetProdutos()
        {
            return _db.Table<Produto>().ToList();
        }
    }
}