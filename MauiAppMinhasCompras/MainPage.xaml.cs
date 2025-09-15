using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Data;
using MauiAppMinhasCompras.Views;
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

            // Inicializa o banco de dados
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "produtos.db3");
            _repository = new ProdutoRepository(dbPath);

            // Carrega os produtos existentes
            ListaProdutos = new ObservableCollection<Produto>(_repository.GetProdutos());
            ProdutosCollectionView.ItemsSource = ListaProdutos;

            // Popula o Picker de filtro
            FiltroCategoriaPicker.ItemsSource = new List<string>
            {
                "Todos",
                "Alimentos",
                "Higiene",
                "Limpeza",
                "Outros"
            };
        }

        // Adicionar novo produto
        private void OnAdicionarProduto(object sender, EventArgs e)
        {
            try
            {
                var produto = new Produto
                {
                    Descricao = DescricaoEntry.Text,
                    Quantidade = double.Parse(QuantidadeEntry.Text),
                    Preco = double.Parse(PrecoEntry.Text),
                    Categoria = FiltroCategoriaPicker.SelectedItem?.ToString() ?? "Outros"
                };

                _repository.SaveProduto(produto);
                ListaProdutos.Add(produto);

                // Limpa os campos
                DescricaoEntry.Text = string.Empty;
                QuantidadeEntry.Text = string.Empty;
                PrecoEntry.Text = string.Empty;
                FiltroCategoriaPicker.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        // Filtro por categoria
        private void OnFiltroCategoriaChanged(object sender, EventArgs e)
        {
            string categoriaSelecionada = FiltroCategoriaPicker.SelectedItem?.ToString();

            if (categoriaSelecionada == "Todos" || string.IsNullOrEmpty(categoriaSelecionada))
            {
                ProdutosCollectionView.ItemsSource = ListaProdutos;
            }
            else
            {
                ProdutosCollectionView.ItemsSource = new ObservableCollection<Produto>(
                    ListaProdutos.Where(p => p.Categoria == categoriaSelecionada)
                );
            }
        }

        // Abrir relatório
        private async void OnAbrirRelatorio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatorioPage(ListaProdutos.ToList()));
        }
    }
}