# Integrador Middleware

Base para integradores API -> API em WinForms. Obtém dados de uma API de origem, transforma-os e envia-os para uma API de destino, sem acesso direto a bases de dados.

Já traz pronto:
- Configurações de origem e destino guardadas encriptadas (`config.config` ao lado do exe)
- Logs por etapa em JSON Lines, com ecrã de consulta e detalhe (payload formatado)
- Histórico de execuções e ecrã inicial com o estado das ligações
- Agendamento pelo Agendador de Tarefas do Windows (diário, semanal, mensal, 1º dia útil), com execução sem interface (`AUTO`)
- Adapter HTTP de exemplo (x-api-key + bearer com renovação, retry em 401, paginação por `next_token`)
- UI com janela Fluent, menu lateral, tema claro/escuro e cor de destaque configurável

## Stack
- .NET 10, WinForms
- DevExpress 25.2.3 (skin WXI)
- Microsoft.Extensions.Hosting (DI), Microsoft.Extensions.Http
- TaskScheduler, Nager.Date 1.x

## Estrutura
```
src/
  Integrador.Common/          Settings, Logging, Scheduling
  Modules/
    Integrador.Source/        Adapter da API de origem (exemplo)
    Integrador.Integration/   Orquestração origem -> destino, histórico
  Integrador.UI/              Host WinForms, composition root, ecrãs
```
Regras de arquitetura e de UI em [CLAUDE.md](CLAUDE.md).

## Começar um integrador novo
1. No GitHub, **Use this template** para criar o repositório do cliente.
2. Procurar `TODO:` na solução e resolver cada um (nome da app, chaves AES, campos de ligação, adapter de origem, implementação do `IntegrationRunner`).
3. Seguir a checklist "Novo integrador a partir do template" no [CLAUDE.md](CLAUDE.md).

Requer licença DevExpress WinForms 25.2 instalada na máquina de desenvolvimento.
