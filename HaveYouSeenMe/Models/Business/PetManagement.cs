using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.IO;
using System.Linq;
using System.Web;

namespace HaveYouSeenMe.Models.Business
{
    public class PetManagement
    {
        private IRepository _repository;

        public PetManagement()
        {

        }

        public PetManagement(IRepository repository) //constructor invokes our business model
        {
            _repository = repository;
        }

        public Pet GetByName(string name)
        {
            Pet pet = _repository.GetPetByName(name);
            return pet;
        }

        public void CreateThumbnail(string fileName, string filePath, int thumbWi, int thumbHi, bool manintainAspect)
        {
            //do nothing if the original is smaller than the designated thumbnail dimensions
            var originalFile = Path.Combine(filePath, fileName);
            var source = Image.FromFile(originalFile);
            if (source.Width <= thumbWi && source.Height <= thumbHi) return; //return if width and height are smaller than or = to thumbnail dimensions

            Bitmap thumbnail;
            try
            {

                int wi = thumbWi; //based on what was passed in to CreateThumbnail method
                int hi = thumbHi; //based on what was passed in to CreateThumbnail method

                if (manintainAspect)
                {
                    //maintain the aspect ratio despite the thumbnail size parameters

                    if (source.Width > source.Height)
                    {
                        wi = thumbWi;
                        hi = (int)(source.Height * ((decimal)thumbWi / source.Width));
                    }
                    else
                    {
                        hi = thumbHi;
                        wi = (int)(source.Width * ((decimal)thumbHi / source.Height));
                    }

                    thumbnail = new Bitmap(wi, hi);
                    using (Graphics g = Graphics.FromImage(thumbnail)) //using graphics class, enstantiate instance called g
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic; //creates highest quality 
                        g.FillRectangle(Brushes.Transparent, 0, 0, wi, hi);//0 = x float, 0 = y float
                        g.DrawImage(source, 0, 0, wi, hi);

                    }

                    var thumbnailName = Path.Combine(filePath, "thumbnail_" + fileName); //creating combined path
                    thumbnail.Save(thumbnailName); //saving thumbnail as that name

                }
            }
            catch
            {
                throw;
            }


                }

            }

        }
    
