using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace chartDemo
{
    public partial class CAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // ViewDWG viewDwg = new ViewDWG();
           // PictureBox1.Image = viewDwg.GetDwgImage("d:\\s.dwg");
            Process p = new Process();
           // ProcessStartInfo =

           // p.StartInfo = new System.Diagnostics.ProcessStartInfo(@".OpenGLExtendedViewExample.exe", "new");

           // p.Start();
        }
        private class ViewDWG
        {
            private struct BITMAPFILEHEADER
            {
                public short bfType;
                public int bfSize;
                public short bfReserved1;
                public short bfReserved2;
                public int bfOffBits;
            }
            public System.Drawing.Image GetDwgImage(string FileName)
            {
                if (!(File.Exists(FileName)))
                {
                    throw new FileNotFoundException("the file didn't find");
                }
                //declare a filestream to read the DWG file
                FileStream DwgF = null;
                //the position of file description block
                int PosSentinel = 0;
                //Binary Reader
                BinaryReader br = null;
                //the thumbnail farmat
                int TypePreview = 0;
                //the thumbnail postion
                int PosBMP = 0;
                //the thumbnail size
                int LenBMP = 0;
                //the thumbnail depth
                short biBitCount = 0;
                //BMP file header，because DWG doesn't include the header，we need add it by ourself
                BITMAPFILEHEADER biH = default(BITMAPFILEHEADER);
                //BMP file body in the DWG file
                byte[] BMPInfo = null;
                //to store the memory stream
                MemoryStream BMPF = new MemoryStream();
                //Binary Writer
                BinaryWriter bmpr = new BinaryWriter(BMPF);
                System.Drawing.Image myImg = null;

                try
                {
                    //DWG file stream
                    DwgF = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(DwgF);
                    //read from the thirteenth byte
                    DwgF.Seek(13, SeekOrigin.Begin);
                    //read the thumbnail description block position
                    PosSentinel = br.ReadInt32();
                    //read from the thirty-first byte of the thumbnail description block
                    DwgF.Seek(PosSentinel + 30, SeekOrigin.Begin);
                    //the thirty-first byte represent the thumbnail picture format, 2 means BMP, 3 means WMF
                    TypePreview = br.ReadByte();

                    if (TypePreview == 1)
                    {
                    }
                    else if (TypePreview == 2 || TypePreview == 3)
                    {
                        //the BMP block postion saved by DWG file
                        PosBMP = br.ReadInt32();
                        //the BMP block size
                        LenBMP = br.ReadInt32();
                        //move to the BMP block
                        DwgF.Seek(PosBMP + 14, SeekOrigin.Begin);
                        //read the btye depth
                        biBitCount = br.ReadInt16();
                        //read all BMP content
                        DwgF.Seek(PosBMP, SeekOrigin.Begin);
                        //the BMP with no header
                        BMPInfo = br.ReadBytes(LenBMP);
                        br.Close();
                        DwgF.Close();
                        biH.bfType = 19778;
                        //build the header
                        if (biBitCount < 9)
                        {
                            biH.bfSize = 54 + 4 * Convert.ToInt32(Math.Truncate(Math.Pow(2, biBitCount))) + LenBMP;
                        }
                        else
                        {
                            biH.bfSize = 54 + LenBMP;
                        }
                        //reserved byte
                        biH.bfReserved1 = 0;
                        //reserved byte
                        biH.bfReserved2 = 0;
                        //BMP data offset
                        //write BMP header
                        biH.bfOffBits = 14 + 40 + 1024;
                        //file type
                        bmpr.Write(biH.bfType);
                        //file size
                        bmpr.Write(biH.bfSize);
                        //0
                        bmpr.Write(biH.bfReserved1);
                        //0
                        bmpr.Write(biH.bfReserved2);
                        //offset
                        bmpr.Write(biH.bfOffBits);
                        //write BMP file
                        bmpr.Write(BMPInfo);
                        //move the pointer to the beginning
                        BMPF.Seek(0, SeekOrigin.Begin);
                        //create the BMP file
                        myImg = System.Drawing.Image.FromStream(BMPF);// Image.FromStream(BMPF);
                        bmpr.Close();
                        BMPF.Close();
                    }
                    return myImg;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}