using System;
using System.Web;

using CMS.DocumentEngine;

namespace MedioClinic.Utils
{
    public interface IFileManagementHelper
    {
        TreeNode GetPage(int pageId);

        string EnsureUploadDirectory(string directoryPath);

        bool CheckPagePermissions(TreeNode page);

        string GetTempFilePath(string directoryPath, string fileName);

        Guid AddUnsortedAttachment(TreeNode page, string uploadDirectory, HttpPostedFileWrapper file);
    }
}