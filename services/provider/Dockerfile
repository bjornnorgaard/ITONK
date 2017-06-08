FROM microsoft/dotnet:1.1-sdk

WORKDIR /app/Provider
COPY ./Provider /app

ENV ASPNETCORE_URLS http://+:80
EXPOSE 80

RUN dotnet restore

ENTRYPOINT ["dotnet", "run"]
