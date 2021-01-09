"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
var app_MainEntryModule_1 = require("./Modules/app.MainEntryModule");
var core_1 = require("@angular/core");
console.log(process.env.ENV);
if (process.env.ENV === "production") {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_MainEntryModule_1.MainEntryModule);
//# sourceMappingURL=app.js.map