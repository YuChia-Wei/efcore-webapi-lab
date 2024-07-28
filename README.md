# dotnet 8 with Ef Core

**this version is not tested!**

> 全文參考以下兩個網址
> * https://blog.jetbrains.com/dotnet/2017/08/09/running-entity-framework-core-commands-rider/
> * https://docs.microsoft.com/zh-tw/ef/core/cli/dotnet

IDE : Rider

## 檢查 EF Core 所需工具

* 開啟 Terminal 輸入以下命令確認 EF Core 所需工具是否已安裝

    ```cl
    dotnet ef
    ```

* 如果還沒安裝，使用以下指令安裝

    ```cl
    dotnet tool install --global dotnet-ef
    ```

## 檢查專案是否已安裝以下套件

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Abstractions
* Microsoft.EntityFrameworkCore.Relational
* Microsoft.EntityFrameworkCore.Tools

以下套件依據使用的 Sql Server 進行安裝

* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.EntityFrameworkCore.InMemory

EF Core 設計相關套件

* Microsoft.EntityFrameworkCore.Design

## 範例專案結構

![](https://i.imgur.com/Jb8VaAW.png)

## DB First

準備一個測試用結構

![](https://i.imgur.com/tHxKajW.png)

下指令以依據 Db 結構產生內容

```cl
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=EFCoreSample;Persist Security Info=False;User ID=SA;Password=<YourStrong@Passw0rd>;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False" Microsoft.EntityFrameworkCore.SqlServer -c DbFirstContext
```

結果

![](https://i.imgur.com/rXb38yn.png)

> 命令列的部分可以 [官方文件](https://docs.microsoft.com/zh-tw/ef/core/cli/dotnet) 去尋找參數

## 補充 - Db 建置 - 使用 docker 架設 MS SqlServer 2019

參考資料：https://docs.microsoft.com/zh-tw/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-powershell

* 準備最新版 MS Sql Server 2019 Image

    ```cli
    docker pull mcr.microsoft.com/mssql/server:2019-latest
    ```

* 執行 SqlServer

    ```cl
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql1 -h sql1 -d mcr.microsoft.com/mssql/server:2019-latest
    ```

完成以上兩個步驟就已經完成在 docker 上建置 sql server 2019，可用 localhost:1433 去測試 sql server 是否可以連線

> Host：localhost
>
> Port：1433
>
> 帳號：SA
>
> 密碼：\<YourStrong@Passw0rd\>
