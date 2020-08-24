using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Interfaces.Services
{
    public interface IImageService
    {
        string SaveImage(string base64Data);
    }
}
