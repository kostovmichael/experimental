import { Component } from "@angular/core";

@Component({
    selector: "mysampleapp-home",
    template: `<h2>Hello from home page</h2>`,
})
export class HomePageComponent {}

function getMyAccountMainTemplateUrl() {
    return document.getElementsByTagName("base")[0].href + "help-center/MainHc/HelpCenterHome";
}
