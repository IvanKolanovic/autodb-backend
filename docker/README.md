# 🗃️ Restore `.bak` File into SQL Server 2022 (Docker on Mac M3)

This guide explains how to restore a `.bak` SQL Server database backup into a SQL Server 2022 instance running in Docker on a Mac (M3 chip).

---

## ✅ Prerequisites

- Docker is installed and running.
- You have a `.bak` file placed on your Mac (e.g. `/Users/navi/Desktop/test/data/master/vPICList_lite_2025_05.bak`).
- You are using a `docker-compose.yml` like this:

```yaml
version: "3.8"

services:
  mssql:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourStrong@Passw0rd
      - MSSQL_PID=Developer
    ports:
      - "1433:1433"
    volumes:
      - mssql-data:/var/opt/mssql
      - /Users/navi/Desktop/test/data/master:/var/opt/mssql/backup
    restart: unless-stopped

volumes:
  mssql-data:
```

```bash
docker exec -i docker-mssql-1 /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U sa -P 'YourStrong@Passw0rd' -C \
  -Q "RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/vPICList_lite_2025_05.bak';"
```

```bash
docker exec -i docker-mssql-1 /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U sa -P 'YourStrong@Passw0rd' -C \
  -Q "RESTORE DATABASE vPICList_Lite \
       FROM DISK = '/var/opt/mssql/backup/vPICList_lite_2025_05.bak' \
       WITH MOVE 'vPICList_Lite1' TO '/var/opt/mssql/data/vPICList_Lite1.mdf', \
            MOVE 'vPICList_Lite1_log' TO '/var/opt/mssql/data/vPICList_Lite1_log.ldf', \
            REPLACE;"
```
