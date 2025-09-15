using MauiAppMinhasCompras.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class RelatorioPage : ContentPage
    {
        public RelatorioPage(List<Produto> produtos)
        {
            InitializeComponent();

            // Agrupa por categoria e calcula o total
            var resumo = produtos
                .GroupBy(p => p.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Sum(p => p.Total)
                })
                .ToList();

            RelatorioCollectionView.ItemsSource = resumo;
        }
    }
}