using Microsoft.AspNetCore.Mvc;
using GIFMakerAPI.Models;
using AnimatedGif;

namespace GIFMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GIFController : ControllerBase
    {    
        [Route("GenerateGIF")]
        [HttpPost]
        public async Task<IActionResult> UploadImageProfile([FromBody] List<Slika> slike)
        {
            string putanjaGIFa = "";
            string nazivHash = "";

            if (!System.IO.Directory.Exists("gifovi"))
                System.IO.Directory.CreateDirectory("gifovi");
            
            for (int i = 0; i < slike.Count; i++)            
                nazivHash += slike[i].Base64.Substring(slike[i].Base64.IndexOf(",") + 1);           
            
            nazivHash = Util.NapraviMD5Hash(nazivHash);


            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory + "\\gifovi"); //https://stackoverflow.com/questions/7385251/how-to-check-if-a-file-exists-in-a-folder
            FileInfo[] TXTFiles = di.GetFiles(nazivHash + ".gif");
            if (TXTFiles.Length > 0)
                putanjaGIFa = "gifovi\\" + nazivHash + ".gif";
            else
            {
                using (var gif = AnimatedGif.AnimatedGif.Create("gifovi\\" + nazivHash + ".gif", 333))
                {
                    for (int i = 0; i < slike.Count; i++)
                        await gif.AddFrameAsync(Util.PretvoriUImage(slike[i].Base64), delay: -1, quality: GifQuality.Bit8);

                    putanjaGIFa = gif.FilePath;
                }
            }
           
            string lokacija = Environment.CurrentDirectory + "\\" + putanjaGIFa;                    
            try
            {
                byte[] imageArray = await System.IO.File.ReadAllBytesAsync(lokacija);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                Slika slikaGIF = new Slika
                {
                    Base64 = "data:image/gif;base64," + base64ImageRepresentation,
                    Ekstenzija = "image/gif",
                    Naziv = "GeneriraniGIF"
                };

                return Ok(slikaGIF);
            }
            catch (Exception)
            {
            }

            return Ok(slike[0]);
        }    
    }
}
