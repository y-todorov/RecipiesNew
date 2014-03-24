using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace RecipiesWebFormApp.Helpers
{
    public static class CloudinaryHelper
    {
        public static Cloudinary Instance;

        static CloudinaryHelper()
        {
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account(
  "hs5i1onab",
  "753947533581273",
  "cBjzF0FQkd8Vrbomep6nZ99tHsc");

            Instance = new Cloudinary(account);

        }

        public static Cloudinary GetInstance()
        {
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account(
"hs5i1onab",
"753947533581273",
"cBjzF0FQkd8Vrbomep6nZ99tHsc");

            Cloudinary inst = new Cloudinary(account);
            return inst;
        }
    }
}