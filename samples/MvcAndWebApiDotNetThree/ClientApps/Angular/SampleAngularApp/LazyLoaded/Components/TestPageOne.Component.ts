import { Component } from "@angular/core";

@Component({
    selector: "test-pageone",
    template: `Hello from TestPageOneComponent`,
    //templateUrl: getTestPageOneTemplateUrl(),
})
export class TestPageOneComponent {}

function getTestPageOneTemplateUrl() {
    return document.getElementsByTagName("base")[0].href + "templates/testpageonepartial";
}
