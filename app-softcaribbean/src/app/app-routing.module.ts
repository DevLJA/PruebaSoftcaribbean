import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { PersonComponent } from './sections/Person/Person.component';
import { ReportPatientComponent } from './sections/ReportPatient/ReportPatient.component';
import { MenuComponent } from './sections/Menu/Menu.component';

const routes: Routes = [
  { path: 'crearnuevo', component: PersonComponent },
  { path: '', component: ReportPatientComponent },
  { path: 'paciente', component: ReportPatientComponent },
  { path: 'menu', component: ReportPatientComponent },
  { path: '**', pathMatch: 'full', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
