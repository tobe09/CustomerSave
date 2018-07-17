﻿/// <reference path="../Common/Helpers/LanguageList.ts" />

namespace CustomerSave.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('CustomerSave');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;

    if ($.fn['colorbox']) {
        $.fn['colorbox'].settings.maxWidth = "95%";
        $.fn['colorbox'].settings.maxHeight = "95%";
    }

    window.onerror = Q.ErrorHandling.runtimeErrorHandler;
}