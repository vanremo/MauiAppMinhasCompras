using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Data;
using MauiAppMinhasCompras.Pages;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        private ProdutoRepository _repository;
        public ObservableCollection<Produto> ListaProdutos { get; set; }

        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "produtos.db3");
            _repository = new ProdutoRepository(dbPath);

            ListaProdutos = new ObservableCollection<Produto>(_repository.GetProdutos());
            ProdutosCollectionView.ItemsSource = ListaProdutos;
        }

        private void OnAdicionarProduto(object sender, EventArgs e)
        {
            try
            {
                var produto = new Produto
                {
                    Descricao = DescricaoEntry.Text,
                    Quantidade = double.Parse(QuantidadeEntry.Text),
                    Preco = double.Parse(PrecoEntry.Text),
                    Categoria = CategoriaPicker.SelectedItem?.ToString() ?? "Outros"
                };

                _repository.SaveProduto(produto);
                ListaProdutos.Add(produto); // ✅ Adiciona à ObservableCollection

                // Limpa campos
                DescricaoEntry.Text = string.Empty;
                QuantidadeEntry.Text = string.Empty;
                PrecoEntry.Text = string.Empty;
                CategoriaPicker.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void OnFiltroCategoriaChanged(object sender, EventArgs e)
        {
            string categoriaSelecionada = FiltroCategoriaPicker.SelectedItem?.ToString();
            if (categoriaSelecionada == "Todos" || string.IsNullOrEmpty(categoriaSelecionada))
            {
                ProdutosCollectionView.ItemsSource = ListaProdutos;
            }
            else
            {
                ProdutosCollectionView.ItemsSource = ListaProdutos
                    .Where(p => p.Categoria == categoriaSelecionada)
                    .ToList();
            }
        }

        private async void OnAbrirRelatorio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatorioPage(ListaProdutos.ToList()));
        }
    }
}