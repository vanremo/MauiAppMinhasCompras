using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        private ProdutoRepository _repository;
        public ObservableCollection<Produto> ListaProdutos { get; set; }

        public ListaProduto()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "produtos.db3");
            _repository = new ProdutoRepository(dbPath);

            // Carrega os produtos existentes
            ListaProdutos = new ObservableCollection<Produto>(_repository.GetProdutos());
            ProdutosCollectionView.ItemsSource = ListaProdutos;
        }

        // Abrir tela de novo produto
        private async void OnAbrirNovoProduto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoProduto(_repository, produto =>
            {
                ListaProdutos.Add(produto);
            }));
        }

        // Filtrar produtos por categoria
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

        // Editar produto selecionado
        private async void OnEditarProduto(object sender, EventArgs e)
        {
            var button = sender as Button;
            var produto = button?.BindingContext as Produto;
            if (produto == null) return;

            var editPage = new EditarProduto(produto, _repository);
            await Navigation.PushAsync(editPage);

            // Atualiza a CollectionView ao voltar
            editPage.Disappearing += (s, args) =>
            {
                ProdutosCollectionView.ItemsSource = null;
                ProdutosCollectionView.ItemsSource = ListaProdutos;
            };
        }

        // Deletar produto selecionado
        private async void OnDeletarProduto(object sender, EventArgs e)
        {
            var button = sender as Button;
            var produto = button?.BindingContext as Produto;
            if (produto == null) return;

            bool confirm = await DisplayAlert("Confirmação", $"Deseja deletar {produto.Descricao}?", "Sim", "Não");
            if (confirm)
            {
                _repository.DeleteProduto(produto);
                ListaProdutos.Remove(produto);
            }
        }

        // Abrir página de relatório
        private async void OnAbrirRelatorio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatorioPage(ListaProdutos.ToList()));
        }
    }
}