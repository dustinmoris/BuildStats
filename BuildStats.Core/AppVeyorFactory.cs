using System.Web.Configuration;

namespace BuildStats.Core
{
    public sealed class AppVeyorFactory : BuildSystemFactory
    {
        public override string CreateBuildHistoryApiUrlFormat()
        {
            return WebConfigurationManager.AppSettings["AppVeyor_API_BuildHistory_URL_Format"];
        }

        public override IBuildHistoryParser CreateBuildHistoryParser()
        {
            return new AppVeyorBuildHistoryParser(CreateSerializer());
        }

        public override IBuildHistoryClient CreateBuildHistoryClient()
        {
            return new AppVeyorBuildHistoryClient(
                CreateRestfulApiClient(),
                CreateBuildHistoryParser(),
                CreateBuildHistoryApiUrlFormat());
        }
    }
}