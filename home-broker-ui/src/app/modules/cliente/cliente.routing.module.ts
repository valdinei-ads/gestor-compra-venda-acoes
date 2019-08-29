import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClienteListComponent } from './components/cliente-list/cliente-list.component';
import { ClienteCreateComponent } from './components/cliente-create/cliente-create.component';
import { ClienteEditComponent } from './components/cliente-edit/cliente-edit.component';
import { ClienteDetailsComponent } from './components/cliente-details/cliente-details.component';

const clientRoutes: Routes = [
    { path: 'cliente', component: ClienteListComponent },
    { path: 'cliente/create', component: ClienteCreateComponent },
    { path: 'cliente/edit/:id', component: ClienteEditComponent },
    { path: 'cliente/details/:id', component: ClienteDetailsComponent }
]

@NgModule({
    imports: [RouterModule.forChild(clientRoutes)],
    exports: [RouterModule]
})
export class ClienteRoutingModule { }