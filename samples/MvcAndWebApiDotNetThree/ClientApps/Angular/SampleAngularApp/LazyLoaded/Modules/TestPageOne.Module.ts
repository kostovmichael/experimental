import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TestPageOneComponent } from "../Components/TestPageOne.Component";
import { TestPageOneRoutingModule } from "./testpageone.routingmodule";

@NgModule({
    imports: [CommonModule, TestPageOneRoutingModule],
    declarations: [TestPageOneComponent],
})
export class TestPageOneModule {}
