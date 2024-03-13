namespace api.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id", CompanyId="company_id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }

        public static class FileLocations
        {
            public const string rootFolder= "uploads";
            public const string rootBrandingMultimediaFolder= "brands";
            public const string rootCatalogMultimediaFolder = "catalogs";
            public const string rootCatalogItemMultimediaFolder = "catalogItems";
            public const string rootMaterialsMultimediaFolder = "materials";
            public const string rootProfileMultimediaFolder = "profiles";
            public const string rootURL= "static";
            public const string rootFolderMultimedia = "multimedia";
        }
    }
}
