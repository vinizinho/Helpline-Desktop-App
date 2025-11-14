#!/bin/bash

# Script para instalar o .NET SDK no macOS

echo "🔍 Verificando se o Homebrew está instalado..."

if ! command -v brew &> /dev/null; then
    echo "❌ Homebrew não encontrado!"
    echo "📦 Instalando Homebrew primeiro..."
    /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
else
    echo "✅ Homebrew encontrado!"
fi

echo ""
echo "📦 Instalando .NET SDK..."
brew install --cask dotnet-sdk

echo ""
echo "✅ Instalação concluída!"
echo ""
echo "🔄 Por favor, feche e reabra o terminal, depois execute:"
echo "   dotnet --version"
echo ""
echo "📝 Se ainda não funcionar, adicione ao seu ~/.zshrc:"
echo "   export PATH=\"/usr/local/share/dotnet:\$PATH\""
echo "   ou"
echo "   export PATH=\"/opt/homebrew/share/dotnet:\$PATH\""

