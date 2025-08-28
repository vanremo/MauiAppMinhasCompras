🛒 MauiAppMinhasCompras
✨ Descrição

O MauiAppMinhasCompras é um aplicativo desenvolvido em .NET MAUI para gerenciamento de produtos, permitindo busca dinâmica e atualização automática da interface usando ObservableCollection. O app inclui funcionalidades de listar, adicionar e editar produtos.

-----------------------------------------------------------------------------------------------------------------------

🎯 Funcionalidades

📋 Listagem de produtos com busca dinâmica em tempo real

➕ Cadastro de novos produtos

✏️ Edição de produtos existentes

🔄 Atualização automática da interface usando ObservableCollection

--------------------------------------------------------------------------------

🛠 Tecnologias utilizadas

⚡ .NET MAUI

💻 C# e XAML

🗄 SQLite para persistência de dados

🔄 ObservableCollection para atualização automática da UI

---------------------------------------------------------------------------------------------------
MauiAppMinhasCompras/
├─ Helpers/
│ └─ SQLITEDatabaseHelpers.cs
├─ Models/
│ └─ Produto.cs
├─ Views/
│ ├─ EditarProduto/
│ │ └─ EditarProduto.xaml + EditarProduto.xaml.cs
│ ├─ ListarProduto/
│ │ └─ ListarProduto.xaml + ListarProduto.xaml.cs
│ └─ NovoProduto/
│ └─ NovoProduto.xaml + NovoProduto.xaml.cs
├─ MauiAppMinhasCompras.csproj
└─ README.md
------------------------------------------------------------------------------------------

🚀 Como executar

Clone o repositório:

git clone https://github.com/seuusuario/MauiAppMinhasCompras.git

Abra a solução .sln no Visual Studio

Configure o projeto como startup project

Execute o app em um emulador ou dispositivo físico

------------------------------------------------------------------------------------------
🔍 Funcionalidade de busca dinâmica

O SearchBar permite filtrar produtos conforme o usuário digita

A lista é armazenada em uma ObservableCollection, garantindo atualização automática da interface

O filtro é case-insensitive, tornando a busca mais intuitiva

----------------------------------------------------------------------------------------

💡 Possíveis melhorias

🏷 Adicionar filtros por categoria ou preço, permitindo buscas mais específicas.

⚡ Substituir ListView por CollectionView para melhorar a performance e fluidez da interface.

❌ Mostrar mensagem quando nenhum produto for encontrado, oferecendo feedback ao usuário.

✏️ Implementar edição de produtos diretamente na lista, utilizando o menu de contexto já previsto (MenuItem_Clicked).

🗑 Implementar exclusão de produtos com confirmação do usuário antes de remover, completando o ciclo CRUD (Criar, Ler, Atualizar e Deletar).

🎨 Aprimorar a interface visual, tornando o app mais profissional e agradável, com cores consistentes, ícones intuitivos e layout moderno.
