using Microsoft.AspNetCore.Razor.TagHelpers;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.IO;
using System;

namespace ASPNET_Seguridad.TagHelpers
{
    [HtmlTargetElement("qr", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CodigoQrTag : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string contenido = context.AllAttributes["contenido"].Value.ToString();
            int ancho = int.Parse(context.AllAttributes["ancho"].Value.ToString());
            int alto = int.Parse(context.AllAttributes["alto"].Value.ToString());
            ZXing.BarcodeWriterPixelData bcpd = new ZXing.BarcodeWriterPixelData { 
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions { 
                    Width = ancho,
                    Height = alto,
                    Margin = 0
                }
            };
            var pixel_data = bcpd.Write(contenido);
            using (var bitmap = new Bitmap(pixel_data.Width, pixel_data.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppRgb)) {
                using (MemoryStream ms = new MemoryStream()) {
                    var contenidoBitmap = bitmap.LockBits(
                        new Rectangle(0,0,pixel_data.Width, pixel_data.Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format32bppRgb
                    );
                    try
                    {
                        //A continuación ponemos los pixeles de pixel_data
                        //en contenidoBitmap.Scan0 desde 0 hasta length 
                        System.Runtime.InteropServices.Marshal.Copy(
                            pixel_data.Pixels,
                            0,
                            contenidoBitmap.Scan0,
                            pixel_data.Pixels.Length
                        );
                    }
                    finally {
                        bitmap.UnlockBits(contenidoBitmap);
                    }
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);//Se graba el flujo como imagen png en memoria
                    output.TagName = "img";// <img...>
                    output.Attributes.Clear();
                    output.Attributes.Add("width", ancho);
                    output.Attributes.Add("height", alto);// <img width="150" height="150">
                    //Al flujo lo convertimos en un arreglo de bytes 
                    //y a este arreglo lo convertimos en un string como imagen
                    output.Attributes.Add("src",
                        string.Format("data:image/png;base64,{0}", 
                            Convert.ToBase64String(ms.ToArray())
                        )
                    );// <img width="150" height="150" src="data:image..."/>
                }
            }
        }
    }
}
