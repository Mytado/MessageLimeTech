import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsPageComponent } from './components/details-page/details-page.component';
import { StartPageComponent } from './components/start-page/start-page.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "/start",
    pathMatch: "full",
  }, 
  {
    path: "start",
    component: StartPageComponent,
  }, 
  {
    path: "details/:id",
    component: DetailsPageComponent,
  }, 
  { path: '**', component: StartPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
