# deploy
dotnet build -c Debug ./Application.Server/Application.Server.sln

# publish
dotnet publish ./Application.Server -c Debug -o ./build/out --no-build

# docker build
cd ./build/out
docker build . -t chatappserver:1.0