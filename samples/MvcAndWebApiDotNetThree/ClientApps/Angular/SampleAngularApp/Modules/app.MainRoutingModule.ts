import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomePageComponent } from "../Components/HomePageComponent";

const appRoutes: Routes = [
    {
        path: "/",
        component: HomePageComponent,
    },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule],
})
export class MainRoutingModule {}
