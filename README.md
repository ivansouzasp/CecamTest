# CecamTest
A solução possui duas partes Backend e Web comm angular.

Nos testes executados utilizei o Visual Studio Code para os testes finais.

A solução foi criada utilizando DDD, IOC, CQRS, Unit Tests e Angular 12.0.5.
DotNet Core 5

Para criar o banco de dados
1. Criar um database sql server localmente ou em algum servidor
2. O nome do database criado foi CecamTest
3. Configurar os conectionstrings nos arquivos appsettings.json dos projetos de testes e CECAM.Application 
4. Utilize o migrations para inicializar o banco de dados
5. Executar o comando dotnet ef database update

Para executar o BackEnd
1. Abrir um terminal e ir para a pasta CECAM.Application
2. Executar na pasta CECAM.Application os commandos dotnet clean e após dotnet build
3. Executar na pasta indicada o comando dotnet run

Para executar o FrontEnd
1. Abrir um terminal e ir para a pasta Presentation/Web/cecamtestweb
2. Executar o coamndo npm start

Se houver algum problema na execução do frontend seguir os seguintes passos.
1. Na pasta Presentation/Web/cecamtestweb executar os comandos abaixo.
2. npm install
3. ng update
4. npm update
