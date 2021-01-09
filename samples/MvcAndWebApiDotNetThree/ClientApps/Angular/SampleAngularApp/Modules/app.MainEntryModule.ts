import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { MainRoutingModule } from "./App.MainRoutingModule";
import { MainModule } from "./app.MainModule";
import { MainComponent } from "../Components/app.MainComponent";

@NgModule({
    imports: [BrowserModule, MainRoutingModule, MainModule],
    declarations: [MainComponent],
    bootstrap: [MainComponent],
})
export class MainEntryModule {}
