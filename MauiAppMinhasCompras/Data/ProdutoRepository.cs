using SQLite;
using MauiAppMinhasCompras.Models;
using System.Collections.Generic;
using System.IO;

namespace MauiAppMinhasCompras.Data
{
    public class ProdutoRepository
    {
        private SQLiteConnection _db;

        public ProdutoRepository(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Produto>();
        }

        public List<Produto> GetProdutos() => _db.Table<Produto>().ToList();

        public void SaveProduto(Produto produto)
        {
            if (produto.Id != 0)
                _db.Update(produto);
            else
                _db.Insert(produto);
        }

        public void DeleteProduto(Produto produto)
        {
            _db.Delete(produto);
        }
    }
}