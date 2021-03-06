using Cake.HockeyApp;

Task("Create-New-Ipa-Version")
    .Does(() =>
    {
        HockeyAppSettings.WithSettings(Context, settings =>
        {
            settings.Version = "1.1.0.1";
            settings.AppId = EnvironmentVariable("HOCKEY_APP_IPA_ID");
        });

        Information("Api Token: {0}", string.IsNullOrEmpty(HockeyAppSettings.ApiToken));
        Information("App Id: {0}:", HockeyAppSettings.AppId);
        Information("App Version: {0}:", HockeyAppSettings.Version);

        Assert.NotNull(HockeyAppSettings.AppId);

        // var result = UploadToHockeyApp(Resources.IpaPath, HockeyAppSettings.Settings);
    });

Task("Upload-Ipa")
    .Does(() =>
    {
        HockeyAppSettings.WithSettings(Context, settings =>
        {
            settings.Version = "1.1.0.1";
            settings.AppId = null;
        });
                
        Assert.Null(HockeyAppSettings.AppId);

        Information("Api Token: {0}", string.IsNullOrEmpty(HockeyAppSettings.ApiToken));
        Information("App Version: {0}:", HockeyAppSettings.Version);

        // var result = UploadToHockeyApp(Resources.IpaPath, HockeyAppSettings.Settings);
    });