# Usa a última versão LTS do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Instala dependências para Playwright e interface gráfica
RUN apt-get update && apt-get install -y \
    xvfb \
    libnss3 \
    libatk1.0-0 \
    libatk-bridge2.0-0 \
    libcups2 \
    libxkbcommon-x11-0 \
    libxcomposite1 \
    libxdamage1 \
    libxrandr2 \
    libgbm1 \
    libasound2 \
    libpangocairo-1.0-0 \
    libpango-1.0-0 \
    libgdk-pixbuf2.0-0 \
    libgtk-3-0 \
    curl \
    unzip \
    && rm -rf /var/lib/apt/lists/*

# Instala Playwright CLI e adiciona ao PATH
RUN dotnet tool install --global Microsoft.Playwright.CLI \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && echo 'export PATH="$PATH:/root/.dotnet/tools"' >> ~/.bashrc

# Adiciona o caminho das ferramentas ao ambiente
ENV PATH="${PATH}:/root/.dotnet/tools"

# Define diretório de trabalho
WORKDIR /workspace

# Copia os arquivos da aplicação (se necessário)
COPY ../ .

# Expõe a porta (caso precise rodar um servidor)
EXPOSE 5000

# Comando padrão ao rodar o container
CMD ["bash"]