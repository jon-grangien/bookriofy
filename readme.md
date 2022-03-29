## What
Blazor wasm  
GraphQL  
EF Core  
...

## With
```bash
dotnet --version
6.0.201
```

## How
```bash
cd Api

# init
dotnet build
dotnet ef database update

# run
dotnet watch run 
```

```bash
cd Bookriofy
npm install
npm run tailwind # tailwind watch build process

# separate process
dotnet watch --project . # https://github.com/dotnet/aspnetcore/issues/38036#issuecomment-950749664
```

Graphql server: http://localhost:5001/graphql  
Blazor app: http://localhost:5000  

### Commands
Client: Regenerate graphql schema
```bash
dotnet graphql update
```

Client: Generate minified tailwind for deploy
```bash
cd Bookriofy
npm run tailwind-build-prod
```

Server: New migration
```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Troubleshooting
<b>VS Code doesn't recognize GraphQl context at all and shows red everywhere </b>  
Make sure schema is regenerated and any new query/mutation created in client has corresponding resolver in Api.  
If true, restart VS Code  