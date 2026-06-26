FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

COPY *.slnx ./*/*.csproj *.props .
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done;

RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "FeedbackForms.WebApi.dll"]
