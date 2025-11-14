# Comandos para Resolver o Erro

O erro menciona `net6.0-windows`, mas o arquivo já foi atualizado para `net9.0-windows`. Isso pode ser cache. Execute estes comandos **na ordem**:

## Passo 1: Verificar que está na pasta correta

```bash
cd /Users/vinicera/CURSOR/PIM4Ba
pwd
```

Deve mostrar: `/Users/vinicera/CURSOR/PIM4Ba`

## Passo 2: Verificar o conteúdo do arquivo .csproj

```bash
cat HelpDeskApp.csproj | grep TargetFramework
```

Deve mostrar: `<TargetFramework>net9.0-windows</TargetFramework>`

## Passo 3: Limpar cache e builds anteriores

```bash
# Limpar builds anteriores
dotnet clean

# Limpar cache do NuGet (opcional, mas ajuda)
dotnet nuget locals all --clear
```

## Passo 4: Atualizar workloads

```bash
dotnet workload update
```

Isso pode demorar alguns minutos na primeira vez.

## Passo 5: Restaurar pacotes

```bash
dotnet restore
```

## Passo 6: Compilar

```bash
dotnet build
```

## Se ainda der erro

### Verificar se há outro arquivo .csproj:

```bash
ls -la *.csproj
```

Se houver `HelpDeskApp_Framework.csproj`, você pode estar compilando o arquivo errado. Certifique-se de usar `HelpDeskApp.csproj`.

### Forçar rebuild completo:

```bash
# Deletar pastas de build
rm -rf bin obj

# Restaurar e compilar novamente
dotnet restore
dotnet build --no-incremental
```

## Comandos Resumidos (copie e cole tudo de uma vez)

```bash
cd /Users/vinicera/CURSOR/PIM4Ba
dotnet clean
dotnet workload update
dotnet restore
dotnet build
```

## O que Esperar

Após executar `dotnet build`, você deve ver:

```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

Se aparecer algum aviso sobre Windows Forms não poder executar no macOS, isso é normal - você só pode compilar, não executar.

