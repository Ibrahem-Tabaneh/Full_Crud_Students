using EducationPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Persistence
{
    public class FileService : IFileService
    {
        public async Task<string> UploadImg(IFormFile file, string folderName)
        {
            // 1. تحديد المسار الأساسي لمجلد المشروع + wwwroot
            // Directory.GetCurrentDirectory() بتعطيك وين مشروعك شغال حالياً
            string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            // 2. دمج المسار الأساسي مع اسم المجلد اللي بدك اياه (images مثلاً)
            string finalFolderPath = Path.Combine(rootPath, folderName);

            // 3. التأكد إذا المجلد موجود، وإذا مش موجود بننشأه
            if (!Directory.Exists(finalFolderPath))
            {
                Directory.CreateDirectory(finalFolderPath);
            }

            // 1. استخراج امتداد الملف الأصلي (مثل .jpg أو .png)
            string extension = Path.GetExtension(file.FileName); // مثلاً .jpg

            // 2. توليد اسم عشوائي فريد ودمجه مع الامتداد
            string fileName = Guid.NewGuid().ToString() + extension;

            // 3. دمج الاسم الجديد مع مسار المجلد الذي جهزناه سابقاً
            string fullPathToSave = Path.Combine(finalFolderPath, fileName);

            // 4. فتح "أنبوب" (Stream) لإنشاء الملف في المسار الذي حددناه
            using (var stream = new FileStream(fullPathToSave, FileMode.Create))
            {
                // نسخ محتويات الملف المرفوع إلى هذا الأنبوب (الStream)
                await file.CopyToAsync(stream);
            }

            // 5. إرجاع "النص" الذي سنخزنه في قاعدة البيانات
            // نحن لا نخزن المسار الكامل (C:\...) بل نخزن المسار الذي سيفهمه المتصفح (Web Path)
            return Path.Combine("images", folderName, fileName).Replace("\\", "/");
        }
        public async Task DeleteImg(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            // 1. تحويل المسار من شكل الويب إلى مسار الهارد ديسك الكامل
            // نقوم بدمج مسار المشروع الحالي مع wwwroot مع المسار القادم من قاعدة البيانات
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);

            // 2. التأكد من وجود الملف فعلياً قبل محاولة حذفه لتجنب الأخطاء
            if (File.Exists(fullPath))
            {
                // 3. الحذف الفعلي للملف
                await Task.Run(() => File.Delete(fullPath));
            }
        }
    }

}
