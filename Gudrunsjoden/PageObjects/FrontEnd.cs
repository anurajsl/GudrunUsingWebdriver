using System;
using System.Net;



namespace Gudrunsjoden.PageObjects
{
    public class FrontEnd
    {
        //assign sce as editor
        public string ManageEditorsTab = "aManageEditor";
        public string EditorSearchBox = "searchAssociateEditor";
        public string AssignSceAsEditorLink = "//a[@id='assignSCEAsEditor']";
        public string AssignSceAsEditorButton = "//div[@class='modal-footer']/div/button[@class='btn btn-blue pull-right']";
        public string PopupOkbutton = "//button[@class='btn btn-blue pull-right']";
        public string EditorsNameLinkInGridListing = "aLinkToProfile";//manage editors tab
        public string ChangedAeInGridListing = "//div[@id='detailAssociateEditor']/div/div[2]/h5/a";
        public string HistoryTab = "aHistory";
        public string ArticleHistory = "divArticleHistory";


        #region ProductDetailPage

        public string HeaderTitleSection = "//section[@data-sectionid='140']";
        public string SKUNoSection = "//section[@data-sectionid='141']";
        public string ProductPrizeSection = "//section[@data-sectionid='142']";
        public string ProductDescriptionSection = "//section[@data-sectionid='143']";
        public string AddToBasketSection = "//section[@data-sectionid='144']";
        public string ProductDetailAttributesSection = "//section[@data-sectionid='145']";
        public string RequestFormLinkSection = "//section[@data-sectionid='146']";
        public string QuickSearchBoxSections = "//section[@data-sectionid='147']";
        public string ProductDocumentSection = "//section[@data-sectionid='148']";
        public string CategoriesSection = "//section[@data-sectionid='149']";
        public string InformationTabSection = "//section[@data-sectionid='150']";

        public string HeaderTitleSectionNotForDesktop = "//section[@data-sectionid='162']";
        public string HeaderTitleSectionForTG1 = "//section[@data-sectionid='163']";
        public string XpathLocatorForAddClassName = "//section[@class='section section_ProductDetail_Header section_163 ";


        #endregion

        #region VirtualProductDetailPage

        public string VP_ImageSection = "//section[@data-sectionid='180']";
        public string VP_HeaderTitleSection = "//section[@data-sectionid='191']";
        public string VP_SKUNoSection = "//section[@data-sectionid='181']";
        public string VP_ProductPrizeSection = "//section[@data-sectionid='193']";
        public string VP_ProductDescriptionSection = "//section[@data-sectionid='184']";
        public string VP_AddToBasketSection = "//section[@data-sectionid='186']";
        public string VP_ProductDetailAttributesSection = "//section[@data-sectionid='190']";
        public string VP_RequestFormLinkSection = "//section[@data-sectionid='188']";
        public string VP_QuickSearchBoxSections = "//section[@data-sectionid='147']";
        public string VP_ProductDocumentSection = "//section[@data-sectionid='148']";
        public string VP_CategoriesSection = "//section[@data-sectionid='149']";
        public string VP_InformationTabSection = "//section[@data-sectionid='182']";
        public string VP_ProductRelationSection = "//section[@data-sectionid='185']";
        public string VP_ProductsListFilter = "//section[@data-sectionid='189']";

        public string VP_HeaderTitleSectionNotForDesktop = "//section[@data-sectionid='192']";
        public string VP_HeaderTitleSectionForTG1 = "//section[@data-sectionid='52']";
        public string VP_XpathLocatorForAddClassName = "//section[@class='section section_ProductDetail_Header section_163 ";


        #endregion

    }
}
