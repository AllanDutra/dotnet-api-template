# 🗒️ Template para APIs .NET Core

O objetivo deste template é simplificar o processo de criação de uma nova API .NET Core do completo zero.

## ℹ️ Versão do Framework

.NET 8.0 - A versão LTS no momento da criação do template.

## 💭 O que já está implementado

- Estrutura básica do Swagger UI;
- Padrão de camadas:
    - Api
    - Application
    - Core
    - Infrastructure
    - Shared

    > Obs: Cada camada possui o seu _Alias_ Module para injeção de dependências
- Notification Pattern;
- Middleware para tratamento de exceções globais;
- Fluent Validation pronto para uso.

## 🖐🏼 Hands-On, como implementar

1. Faça o clone do projeto para a sua máquina;

2. Delete a pasta oculta ".git" para que consiga criar a nova estrutura git para o seu novo projeto;

3. Altere os nomes das pastas de **Template**._Camada_ para **SeuProjeto**._Camada_;

    > Exemplo: **Pokedex**._Api_

4. Altere os nomes dos arquivos .csproj de Template.Camada.csproj para SeuProjeto.Camada.csproj;

5. Altere dentro de cada .csproj o caminho presente em ProjectReference para que passe a apontar para o novo caminho definido das demais camadas.

6. Altere os namespaces que contenham a palavra "Template" para o nome do seu projeto;

7. Altere dentro da classe Constants.cs, presente na camada Template.Core, a variável ApplicationName para também o nome da sua aplicação;

8. Dentro da pasta src, crie a sua solução executando a seguinte linha de comando:

    ```dotnet new sln --name SeuProjeto```

9. Após isso, ainda dentro da pasta src, adicione seu projeto API à solução criada:

    ```dotnet sln add ./SeuProjeto.API/SeuProjeto.API.csproj```

10. Altere dentro do seu Dockerfile e docker-compose.yml onde estiver "template" para o nome do seu projeto;

11. Entre dentro da pasta da camada Api e execute os comandos `dotnet restore` e `dotnet build` para assegurar que tudo está funcionando normalmente;

12. Se tiver feito corretamente todos os passos anteriores, ao executar `dotnet run` seu Swagger estará disponível em http://localhost:5043;

13. Por fim, basta executar seu git init na pasta raíz e seguir com o código do seu novo projeto!

14. Caso tenha alguma sugestão de melhoria para o template, crie um PullRequest adicionando seus comentários na seção "🎈 Sugestões" deste arquivo README.md.

## ⚠️ Atualizações

De tempos em tempos tentarei atualizar a versão LTS do framework a fim de acompanhar a evolução da tecnologia, sempre mantendo o template utilizável.

## 🤔 Dúvidas Frequentes

- O arquivo .gitkeep presente em algumas pastas foi criado apenas para que o git considerasse a pasta para o commit. Assim que baixar o repositório pode apagar o arquivo sem problemas.

## 🎈 Sugestões

_Digite aqui suas possíveis sugestões para incrementos de melhorias no template._