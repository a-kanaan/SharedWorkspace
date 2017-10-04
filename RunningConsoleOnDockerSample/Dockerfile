FROM microsoft/dotnet:1.1.2-runtime

WORKDIR /app
COPY /bin/Debug/netcoreapp1.1/publish/ .

ENTRYPOINT ["dotnet", "RunningConsoleOnDockerSample.dll"]