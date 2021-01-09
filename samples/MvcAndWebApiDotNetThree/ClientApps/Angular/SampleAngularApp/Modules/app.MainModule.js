"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.MainModule = void 0;
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/common/http");
var App_MainRoutingModule_1 = require("./App.MainRoutingModule");
var HomePageComponent_1 = require("../Components/HomePageComponent");
var MainModule = /** @class */ (function () {
    //HelpCenterMainComponent
    function MainModule() {
    }
    MainModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpClientModule,
                http_1.HttpClientXsrfModule.withOptions({
                    cookieName: "My-Xsrf-Cookie",
                    headerName: "My-Xsrf-Header",
                }),
                App_MainRoutingModule_1.MainRoutingModule,
            ],
            exports: [HomePageComponent_1.HomePageComponent],
            declarations: [HomePageComponent_1.HomePageComponent],
            bootstrap: [HomePageComponent_1.HomePageComponent],
        })
        //HelpCenterMainComponent
    ], MainModule);
    return MainModule;
}());
exports.MainModule = MainModule;
//# sourceMappingURL=app.MainModule.js.map