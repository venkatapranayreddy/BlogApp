FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY *.csproj ./ 
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Create the /app/uploads directory
RUN mkdir -p /app/uploads

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# # Create the /app/uploads directory again in the final image
RUN mkdir -p /app/uploads


ENTRYPOINT [ "dotnet", "BlogApplication.dll" ]