FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY ./bin/Debug/net6.0/ref .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
