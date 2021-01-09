import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomePageComponent } from "../Components/HomePageComponent";

const appRoutes: Routes = [
    {
        path: "AngularSample",
        component: HomePageComponent,
    },
    {
        path: "AngularSample/Landing/Main",
        component: HomePageComponent,
    },
    {
        path: "AngularSample/Landing/TestPageOne",
        loadChildren: "../LazyLoaded/Modules/TestPageOne.Module#TestPageOneModule",
    },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule],
})
export class MainRoutingModule {}
