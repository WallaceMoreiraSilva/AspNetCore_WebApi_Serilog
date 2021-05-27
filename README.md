# AspNetCore_WebApi_Serilog
AspNetCore + WebApi + Serilog

#Aplicação tem por objetivo criar registros de log: no console, em arquivo e em um banco de dados Sql Server

#Pacotes Nuget usados:
Serilog.AspNetCore
Serilog.Enrichers.Thread
Serilog.Enrichers.Environment
Serilog.Sinks.MSSqlServer
Serilog.Enrichers.Process

#Roteiro:

- Configurar o Serilog no arquivo Program.cs
- Criar no arquivo appsettings.json as definicoes para os logs desejados
- Invocar o metodo para criação do registro de log

#É fundamental criar o banco de dados com nome => SerilogDB , antes de executar a aplicação no swagger
create database SerilogDB

#Enrichers foram usados para enriquecer os eventos de registros (appsettings.json):
--Incluio nome da maquina
--Inclui o Id do processo
--Inclui o Id da Thread

Obs: Definimos o registro do log para o banco de dados Sql Server (appsettings.json)

obs: Definimos a string de conexao, o nome da tabela e o nivel minimo de registro (appsettings.json)

#Niveis de Log

- Verbose: Descreve informações detalhadas de debug e rastreamento

- Debug: Descreve informações de debug e fluxo da aplicação(eventos internos)

- nformation: Registra eventos de interesse e relevância (funções do sistema)

- Warning: Registra informações de possíveis problemas e comportamento inesperado

- Error: Registra informações de falhas de qualquer tipo; usado em exceções

- Fatal: Registra erros críticos que comprometam a aplicação de forma completa