using Microsoft.SharePoint.Client;
using PnP.Framework.Attributes;
using System;
using System.Text.RegularExpressions;

namespace PnP.Framework.Provisioning.ObjectHandlers.TokenDefinitions
{
    [TokenDefinitionDescription(
        Token = "{apppackageid:[packagename]}",
        Description = "Returns the ID of an app package given its name",
        Example = "{apppackageid:MyPackageName}",
        Returns = "55898e77-a7bf-4799-8034-506db5521b98")]
    internal class AppPackageIdToken : TokenDefinition
    {
        private readonly string _appPackageId = null;

        public AppPackageIdToken(Web web, string name, Guid appPackageId)
            : base(web, $"{{apppackageid:{Regex.Escape(name)}}}")
        {
            _appPackageId = appPackageId.ToString();
        }

        public override string GetReplaceValue()
        {
            if (string.IsNullOrEmpty(CacheValue))
            {
                CacheValue = _appPackageId;
            }
            return CacheValue;
        }
    }
}