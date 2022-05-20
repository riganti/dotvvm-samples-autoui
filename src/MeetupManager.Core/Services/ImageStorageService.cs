using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace MeetupManager.Core.Services
{
    public class ImageStorageService
    {
        private readonly IWebHostEnvironment environment;

        public ImageStorageService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public async Task<string> ResizeAndStoreImage(Stream stream)
        {
            var directory = Path.Combine(environment.WebRootPath, "meetup-images");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var path = $"{Guid.NewGuid()}.jpg";
            
            await using var fs = File.OpenWrite(Path.Combine(directory, path));
            using var image = await Image.LoadAsync(stream);
            image.Mutate(i => i.Resize(400, 100));
            await image.SaveAsJpegAsync(fs, new JpegEncoder() { Quality = 95 });
            
            return "/meetup-images/" + path;
        }

    }
}
