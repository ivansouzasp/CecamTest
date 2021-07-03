import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteDetailComponent } from './components/cliente-detail/cliente-detail.component';
import { ClienteListComponent } from './components/cliente-list/cliente-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'clientes', pathMatch: 'full' },
  { path: 'listclientes', component: ClienteListComponent },
  { path: 'clientes/:codigo', component: ClienteDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
