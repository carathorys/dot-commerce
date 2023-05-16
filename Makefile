mc:
	dotnet ef migrations add ${MIGRATION_NAME} --project src/FuryTechs.DotCommerce.WebAPI --context WebDbContext

rm:
	dotnet ef migrations remove --project src/FuryTechs.DotCommerce.WebAPI --context WebDbContext

up:
	dotnet ef database update --project src/FuryTechs.DotCommerce.WebAPI --context WebDbContext
