using System.Security.Claims;

namespace EducationPlatform.API.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// يتحقق مما إذا كان المستخدم الحالي هو الأدمن أو صاحب المعرف (ID) الممرر.
        /// </summary>
        public static bool IsOwnerOrAdmin(this ClaimsPrincipal user, int resourceOwnerId)
        {
            // 1. إذا كان المستخدم آدمن، اسمح له فوراً
            if (user.IsInRole("admin"))
            {
                return true;
            }

            // 2. استخراج معرف المستخدم الحالي من الـ Claims
            var userIdClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userIdClaim, out int authenticatedUserId))
            {
                // 3. مقارنة معرف المستخدم الحالي بمعرف صاحب المنشور/الملف
                return authenticatedUserId == resourceOwnerId;
            }

            return false;
        }
    
    
    }
}
