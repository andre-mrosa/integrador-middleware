# Integrador Middleware (template)

WinForms .NET 10 + DevExpress 25.2.3. Middleware entre APIs (origem -> destino), sem acesso direto a base de dados.
Modular monolith pragmático. Clean architecture só onde há fronteira real.

Template: cada integrador novo nasce daqui ("Use this template" no GitHub). Os pontos a mudar estão marcados com `// TODO:`.

## Estrutura
```
src/
  Integrador.Common/            Técnico e partilhado (não é negócio)
    Settings/                   ISettingsService (config.config AES ao lado do exe)
    Logging/                    IIntegrationLogger, ILogQueryService (Logs/yyyy-MM-dd.log, JSON Lines, retenção 90 dias)
    Scheduling/                 ISchedulerService. Portado de C:\Mine\.Net Schedulers (andre-mrosa/dotnet-schedulers). Correções fazer lá e trazer.
  Modules/
    Integrador.Source/          Adapter da API de origem (exemplo: REST com x-api-key + bearer, paginação next_token)
      Contracts/                Único código público (ISourceApiClient, respostas base)
      Auth/ Http/               internal. Token, handler x-api-key + bearer, cliente HTTP
    Integrador.Integration/     Caso de uso origem -> destino
      Contracts/                IIntegrationRunner
      Application/              internal. Orquestração
  Integrador.UI/                Host WinForms e composition root (DI via Microsoft.Extensions.Hosting)
    AppInfo.cs                  Nome da app, nomes de origem/destino, cor de destaque
    Configuration/AppTheme.cs   Skin WXI, tema claro/escuro, estilo comum das grelhas
    MainForm                    FluentDesignForm + AccordionControl (menu lateral). Páginas criadas uma vez e mantidas
    UserControls/               Início (cartões HTML + histórico), Configurações (origem + destino), Logs, Agendamento
    Forms/                      LogDetailForm (duplo clique nas logs)
```

## Regras
- Cada módulo expõe só `Contracts/` e um `XModule.AddXModule()`. Tudo o resto é `internal`.
- Módulos só falam entre si por `Contracts`. A UI só usa `Contracts` e `Integrador.Common`.
- Criar camadas/projetos novos apenas quando houver necessidade real. Nada de pastas vazias.
- Configurações do destino (URL, utilizador, password) já existem em `IntegratorSettings`. O módulo do destino (adapter igual ao da origem) cria-se quando se souber a API a usar, com `Contracts/` consumidos pelo Integration.
- Sem base de dados. Estado local (ex: registos já integrados) em ficheiro ao lado do exe, se for preciso.
- Modelos de domínio da integração (mapeamento origem -> destino) ficam em `Integrador.Integration/Domain`.
- Páginas que dependem do resultado da integração implementam `IRefreshable`. O MainForm atualiza-as no fim de cada execução.
- Histórico de execuções em `History/runs.log` (IIntegrationRunHistory, módulo Integration).
- UI sempre no designer (`*.Designer.cs`). User controls recebem dependências no construtor e são resolvidos pelo DI (`MainForm.ShowPage<T>`).
- Aspeto: skin WXI fixo (sem escolha de skins), tema claro/escuro na barra de título, cor de destaque em `AppInfo.AccentColor`.
- Cada página segue o mesmo padrão: título (Segoe UI Semibold 15.75) + subtítulo (DisabledText) + botões à direita, um único botão principal (`DXSkinColors.FillColors.Primary`, sem ícone). Secções em `LayoutControlGroup` com `GroupStyle.Card` e labels em cima.
- Grelhas só de leitura chamam `AppTheme.ApplyListStyle` no construtor. Estados com cor só na célula (`RowCellStyle`), não na linha toda.
- Cartões do Início são um `HtmlContentControl` (template/CSS no resx). Cores do tema no CSS (`@Success`, `@Warning`, `@Danger`); classes dinâmicas aplicadas por código (`FindElementById`), o binding `${}` não funciona em `class`.
- Logs em todas as etapas via `IIntegrationLogger`, com payload quando houver dados da API.
- Versões de pacotes só em `Directory.Packages.props`. Nager.Date fica na 1.x (2.x exige licença).

## Adapter de exemplo (Integrador.Source)
- Header `x-api-key` em todos os pedidos. `POST /login` {email, password} devolve `token` (12h) para `Authorization: Bearer`.
- `SourceTokenProvider` renova perto das 12h. `SourceAuthHandler` renova e repete 1 vez em 401. Token invalidado ao guardar configurações.
- Paginação por `next_token` (`GetAllPagesAsync`). JSON em snake_case (`SourceJson`).
- Se a API real autenticar de outra forma, adaptar `Auth/` e manter o resto (retry em 401, logs com payload).

## Novo integrador a partir do template
1. Procurar `TODO:` na solução e resolver cada um.
2. `AppInfo` (nome, pasta de preferências, nomes de origem/destino, cor), `AssemblyName` no `Integrador.UI.csproj` e `Product` no `Directory.Build.props`.
3. Chaves AES próprias em `EncryptedSettingsService` (16 caracteres cada).
4. Campos de ligação em `IntegratorSettings` e no ecrã Configurações (labels, campos a mais ou a menos).
5. Renomear `Integrador.Source` para o sistema real (ex: `Integrador.Crm`) ou apagar o exemplo se a API não servir. Criar o módulo do destino quando houver API.
6. Implementar `IntegrationRunner.RunAsync` (obter da origem, mapear em `Domain/`, enviar para o destino).
7. Atualizar este ficheiro: tirar esta secção, acrescentar a secção da API real e os próximos passos do orçamento.
