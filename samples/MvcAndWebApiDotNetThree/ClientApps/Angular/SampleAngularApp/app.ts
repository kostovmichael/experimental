import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { MainEntryModule } from "./Modules/app.MainEntryModule";
import { enableProdMode } from "@angular/core";

console.log(process.env.ENV);
if (process.env.ENV === "production") {
    enableProdMode();
}
platformBrowserDynamic().bootstrapModule(MainEntryModule);
