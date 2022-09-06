using Android;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPermission;

public class RequestPermission : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions
    {
        get
        {
            List<(string, bool)> permissions = new();

            if ((int)Build.VERSION.SdkInt >= 31)
            {
                permissions.Add((Manifest.Permission_group.NearbyDevices, true));
                permissions.Add((Manifest.Permission.AccessFineLocation, true));
            }
            else if ((int)Build.VERSION.SdkInt <= 30)
            {
                permissions.Add((Manifest.Permission.AccessCoarseLocation, true));
                permissions.Add((Manifest.Permission.AccessFineLocation, true));
            }

            return permissions.ToArray();
        }
    }
}