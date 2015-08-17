using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System.Configuration;
using System.IO;

namespace DCC_PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        AlumniDBModel db = new AlumniDBModel();

        public ActionResult Index(List<ContactProfile> SearchResults)
        {
            List<ContactProfile> results = null;

            if (SearchResults != null)
            {
                results = SearchResults.ToList();
            }
            return View("Index", results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to the devCodeCamp Alumni Network.";



            var connectionString = @"DefaultEndpointsProtocol=https;AccountName=dccportfolio;AccountKey=/MxXUfGzY8W+e0GTYUTQtA4EnlfgaROeUhPipxRFew7ckKk5sXiHDmDZmIOd4AkZ6luZS994UXYaPeRKboHOaA==";
            var account = CloudStorageAccount.Parse(connectionString);
            
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("pictures");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            //blockBlob.UploadFromFile(imageUploader.PostedFile.FileName, FileMode.Open);

            return View();
        }

        [HttpPost]
        public ActionResult ImageUpload()
        {
            var image = Request.Files["image"];
            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                    image.FileName, image.ContentType, image.ContentLength);
                // TODO: actually save the image to Azure blob storage

                var connectionString = @"DefaultEndpointsProtocol=https;AccountName=dccportfolio;AccountKey=/MxXUfGzY8W+e0GTYUTQtA4EnlfgaROeUhPipxRFew7ckKk5sXiHDmDZmIOd4AkZ6luZS994UXYaPeRKboHOaA==";
                var account = CloudStorageAccount.Parse(connectionString);

                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                CloudBlobClient blobClient = account.CreateCloudBlobClient();

                // Retrieve a reference to a container.
                CloudBlobContainer container = blobClient.GetContainerReference("pictures");

                // Create the container if it doesn't already exist.
                container.CreateIfNotExists();
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

                string uniqueBlobName = string.Format("productimages/image_{0}{1}",
                Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = image.ContentType;
                blob.UploadFromStream(image.InputStream);
                blob.Uri.ToString();

                string connectionStringDB = "Server=tcp:wx9a1lruht.database.windows.net,1433;Database=DCCPortfolioSite_db;User ID=devcodecamp;Password=heliumdev1!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionStringDB))
                {
                      connection.Open();
                      SqlCommand cmd = new SqlCommand("UPDATE ContactProfile SET Photo= @Photo WHERE PrimaryEmail = @fNameUser");
                      cmd.CommandType = CommandType.Text;
                      cmd.Connection = connection;
                      cmd.Parameters.AddWithValue("@Photo", blob.Uri.ToString());
                      cmd.Parameters.AddWithValue("@fNameUser", User.Identity.Name);
                      cmd.ExecuteNonQuery();
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult ResumeUpload()
        {
            var image = Request.Files["image"];
            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
               

                var connectionString = @"DefaultEndpointsProtocol=https;AccountName=dccportfolio;AccountKey=/MxXUfGzY8W+e0GTYUTQtA4EnlfgaROeUhPipxRFew7ckKk5sXiHDmDZmIOd4AkZ6luZS994UXYaPeRKboHOaA==";
                var connectionString2 = ConfigurationManager.ConnectionStrings[3].ConnectionString;
                var account = CloudStorageAccount.Parse(connectionString2);

                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                CloudBlobClient blobClient = account.CreateCloudBlobClient();

                 //Retrieve a reference to a container.
                CloudBlobContainer container = blobClient.GetContainerReference("pictures");

                 //Create the container if it doesn't already exist.
                container.CreateIfNotExists();
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

                string uniqueBlobName = string.Format("productimages/image_{0}{1}",
                Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = image.ContentType;
                blob.UploadFromStream(image.InputStream);
                blob.Uri.ToString();

                string connectionStringDB = "Server=tcp:wx9a1lruht.database.windows.net,1433;Database=DCCPortfolioSite_db;User ID=devcodecamp;Password=heliumdev1!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionStringDB))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE UserResume SET HtmlUpload = @Resume WHERE ProfileId = 2");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@Resume", blob.Uri.ToString());


                    cmd.ExecuteNonQuery();
                }


            }
            return View("Index");
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Contact devCodeCamp at:";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Error";

            return View();
        }



        public ActionResult Search(string tb_SearchBox)
        {
            if (string.IsNullOrEmpty(tb_SearchBox))
            {
                tb_SearchBox = "";
            }
            var results = (from contact in db.ContactProfiles
                            where
                                contact.FirstName.Contains(tb_SearchBox)
                                || contact.LastName.Contains(tb_SearchBox)
                                || contact.AlternateEmail.Contains(tb_SearchBox)
                                || contact.PrimaryEmail.Contains(tb_SearchBox)
                                || contact.About.Contains(tb_SearchBox)
                                || contact.Country.Contains(tb_SearchBox)
                                || contact.USAState.Contains(tb_SearchBox)
                            select contact).ToList();
            
            return View("Index", results);
        }
    }
}