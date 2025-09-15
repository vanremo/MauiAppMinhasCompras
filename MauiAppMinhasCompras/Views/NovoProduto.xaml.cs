using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Data;
using System;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class NovoProduto : ContentPage
    {
        private ProdutoRepository _repository;
        private Action<Produto> _onProdutoAdicionado;

        public NovoProduto(ProdutoRepository repository, Action<Produto> onProdutoAdicionado)
        {
            InitializeComponent();

            _repository = repository;
            _onProdutoAdicionado = onProdutoAdicionado;
        }

        private async void OnAdicionarProduto(object sender, EventArgs e)
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

                // Salva no banco
                _repository.SaveProduto(produto);

                // Callback para atualizar lista
                _onProdutoAdicionado?.Invoke(produto);

                await DisplayAlert("Sucesso", "Produto adicionado!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}