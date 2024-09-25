Contact Control 
1. Introdução: Este projeto tem como objetivo o desenvolvimento de um sistema 
de controle de cadastros de usuários. A aplicação permite a inserção, edição e 
exclusão de usuários, com o preenchimento de campos essenciais como nome, 
telefone, data de nascimento e CEP. O sistema foi projetado para ser simples e 
funcional, atendendo às necessidades básicas de gerenciamento de dados dos 
usuários. 
2. Tema: O tema do projeto é o desenvolvimento de uma aplicação web para 
controle de cadastros de usuários. A solução é baseada na criação de uma 
interface amigável, onde os usuários podem ser cadastrados no sistema, com a 
capacidade de editar e excluir suas informações quando necessário. 
3. Diagrama de Caso de Uso: O diagrama de caso de uso foi projetado para 
ilustrar as funcionalidades principais do sistema. Nele, é possível visualizar as 
interações do usuário com a aplicação, abrangendo as ações de cadastro, edição 
e exclusão de usuários, além da visualização de dados pré-preenchidos a partir do 
CEP. 
4. Protótipos de Telas: 
• Tela de Cadastro de Usuários: Um formulário onde o usuário pode inserir os 
dados necessários para o cadastro. Campos como nome, telefone (com 
máscara), data de nascimento (com máscara) e CEP (com máscara que 
preenche automaticamente rua e número) estão presentes. 
• Tela de Edição de Usuários: Permite a modificação dos dados do usuário 
previamente cadastrado. 
• Tela de Exclusão: Opção de excluir um usuário do sistema. 
5. MVP (Produto Viável Mínimo): O MVP do projeto inclui as funcionalidades 
principais de um sistema de cadastro de usuários, focando na adição, edição e 
remoção de dados. Cada uma dessas funcionalidades já foi implementada e está 
em pleno funcionamento, proporcionando uma base sólida para futuras 
expansões. 
6. Modelagem do Banco de Dados (DER): O banco de dados foi modelado de 
forma a suportar todas as informações relacionadas aos usuários. As principais 
tabelas incluem: 
• Usuários: Com colunas como Nome, Telefone, Data de Nascimento, CEP, 
Rua, Número. 
• Migrations foram utilizadas para estruturar e atualizar o banco de dados ao 
longo do desenvolvimento. 
7. Diagrama de Classes: O diagrama de classes representa as relações entre as 
entidades do sistema. O uso do Entity Framework permite que essas entidades 
sejam diretamente mapeadas para as tabelas do banco de dados. 
8. Tecnologias Utilizadas: 
• Backend: ASP.NET Core com Entity Framework para facilitar a 
comunicação com o banco de dados. 
• Banco de Dados: SQL Server com Migrations para controlar a estrutura do 
banco. 
• Frontend: HTML, CSS, JavaScript, com máscaras aplicadas aos campos de 
telefone, data de nascimento e CEP. 
9. GitHub: Todos os arquivos relacionados ao projeto, incluindo o código-fonte, 
diagramas e documentação, estão disponíveis no repositório do GitHub: 
https://github.com/WillSchmidt97/Contact-Control 
10. Conclusão: O projeto foi desenvolvido com sucesso, implementando as 
principais funcionalidades de um sistema de controle de cadastros de usuários. A 
estruturação do banco de dados, o uso de máscaras para campos específicos e a 
automação do preenchimento de endereço a partir do CEP são os principais 
diferenciais desta aplicação. 
