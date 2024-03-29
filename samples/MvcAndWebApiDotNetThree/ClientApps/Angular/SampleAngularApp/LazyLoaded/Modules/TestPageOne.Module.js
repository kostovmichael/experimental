"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.TestPageOneModule = void 0;
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var TestPageOne_Component_1 = require("../Components/TestPageOne.Component");
var testpageone_routingmodule_1 = require("./testpageone.routingmodule");
var TestPageOneModule = /** @class */ (function () {
    function TestPageOneModule() {
    }
    TestPageOneModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, testpageone_routingmodule_1.TestPageOneRoutingModule],
            declarations: [TestPageOne_Component_1.TestPageOneComponent],
        })
    ], TestPageOneModule);
    return TestPageOneModule;
}());
exports.TestPageOneModule = TestPageOneModule;
//# sourceMappingURL=TestPageOne.Module.js.map