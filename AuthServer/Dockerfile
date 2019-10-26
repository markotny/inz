FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /vsdbg

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
            unzip \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sSL https://aka.ms/getvsdbgsh \
        | bash /dev/stdin -v latest -l /vsdbg

ENV DOTNET_USE_POLLING_FILE_WATCHER ${ENABLE_POLLING:-0}

WORKDIR /app

ENTRYPOINT dotnet ${ENABLE_POLLING:+watch} run --urls=http://+:80