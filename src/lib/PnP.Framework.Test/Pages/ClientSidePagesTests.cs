﻿/*
using System;
using Microsoft.SharePoint.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PnP.Framework.Entities;
using System.Linq;
using PnP.Framework.Provisioning.ObjectHandlers;
using PnP.Framework.Provisioning.Model;
using PnP.Framework.Provisioning.Connectors;
using PnP.Framework.Provisioning.Providers.Xml;
using System.Threading.Tasks;
using System.Globalization;
using PnP.Framework.Pages;
using Microsoft.SharePoint.Client.Taxonomy;

namespace PnP.Framework.Test.Authentication
{
    [TestClass]
    public class ClientSidePagesTests
    {

#region Test initialization
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //using (var clientContext = TestCommon.CreateClientContext())
            //{
                
            //}
        }
        #endregion

        //[TestMethod]
        //public void ExportPagesTest()
        //{
        //    using (var clientContext = TestCommon.CreateClientContext("https://bertonline.sharepoint.com/sites/KnowledgeCenter"))
        //    {
        //        ProvisioningTemplateCreationInformation ptci = new ProvisioningTemplateCreationInformation(clientContext.Web)
        //        {
        //            // Limit the amount of handlers in this demo
        //            HandlersToProcess = Handlers.PageContents,
        //            // Create FileSystemConnector, so that we can store composed files temporarely somewhere 
        //            FileConnector = new FileSystemConnector(@"d:\temp\topicpages", ""),
        //            PersistBrandingFiles = true,
        //            IncludeAllClientSidePages = true,
        //            ProgressDelegate = delegate (String message, Int32 progress, Int32 total)
        //            {
        //                // Only to output progress for console UI
        //                Console.WriteLine("{0:00}/{1:00} - {2}", progress, total, message);
        //            }
        //        };

        //        // Execute actual extraction of the tepmplate
        //        ProvisioningTemplate template = clientContext.Web.GetProvisioningTemplate(ptci);

        //        // Serialize to XML using the beta 201705 schema
        //        XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(@"d:\temp\topicpages", "");
        //        var formatter = XMLPnPSchemaFormatter.GetSpecificFormatter(XMLConstants.PROVISIONING_SCHEMA_NAMESPACE_2020_02);
        //        provider.SaveAs(template, "PnPProvisioningDemo202002.xml", formatter);
        //    }
        //}

        //[TestMethod]
        //public void ApplyPagesTest()
        //{
        //    using (var clientContext = TestCommon.CreateClientContext("https://bertonline.sharepoint.com/sites/KnowledgeCenter"))
        //    {
        //        ProvisioningTemplateApplyingInformation ptai = new ProvisioningTemplateApplyingInformation()
        //        {
        //            //HandlersToProcess = Handlers.PageContents,
        //            ProgressDelegate = delegate (String message, Int32 progress, Int32 total)
        //            {
        //                // Only to output progress for console UI
        //                Console.WriteLine("{0:00}/{1:00} - {2}", progress, total, message);
        //            }
        //        };

        //        XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(@"d:\temp\topicpages", "");
        //        ProvisioningTemplate sourceTemplate = provider.GetTemplate("PnPProvisioningDemo202002.xml");
        //        sourceTemplate.Connector = new FileSystemConnector(@"d:\temp\topicpages", "");

        //        // Execute actual extraction of the tepmplate
        //        clientContext.Web.ApplyProvisioningTemplate(sourceTemplate);
        //    }
        //}

        [TestMethod]
        public void MUITest()
        {
            //using (var cc = new AuthenticationManager().GetWebLoginClientContext("https://contoso.sharepoint.com/teams/TEST_Provisioning"))
            using (var cc = TestCommon.CreateClientContext("https://bertonline.sharepoint.com/sites/prov-1"))
            {
                var list = cc.Web.GetListByTitle("FieldTypes");
                var item = list.GetItemById(1);
                cc.Load(item);
                cc.ExecuteQueryRetry();

                //item["Url"] = new FieldUrlValue() { Url = "", Description = "" }; 

                //item["PersonSingle"] = new FieldUserValue() { LookupId = 0 };
                item["PersonSingle"] = null;
                //item["PersonMultiple"] = new List<FieldUserValue>().ToArray();

                //item["Url"] = new FieldUrlValue() { Url = "https://bla1", Description = "fdmslkfqmsl" };

                //item["PersonSingle"] = new FieldUserValue() { LookupId = 6};

                //item["ChoiceSingle"] = "Choice 1";

                //item["ChoiceMultiple"] = new List<string>() { "Choice 1", "Choice 4" }.ToArray();

                //item["PersonSingle"] = new FieldUserValue() { LookupId = 15 };

                //var personMultiple = new List<FieldUserValue>
                //{
                //    new FieldUserValue() { LookupId = 15 },
                //    new FieldUserValue() { LookupId = 6 }
                //};

                //item["PersonMultiple"] = personMultiple.ToArray();

                TaxonomyFieldValue mbiTermValue = new TaxonomyFieldValue
                {
                    Label = "MBI",
                    TermGuid = "1824510b-00e1-40ac-8294-528b1c9421e0",
                    WssId = 2
                };

                TaxonomyFieldValue lbiTermValue = new TaxonomyFieldValue
                {
                    Label = "LBI",
                    TermGuid = "ed5449ec-4a4f-4102-8f07-5a207c438571",
                    WssId = 1
                };

                //var field = list.Fields.GetByInternalNameOrTitle("MMMultiple");
                //cc.Load(field);
                //cc.ExecuteQueryRetry();


                //item["MMSingle"] = mbiTermValue;

                //TaxonomyFieldValueCollection termCollection = new TaxonomyFieldValueCollection(cc, null, field);
                //termCollection.PopulateFromLabelGuidPairs("MBI|1824510b-00e1-40ac-8294-528b1c9421e0;LBI|ed5449ec-4a4f-4102-8f07-5a207c438571");

                //item["MMMultiple"] = termCollection;


                item.UpdateOverwriteVersion();
                cc.ExecuteQueryRetry();
            }
        }

        //[TestMethod]
        //public void BertTest5()
        //{
        //    using (var cc = TestCommon.CreateClientContext("https://bertonline.sharepoint.com/sites/blabla"))
        //    {
        // var page = cc.Web.LoadClientSidePage("vertical-section.aspx");
        //        //page.Save("home2_normal.aspx");

        //        var newPage = new Pages.ClientSidePage(cc);
        //        newPage.AddSection(CanvasSectionTemplate.TwoColumnVerticalSection, 1);

        //        newPage.Sections[0].Columns[0].VerticalSectionEmphasis = 2;
        //        newPage.Sections[0].VerticalSectionColumn.VerticalSectionEmphasis = 2;
        //        newPage.Sections[0].ZoneEmphasis = 3;

        //        var t1 = new ClientSideText()
        //        {
        //            Text = "AA"
        //        };
        //        var t2 = new ClientSideText()
        //        {
        //            Text = "BB"
        //        };
        //        var t3 = new ClientSideText()
        //        {
        //            Text = "CC"
        //        };
        //        var t4 = new ClientSideText()
        //        {
        //            Text = "DD"
        //        };
        //        var t5 = new ClientSideText()
        //        {
        //            Text = "EE"
        //        };
        //        var t6 = new ClientSideText()
        //        {
        //            Text = "FF"
        //        };

        //        newPage.AddControl(t1, newPage.Sections[0].Columns[0]);
        //        newPage.AddControl(t2, newPage.Sections[0].Columns[0]);
        //        newPage.AddControl(t3, newPage.Sections[0].Columns[1]);
        //        newPage.AddControl(t4, newPage.Sections[0].Columns[2]);
        //        newPage.AddControl(t5, newPage.Sections[0].Columns[2]);
        //        newPage.AddControl(t6, newPage.Sections[0].Columns[2]);

        //        newPage.AddSection(CanvasSectionTemplate.ThreeColumn, 2);
        //        var t7 = new ClientSideText()
        //        {
        //            Text = "DD"
        //        };
        //        var t8 = new ClientSideText()
        //        {
        //            Text = "EE"
        //        };
        //        var t9 = new ClientSideText()
        //        {
        //            Text = "FF"
        //        };

        //        newPage.AddControl(t7, newPage.Sections[1].Columns[0]);
        //        newPage.AddControl(t9, newPage.Sections[1].Columns[2]);

        //        newPage.Sections[1].ZoneEmphasis = 1;

        //        newPage.AddSection(CanvasSectionTemplate.TwoColumnLeft, 3);
        //        newPage.AddControl(t8, newPage.Sections[2].Columns[0]);

        //        newPage.Save("verticalsectiontest1.aspx");
        //    }
        //}


        //[TestMethod]
        //public void BertTest4()
        //{
        //    using (var cc = TestCommon.CreateClientContext("https://bertonline.sharepoint.com/sites/bert1"))
        //    {
        //        var newPage = new Pages.ClientSidePage(cc);
        //        //newPage.AddZone(CanvasZoneTemplate.OneColumn, 1);

        //        var imageWebPart = newPage.InstantiateDefaultWebPart(DefaultClientSideWebParts.Image);
        //        imageWebPart.PropertiesJson = "{\"controlType\":3,\"displayMode\":2,\"id\":\"73f2310d-3d91-4458-b508-fbfb2fd0a524\",\"position\":{\"zoneIndex\":1,\"sectionIndex\":1,\"controlIndex\":1},\"webPartId\":\"d1d91016-032f-456d-98a4-721247c305e8\",\"webPartData\":{\"id\":\"d1d91016-032f-456d-98a4-721247c305e8\",\"instanceId\":\"73f2310d-3d91-4458-b508-fbfb2fd0a524\",\"title\":\"Image\",\"description\":\"Show an image on your page.\",\"serverProcessedContent\":{\"htmlStrings\":{},\"searchablePlainTexts\":{},\"imageSources\":{\"imageSource\":\"/sites/bert1/Images1/Gs9313d6d1-9a28-4ae0-86bc-16d9770cce7c.jpg\"},\"links\":{\"linkUrl\":\"\"}},\"dataVersion\":\"1.8\",\"properties\":{\"imageSourceType\":2,\"altText\":\"My black bike\",\"overlayText\":\"\",\"siteId\":\"78eaf8ed-fb6c-4bcb-a8ba-b4e251a90910\",\"webId\":\"ac56a969-5ca1-45fd-aca3-9ee5819e418f\",\"listId\":\"5d7a3301-0760-4472-97dd-af57f9cdd6f2\",\"uniqueId\":\"{37DE58D1-A666-4BC6-AB86-73A6792022EE}\",\"imgWidth\":960,\"imgHeight\":960,\"fixAspectRatio\":false}}}";
        //        newPage.AddControl(imageWebPart);


        //        //var t1 = new ClientSideText()
        //        //{
        //        //    Text = "This is some plain text :-) <BR><p>The HTML DOM has a property called textContent (this is TextContent in <b>AngleSharp</b>) for node objects. Usually if you use this on e.g. the document root (HTML) element it should give you the whole textual content.But beware - there might be an unusual amount of spaces and newlines in there, since those are not getting stripped out by the parser - that you do not see most of them in rendered content is a feature of the HTML renderer.</p>"
        //        //};
        //        var t2 = new ClientSideText()
        //        {
        //            Text = "this is a short text!!"
        //        };

        //        //newPage.AddControl(t1, 0);
        //        newPage.AddControl(t2, 1);
        //        //newPage.AddControl(t1, newPage.Zones[0].Sections[0], 2);
        //        //newPage.AddControl(t2, newPage.Zones[0].Sections[0], 1);

        //        //newPage.RemovePageHeader();
        //        //newPage.PageTitle = "no header page";
        //        //newPage.Save("B3.aspx");

        //        newPage.SetPageHeader("/sites/bert1/Images1/DE03E3D9-78DB-4EB2-A096-A9B3AA375217.jpg", "50", "90");
        //        newPage.PageTitle = "header image";
        //        newPage.Save("B11.aspx");
        //        newPage.Publish();

        //    }
        //}


        //[TestMethod]
        //public async Task GetAvailableClientSideComponentsTestAsync()
        //{
        //    using (var cc = TestCommon.CreateClientContext("https://bertonline.sharepoint.com/sites/bert1"))
        //    {
        //        var newPage = new Pages.ClientSidePage(cc);

        //        var components = await newPage.AvailableClientSideComponentsAsync("");

        //        Assert.IsTrue(components.Count() > 0);
        //    }
        //}

        #region Helper methods
        #endregion
    }
}
*/