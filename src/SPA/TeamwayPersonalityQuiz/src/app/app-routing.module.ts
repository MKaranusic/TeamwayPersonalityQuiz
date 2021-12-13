import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { QuizComponent } from './pages/quiz/quiz.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "quiz",
    component: QuizComponent
  },
  { path: '**', redirectTo: "", pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
