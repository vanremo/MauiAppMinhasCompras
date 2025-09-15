using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Data;
using System;

namespace MauiAppMinhasCompras.Views
{
    public partial class EditarProduto : ContentPage
    {
        private Produto _produto;
        private ProdutoRepository _repository;

        public EditarProduto(Produto produto, ProdutoRepository repository)
        {
            InitializeComponent();

            _produto = produto;
            _repository = repository;

            // Preenche campos com os valores existentes
            DescricaoEntry.Text = _produto.Descricao;
            QuantidadeEntry.Text = _produto.Quantidade.ToString();
            PrecoEntry.Text = _produto.Preco.ToString();
            CategoriaPicker.SelectedItem = _produto.Categoria;
        }

        private async void OnSalvarAlteracoes(object sender, EventArgs e)
        {
            try
            {
                _produto.Descricao = DescricaoEntry.Text;
                _produto.Quantidade = double.Parse(QuantidadeEntry.Text);
                _produto.Preco = double.Parse(PrecoEntry.Text);
                _produto.Categoria = CategoriaPicker.SelectedItem?.ToString() ?? "Outros";

                _repository.SaveProduto(_produto);

                await DisplayAlert("Sucesso", "Produto atualizado!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}