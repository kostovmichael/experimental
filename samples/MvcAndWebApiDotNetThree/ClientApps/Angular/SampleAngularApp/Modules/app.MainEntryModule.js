"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.MainEntryModule = void 0;
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var App_MainRoutingModule_1 = require("./App.MainRoutingModule");
var app_MainModule_1 = require("./app.MainModule");
var app_MainComponent_1 = require("../Components/app.MainComponent");
var MainEntryModule = /** @class */ (function () {
    function MainEntryModule() {
    }
    MainEntryModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule, App_MainRoutingModule_1.MainRoutingModule, app_MainModule_1.MainModule],
            declarations: [app_MainComponent_1.MainComponent],
            bootstrap: [app_MainComponent_1.MainComponent],
        })
    ], MainEntryModule);
    return MainEntryModule;
}());
exports.MainEntryModule = MainEntryModule;
//# sourceMappingURL=app.MainEntryModule.js.map