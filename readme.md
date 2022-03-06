# Testing remote dev for dotnet and react project

## preparations
Ensure you have the dotnet-ef tools installed:
dotnet tool install --global dotnet-ef

If the command doesn't run in your app app:
export PATH="$PATH:$HOME/.dotnet/tools/"

After changing any entities/models:
dotnet ef migrations add <migration name>

To effect the update with the migration:
dotnet ef database update