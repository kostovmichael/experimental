"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.MainRoutingModule = void 0;
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var HomePageComponent_1 = require("../Components/HomePageComponent");
var appRoutes = [
    {
        path: "AngularSample",
        component: HomePageComponent_1.HomePageComponent,
    },
    {
        path: "AngularSample/Landing/Main",
        component: HomePageComponent_1.HomePageComponent,
    },
    {
        path: "AngularSample/Landing/TestPageOne",
        loadChildren: "../LazyLoaded/Modules/TestPageOne.Module#TestPageOneModule",
    },
];
var MainRoutingModule = /** @class */ (function () {
    function MainRoutingModule() {
    }
    MainRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(appRoutes)],
            exports: [router_1.RouterModule],
        })
    ], MainRoutingModule);
    return MainRoutingModule;
}());
exports.MainRoutingModule = MainRoutingModule;
//# sourceMappingURL=App.MainRoutingModule.js.map