﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PnP.Framework.Tests.Framework.Functional.Implementation;

namespace PnP.Framework.Tests.Framework.Functional
{
    /// <summary>
    /// Test cases for the provisioning engine search settings functionality
    /// </summary>
    [TestClass]
    public class SearchSettingTests : FunctionalTestBase
    {
        #region Construction
        public SearchSettingTests()
        {
            //debugMode = true;
            //centralSiteCollectionUrl = "https://bertonline.sharepoint.com/sites/TestPnPSC_12345_83c723ec-8bf4-4659-a281-a3ce56fdcb51";
            //centralSubSiteUrl = "https://bertonline.sharepoint.com/sites/TestPnPSC_12345_83c723ec-8bf4-4659-a281-a3ce56fdcb51/sub";
        }
        #endregion

        #region Test setup
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            ClassInitBase(context);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            ClassCleanupBase();
        }

        [TestInitialize()]
        public override void Initialize()
        {
            base.Initialize();

            if (TestCommon.AppOnlyTesting())
            {
                Assert.Inconclusive("Test that require search settings are not supported in app-only.");
            }
        }
        #endregion

        #region Site collection test cases
        /// <summary>
        /// Site Search Settings Test
        /// </summary>
        [TestMethod]
        [Timeout(15 * 60 * 1000)]
        public void SiteCollection1605SearchSettingsTest()
        {
            new SearchSettingsImplementation().SiteCollection1605SearchSettings(centralSiteCollectionUrl);
        }
        #endregion

        #region Web test cases
        /// <summary>
        /// Web Search Settings test
        /// </summary>
        [TestMethod]
        [Timeout(15 * 60 * 1000)]
        public void Web1605SearchSettingsTest()
        {
            new SearchSettingsImplementation().Web1605SearchSettings(centralSubSiteUrl);
        }
        #endregion
    }
}