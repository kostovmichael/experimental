import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { TestPageOneComponent } from "../Components/TestPageOne.Component";

const routes: Routes = [
    {
        path: "",
        component: TestPageOneComponent,
        // children: [
        //     {
        //         path: "",
        //         component: AllTopicsNavComponent,
        //     },
        // ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class TestPageOneRoutingModule {}
