using System;
using System.Threading.Tasks;
using TracageAlimentaireXamarin.Models;
using ZXing;
using ZXing.Common;

namespace Tracage.Models
{
    public class SharedScanner
    {

        public async Task<string> ScanCodeAsync()
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();

                scanner.BottomText = "You can now scan a product from the label :)";
                
                var result = await scanner.Scan();
                return result.Text;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public void GenerateBarCode(string code)
        {
            var writer = new BarcodeWriterSvg
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions { Height = 300, Width = 300 }
            };
            var bitmap = writer.Write(code);
        }

        public void GenerateQRCode(string code)
        {
            var qrWriter = new BarcodeWriterSvg
            {
                Format = BarcodeFormat.EAN_13,
                Options = new EncodingOptions { Height = 400, Width = 400 }
            };
            var bitmap = qrWriter.Write(code);
        }
    }
}
