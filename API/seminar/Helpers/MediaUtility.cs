using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using api.Options;
using api.Helpers;

namespace api.Options
{
    /// <summary>
    /// 
    /// </summary>
    public static class MediaUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativePath">
        /// 
        /// </param>
        /// <param name="options">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static string ConstructUrl(string relativePath, UrlsOptions options)
        {
            if (relativePath == null || options?.BaseUrl == null)
            {
                return null;
            }

            if (relativePath.Contains("\\"))
            {
                relativePath = relativePath.Replace("\\", "/");
            }

            if (options.BaseUrl.EndsWith("/"))
            {
                options.BaseUrl = options.BaseUrl.Remove(options.BaseUrl.LastIndexOf("/"), 1);
            }

            return $"{options.BaseUrl}/{Constants.FileLocations.rootURL}/{relativePath}";

        }

        public static string ConstructNewUrl(string relativePath, UrlsOptions options)
        {
            if (relativePath == null || options?.BaseUrl == null)
            {
                return null;
            }

            if (relativePath.Contains("\\"))
            {
                relativePath = relativePath.Replace("\\", "/");
            }

            if (options.BaseUrl.EndsWith("/"))
            {
                options.BaseUrl = options.BaseUrl.Remove(options.BaseUrl.LastIndexOf("/"), 1);
            }

            return $"{options.BaseUrl}/{relativePath}";
        }

        public static string ConstructNewRelativUrl(string relativePath, UrlsOptions options)
        {
            if (relativePath == null || options?.BaseUrl == null)
            {
                return null;
            }

            if (relativePath.Contains("\\"))
            {
                relativePath = relativePath.Replace("\\", "/");
            }

            if (options.BaseUrl.EndsWith("/"))
            {
                options.BaseUrl = options.BaseUrl.Remove(options.BaseUrl.LastIndexOf("/"), 1);
            }

            return $"{relativePath}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static string ConstructFileName(IFormFile file)
        {
            if (file == null)
            {
                throw new InvalidOperationException($"{nameof(file)} is null.");
            }

            // case where whitespace is inside a name of file, replace it.
            var clean = file.FileName.Replace(" ", "_");

            return $"{Path.GetFileNameWithoutExtension(clean)}{Path.GetExtension(clean)}";
        }
    }
}
