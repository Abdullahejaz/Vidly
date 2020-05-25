using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using ExcelDataReader;
using LumenWorks.Framework.IO.Csv;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class ExcelFileUploadController : Controller
    {
        // GET: ExcelFileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                if(uploadFile != null && uploadFile.ContentLength > 0)
                {
                    //ExcelDataReader works on binary excel file
                    Stream stream = uploadFile.InputStream;

                    IExcelDataReader reader;

                    if (uploadFile.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (uploadFile.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    reader.Close();
                    return View(result.Tables[0]);
                }
            }


            else
            {
                ModelState.AddModelError("File", "Please upload your file");
            }
            return View();
        }


    }
}