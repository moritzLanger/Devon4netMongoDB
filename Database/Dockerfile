FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y

ENV SA_PASSWORD=C@pgemini2017

ENV MSSQL_TCP_PORT=1433

ENV MSSQL_PID=Developer

WORKDIR /src

COPY Schema.sql ./Schema.sql

USER mssql
RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1,1433 -U sa -P C@pgemini2017 -i Schema.sql \
    && pkill sqlservr

EXPOSE 1433

