import { Component } from "@angular/core";

@Component({
    selector: "mysampleapp-home",
    template: `<p> </p><h2>Hello from the HomePageComponent</h2> <p></p
        ><p>
            <a routerLink="/AngularSample/Landing/TestPageOne">Test Page One (lazy load) </a>
        </p>`,
})
export class HomePageComponent {}
