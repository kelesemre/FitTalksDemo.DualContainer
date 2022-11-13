# FitTalksDemo.DualContainer
Dual Container


```docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=StrongPass" -p 1455:1433 --name demo --hostname demo -d mcr.microsoft.com/mssql/server:2017-latest```

----------------------------------------------------------------------------------------------------------------------------------------------------------------

```docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d```

```docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build```

```docker-compose -f docker-compose.yml -f docker-compose.override.yml down```

