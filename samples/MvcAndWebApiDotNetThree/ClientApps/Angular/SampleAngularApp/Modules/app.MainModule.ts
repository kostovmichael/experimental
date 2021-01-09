import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HttpClientXsrfModule } from "@angular/common/http";
import { MainRoutingModule } from "./App.MainRoutingModule";
import { MainComponent } from "../Components/app.MainComponent";

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        FormsModule,
        HttpClientModule,
        HttpClientXsrfModule.withOptions({
            cookieName: "My-Xsrf-Cookie",
            headerName: "My-Xsrf-Header",
        }),
        MainRoutingModule,
    ],
    exports: [MainComponent],
    declarations: [MainComponent],
    bootstrap: [MainComponent],
})

//HelpCenterMainComponent
export class MainModule {}
