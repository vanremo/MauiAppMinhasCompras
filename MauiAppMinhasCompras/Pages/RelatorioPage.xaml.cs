using MauiAppMinhasCompras.Models; // Produto
using System.Collections.Generic;
using System.Linq;

namespace MauiAppMinhasCompras.Pages
{
    public partial class RelatorioPage : ContentPage
    {
        public RelatorioPage(List<Produto> produtos) // Construtor que aceita produtos
        {
            InitializeComponent();

            // Agrupa por categoria e calcula total
            var resumo = produtos
                .GroupBy(p => p.Categoria)
                .Select(g => new { Categoria = g.Key, Total = g.Sum(p => p.Total) })
                .ToList();

            RelatorioCollectionView.ItemsSource = resumo;
        }
    }
}